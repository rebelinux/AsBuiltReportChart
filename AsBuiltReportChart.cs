using System;

namespace AsBuiltReportChart
{
    public class MainEntry
    {
        public static void Main(string[] args)
        {
            double[] values = [20,7, 40];
            string[] labels = ["cpu", "mem", "hdd"];

            Chart.EnableLegend = true;
            // Chart.Title = "Caca";

            Chart.PieChart(values, labels, width:600,height:400);
        }

    }
}