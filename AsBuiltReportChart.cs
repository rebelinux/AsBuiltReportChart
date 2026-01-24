using AsBuiltReportChart.Enums;

namespace AsBuiltReportChart
{
    public static class MainEntry
    {
        public static void Main(string[] args)
        {
            List<double[]> values =
            [
                [3, 2,],
                [8, 12],
                [5, 5]
            ];
            string[] labels = ["Aggr0", "Aggr1", "Aggr2"];
            string[] category = ["Free", "Used"];

            Chart.EnableLegend = true;
            Chart.LegendFontColor = BasicColors.Black;
            Chart.Title = "Aggregate Usage";
            Chart.TitleFontBold = false;
            Chart.TitleFontSize = 18;
            Chart.TitleFontColor = BasicColors.Black;
            Chart.LabelXAxis = "Names";
            Chart.LabelYAxis = "Usage";
            Chart.LabelBold = false;
            Chart.LabelFontSize = 14;
            Chart.LabelFontColor = BasicColors.Black;
            Chart.ChartBorderStyle = BorderStyles.Dotted;
            Chart.ChartBorderColor = BasicColors.DarkGreen;
            Chart.ChartBorderSize = 2;
            Chart.EnableChartBorder = true;
            Chart.LegendOrientation = Orientations.Vertical;
            Chart.LegendAlignment = Alignments.UpperRight;
            Chart.LegendBorderSize = 0;

            Chart.ColorPalette = ColorPalettes.Nord;

            Chart.AreaOrientation = Orientations.Horizontal;

            StackedBar myStackedBar = new();
            Chart.Format = Formats.png;

            myStackedBar.Chart(values, labels, category, width: 600, height: 600, filename: "StackedBarChartExample");
        }
    }
}