using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static orcToDh.OfsetFile;

namespace orcToDh.Calculators
{
    public class BMaxOld
    {
        /// <summary>
        /// Calculate BMax from an ofset file object
        /// </summary>
        /// <param name="ofsetFile"></param>
        /// <returns>BMax as double</returns>
        public static double Calculate(OfsetFile ofsetFile)
        {
            
            List<Station> portStations = ofsetFile.PortStations.OrderBy(s => s.X).ToList();
            List<Station> starboardStations = ofsetFile.StarboardStations.OrderBy(s => s.X).ToList();

            int portIndex = 0;
            int starboardIndex = 0;
            double maxBMax = 0.0;
            double currentBMax = 0.0;

            while (portIndex < portStations.Count && starboardIndex < starboardStations.Count)
            {
                if (portStations[portIndex].X < starboardStations[starboardIndex].X)
                {
                    currentBMax = 0;
                    portIndex++;
                }
                else if (portStations[portIndex].X > starboardStations[starboardIndex].X)
                {
                    currentBMax = 0;
                    starboardIndex++;
                }
                else
                {
                    double maxPort = 0;
                    foreach (DataPoint dataPoint in portStations[portIndex].dataPoints)
                    {
                        if (dataPoint.Y > maxPort)
                        {
                            maxPort = dataPoint.Y;
                        }
                    }

                    double maxStarboard = 0;
                    foreach (DataPoint dataPoint in starboardStations[starboardIndex].dataPoints)
                    {
                        if (dataPoint.Y > maxStarboard)
                        {
                            maxStarboard = dataPoint.Y;
                        }
                    }
                    
                    currentBMax = maxPort + maxStarboard;
                    portIndex++;
                    starboardIndex++;
                }

                if (currentBMax > maxBMax)
                {
                    maxBMax = currentBMax;
                }
            }

            return maxBMax;
        }
    }
}
