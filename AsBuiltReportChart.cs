using AsBuiltReportChart.Enums;

namespace AsBuiltReportChart
{
    public static class MainEntry
    {
        public static void Main(string[] args)
        {
            double[] values = [100, 7, 40, 18];
            string[] labels = ["Instances Capacity", "Used Instances", "New Instances", "Rental Instances"];

            Chart.EnableLegend = true;
            Chart.Title = "Instance License Usage";
            Chart.LabelBold = false;
            Chart.LabelFontSize = 20;
            Chart.TitleFontColor = ScottPlot.Color.FromColor(System.Drawing.Color.DarkGreen);
            Chart.ChartBorderStyle = BorderStyles.Dotted;
            Chart.ChartBorderColor = ScottPlot.Color.FromColor(System.Drawing.Color.DarkGreen);
            Chart.ChartBorderSize = 2;
            Chart.EnableChartBorder = true;
            Chart.LegendOrientation = Orientations.Vertical;
            Chart.LegendAlignment = Alignments.UpperRight;
            Chart.LegendBorderSize = 0;

            Chart.CustomColorPalette = ["#ddf6ed", "#c3e2d7", "#aacec2", "#90bbad", "#77a898", "#5e9584", "#458370", "#2a715d", "#005f4b"];
            // Chart.ColorPalette = ColorPalettes.Nero;

            Pie.Chart(values, labels, width: 600, height: 400);
        }
    }
}