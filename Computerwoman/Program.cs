using System;
using System.IO;

namespace Computerwoman
{
    class Program
    {
        static void Main(string[] args)
        {
            const double g = 9.807;

            Console.WriteLine("introduce initial velocity");

            double v0 = double.Parse(Console.ReadLine());

            Console.WriteLine("introduce Launch angle");

            int alpha = int.Parse(Console.ReadLine());

            Console.WriteLine("Do you want to save the results into a file (y/n)");

            string SaveResults = Console.ReadLine();

            double h_max = maxHeight(v0, g);

            double x_max = maxTraveledDistance(v0, g, alpha);

            Console.WriteLine("Maximum height of the projectile: " +h_max);

            Console.WriteLine("Maximum traveled distance: "+x_max);

            if(SaveResults == "y")
            {
                saveData(v0, g, alpha, x_max, h_max);
            }


        }

        static double maxHeight(double v0, double g)
        {
            double h_max = (v0 * v0) / (2 * g);

            return h_max;
        }

        static double maxTraveledDistance(double v0, double g, double alpha)
        {
            double x_max = 2 * v0 * (Math.Sin(alpha) / g);

            return x_max;
        }

        static void saveData(double v0, double g, double alpha, double x_max, double h_max)
        {
            try
            {
                TextWriter writer = new StreamWriter("file.txt");

                writer.WriteLine("Inputs-> " + "V0: " + v0 + " alpha: " + alpha);

                writer.WriteLine("Results-> " + "Maximum height of the projectile: " + h_max + " Maximum traveled distance: " + x_max);

                writer.Close();

                Console.WriteLine("Data saved");
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            

        }
    }
}
