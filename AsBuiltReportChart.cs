using AsBuiltReportChart.Enums;

namespace AsBuiltReportChart
{
    public static class MainEntry
    {
        public static void Main(string[] args)
        {
            double[] values = [17, 2, 16, 1];
            string[] labels = ["Passed", "Unable to detect", "Not Implemented", "Suppressed"];

            Chart.EnableLegend = true;
            Chart.Title = "Best Practices";
            Chart.TitleFontBold = true;
            Chart.TitleFontSize = 18;
            Chart.LabelXAxis = "Values";
            Chart.LabelYAxis = "Count";
            Chart.LabelBold = false;
            Chart.LabelFontSize = 20;
            Chart.ChartBorderStyle = BorderStyles.Dotted;
            Chart.ChartBorderColor = ScottPlot.Color.FromColor(System.Drawing.Color.DarkGreen);
            Chart.ChartBorderSize = 2;
            Chart.EnableChartBorder = true;
            Chart.LegendOrientation = Orientations.Vertical;
            Chart.LegendAlignment = Alignments.UpperRight;
            Chart.LegendBorderSize = 0;

            Chart.CustomColorPalette = ["#DFF0D0", "#FFF4C7", "#FEDDD7", "#878787",];
            // Chart.ColorPalette = ColorPalettes.Nero;

            Chart.AreaOrientation = Orientations.Horizontal;

            Chart.Format = "svg";

            Pie.Chart(values, labels, width: 600, height: 400, filename: "PieChartExample");

            Bar.Chart(values, labels, width: 600, height: 400, filename: "BarChartExample");

        }
    }
}