using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using orcToDh.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace orcToDh
{
    public class OfsetFile
    {
        Metadata metadata;
        MetericSystem metericSystem;

        public OfsetFile(StreamReader file)
        {
            try
            {
                if (file == null)
                {
                    throw new ArgumentNullException("file");
                }

                string line = readLine(file);

                if (string.IsNullOrEmpty(line))
                {
                    throw new WrongDataFormatExeception("file is empty");
                }

                metadata = new Metadata(line);

                string line1 = readLine(file);
                string line2 = readLine(file);

                metericSystem = new MetericSystem(line1, line2);

                Console.WriteLine("metadata: " + metadata.ToString());
                Console.WriteLine("metericSystem: " + metericSystem.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private class MetericSystem
        {
            public double sffps, ffpvs, safps, fapvs;
            public double sffpp, ffpvp, safpp, fapvp;

            public MetericSystem(string line1, string line2)
            {
                string[] line1Values = line1.Split(',');
                string[] line2Values = line2.Split(',');

                if (line1Values.Length != 5 || line2Values.Length != 5)
                {
                    throw new WrongDataFormatExeception("Invalid number of values in line1 or line2");
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
            }

            public override string ToString()
            {
                string str = "";
                str += "SFFPs: " + sffps + " - FFPVs: " + ffpvs + " - SAPFs: " + safps + " - FAPVs: " + fapvs + "\n";
                str += "SFFPp: " + sffpp + " - FFPVp: " + ffpvp + " - SAPFp: " + safpp + " - FAPVp: " + fapvp + "\n";
                return str;
            }
        }

        private class Metadata
        {
            DateTime date;
            string measuresCode;
            string machineCode;
            string filename;
            string classboat;
            string ageDate;

            /// <summary>
            /// gets data from a line of text from the ofset file
            /// </summary>
            /// <param name="line"></param>
            /// <exception cref="WrongDataFormatExeception">if the line is not the right length</exception>
            public Metadata(string line)
            {
                string[] data = line.Split(',');
                if (data.Length != 8)
                {
                    throw new WrongDataFormatExeception(string.Format("line for metadata is not the right length  nr of dataFields in line: {0}", data.Length));
                }

                MatchCollection matches = Regex.Matches(data[1], @"\b\d{2}\b");

                int dd = int.Parse(matches[0].ToString());
                int mm = int.Parse(matches[1].ToString());
                int yy = int.Parse(matches[2].ToString());
                int currentYear = DateTime.Now.Year;
                if (yy + 2000 > currentYear)
                {
                    yy += 1900;
                }
                else
                {
                    yy += 2000;
                }

                string dateString = yy + "-" + mm + "-" + dd;
                DateOnly dateOnly = DateOnly.ParseExact(dateString, "yyyy-mm-dd", null);


                matches = Regex.Matches(data[0], @"\b\d{2}\b");

                int hh = int.Parse(matches[0].ToString());
                mm = int.Parse(matches[1].ToString());
                int ss = int.Parse(matches[2].ToString());

                TimeOnly time = new TimeOnly(hh, mm, ss);


                date = new DateTime(dateOnly, time);

                measuresCode = data[2];
                machineCode = data[3];
                filename = data[4];
                classboat = data[5];
                ageDate = data[6];
            }

            public override string ToString()
            {
                return $"Date: {date}, MeasuresCode: {measuresCode}, MachineCode: {machineCode}, Filename: {filename}, Classboat: {classboat}, AgeDate: {ageDate}";
            }
        }

        private string readLine(StreamReader file)
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
