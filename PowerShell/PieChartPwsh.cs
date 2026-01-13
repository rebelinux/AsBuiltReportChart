using ScottPlot;
using System.Management.Automation;

namespace AsBuiltReportChart.PowerShell
{
    [Cmdlet(VerbsCommon.New, "PieChart")]
    public class NewPieChartCommand : Cmdlet
    {
        // Declare the parameters for the cmdlet.
        [Parameter(Mandatory = false)]
        public string Filename { get; set; } = "PieChartExample";

        [Parameter(Mandatory = true)]
        public double[]? Values { get; set; }

        [Parameter(Mandatory = true)]
        public string[]? Labels { get; set; }

        [Parameter(Mandatory = true)]
        public string? Title { get; set; }

        [Parameter(Mandatory = false)]
        public bool TitleFontBold { get; set; }

        [Parameter(Mandatory = false)]
        public int TitleFontSize { get; set; } = 14;

        [Parameter(Mandatory = false)]
        public Color TitleFontColor { get; set; }

        [Parameter(Mandatory = false)]
        public bool EnableLegend { get; set; }

        [Parameter(Mandatory = false)]
        public Enums.Orientations LegendOrientation { get; set; } = Enums.Orientations.Vertical;

        [Parameter(Mandatory = false)]
        public Enums.Alignments LegendAlignment { get; set; } = Enums.Alignments.UpperRight;

        [Parameter(Mandatory = true)]
        public Formats Format { get; set; }

        [Parameter(Mandatory = false)]
        public double AreaExplodeFraction { get; set; }

        [Parameter(Mandatory = false)]
        public Color ChartBorderColor { get; set; }

        [Parameter(Mandatory = false)]
        public int ChartBorderSize { get; set; }

        [Parameter(Mandatory = false)]
        public Enums.BorderStyles ChartBorderStyle { get; set; }

        [Parameter(Mandatory = false)]
        public bool EnableChartBorder { get; set; }

        [Parameter(Mandatory = false)]
        public int LegendFontSize { get; set; }

        [Parameter(Mandatory = false)]
        public Color LegendFontColor { get; set; }

        [Parameter(Mandatory = false)]
        public Enums.BorderStyles LegendBorderStyle { get; set; }

        [Parameter(Mandatory = false)]
        public int LegendBorderSize { get; set; }

        [Parameter(Mandatory = false)]
        public Color LegendBorderColor { get; set; }

        [Parameter(Mandatory = false)]
        public Enums.ColorPalettes ColorPalette { get; set; } = Enums.ColorPalettes.Category10;

        [Parameter(Mandatory = false)]
        public bool EnableCustomColorPalette { get; set; }

        [Parameter(Mandatory = false)]
        public string[]? CustomColorPalette { get; set; }

        [Parameter(Mandatory = false)]
        public string FontName { get; set; } = "Arial";

        // Label Font settings
        [Parameter(Mandatory = false)]
        public int LabelFontSize { get; set; } = 14;

        [Parameter(Mandatory = false)]
        public Color LabelFontColor { get; set; } = Colors.Black;

        [Parameter(Mandatory = false)]
        public bool LabelBold { get; set; }

        // this set the distance of the labels from the chart center (Pie Chart)
        [Parameter(Mandatory = false)]
        public double LabelDistance { get; set; } = 0.6;

        protected override void ProcessRecord()
        {
            if (Values != null && Labels != null)
            {
                if (EnableLegend)
                {
                    Chart.EnableLegend = EnableLegend;
                    // Legend box settings
                    Chart.LegendOrientation = LegendOrientation;
                    Chart.LegendAlignment = LegendAlignment;

                    // Legend font settings
                    Chart.LegendFontSize = LegendFontSize;
                    Chart.LegendFontColor = LegendFontColor;
                    // Legend border settings
                    Chart.LegendBorderStyle = LegendBorderStyle;
                    Chart.LegendBorderSize = LegendBorderSize;
                    Chart.LegendBorderColor = LegendBorderColor;
                }

                Chart.AreaExplodeFraction = AreaExplodeFraction;
                // Chart area settings
                Chart.EnableChartBorder = EnableChartBorder;
                Chart.ChartBorderColor = ChartBorderColor;
                Chart.ChartBorderSize = ChartBorderSize;
                Chart.ChartBorderStyle = ChartBorderStyle;
                // Color palette settings
                if (EnableCustomColorPalette)
                {
                    if (CustomColorPalette is not null or [])
                    {
                        // Set ScottPlot custom color palette
                        Chart.EnableCustomColorPalette = EnableCustomColorPalette;
                        Chart.CustomColorPalette = CustomColorPalette;
                    }
                    else
                    {
                        throw new Exception("EnableCustomColorPalette requires CustomColorPalette to be set.");
                    }
                }
                else
                {
                    Chart.ColorPalette = ColorPalette;
                }

                Chart.Title = Title;
                Chart.Format = Format;
                Pie myPie = new();
                myPie.Chart(Values, Labels, Filename);
            }
            else
            {
                WriteObject("Please provide both Values and Labels parameters.");
            }
        }
    }
}