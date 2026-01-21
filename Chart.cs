using ScottPlot;
using System.Text.RegularExpressions;
using AsBuiltReportChart.Enums;
namespace AsBuiltReportChart;

public partial class Chart
{
    // Save settings (All Charts)
    public static Formats Format { get; set; } = Formats.png;

    // Title setting  (All Charts)
    public static string? Title { get; set; }
    public static bool TitleFontBold { get; set; }
    public static int TitleFontSize { get; set; } = 14;
    public static BasicColors TitleFontColor { get; set; } = BasicColors.Black;

    // Global Font settings  (All Charts)
    public static string FontName { get; set; } = "Arial";

    // Label Font settings  (All Charts)
    public static int LabelFontSize { get; set; } = 14;
    public static BasicColors LabelFontColor { get; set; } = BasicColors.Black;
    public static bool LabelBold { get; set; }

    // Set font for the X and Y axis labels (Bar Chart)
    public static string LabelYAxis { get; set; } = "Count";
    public static string LabelXAxis { get; set; } = "Values";

    // this set the distance of the labels from the chart center (Pie Chart)
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

    // this set the orientation chart area  (Bar Chart)
    public static Orientations AreaOrientation { get; set; } = Orientations.Vertical;

    // this set the distance of the chart area elements  (Pie Chart)
    internal static double _areaExplodeFraction;
    public static double AreaExplodeFraction
    {
        get { return _areaExplodeFraction; }
        set
        {
            if (value is >= 0.0 and <= 0.5)
            {
                _areaExplodeFraction = value;
            }
            else
            {
                throw new ArgumentException("Error: AreaExplodeFraction value range must be from 0.0 to 0.5.");
            }
        }
    }

    // Legend setting (Pie Chart)
    public static bool EnableLegend { get; set; }

    // Legend Font settings (Pie Chart)
    public static int LegendFontSize { get; set; } = 12;
    public static BasicColors LegendFontColor { get; set; } = BasicColors.Black;

    // Legend border settings (Pie Chart)
    public static BorderStyles LegendBorderStyle { get; set; } = BorderStyles.Solid;
    public static int LegendBorderSize { get; set; } = 1;
    public static BasicColors LegendBorderColor { get; set; } = BasicColors.Black; // Todo change this to rgb color
    public static Orientations LegendOrientation { get; set; } = Orientations.Vertical;

    public static Alignments LegendAlignment { get; set; } = Alignments.LowerRight;

    // Chart border settings (All Charts)
    public static bool EnableChartBorder { get; set; }
    public static BorderStyles ChartBorderStyle { get; set; }
    public static int ChartBorderSize { get; set; } = 1;
    public static BasicColors ChartBorderColor { get; set; } = BasicColors.Black;  // Todo change this to rgb color

    // Color Palette settings (All Charts)
    internal static IPalette? colorPalette;
    public static ColorPalettes? ColorPalette
    {
        get => colorPalette switch
        {
            ScottPlot.Palettes.Amber => Enums.ColorPalettes.Amber,
            ScottPlot.Palettes.Category10 => Enums.ColorPalettes.Category10,
            ScottPlot.Palettes.Category20 => Enums.ColorPalettes.Category20,
            ScottPlot.Palettes.Aurora => Enums.ColorPalettes.Aurora,
            ScottPlot.Palettes.Building => Enums.ColorPalettes.Building,
            ScottPlot.Palettes.ColorblindFriendly => Enums.ColorPalettes.ColorblindFriendly,
            // ScottPlot.Palettes.ColorblindFriendlyDark => Enums.ColorPalettes.ColorblindFriendlyDark,
            ScottPlot.Palettes.Dark => Enums.ColorPalettes.Dark,
            ScottPlot.Palettes.DarkPastel => Enums.ColorPalettes.DarkPastel,
            ScottPlot.Palettes.Frost => Enums.ColorPalettes.Frost,
            ScottPlot.Palettes.LightOcean => Enums.ColorPalettes.LightOcean,
            ScottPlot.Palettes.LightSpectrum => Enums.ColorPalettes.LightSpectrum,
            ScottPlot.Palettes.Microcharts => Enums.ColorPalettes.Microcharts,
            ScottPlot.Palettes.Nero => Enums.ColorPalettes.Nero,
            ScottPlot.Palettes.Nord => Enums.ColorPalettes.Nord,
            ScottPlot.Palettes.Normal => Enums.ColorPalettes.Normal,
            ScottPlot.Palettes.OneHalf => Enums.ColorPalettes.OneHalf,
            ScottPlot.Palettes.OneHalfDark => Enums.ColorPalettes.OneHalfDark,
            ScottPlot.Palettes.PastelWheel => Enums.ColorPalettes.PastelWheel,
            ScottPlot.Palettes.Penumbra => Enums.ColorPalettes.Penumbra,
            ScottPlot.Palettes.PolarNight => Enums.ColorPalettes.PolarNight,
            ScottPlot.Palettes.Redness => Enums.ColorPalettes.Redness,
            ScottPlot.Palettes.SnowStorm => Enums.ColorPalettes.SnowStorm,
            ScottPlot.Palettes.SummerSplash => Enums.ColorPalettes.SummerSplash,
            ScottPlot.Palettes.Tsitsulin => Enums.ColorPalettes.Tsitsulin,
            _ => Enums.ColorPalettes.Normal
        };
        set
        {
            colorPalette = value switch
            {
                ColorPalettes.Amber => new ScottPlot.Palettes.Amber(),
                ColorPalettes.Category10 => new ScottPlot.Palettes.Category10(),
                ColorPalettes.Category20 => new ScottPlot.Palettes.Category20(),
                ColorPalettes.Aurora => new ScottPlot.Palettes.Aurora(),
                ColorPalettes.Building => new ScottPlot.Palettes.Building(),
                ColorPalettes.ColorblindFriendly => new ScottPlot.Palettes.ColorblindFriendly(),
                // ColorPalettes.ColorblindFriendlyDark => new ScottPlot.Palettes.ColorblindFriendlyDark(),
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
        }
    }

    // Custom color palette (All Charts)
    internal static string[]? _customColorPalette;
    public static string[] CustomColorPalette
    {
        get => _customColorPalette ?? [];
        set
        {
            if (value is not null or [])
            {
                foreach (var color in value)
                {
                    if (!IsValidHexColor(color))
                    {
                        throw new ArgumentException($"Error: '{color}' is not a valid hex color code.");
                    }
                }
            }
            else
            {
                throw new ArgumentException("Error: CustomColorPalette cannot be null or empty when setting custom colors.");
            }
            _customColorPalette = value;
        }
    }
    public static bool EnableCustomColorPalette { get; set; }

    internal static string? _outputFolderPath;

    public static string OutputFolderPath
    {
        get
        {
            return _outputFolderPath ?? Directory.GetCurrentDirectory();
        }
        set
        {
            if (value is null)
            {
                _outputFolderPath = Directory.GetCurrentDirectory();
            }
            else if (Directory.Exists(value))
            {
                _outputFolderPath = value;
            }
            else
            {
                throw new ArgumentException("Error: Directory Not Found Exception");
            }
        }
    }

    public static bool IsValidHexColor(string hexCode)
    {
        // Regex for #RGB, #RRGGBB, #RGBA, or #RRGGBBAA formats (case-insensitive)
        var regex = MyRegex();
        return regex.IsMatch(hexCode);
    }

    [GeneratedRegex("^#([A-Fa-f0-9]{3,4}|[A-Fa-f0-9]{6}|[A-Fa-f0-9]{8})$")]
    private static partial Regex MyRegex();

    internal static readonly IReadOnlyDictionary<BasicColors, Color> ColorMap = new Dictionary<BasicColors, Color>()
    {
        { BasicColors.Black,  Colors.Black },
        { BasicColors.White,  Colors.White },
        { BasicColors.Red,  Colors.Red },
        { BasicColors.Yellow,  Colors.Yellow },
        { BasicColors.Green,  Colors.Green },
        { BasicColors.Brown,  Colors.Brown },
        { BasicColors.Orange,  Colors.Orange },
        { BasicColors.Pink,  Colors.Pink },
        { BasicColors.Purple,  Colors.Purple },
        { BasicColors.Gray,  Colors.Gray },
        { BasicColors.Blue,  Colors.Blue },
        { BasicColors.DarkBlue,  Colors.DarkBlue },
        { BasicColors.DarkGreen,  Colors.DarkGreen },
    };

    public static Color GetDrawingColor(BasicColors color)
    {
        return ColorMap[color];
    }
    public static string GenerateToken(Byte length)
    {
        var bytes = new byte[length];
        var rnd = new Random();
        rnd.NextBytes(bytes);
        return Convert.ToBase64String(bytes).Replace("=", "").Replace("+", "").Replace("/", "");
    }
}
