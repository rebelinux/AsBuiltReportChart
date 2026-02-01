using AsBuiltReportChart.Enums;

namespace AsBuiltReportChart
{
    public static class MainEntry
    {
        public static void Main(string[] args)
        {
            List<double[]> values =
            [
                [3, 5,20],
                [8, 20,33],
                [5, 10,23]
            ];
            string[] labels = ["Aggr0", "Aggr1", "Aggr2"];
            string[] category = ["Used", "Free","Papa"];

            Chart.EnableLegend = true;
            Chart.LegendFontColor = BasicColors.Black;
            Chart.Title = "Aggregate Usage";
            Chart.TitleFontBold = false;
            Chart.TitleFontSize = 18;
            Chart.TitleFontColor = BasicColors.Black;
            Chart.LabelXAxis = "Aggregates";
            Chart.LabelYAxis = "Usage";
            Chart.LabelBold = false;
            Chart.LabelFontSize = 14;
            Chart.LabelFontColor = BasicColors.Black;
            Chart.ChartBorderStyle = BorderStyles.Dotted;
            Chart.ChartBorderColor = BasicColors.DarkGreen;
            Chart.ChartBorderSize = 2;
            Chart.EnableChartBorder = true;
            Chart.LegendOrientation = Orientations.Horizontal;
            Chart.LegendAlignment = Alignments.UpperCenter;
            Chart.LegendBorderSize = 0;

            Chart.ColorPalette = ColorPalettes.Dark;

            Chart.AreaOrientation = Orientations.Vertical;

            StackedBar myStackedBar = new();
            Chart.Format = Formats.png;

            myStackedBar.Chart(values, labels, category, width: 600, height: 600, filename: "StackedBarChartExample");
        }
    }
}