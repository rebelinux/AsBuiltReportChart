using System.Management.Automation;

namespace AsBuiltReportChart.PowerShell
{
    [Cmdlet(VerbsCommon.New, "PieChart")]
    public class NewPieChartCommand : Cmdlet
    {
        // Declare the parameters for the cmdlet.
        [Parameter(Mandatory = false)]
        public string Filename { get; set; } = Chart.GenerateToken(8);

        [Parameter(Mandatory = true)]
        public double[]? Values { get; set; }

        [Parameter(Mandatory = true)]
        public string[]? Labels { get; set; }

        [Parameter(Mandatory = true)]
        public string? Title { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter TitleFontBold { get; set; }

        [Parameter(Mandatory = false)]
        public int TitleFontSize { get; set; } = 14;

        [Parameter(Mandatory = false)]
        public BasicColors TitleFontColor { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter EnableLegend { get; set; }

        [Parameter(Mandatory = false)]
        public Enums.Orientations LegendOrientation { get; set; } = Enums.Orientations.Vertical;

        [Parameter(Mandatory = false)]
        public Enums.Alignments LegendAlignment { get; set; } = Enums.Alignments.UpperRight;

        [Parameter(Mandatory = true)]
        public Formats Format { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateSet("0.0", "0.1", "0.2", "0.3", "0.4", "0.5")]
        public double AreaExplodeFraction { get; set; }

        [Parameter(Mandatory = false)]
        public BasicColors ChartBorderColor { get; set; }

        [Parameter(Mandatory = false)]
        public int ChartBorderSize { get; set; } = 1;

        [Parameter(Mandatory = false)]
        public Enums.BorderStyles ChartBorderStyle { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter EnableChartBorder { get; set; }

        [Parameter(Mandatory = false)]
        public int LegendFontSize { get; set; } = 14;

        [Parameter(Mandatory = false)]
        public BasicColors LegendFontColor { get; set; } = BasicColors.Black;

        [Parameter(Mandatory = false)]
        public Enums.BorderStyles LegendBorderStyle { get; set; }

        [Parameter(Mandatory = false)]
        public int LegendBorderSize { get; set; } = 1;

        [Parameter(Mandatory = false)]
        public BasicColors LegendBorderColor { get; set; } = BasicColors.Black;

        [Parameter(Mandatory = false)]
        public Enums.ColorPalettes ColorPalette { get; set; } = Enums.ColorPalettes.Category10;

        [Parameter(Mandatory = false)]
        public SwitchParameter EnableCustomColorPalette { get; set; }

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
        public SwitchParameter LabelBold { get; set; }

        // this set the distance of the labels from the chart center (Pie Chart)
        [Parameter(Mandatory = false)]
        [ValidateSet("0.5", "0.6", "0.7", "0.8", "0.9")]
        public double LabelDistance { get; set; } = 0.6;

        // Set chart Size WxH
        [Parameter(Mandatory = false)]
        public int Width { get; set; } = 400;

        [Parameter(Mandatory = false)]
        public int Height { get; set; } = 300;

        // Set OutputFolderPath
        [Parameter(Mandatory = false)]
        [ValidatePath()]
        public string OutputFolderPath { get; set; } = Directory.GetCurrentDirectory();

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

                // This set the distance of the labels from the chart center (Pie Chart)
                Chart.LabelDistance = LabelDistance;

                // Font Settings
                Chart.FontName = FontName;
                Chart.LabelFontSize = LabelFontSize;
                Chart.LabelFontColor = LabelFontColor;
                Chart.LabelBold = LabelBold;

                // Set file directory save path 
                Chart.OutputFolderPath = OutputFolderPath;

                Chart.Format = Format;
                Pie myPie = new();
                myPie.Chart(Values, Labels, Filename, Width, Height);
            }
            else
            {
                WriteObject("Please provide both Values and Labels parameters.");
            }
        }
    }
}

class ValidatePath : ValidateArgumentsAttribute
{
    protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
    {
        string path = (string)arguments;
        if (Directory.Exists(path) == false)
        {
            throw new ArgumentException("Error: Directory Not Found Exception");
        }
    }
}