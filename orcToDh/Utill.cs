using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace orcToDh
{
    public class Utill
    {
        public static string IniPath = "setting.ini";


        public static double GetYPointInX(double x1, double y1, double x2, double y2, double x = 0)
        {
            return y1 + ((x - x1) * (y2 - y1)) / (x2 - x1);
        }

    }
}
