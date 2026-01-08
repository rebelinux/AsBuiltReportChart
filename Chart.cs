using ScottPlot;
using AsBuiltReportChart.Enums;
namespace AsBuiltReportChart;

public class Chart
{
    // Save settings
    internal static string _format = "png";
    public static string Format
    {
        get { return _format; }
        set
        {
            if (value is "png" or "jpg" or "jpeg" or "bmp" or "svg")
            {
                _format = value;
            }
            else
            {
                throw new ArgumentException("Error: Format value must be a valid image format (png, jpg, jpeg, bmp, svg).");
            }
        }
    }

    // Title setting
    public static string? Title { get; set; }
    public static bool TitleFontBold { get; set; } = false;
    public static int TitleFontSize { get; set; } = 14;
    public static Color TitleFontColor { get; set; } = Colors.Black;

    // Global Font settings
    public static string FontName { get; set; } = "Arial";

    // Label Font settings
    public static int LabelFontSize { get; set; } = 14;
    public static Color LabelFontColor { get; set; } = Colors.Black;
    public static bool LabelBold { get; set; }

    // Set font for the X and Y axis labels
    public static string LabelYAxis { get; set; } = "Count";
    public static string LabelXAxis { get; set; } = "Values";


    // Bar Axes Font settings
    public static int AxisLabelFontSize { get; set; } = 12;
    public static Color AxisLabelFontColor { get; set; } = Colors.Black;
    public static bool AxisLabelFontBold { get; set; }

    // this set the distance of the labels from the chart center
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

    // this set the orientation chart area 
    public static Orientations AreaOrientation { get; set; } = Orientations.Vertical;


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

    // Legend setting
    public static bool EnableLegend { get; set; }

    // Legend Font settings
    public static int LegendFontSize { get; set; } = 12;
    public static Color LegendFontColor { get; set; } = Colors.Black;

    // Legend border settings
    internal static LinePattern legendborderstyle;
    public static BorderStyles LegendBorderStyle { get; set; } = BorderStyles.Solid;
    public static int LegendBorderSize { get; set; } = 1;
    public static Color LegendBorderColor { get; set; } = Colors.Black; // Todo change this to rgb color
    internal static Orientation legendOrientation;
    public static Orientations LegendOrientation { get; set; } = Orientations.Vertical;

    public static Alignments LegendAlignment { get; set; } = Alignments.LowerRight;
    internal static Alignment legendAlignment;

    // Chart border settings
    public static bool EnableChartBorder { get; set; }
    internal static LinePattern chartborderstyle;
    public static BorderStyles ChartBorderStyle { get; set; }
    public static int ChartBorderSize { get; set; } = 1;
    public static Color ChartBorderColor { get; set; } = Colors.Black;  // Todo change this to rgb color

    // Color Palette settings
    internal static IPalette? colorPalette;
    public static ColorPalettes ColorPalette { get; set; } = ColorPalettes.Normal;

    // Custom color palette
    private static string[]? _customColorPalette;
    public static string[] CustomColorPalette
    {
        get
        {
            return _customColorPalette ?? [];
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Error: CustomColorPalette must contain at least 3 colors.");
            }
            _customColorPalette = value;
        }
    }
}