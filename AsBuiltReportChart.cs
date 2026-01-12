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

            Chart.CustomColorPalette = ["#DFF0D0", "#FFF4C7", "#FEDDD7", "#878787", "#77a898", "#5e9584", "#458370", "#2a715d", "#005f4b"];
            Chart.EnableCustomColorPalette = true;
            // Chart.ColorPalette = ColorPalettes.LightOcean;

            Chart.AreaOrientation = Orientations.Horizontal;

            Pie myPie = new();
            Bar myBar = new();

            Chart.Format = Formats.png;

            myPie.Chart(values, labels, width: 600, height: 400, filename: "PieChartExample");

            myBar.Chart(values, labels, width: 600, height: 400, filename: "BarChartExample");

        }
    }
}