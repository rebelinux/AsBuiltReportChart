using System;

namespace AsBuiltReportChart
{
    public class MainEntry
    {
        public static void Main(string[] args)
        {        
            double[] values = [100, 7, 40, 18];
            string[] labels = ["Instances Capacity", "Used Instances", "New Instances", "Rental Instances"];

            Chart.EnableLegend = true;
            Chart.Title = "Instance License Usage";
            Chart.LabelBold = false;
            Chart.LabelFontSize = 20;
            Chart.ChartBorderStyle = BorderStyle.Dotted;
            Chart.ChartBorderColor = ScottPlot.Color.FromColor(System.Drawing.Color.DarkGreen);
             Chart.ChartBorderSize = 2;
            Chart.EnableChartBorder = true;
            Chart.LegendOriantation = Orientation.Vertical;
            Chart.LegendAlignment = Alignment.UpperRight;
            Chart.LegendBorderSize = 0;

            Pie.Chart(values, labels, width: 600, height: 400);
        }
    }
}