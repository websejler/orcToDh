using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using orcToDh.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.LinkLabel;

namespace orcToDh
{
    public class OfsetFile
    {
        Metadata metadata;
        List<Station> stations;

        public OfsetFile(StreamReader file)
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
                Station station = new Station(line);
                stations.Add(station);
                for (int j = 0; j < station.NPT; j++)
                {
                    line = readLine(file);
                    DataPoint point = new DataPoint(line);
                    station.dataPoints.Add(point);
                }
            }

            PrintAll();
        }

        //inner classes
        // Metadata
        // Station
        // DataPoint
        #region innerClasses
        private class Metadata
        {
            public DateTime date;
            public string measuresCode;
            public string machineCode;
            public string filename;
            public string classboat;
            public string ageDate;

            public double sffps, ffpvs, safps, fapvs;
            public double sffpp, ffpvp, safpp, fapvp;

            public int nst;
            public double loa, sfj, sfbi;

            public Metadata(StreamReader file)
            {
                //read date and time
                string line = readLine(file);
                string[] data = line.Split(',');
                if (data.Length != 8)
                {
                    throw new WrongDataFormatExeception(string.Format("line1 for metadata is not the right length  nr of dataFields in line: {0}", data.Length));
                }

                MatchCollection matches = Regex.Matches(data[1], @"\b\d{2}\b");

                int dd = int.Parse(matches[0].ToString());
                int mm = int.Parse(matches[1].ToString());
                int yyyy = int.Parse(matches[2].ToString());
                int currentYear = DateTime.Now.Year;
                if (yyyy + 2000 > currentYear)
                {
                    yyyy += 1900;
                }
                else
                {
                    yyyy += 2000;
                }

                string dateString = yyyy + "-" + mm + "-" + dd;
                DateOnly dateOnly = DateOnly.ParseExact(dateString, "yyyy-mm-dd", null);


                matches = Regex.Matches(data[0], @"\b\d{2}\b");

                int hh = int.Parse(matches[0].ToString());
                mm = int.Parse(matches[1].ToString());
                int ss = int.Parse(matches[2].ToString());

                TimeOnly time = new TimeOnly(hh, mm, ss);


                date = new DateTime(dateOnly, time);

                measuresCode = data[2].Trim();
                machineCode = data[3].Trim();
                filename = data[4].Trim();
                classboat = data[5].Trim();
                ageDate = data[6].Trim();


                //read Metrec system
                string[] line1Values = readLine(file).Split(',');
                string[] line2Values = readLine(file).Split(',');

                if (line1Values.Length != 5 || line2Values.Length != 5)
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
                if (data.Length != 5)
                {
                    throw new WrongDataFormatExeception("Invalid number of values in line 4");
                }

                int.TryParse(data[0].Trim(), out nst);
                double.TryParse(data[1].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out loa);
                double.TryParse(data[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out sfj);
                double.TryParse(data[3].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out sfbi);

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

        private class Station
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

            public double X { get; } // Distance from the stem for each station in millimeters for metric units, in hundredths of feet for imperial units
            public int NPT { get; } // Number of points in a section. Important to be correct.
            public SideCode SID { get; } // Side code: Port, Starboard, Both
            public StationLabel SCD { get; } // Station label: Forward freeboard, Aft freeboard, Prop shaft exit point, Propeller hub point
            public int STA { get; } // Station count, not necessary but included for convenience

            public List<DataPoint> dataPoints;

            public Station(string line)
            {
                string[] data = line.Split(',');
                if (data.Length != 5 && data.Length != 6)
                {
                    throw new WrongDataFormatExeception("Invalid number of values in line");
                }
                X = double.Parse(data[0]);
                NPT = int.Parse(data[1]);
                SID = (SideCode)Enum.Parse(typeof(SideCode), data[2]);
                SCD = (StationLabel)Enum.Parse(typeof(StationLabel), data[3]);
                try
                {
                    STA = int.Parse(data[4]);
                }
                catch (Exception e)
                {
                    STA = 0;
                }

                dataPoints = new List<DataPoint>();

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
        }

        private class DataPoint
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

            public double Z { get; } // Vertical co-ordinate for points on a half section, positive up, negative down in millimeters for metric units, in hundredths Of feet for imperial units
            public double Y { get; } // Horizontal distance from the centerline for points on a half section. Negative only in the gap in section for example, between the canoe body and the trailing edge where point code PTC is set to 2.
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
                Z = double.Parse(data[0]);
                Y = double.Parse(data[1]);
                PTC = (PointCode)Enum.Parse(typeof(PointCode), data[2]);
            }

            public override string ToString()
            {
                return $"Z: {Z}, Y: {Y}, PTC: {PTC}";
            }

        }
        #endregion

        // This function prints all the stations and their data points in the offset file
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
    }
}
