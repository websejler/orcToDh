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

        public OfsetFile(StreamReader file)
        {
            try
            {
                if (file == null)
                {
                    throw new ArgumentNullException("file");
                }
                metadata = new Metadata(file);

                Console.WriteLine("metadata: " + metadata.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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

            double sffps, ffpvs, safps, fapvs;
            double sffpp, ffpvp, safpp, fapvp;

            int nst;
            double loa, sfj, sfbi;

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
