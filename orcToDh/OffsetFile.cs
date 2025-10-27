using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using orcToDh.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.LinkLabel;
using static orcToDh.OffsetFile;

namespace orcToDh
{
    public class OffsetFile
    {
        Metadata? metadata;
        public List<Station>? stations;
        private List<Station>? portStations;
        private List<Station>? starboardStations;
        public Station bestGmaxStation = null;
        public List<DataPoint> bestGmaxDataPoints = null;
        public Station bestBMaxStation = null;
        public List<OffsetFile.DataPoint> bestBMaxDataPoints = null;
        private List<Utill.Point> profileBottomLine = new();
        private double WLZ_AF = 0;
        private double WLZ_STF = 0;
        private int aF = 0;
        private int sTF = 0;
        private int fFM = 0;
        private Station fFMStation = null;
        private Station fAMStation = null;
        private int fAM = 0;
        private int gMax = 0;
        private int bMax = 0;
        public bool UseDH = true;
        private int bottomLineFilterAngle = 10;
        

        public OffsetFile(StreamReader file)
        {

            if (file == null)
            {
                throw new ArgumentNullException("file");
            }

            metadata = new Metadata(file);
            stations = new List<Station>();


            for (int i = 0; i < metadata.nst; i++)
            {
                // read station
                string line = readLine(file);
                Station station = new Station(line, this);
                stations.Add(station);
                for (int j = 0; j < station.NPT; j++)
                {
                    line = readLine(file);
                    DataPoint point = new DataPoint(line);
                    station.dataPoints.Add(point);
                }
            }

            //PrintAll();
        }

        public int BowPointZ
        {
            get
            {

                Station station0 = stations[0];
                Station station1 = stations[1];
                double z1 = station0.dataPoints.Max(p => p.Z);
                double z2 = station1.dataPoints.Max(p => p.Z);
                double x1 = station0.X;
                double x2 = station1.X;
                double z = Utill.GetYPointInX(x1, z1, x2, z2);
                Console.WriteLine("BowPoint: " + z);
                return(int)z;

            }
        }

        public int SternPointX
        {
            get
            {
                //get the last station
                Station station = stations[stations.Count - 1];
                //get the X value of the last station
                return (int)station.X;
            }
        }
        public int SternPointZ
        {
            get
            {

                //get the last station
                Station station = stations[stations.Count - 1];
                //if the station contains a single data point, return the Z value of that point
                if (station.dataPoints.Count == 1)
                {
                    return (int)station.dataPoints[0].Z;
                } else
                {
                    //use the getBottomLine method to get the Z value of the last station
                    List<Utill.Point> bottomLine = GetProfileBottomLine();
                    //get the Z value of the last station
                    return (int) bottomLine[bottomLine.Count-1].y;
                }
            }
        }

        public int AF
        {
            get
            {
                if (UseDH)
                {
                    return aF;
                }
                else
                {

                    Utill.Point point = new Utill.Point();
                    point.x = SternPointX;
                    point.y = SternPointZ;
                    return (int)Utill.DistanceFromPointToLine(WaterLine, point);
                }
            }
            set
            {
                aF = value;
                WLZ_AF = SternPointZ - aF;
            }
        }
        public int STF
        {
            get
            {
                if (UseDH)
                {
                    return sTF;
                } else
                {
                    Utill.Point point = new Utill.Point();
                    point.x = 0;
                    point.y = BowPointZ;
                    return (int)Utill.DistanceFromPointToLine(WaterLine, point); ;
                }
            }
            set
            {
                sTF = value;
                WLZ_STF = BowPointZ - sTF;
            }
        }

        public int FFM
        {
            get
            {
                return fFM;
            }
            set
            {
                fFM = value;
            }
        }
        public int FAM
        {
            get
            {
                return fAM;
            }
            set
            {
                fAM = value;
            }
        }
        public int XFFM
        {
            get
            {
                fFMStation = stations.FirstOrDefault(s => s.SCD == Station.StationLabel.ForwardFreeboard);
                if (fFMStation == null)
                {
                    throw new Exception("fFMStation is null");
                }
                return (int)fFMStation.X;
            }
        }

        public int XFAM
        {
            get
            {
                fAMStation = stations.FirstOrDefault(s => s.SCD == Station.StationLabel.AftFreeboard);
                if (fAMStation == null)
                {
                    throw new Exception("fFMStation is null");
                }
                return (int)fAMStation.X;
            }
        }
        public int WLZ_FFM
        {
            get
            {
                return (int)(fFMStation.dataPoints.FirstOrDefault(s => s.PTC ==DataPoint.PointCode.SheerPoint).Z-FFM);
            }
        }

        public int WLZ_FAM
        {
            get
            {
                return (int)(fAMStation.dataPoints.FirstOrDefault(s => s.PTC == DataPoint.PointCode.SheerPoint).Z - FAM);
            }
        }


        public int BoG3
        {
            get
            {   
                int bMax = BMax;
                int gMax = GMax;
                return (int)((bestGmaxStation.G + bestBMaxStation.WLBredde) * 0.03);
            }
        }

        public Utill.Line WaterLine
        {
            get
            {
                Utill.Line line = new Utill.Line();
                if (UseDH)
                {
                    line.x1 = Stations[0].X;
                    line.y1 = BowPointZ - STF; //this is z
                    line.x2 = Stations[Stations.Count - 1].X;
                    line.y2 = SternPointZ - AF;//this is z
                }
                else
                {
                    line.x1 = XFFM;
                    line.y1 = WLZ_FFM;
                    line.x2 = XFAM;
                    line.y2 = WLZ_FAM;
                }
                return line;
            }
        }

        public int GMax
        {
            get
            {
                if (gMax == 0) {
                    double bestGmax = 0;
                    int index = 0;
                    //cal gmax  over all stations and keep the best
                    while (index < stations.Count)
                    {
                        List<OffsetFile.DataPoint> dataPoints = stations[index].GMaxDataPoints;

                        double tempGmax = stations[index].GMax;
                        if (tempGmax > bestGmax)
                        {
                            bestGmax = tempGmax;
                            bestGmaxStation = stations[index];
                            bestGmaxDataPoints = dataPoints;
                        }

                        index++;
                    }
                    gMax = (int)bestGmax;
                }
                return gMax;
            }
        }

        public int BMax
        {
            get
            {
                if (bMax == 0)
                {
                    double bestBMax = 0;
                    double bestBMaxHight = 0;
                    int maxBMaxIndex = 0;
                    for (int i = 0; i < stations.Count; i++)
                    {
                        double bMax = stations[i].BMax;
                        double bMaxHight = stations[i].BMaxZ;
                        if (bMax > bestBMax)
                        {
                            bestBMax = bMax;
                            bestBMaxHight = bMaxHight;
                            bestBMaxStation = stations[i];
                            bestBMaxDataPoints = stations[i].dataPoints;
                            maxBMaxIndex = i;
                        }
                    }
                    bMax = (int)bestBMax;
                }
                return bMax;
            }
        }

        public int OF
        {
            get
            {
                Utill.Line messermentLine = new Utill.Line();
                messermentLine.x1 =Stations[0].X - 20;
                messermentLine.y1 = BowPointZ - STF + BoG3; //this is z
                messermentLine.x2 = Stations[Stations.Count - 1].X + 20;
                messermentLine.y2 = SternPointZ - AF + BoG3;//this is z

                List<Utill.Point> profileBottomLine = GetProfileBottomLine();
                Utill.Point point = default(Utill.Point);
                for (int i = 1; i < profileBottomLine.Count/2; i++)
                {
                    Utill.Line line = new Utill.Line();
                    line.x1 = profileBottomLine[i - 1].x;
                    line.y1 = profileBottomLine[i - 1].y;//this is z
                    line.x2 = profileBottomLine[i].x;
                    line.y2 = profileBottomLine[i].y;//this is z
                    point = Utill.LineIntersection.FindIntersection(messermentLine, line);
                    if(default(Utill.Point).y != point.y && default(Utill.Point).x != point.x)
                    {
                        break;
                    }
                }
                Console.WriteLine("OF: " + point.x);
                return (int)point.x;
            }
        }

        public int OA
        {
            get
            {
                Utill.Line messermentLine = new Utill.Line();
                messermentLine.x1 = Stations[0].X;
                messermentLine.y1 = BowPointZ - STF + BoG3; //this is z
                messermentLine.x2 = Stations[Stations.Count - 1].X;
                messermentLine.y2 = SternPointZ - AF + BoG3;//this is z

                List<Utill.Point> profileBottomLine = GetProfileBottomLine();
                Utill.Point point = default(Utill.Point);
                int index = profileBottomLine.Count - 1;
                for (; index > profileBottomLine.Count/2; index--)
                {
                    Utill.Line line = new Utill.Line();
                    line.x1 = profileBottomLine[index].x;
                    line.y1 = profileBottomLine[index].y; // this is z
                    line.x2 = profileBottomLine[index - 1].x;
                    line.y2 = profileBottomLine[index - 1].y; // this is z
                    point = Utill.LineIntersection.FindIntersection(messermentLine, line);
                    if (default(Utill.Point).y != point.y && default(Utill.Point).x != point.x)
                    {
                        break;
                    }
                }
                if (index > profileBottomLine.Count / 2)
                {
                    Console.WriteLine("OA: " + point.x);
                    return (int)(LOA - point.x);
                }
                else
                {
                    Console.WriteLine("OA: end of profileBottomLine");
                    return 0;
                }
            }
        }

        public int LOA
        {
            get
            {
                // get the station with the greatest x value
                Station stationWithGreatestX = stations.OrderByDescending(station => station.X).FirstOrDefault();
                return (int)stationWithGreatestX?.X;
            }
        }
        public int L
        {
            get
            {
                return (int)(LOA - OF - OA);
            }
        }

        public List<Utill.Point> GetProfileBottomLine(double filterValueBack = 0.2)
        {
            profileBottomLine.Clear();
            foreach (Station station in stations)
            {
                Utill.Point bottomPoint = station.GetBottomPoint(true);
                profileBottomLine.Add(bottomPoint);
            }
            return profileBottomLine;
        }
        public OffsetFile()
        {
        }

        //inner classes
        // Metadata
        // Station
        // DataPoint
        #region innerClasses
        private class Metadata
        {
            public DateTime? date;
            public string? measuresCode;
            public string? machineCode;
            public string? filename;
            public string? classboat;
            public string? ageDate;

            public double sffps, ffpvs, safps, fapvs;
            public double sffpp, ffpvp, safpp, fapvp;

            public int nst;
            public double loa, sfj, sfbi;

            public Metadata(StreamReader file)
            {
                //read date and time
                string line = readLine(file);
                string[] data = line.Split(',');
                if (!(data.Length == 7 || data.Length == 8))
                {
                    throw new WrongDataFormatExeception(string.Format("line1 for metadata is not the right length  nr of dataFields in line: {0}", data.Length));
                }

                MatchCollection matches = Regex.Matches(data[1], @"\b\d{2}\b");

                int dd = int.Parse(matches[0].ToString());
                int mm = int.Parse(matches[1].ToString());
                int yyyy = int.Parse(matches[2].ToString());
                if (dd == 0 && mm == 0 && yyyy == 0)
                {
                    date = null;
                }
                else
                {
                    int currentYear = DateTime.Now.Year;
                    if (yyyy + 2000 > currentYear)
                    {
                        yyyy += 1900;
                    }
                    else
                    {
                        yyyy += 2000;
                    }
                    string dateString = yyyy + "-" + (mm < 10 ? "0" + mm : mm) + "-" + (dd < 10 ? "0" + dd : dd);
                    DateOnly dateOnly = DateOnly.ParseExact(dateString, "yyyy-mm-dd", null);

                    matches = Regex.Matches(data[0], @"\b\d{2}\b");
                    int hh = 0;
                    int ss = 0;
                    if (matches.Count != 0)
                    {
                        hh = int.Parse(matches[0].ToString());
                        mm = int.Parse(matches[1].ToString());
                        ss = int.Parse(matches[2].ToString());
                    }
                    TimeOnly time = new TimeOnly(hh, mm, ss);

                    date = new DateTime(dateOnly, time);
                }

                measuresCode = data[2].Trim();
                machineCode = data[3].Trim();
                filename = data[4].Trim();
                classboat = data[5].Trim();
                ageDate = data[6].Trim();


                //read Metrec system
                string[] line1Values = readLine(file).Split(',');
                string[] line2Values = readLine(file).Split(',');

                //for (int i = 0; i < line1Values.Length; i++)
                //{
                //    string item = line1Values[i];
                //    item = item.Replace('.', ',');
                //}
                //for (int i = 0; i < line2Values.Length; i++)
                //{
                //    string item = line2Values[i];
                //    item = item.Replace('.', ',');
                //}

                if (!(line1Values.Length >= 4 && line2Values.Length >= 4))
                {
                    throw new WrongDataFormatExeception("Invalid number of values in line2 or line3");
                }

                double.TryParse(line1Values[0].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out sffps);
                double.TryParse(line1Values[0].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out sffps);
                double.TryParse(line1Values[1].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out ffpvs);
                double.TryParse(line1Values[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out safps);
                double.TryParse(line1Values[3].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out fapvs);

                double.TryParse(line2Values[0].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out sffpp);
                double.TryParse(line2Values[1].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out ffpvp);
                double.TryParse(line2Values[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out safpp);
                double.TryParse(line2Values[3].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out fapvp);

                //read misc
                line = readLine(file);
                data = line.Split(',');
                if (data.Length < 4)
                {
                    throw new WrongDataFormatExeception("Invalid number of values in line 4");
                }

                int.TryParse(data[0].Trim(), out nst);
                double.TryParse(data[1].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out loa);
                double.TryParse(data[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out sfj);
                double.TryParse(data[3].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out sfbi);

            }

            public Metadata()
            {

            }

            public override string ToString()
            {
                string str = $"Date: {date}, MeasuresCode: {measuresCode}, MachineCode: {machineCode}, Filename: {filename}, Classboat: {classboat}, AgeDate: {ageDate}\n";
                str += "SFFPs: " + sffps + " - FFPVs: " + ffpvs + " - SAPFs: " + safps + " - FAPVs: " + fapvs + "\n";
                str += "SFFPp: " + sffpp + " - FFPVp: " + ffpvp + " - SAPFp: " + safpp + " - FAPVp: " + fapvp + "\n";
                str += "NST: " + nst + " - LOA: " + loa + " - SFJ: " + sfj + " - SFBI: " + sfbi + "\n";
                return str;
            }
        }

        public class Station
        {
            public enum SideCode
            {
                Port = 1,
                Starboard = 2,
                Both = 3
            }

            public enum StationLabel
            {
                ForwardFreeboard = 1,
                AftFreeboard = 2,
                PropShaftExitPoint = 3,
                PropellerHubPoint = 4
            }

            public double X { get; set; } // Distance from the stem for each station in millimeters for metric units, in hundredths of feet for imperial units
            public int NPT { get; set; } // Number of points in a section. Important to be correct.
            public SideCode SID { get; set; } // Side code: Port, Starboard, Both
            public StationLabel SCD { get; set; } // Station label: Forward freeboard, Aft freeboard, Prop shaft exit point, Propeller hub point
            public int STA { get; } // Station count, not necessary but included for convenience

            private List<DataPoint>? gMaxDataPoints;
            private double gMax = 0;
            private double bMax = 0;
            private double bMaxZ = 0;

            public List<DataPoint>? dataPoints;

            public OffsetFile offsetFile;

            public Station(string line, OffsetFile offsetFile)
            {
                this.offsetFile = offsetFile;
                string[] data = line.Split(',');
                //for (int i = 0; i < data.Length; i++)
                //{
                //    data[i] = data[i].Replace('.', ',');
                //}
                if (data.Length < 4)
                {
                    throw new WrongDataFormatExeception("Invalid number of values in line");
                }
                X = double.Parse(data[0], NumberStyles.Any, CultureInfo.InvariantCulture);
                NPT = int.Parse(data[1]);
                SID = (SideCode)Enum.Parse(typeof(SideCode), data[2]);
                SCD = (StationLabel)Enum.Parse(typeof(StationLabel), data[3]);
                try
                {
                    STA = int.Parse(data[4]);
                }
                catch (Exception)
                {
                    STA = 0;
                }

                dataPoints = new List<DataPoint>();

            }

            public Station()
            {
            }

            public override string ToString()
            {
                return $"X: {X}, NPT: {NPT}, SID: {SID}, SCD: {SCD}, STA: {STA}";
            }

            public void PrintDataPoints()
            {
                foreach (var point in dataPoints)
                {
                    Console.WriteLine(point.ToString());
                }
            }

            public int WLZ
            {
                get
                {
                    double z = Utill.GetYPointInX(0, offsetFile.WLZ_STF, offsetFile.SternPointX, offsetFile.WLZ_AF, X);
                    return (int)z;
                }
            }

            public int FribordHoejde
            {
                get
                {
                    //get the max Z value
                    double z = dataPoints.Max(p => p.Z);
                    return (int)z - WLZ;
                }
            }

            public int WLBredde
            {
                get
                {
                    int wLBrede = 0;
                    //check if the a datapoint's Z value is FribordHoejde
                    bool hasFribordHoejde = dataPoints.Any(p => p.Z == WLZ);
                    if (hasFribordHoejde)
                    {
                        foreach (var point in dataPoints)
                        {
                            if (point.Z == WLZ)
                            {
                                wLBrede = (int)point.Y;
                                break;
                            }
                        }
                    }
                    else
                    {
                        //finde the 2 datapoints with the Z value closest to FribordHoejde
                        DataPoint? point1 = null;
                        DataPoint? point2 = null;
                        double minDiff = double.MaxValue;
                        foreach (var point in dataPoints)
                        {
                            double diff = Math.Abs(point.Z - WLZ);
                            if (diff < minDiff)
                            {
                                minDiff = diff;
                                point1 = point;
                            }
                        }
                        minDiff = double.MaxValue;
                        foreach (var point in dataPoints)
                        {
                            double diff = Math.Abs(point.Z - WLZ);
                            if (diff < minDiff && point != point1)
                            {
                                minDiff = diff;
                                point2 = point;
                            }
                        }
                        double y = Utill.GetYPointInX(point1.Z, point1.Y, point2.Z, point2.Y, WLZ);
                        wLBrede = (int)y;
                        if (wLBrede < 0)
                            wLBrede *= -1;

                    }
                    return wLBrede * 2;
                }
            }

            public int Udfald
            {
                get
                {
                    //get the min Z value
                    double z = dataPoints.Max(p => p.Y);
                    return (int)z - WLBredde/2;
                }
            }

            public double GMax
            {
                get
                {
                    if (gMax == 0)
                    {
                        gMax = calGMaxOnStation(out gMaxDataPoints);
                    }
                    return gMax;
                }
            }

            public int G
            {
                get
                {
                    return (int)GMax - (FribordHoejde * 2);
                }
            }

            public int BMax
            {
                get
                {
                    if (bMax == 0)
                    {
                        foreach (DataPoint dataPoint in dataPoints)
                        {
                            if (dataPoint.Y > bMax)
                            {
                                bMax = dataPoint.Y;
                                bMaxZ = dataPoint.Z;
                            }
                        }
                    }
                    return (int) bMax;
                }
            }

            public int BMaxZ
            {
                get
                {
                    return (int)bMaxZ;
                }
            }

            public double ZLow
            {
                get
                {
                    return dataPoints.Min(p => p.Z);
                }
            }

            public List<DataPoint> GMaxDataPoints
            {
                get
                {
                    if (gMaxDataPoints == null)
                    {
                        gMax = calGMaxOnStation(out gMaxDataPoints);
                    }
                    return gMaxDataPoints;
                }
            }

            private double calGMaxOnStation(out List<OffsetFile.DataPoint> gmaxdataPoints)
            {
                gmaxdataPoints = new();
                if (dataPoints == null || dataPoints.Count == 0)
                {
                    return 0;
                }
                gmaxdataPoints.Add(dataPoints[0]);
                Vector2 dir = new Vector2(0, -1);
                //extracts the datapoints in GMax
                for (int i = 0; i < dataPoints.Count - 1; i++)
                {
                    int smallestAngleIndex = -1;
                    double smallestAngle = double.MaxValue;
                    List<OffsetFile.DataPoint> points = dataPoints.Skip(i).ToList();
                    for (int j = 1; j < points.Count; j++)
                    {
                        Vector2 v = Vector2.Subtract(points[0].GetVector2(), points[j].GetVector2());

                        // dot product
                        float dotProduct = Vector2.Dot(dir, v);
                        float crossProduct = dir.X * v.Y - dir.Y * v.X;
                        float sign = Math.Sign(crossProduct);

                        // magnitudes
                        float magD = dir.Length();
                        float magV = v.Length();


                        // angle in radians
                        float theta = (float)(Math.Acos(dotProduct / (magD * magV)) * sign);

                        theta = (float)(theta * (180 / Math.PI));

                        if (theta < smallestAngle)
                        {
                            smallestAngle = theta;
                            smallestAngleIndex = i + j;
                        }
                    }
                    if (smallestAngleIndex != -1)
                    {
                        dir = Vector2.Subtract(dataPoints[i].GetVector2(), dataPoints[smallestAngleIndex].GetVector2());
                        if (dir.Y * -1 < dir.X && dir.X > 0)
                        {
                            break;
                        }
                        i = smallestAngleIndex - 1;
                        gmaxdataPoints.Add(dataPoints[smallestAngleIndex]);

                    }
                    else
                    {
                        break;
                    }
                }

                //calculates the distance
                double gMax = 0;
                for (int i = 0; i < gmaxdataPoints.Count - 1; i++)
                {
                    Point p1 = new Point((int)gmaxdataPoints[i].Y, (int)gmaxdataPoints[i].Z);
                    Point p2 = new Point((int)gmaxdataPoints[i + 1].Y, (int)gmaxdataPoints[i + 1].Z);
                    double distance = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
                    gMax += distance;
                }

                double distanceBetweenLowerDataPoints = 0;
                try
                {
                    distanceBetweenLowerDataPoints = dataPoints[0].Y >= 0 ? dataPoints[0].Y : 0.0;
                }
                catch (Exception)
                {
                    distanceBetweenLowerDataPoints = 0.0;
                }

                gMax += distanceBetweenLowerDataPoints;

                gMax *= 2;

                Console.WriteLine("Station.x;" + X + ";GMax;" + gMax);
                return gMax;
            }

            public Utill.Point GetBottomPoint(bool filter = false)
            {
                Utill.Point bottomPoint = new Utill.Point();
                bottomPoint.x = X;
                bottomPoint.y = ZLow;
                if (!filter)
                {
                    return bottomPoint;
                }
                //run through all dataPoints and start form the end with the biggest Z value
                if(dataPoints.Count <= 4)
                {
                    return bottomPoint;
                }
                for (int i = dataPoints.Count - 1 - 3; i > 2; i--)
                {
                    //get 3 vectors between the dataPoints from the current index and back
                    Vector2 v1 = Vector2.Subtract(dataPoints[i].GetVector2(), dataPoints[i - 1].GetVector2());
                    Vector2 v2 = Vector2.Subtract(dataPoints[i-1].GetVector2(), dataPoints[i - 2].GetVector2());
                    Vector2 v3 = Vector2.Subtract(dataPoints[i-2].GetVector2(), dataPoints[i - 3].GetVector2());
                    Vector2 v0 = Vector2.Subtract(dataPoints[i+1].GetVector2(), dataPoints[i].GetVector2());
                    //get the angle between the vectors
                    double angle1 = Vector2.Dot(v1, v2) / (v1.Length() * v2.Length()) * (180 / Math.PI);
                    double angle2 = Vector2.Dot(v2, v3) / (v2.Length() * v3.Length()) * (180 / Math.PI);
                    double angle3 = Vector2.Dot(v0, v1) / (v0.Length() * v1.Length()) * (180 / Math.PI);
                    double avgAngle = (angle1 + angle2) / 2;
                    double diff = Math.Abs(angle3 - avgAngle);
                    if(diff > offsetFile.bottomLineFilterAngle)
                    {
                        //if the angle is greater than 10 degrees, set the bottomPoint to the current point
                        bottomPoint.x = X;
                        bottomPoint.y = dataPoints[i].Z;
                        break;
                    }

                }
                return bottomPoint;
                
                return bottomPoint;
            }
        }

        public class DataPoint
        {

            public enum PointCode
            {
                NormalHullPoint = 0,
                SheerPoint = 1,
                PokeThrough = 2,
                PropellerOrShaftExitPoint = 3,
                MaximumWidthPointsOfWingKeel = 4,
                USMeasurementMachineCenterlinePoints = 5,
                PropellerApertureBottomPoint = 6,
                PropellerApertureTopPoint = 7,
                LeadingEdgePokeThrough = 8,
                TrailingEdgePokeThrough = 9,
                PokeThroughInClosedHole = 10,
                PokeThroughSeveringAppendage = 11,
                DoNotClipAtSpecificPoint = 12,
                PreventClippingOfNarrowStations = 13,
                ForceClippingOfEntireStation = 14,
                DoNotClipStation = 15,
                ForceClipAtSpecificPoint = 16
            }

            public double Z { get; set; } // Vertical co-ordinate for points on a half section, positive up, negative down in millimeters for metric units, in hundredths Of feet for imperial units
            public double Y { get; set; } // Horizontal distance from the centerline for points on a half section. Negative only in the gap in section for example, between the canoe body and the trailing edge where point code PTC is set to 2.
            public PointCode PTC;
            /*
                POINT CODES:
                o Normal hull point.
                1 Sheer point. If no point on a station has a point code Of I, the top point
                2 on the station becomes the sheer point. Poke-through (empty space in a gap bounded by the point immediately above and below. More commonly represented by a Y (transverse Offset) Of less than -0.3 feet.
                3 Propeller or shaft exit point (the appropriate station code having already been entered).
                4 Maximum Width points Of a Wing keel.
                5 US measurement machine centerline points (has no rating effect.
                6 Propeller aperture bottom point (may exist in some Old US offset files).
                7 Propeller aperture top point (may exist in some Old US offset files).
                8 Poke-through on the Ieading edge Of an appendage. Most Of the time, the program can decide automatically if one or more stations with pokethroughs are Ieading or trailing edge. If an appendage with Ieading edge poke-throughs plots incorrectly, this may help.
                9 Poke through on the trailing edge Of an appendage. If an appendage with trailing edge poke-throughs plots incorrectly, this may help.
                10 Poke-through in a closed hole through an appendage. There is no automatic recognition Of holes.
                11 Poke-through in a contiguous set Of stations that all have poke-throughs which completely sever the appendage from the hull. This code will limit the appendage profile to only those points below the pokethroughs.
                12 Do NOT clip at this specific point. Use on points which are the inside corner Of a Ieft turn while scanning down the section. This is typically used to ptevent clips at hard chines with lips or lapstrake type construction.
                13 Prevent clipping Of entire stations narrower that 3 percent Of BMAX by setting this code on any point in the station. This would be typically used on the very tip Of a transom that comes to a point. This code Will not prevent a Clip at a left turn or poke through in the station.
                14 If this code is set on any point in the station, you force clipping Of the entire station even though it may be wider than 3% Of BMAX, and regardless Of any poke-throughs and left turns.
                15 DO not clip this station in any way, either entirely or at any point if this code is set on any point in the station.
                16 Force a clip at this point.
             */

            public DataPoint(string line)
            {
                string[] data = line.Split(',');
                if (data.Length < 3)
                {
                    throw new WrongDataFormatExeception("Invalid number of values in line");
                }

                //for (int i = 0; i < data.Length; i++)
                //{
                //    data[i] = data[i].Replace('.', ',');
                //}

                Z = double.Parse(data[0], NumberStyles.Any, CultureInfo.InvariantCulture);
                Y = double.Parse(data[1], NumberStyles.Any, CultureInfo.InvariantCulture);
                PTC = (PointCode)Enum.Parse(typeof(PointCode), data[2]);
            }

            public DataPoint()
            {
            }

            public override string ToString()
            {
                return $"Z: {Z}, Y: {Y}, PTC: {PTC}";
            }

            public Vector2 GetVector2()
            {
                return new Vector2((float)Y, (float)Z);
            }

            public Utill.Point GetPoint()
            {
                Utill.Point point = new Utill.Point();
                point.x = (int)Y;
                point.y = (int)Z;
                return point;
            }
        }
        #endregion

        public List<Station> PortStations
        {
            get
            {
                if (portStations == null)
                {
                    portStations = stations.Where(s => s.SID == Station.SideCode.Port).ToList();
                }
                return portStations;
            }
        }

        public List<Station> StarboardStations
        {
            get
            {
                if (starboardStations == null)
                {
                    starboardStations = stations.Where(s => s.SID == Station.SideCode.Starboard).ToList();
                }
                return starboardStations;
            }
        }

        public List<Station> Stations
        {
            get
            {
                return stations;
            }
        }

        private void PrintAll()
        {
            foreach (var station in stations)
            {
                Console.WriteLine(station.ToString());
                station.PrintDataPoints();
            }
        }

        protected static string readLine(StreamReader file)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file");
            }
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string line = file.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (string.IsNullOrEmpty(line))
            {
                throw new WrongDataFormatExeception("file is empty");
            }
            return line;
        }
        public static OffsetFile ParseOffsetFile(string filePath)
        {
            XDocument doc = XDocument.Load(filePath);
            XElement root = doc.Element("ORC").Element("offset");

            OffsetFile offsetFile = new OffsetFile
            {
                //metadata = new Metadata
                //{
                //    date = DateTime.Parse(root.Attribute("date").Value + " " + root.Attribute("time").Value),
                //    measuresCode = root.Attribute("measurer").Value,
                //    machineCode = root.Attribute("machine").Value,
                //    filename = root.Attribute("filename").Value,
                //    classboat = root.Attribute("yachtname").Value,
                //    // Add other properties as needed
                //},
                stations = root.Elements("station").Select(station => new Station
                {
                    X = double.Parse(station.Attribute("x").Value),
                    SCD = (Station.StationLabel)Enum.Parse(typeof(Station.StationLabel), station.Attribute("label").Value),
                    // Add other properties as needed
                    dataPoints = station.Elements("point").Select(point => new DataPoint
                    {
                        Y = double.Parse(point.Attribute("y").Value),
                        Z = double.Parse(point.Attribute("z").Value),
                        PTC = (DataPoint.PointCode)Enum.Parse(typeof(DataPoint.PointCode), point.Attribute("code").Value),
                        // Add other properties as needed
                    }).ToList()
                }).ToList()
            };

            foreach (Station station in offsetFile.stations)
            {
                station.offsetFile = offsetFile;
            }

            return offsetFile;
        }

        internal void setbottomLineFilter(int bottomFilter)
        {
            bottomLineFilterAngle = bottomFilter;
        }
    }
}
