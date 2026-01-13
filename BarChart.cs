using ScottPlot;
using AsBuiltReportChart.Enums;
namespace AsBuiltReportChart;

public class Bar : Chart
{
    static Bar() { }
    public void Chart(double[] values, string[] labels, string filename = "output", int width = 400, int height = 300)
    {
        if (values.Length == labels.Length)
        {
            Plot myPlot = new();

            if (EnableCustomColorPalette)
            {
                if (_customColorPalette is not null and not [] && _customColorPalette.Length > 0)
                {
                    myPlot.Add.Palette = new ScottPlot.Palettes.Custom(_customColorPalette);
                }
                else
                {
                    throw new Exception("CustomColorPalette is empty. Please provide valid color values.");
                }
            }
            else
            {
                // Set ScottPlot native color palette
                if (colorPalette is not null)
                {
                    myPlot.Add.Palette = colorPalette;
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

                myPlot.Legend.OutlinePattern = LegendBorderStyle switch
                {
                    BorderStyles.Solid => LinePattern.Solid,
                    BorderStyles.Dashed => LinePattern.Dashed,
                    BorderStyles.Dotted => LinePattern.Dotted,
                    BorderStyles.DenselyDashed => LinePattern.DenselyDashed,
                    _ => LinePattern.Solid
                };

                myPlot.Legend.Orientation = LegendOrientation switch
                {
                    Orientations.Horizontal => Orientation.Horizontal,
                    _ => Orientation.Vertical
                };

                myPlot.Legend.Alignment = LegendAlignment switch
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
                    Pattern = ChartBorderStyle switch
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
            switch (Format)
            {
                case Formats.png:
                    myPlot.SavePng($"{filename}.png", width, height);
                    break;
                case Formats.jpg:
                    myPlot.SaveJpeg($"{filename}.jpg", width, height);
                    break;
                case Formats.jpeg:
                    myPlot.SaveJpeg($"{filename}.jpg", width, height);
                    break;
                case Formats.bmp:
                    myPlot.SaveBmp($"{filename}.bmp", width, height);
                    break;
                case Formats.svg:
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


