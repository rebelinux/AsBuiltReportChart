using ScottPlot;
using AsBuiltReportChart.Enums;
namespace AsBuiltReportChart;

public class Chart
{
    // Title setting
    public static string? Title { get; set; }
    protected static bool TitleFontBold { get; set; } = false;
    protected static int TitleFontSize { get; set; } = 14;
    protected static Color TitleFontColor { get; set; } = Colors.Black;

    // Font settings
    public static int LabelFontSize { get; set; } = 14;
    internal static double _labelDistance = 0.6;
    public static double LabelDistance
    {
        get { return _labelDistance; }
        set
        {
            if (value is >= 0.5 and <= 0.9)
            {
                _labelDistance = value;
            }
            else
            {
                throw new ArgumentException("Error: LabelDistance value range must be from 0.5 to 0.9.");
            }
        }
    }

    // this set the distance of the chart area elements
    internal static double _areaExplodeFraction;
    public static double AreaExplodeFraction
    {
        get { return _areaExplodeFraction; }
        set
        {
            if (value is >= 0.1 and <= 0.5)
            {
                _areaExplodeFraction = value;
            }
            else
            {
                throw new ArgumentException("Error: AreaExplodeFraction value range must be from 0.1 to 0.5.");
            }
        }
    }
    protected static Color LabelFontColor { get; set; } = Colors.Black;
    public static bool LabelBold { get; set; }

    // Legend setting
    public static bool EnableLegend { get; set; }
    // Legend border settings
    internal static LinePattern legendborderstyle;
    protected static BorderStyles LegendBorderStyle { get; set; } = BorderStyles.Solid;
    public static int LegendBorderSize { get; set; } = 1;
    protected static Color LegendBorderColor { get; set; } = Colors.Black; // Todo change this to rgb color
    internal static Orientation legendOriantation;
    public static Orientations LegendOrientation { get; set; } = Orientations.Vertical;
    internal static Alignment legendAlignment;
    public static Alignments LegendAlignment { get; set; } = Alignments.LowerRight;

    // Chart border settings
    public static bool EnableChartBorder { get; set; }
    internal static LinePattern chartborderstyle;
    public static BorderStyles ChartBorderStyle { get; set; }
    public static int ChartBorderSize { get; set; } = 1;
    public static Color ChartBorderColor { get; set; } = Colors.Black;  // Todo change this to rgb color

    // Color Pallete settings


}