using ScottPlot;
using AsBuiltReportChart.Enums;
namespace AsBuiltReportChart;

public class Bar : Chart
{
    public static void Chart(double[] values, string[] labels, string filename = "output", int width = 400, int height = 300)
    {
        if (values.Length == labels.Length)
        {
            Plot myPlot = new();

            if (CustomColorPalette is not null and { Length: > 0 })
            {
                // Set ScottPlot custom color palette
                myPlot.Add.Palette = colorPalette = new ScottPlot.Palettes.Custom(CustomColorPalette);
            }
            else
            {
                // Set ScottPlot native color palette if not null
                if (colorPalette is not null)
                {
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
            }

            // Set X and Y axis label settings
            myPlot.Axes.Bottom.Label.Text = AreaOrientation switch
            {
                Orientations.Horizontal => LabelYAxis,
                Orientations.Vertical => LabelXAxis,
                _ => ""
            };
            myPlot.Axes.Bottom.Label.FontSize = AxisLabelFontSize;
            myPlot.Axes.Bottom.Label.ForeColor = AxisLabelFontColor;
            myPlot.Axes.Bottom.Label.Bold = AxisLabelFontBold;
            myPlot.Axes.Bottom.Label.FontName = FontName;

            myPlot.Axes.Left.Label.Text = AreaOrientation switch
            {
                Orientations.Horizontal => LabelXAxis,
                Orientations.Vertical => LabelYAxis,
                _ => ""
            };
            myPlot.Axes.Left.Label.FontSize = AxisLabelFontSize;
            myPlot.Axes.Left.Label.ForeColor = AxisLabelFontColor;
            myPlot.Axes.Left.Label.Bold = AxisLabelFontBold;
            myPlot.Axes.Left.Label.FontName = FontName;

            // create bars
            var bars = new List<ScottPlot.Bar>();
            // assign values and colors to each bar
            double positionIndex = 0;
            foreach (var item in values)
            {
                if (colorPalette is not null)
                {
                    bars.Add(new ScottPlot.Bar { Position = positionIndex++, Value = item, ValueBase = 0, FillColor = colorPalette.GetColor(bars.Count) });
                }
            }

            // add bars to plot
            var bar = myPlot.Add.Bars(bars);

            // set each slice value to its label
            ScottPlot.TickGenerators.NumericManual tickGen = new();

            // assign labels to each bar
            if (AreaOrientation == Orientations.Vertical)
            {
                myPlot.Axes.Bottom.TickGenerator = tickGen;
                for (var i = 0; i < bar.Bars.Count; i++)
                {
                    // set bar value as label
                    bar.Bars[i].Label = values[i].ToString();
                    // set ticks
                    tickGen.AddMajor(i, labels[i]);
                }
            }
            else
            {
                double[] positions = new double[bar.Bars.Count];
                for (var i = 0; i < bar.Bars.Count; i++)
                {
                    // set bar value as label
                    bar.Bars[i].Label = values[i].ToString();
                    positions[i] = i;
                }
                // set ticks for horizontal orientation
                myPlot.Axes.Left.SetTicks(positions, labels);
            }

            bar.Horizontal = AreaOrientation switch
            {
                Orientations.Horizontal => true,
                _ => false
            };


            // hide unnecessary plot components
            myPlot.HideGrid();
            myPlot.Axes.Top.IsVisible = false;
            myPlot.Axes.Right.IsVisible = false;

            if (EnableLegend)
            {
                // Legend Font Properties
                myPlot.Legend.FontName = FontName;
                myPlot.Legend.FontSize = LegendFontSize;
                myPlot.Legend.FontColor = LegendFontColor;

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

                myPlot.Legend.Orientation = legendOrientation = LegendOrientation switch
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
                    // Set chart border properties
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
                myPlot.Axes.Title.Label.FontName = FontName;
            }

            // Set filename
            switch (_format.ToLower())
            {
                case "png":
                    myPlot.SavePng($"{filename}.png", width, height);
                    break;
                case "jpg":
                case "jpeg":
                    myPlot.SaveJpeg($"{filename}.jpg", width, height);
                    break;
                case "bmp":
                    myPlot.SaveBmp($"{filename}.bmp", width, height);
                    break;
                case "svg":
                    myPlot.SaveSvg($"{filename}.svg", width, height);
                    break;
                default:
                    myPlot.SavePng($"{filename}.png", width, height);
                    break;
            }
        }
        else
        {
            throw new ArgumentException("Error: Values and labels must be equal.");
        }
    }
}


