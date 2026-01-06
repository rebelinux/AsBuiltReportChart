using ScottPlot;
using AsBuiltReportChart.Enums;
namespace AsBuiltReportChart;

public class Pie : Chart
{
    public static void Chart(double[] values, string[] labels, string filename = "output", int width = 400, int height = 300, string format = "png")
    {
        if (values.Length == labels.Length)
        {
            Plot myPlot = new();

            if (CustomColorPalette is not null and { Length: > 0 })
            {
                // Set ScottPlot custom color palette
                myPlot.Add.Palette = new ScottPlot.Palettes.Custom(CustomColorPalette);
            }
            else
            {
                // Set ScottPlot native color palette
                myPlot.Add.Palette = colorPalette = ColorPalette switch
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
            }

            var pie = myPlot.Add.Pie(values);
            pie.ExplodeFraction = _areaExplodeFraction;
            pie.SliceLabelDistance = _labelDistance;

            // set each slice value to its label
            for (var i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].LabelText = values[i].ToString();
                pie.Slices[i].LabelFontSize = LabelFontSize;
                pie.Slices[i].LabelFontColor = LabelFontColor;
                pie.Slices[i].LabelBold = LabelBold;

                if (EnableLegend)
                {
                    pie.Slices[i].LegendText = labels[i];
                }
            }

            // hide unnecessary plot components
            myPlot.Axes.Frameless();
            myPlot.HideGrid();

            if (EnableLegend)
            {
                // Legend box Style Properties
                myPlot.Legend.OutlineColor = LegendBorderColor;
                myPlot.Legend.OutlineWidth = LegendBorderSize;

                myPlot.Legend.OutlinePattern = legendborderstyle = LegendBorderStyle switch
                {
                    BorderStyles.Solid => LinePattern.Solid,
                    BorderStyles.Dashed => LinePattern.Dashed,
                    BorderStyles.Dotted => LinePattern.Dotted,
                    BorderStyles.DenselyDashed => LinePattern.DenselyDashed,
                    _ => LinePattern.Solid
                };

                myPlot.Legend.Orientation = legendOriantation = LegendOrientation switch
                {
                    Orientations.Horizontal => Orientation.Horizontal,
                    _ => Orientation.Vertical
                };

                myPlot.Legend.Alignment = legendAlignment = LegendAlignment switch
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
            }

            if (EnableChartBorder)
            {
                myPlot.FigureBorder = new()
                {
                    Color = ChartBorderColor,
                    Width = ChartBorderSize,
                    Pattern = chartborderstyle = ChartBorderStyle switch
                    {
                        BorderStyles.Solid => LinePattern.Solid,
                        BorderStyles.Dashed => LinePattern.Dashed,
                        BorderStyles.Dotted => LinePattern.Dotted,
                        BorderStyles.DenselyDashed => LinePattern.DenselyDashed,
                        _ => LinePattern.Solid
                    }
                };
            }

            // Set title properties
            if (Title != null)
            {
                myPlot.Title(Title);
                myPlot.Axes.Title.Label.FontSize = TitleFontSize;
                myPlot.Axes.Title.Label.ForeColor = TitleFontColor;
                myPlot.Axes.Title.Label.Bold = TitleFontBold;
            }

            // Set filename
            myPlot.SavePng(filename + "." + format, width, height);
        }
        else
        {
            throw new ArgumentException("Error: Values and labels must be equal.");
        }
    }
}


