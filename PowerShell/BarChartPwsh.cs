using System.Management.Automation;

namespace AsBuiltReportChart.PowerShell
{
    [Cmdlet(VerbsCommon.New, "BarChart")]
    public class NewBarChartCommand : Cmdlet
    {
        // Declare the parameters for the cmdlet.
        [Parameter(Mandatory = false)]
        public string Filename { get; set; } = "BarChartExample";

        [Parameter(Mandatory = true)]
        public double[]? Values { get; set; }

        [Parameter(Mandatory = true)]
        public string[]? Labels { get; set; }

        // Title settings
        [Parameter(Mandatory = true)]
        public string? Title { get; set; }

        [Parameter(Mandatory = false)]
        public bool TitleFontBold { get; set; }

        [Parameter(Mandatory = false)]
        public int TitleFontSize { get; set; } = 14;

        [Parameter(Mandatory = false)]
        public BasicColors TitleFontColor { get; set; } = BasicColors.Black;

        [Parameter(Mandatory = true)]
        public Formats Format { get; set; }

        [Parameter(Mandatory = false)]
        public BasicColors ChartBorderColor { get; set; } = BasicColors.Black;

        [Parameter(Mandatory = false)]
        public int ChartBorderSize { get; set; } = 1;

        [Parameter(Mandatory = false)]
        public Enums.BorderStyles ChartBorderStyle { get; set; }

        [Parameter(Mandatory = false)]
        public bool EnableChartBorder { get; set; }

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
        public BasicColors LabelFontColor { get; set; } = BasicColors.Black;

        [Parameter(Mandatory = false)]
        public bool LabelBold { get; set; }

        // Set font for the X and Y axis labels (Bar Chart)
        [Parameter(Mandatory = false)]
        public string LabelYAxis { get; set; } = "Count";

        [Parameter(Mandatory = false)]
        public string LabelXAxis { get; set; } = "Values";

        // this set the orientation chart area  (Bar Chart)
        [Parameter(Mandatory = false)]
        public Enums.Orientations AreaOrientation { get; set; } = Enums.Orientations.Vertical;

        protected override void ProcessRecord()
        {
            if (Values != null && Labels != null)
            {

                if (EnableChartBorder)
                {
                    // Chart area settings
                    Chart.EnableChartBorder = EnableChartBorder;
                    Chart.ChartBorderColor = ChartBorderColor;
                    Chart.ChartBorderSize = ChartBorderSize;
                    Chart.ChartBorderStyle = ChartBorderStyle;
                }
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

                // Title settings
                if (Title != null)
                {
                    Chart.Title = Title;
                    Chart.TitleFontBold = TitleFontBold;
                    Chart.TitleFontSize = TitleFontSize;
                    Chart.TitleFontColor = TitleFontColor;
                }

                // Font Settings
                Chart.FontName = FontName;
                Chart.LabelFontSize = LabelFontSize;
                Chart.LabelFontColor = LabelFontColor;
                Chart.LabelBold = LabelBold;

                // Set font for the X and Y axis labels
                Chart.LabelXAxis = LabelXAxis;
                Chart.LabelYAxis = LabelYAxis;

                // this set the orientation chart area  (Bar Chart)
                Chart.AreaOrientation = AreaOrientation;

                Chart.Format = Format;
                Bar myBar = new();
                myBar.Chart(Values, Labels, Filename);
            }
            else
            {
                WriteObject("Please provide both Values and Labels parameters.");
            }
        }
    }
}