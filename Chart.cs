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
    public static string LabelYAxis { get; set; } = "Y Axis";
    public static string LabelXAxis { get; set; } = "X Axis";


    // Bar Axes Font settings
    public static int AxisLabelFontSize { get; set; } = 12;
    public static Color AxisLabelFontColor { get; set; } = Colors.Black;
    public static bool AxisLabelFontBold { get; set; }

    // this set the distance of the labels from the chart center
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
    internal static double _labelDistance = 0.6;

    // this set the orientation chart area 
    public static Orientations AreaOrientation { get; set; } = Orientations.Vertical;
    internal static Orientation _areaOrientation = AreaOrientation switch
    {
        Orientations.Horizontal => Orientation.Horizontal,
        _ => Orientation.Vertical
    };

    // this set the distance of the chart area elements
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
    internal static double _areaExplodeFraction;

    // Legend setting
    public static bool EnableLegend { get; set; }

    // Legend Font settings
    public static int LegendFontSize { get; set; } = 12;
    public static Color LegendFontColor { get; set; } = Colors.Black;

    // Legend border settings
    public static BorderStyles LegendBorderStyle { get; set; } = BorderStyles.Solid;
    internal static LinePattern legendborderstyle = LegendBorderStyle switch
    {
        BorderStyles.Solid => LinePattern.Solid,
        BorderStyles.Dashed => LinePattern.Dashed,
        BorderStyles.Dotted => LinePattern.Dotted,
        BorderStyles.DenselyDashed => LinePattern.DenselyDashed,
        _ => LinePattern.Solid
    };
    public static int LegendBorderSize { get; set; } = 1;
    public static Color LegendBorderColor { get; set; } = Colors.Black; // Todo change this to rgb color
    public static Orientations LegendOrientation { get; set; } = Orientations.Vertical;
    internal static Orientation legendOrientation = LegendOrientation switch
    {
        Orientations.Horizontal => Orientation.Horizontal,
        _ => Orientation.Vertical
    };
    public static Alignments LegendAlignment { get; set; } = Alignments.LowerRight;
    internal static Alignment legendAlignment = LegendAlignment switch
    {
        Alignments.LowerCenter => Alignment.LowerCenter,
        Alignments.LowerLeft => Alignment.LowerLeft,
        Alignments.LowerRight => Alignment.LowerRight,
        Alignments.MiddleCenter => Alignment.MiddleCenter,
        Alignments.MiddleLeft => Alignment.MiddleLeft,
        Alignments.MiddleRight => Alignment.MiddleRight,
        Alignments.UpperCenter => Alignment.UpperCenter,
        Alignments.UpperLeft => Alignment.UpperLeft,
        Alignments.UpperRight => Alignment.UpperRight,
        _ => Alignment.LowerRight
    };

    // Chart border settings
    public static bool EnableChartBorder { get; set; }
    public static BorderStyles ChartBorderStyle { get; set; }
    internal static LinePattern chartborderstyle = ChartBorderStyle switch
    {
        BorderStyles.Solid => LinePattern.Solid,
        BorderStyles.Dashed => LinePattern.Dashed,
        BorderStyles.Dotted => LinePattern.Dotted,
        BorderStyles.DenselyDashed => LinePattern.DenselyDashed,
        _ => LinePattern.Solid
    };
    public static int ChartBorderSize { get; set; } = 1;
    public static Color ChartBorderColor { get; set; } = Colors.Black;  // Todo change this to rgb color

    // Color Palette settings
    public static ColorPalettes ColorPalette { get; set; } = ColorPalettes.Normal;

    internal static IPalette? colorPalette = ColorPalette switch
    {
        ColorPalettes.Amber => new ScottPlot.Palettes.Amber(),
        ColorPalettes.Category10 => new ScottPlot.Palettes.Category10(),
        ColorPalettes.Category20 => new ScottPlot.Palettes.Category20(),
        ColorPalettes.Aurora => new ScottPlot.Palettes.Aurora(),
        ColorPalettes.Building => new ScottPlot.Palettes.Building(),
        ColorPalettes.ColorblindFriendly => new ScottPlot.Palettes.ColorblindFriendly(),
        ColorPalettes.ColorblindFriendlyDark => new ScottPlot.Palettes.ColorblindFriendlyDark(),
        ColorPalettes.Dark => new ScottPlot.Palettes.Dark(),
        ColorPalettes.DarkPastel => new ScottPlot.Palettes.DarkPastel(),
        ColorPalettes.Frost => new ScottPlot.Palettes.Frost(),
        ColorPalettes.LightOcean => new ScottPlot.Palettes.LightOcean(),
        ColorPalettes.LightSpectrum => new ScottPlot.Palettes.LightSpectrum(),
        ColorPalettes.Microcharts => new ScottPlot.Palettes.Microcharts(),
        ColorPalettes.Nero => new ScottPlot.Palettes.Nero(),
        ColorPalettes.Nord => new ScottPlot.Palettes.Nord(),
        ColorPalettes.Normal => new ScottPlot.Palettes.Normal(),
        ColorPalettes.OneHalf => new ScottPlot.Palettes.OneHalf(),
        ColorPalettes.OneHalfDark => new ScottPlot.Palettes.OneHalfDark(),
        ColorPalettes.PastelWheel => new ScottPlot.Palettes.PastelWheel(),
        ColorPalettes.Penumbra => new ScottPlot.Palettes.Penumbra(),
        ColorPalettes.PolarNight => new ScottPlot.Palettes.PolarNight(),
        ColorPalettes.Redness => new ScottPlot.Palettes.Redness(),
        ColorPalettes.SnowStorm => new ScottPlot.Palettes.SnowStorm(),
        ColorPalettes.SummerSplash => new ScottPlot.Palettes.SummerSplash(),
        ColorPalettes.Tsitsulin => new ScottPlot.Palettes.Tsitsulin(),
        _ => new ScottPlot.Palettes.Category10()
    };

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