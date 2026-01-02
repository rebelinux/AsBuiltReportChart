using HarfBuzzSharp;
using ScottPlot;
namespace AsBuiltReportChart;

public class Chart
{
    // Title setting
    public static string? Title { get; set; }
    public static bool TitleFontBold { get; set; } = false;
    public static int TitleFontSize { get; set; } = 14;
    public static Color TitleFontColor { get; set; } = Colors.Black;

    // Font settings
    public static int LabelFontSize { get; set; } = 14;
    internal static double _labelDistance = 0.6;
    public static double LabelDistance
    {
        get { return _labelDistance; }
        set
        {
            if (value >= 0.5 && value <= 0.9)
            {
                _labelDistance = value;
            }
            else
            {
                throw new ArgumentException("Error: LabelDistance value rage must be from 0.5 to 0.9.");
            }
        }
    }
    public static Color LabelFontColor { get; set; } = Colors.Black;
    public static bool LabelBold { get; set; } = false;

    // Legend setting
    public static bool EnableLegend { get; set; } = false;
    // Legend boder settings
    internal static ScottPlot.LinePattern legendborderstyle;
    public static BorderStyle LegendBorderStyle { get; set; } = BorderStyle.Solid;
    public static int LegendBorderSize { get; set; } = 1;
    public static Color LegendBorderColor { get; set; } = Colors.Black; // Todo chage this to rgb color
    internal static ScottPlot.Orientation legendOriantation;
    public static Orientation LegendOriantation { get; set; } = Orientation.Vertical;
    internal static ScottPlot.Alignment legendAlignment;
    public static Alignment LegendAlignment { get; set; } = Alignment.LowerRight;

    // Chart boder settings
    public static bool EnableChartBorder { get; set; } = false;
    internal static ScottPlot.LinePattern chartborderstyle;
    public static BorderStyle ChartBorderStyle { get; set; }
    public static int ChartBorderSize { get; set; } = 1;
    public static Color ChartBorderColor { get; set; } = Colors.Black;  // Todo chage this to rgb color

    // Color Pallete settings

    
}