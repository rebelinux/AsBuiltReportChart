using ScottPlot;
using AsBuiltReportChart.Enums;
namespace AsBuiltReportChart;

public class StackedBar : Chart
{
    static StackedBar() { }
    public void Chart(List<double[]> values, string[] labels, string[] categoryNames, string filename = "output", int width = 400, int height = 300)
    {
        if (values.Count == labels.Length)
        {
            Plot myPlot = new();

            if (EnableCustomColorPalette)
            {
                if (_customColorPalette is not null and not [] && _customColorPalette.Length > 0)
                {
                    myPlot.Add.Palette = colorPalette = new ScottPlot.Palettes.Custom(_customColorPalette);
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
            myPlot.Axes.Bottom.Label.FontSize = LabelFontSize;
            myPlot.Axes.Bottom.Label.ForeColor = GetDrawingColor(LabelFontColor);
            myPlot.Axes.Bottom.Label.FontName = FontName;

            myPlot.Axes.Bottom.TickLabelStyle.FontSize = LabelFontSize;
            myPlot.Axes.Bottom.TickLabelStyle.ForeColor = GetDrawingColor(LabelFontColor);
            myPlot.Axes.Bottom.TickLabelStyle.FontName = FontName;

            // myPlot.Axes.Bottom.TickLabelStyle.Rotation = -10;


            myPlot.Axes.Left.Label.Text = AreaOrientation switch
            {
                Orientations.Horizontal => LabelXAxis,
                Orientations.Vertical => LabelYAxis,
                _ => ""
            };
            myPlot.Axes.Left.Label.FontSize = LabelFontSize;
            myPlot.Axes.Left.Label.ForeColor = GetDrawingColor(LabelFontColor);
            myPlot.Axes.Left.Label.FontName = FontName;

            myPlot.Axes.Left.TickLabelStyle.FontSize = LabelFontSize;
            myPlot.Axes.Left.TickLabelStyle.ForeColor = GetDrawingColor(LabelFontColor);
            myPlot.Axes.Left.TickLabelStyle.FontName = FontName;

            // create bars
            var bars = new List<ScottPlot.Bar>();
            // assign values and colors to each bar
            for (int x = 0; x < values.Count; x++)
            {
                double nextBarBase = 0;
                for (int i = 0; i < values[x].Length; i++)
                {
                    if (colorPalette is not null)
                    {
                        bars.Add(new ScottPlot.Bar { Position = x, Value = nextBarBase + values[x][i], ValueBase = nextBarBase, FillColor = colorPalette.GetColor(bars.Count) });
                        nextBarBase +=values[x][i];
                    }
                }
            }

            // add bars to plot
            var bar = myPlot.Add.Bars(bars);

            // Customize bars label style, including color
            bar.ValueLabelStyle.FontName = FontName;
            bar.ValueLabelStyle.ForeColor = GetDrawingColor(LabelFontColor);
            bar.ValueLabelStyle.Bold = LabelBold;
            bar.ValueLabelStyle.FontSize = LabelFontSize;

            // set each slice value to its label
            ScottPlot.TickGenerators.NumericManual tickGen = new();

            // assign labels to each bar
            // if (AreaOrientation == Orientations.Vertical)
            // {
            //     // myPlot.Axes.Bottom.TickGenerator = tickGen;
            //     for (var i = 0; i < bar.Bars.Count; i++)
            //     {
            //         // set bar value as label
            //         bar.Bars[i].Label = values[i].ToString();
            //         // set ticks
            //         // tickGen.AddMajor(i, labels[i]);
            //         if (colorPalette is not null && EnableLegend)
            //         {
            //             myPlot.Legend.ManualItems.Add(new LegendItem()
            //             {
            //                 LabelText = labels[i],
            //                 FillColor = colorPalette.GetColor(i)
            //             });
            //         }
            //     }
            // }
            // else
            // {
            //     double[] positions = new double[bar.Bars.Count];
            //     for (var i = 0; i < bar.Bars.Count; i++)
            //     {
            //         // set bar value as label
            //         bar.Bars[i].Label = values[i].ToString();
            //         positions[i] = i;
            //     }
            //     // set ticks for horizontal orientation
            //     myPlot.Axes.Left.SetTicks(positions, labels);
            // }

            bar.Horizontal = AreaOrientation switch
            {
                Orientations.Horizontal => true,
                _ => false
            };


            // hide unnecessary plot components
            myPlot.HideGrid();
            myPlot.Axes.Top.IsVisible = false;
            myPlot.Axes.Right.IsVisible = false;

            if (AreaOrientation == Orientations.Vertical && EnableLegend)
            {
                myPlot.ShowLegend();

                // Legend Font Properties
                myPlot.Legend.FontName = FontName;
                myPlot.Legend.FontSize = LegendFontSize;
                myPlot.Legend.FontColor = GetDrawingColor(LegendFontColor);

                // Legend box Style Properties
                myPlot.Legend.OutlineColor = GetDrawingColor(LegendBorderColor);
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
                    _ => Alignment.UpperRight
                };
            }

            if (EnableChartBorder)
            {
                myPlot.FigureBorder = new()
                {
                    // Set chart border properties
                    Color = GetDrawingColor(ChartBorderColor),
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
                myPlot.Axes.Title.Label.ForeColor = GetDrawingColor(TitleFontColor);
                myPlot.Axes.Title.Label.Bold = TitleFontBold;
                myPlot.Axes.Title.Label.FontName = FontName;
            }

            // Set margins settings
            myPlot.Axes.Margins(left: 0.1, right: 0.1, bottom: 0.1, top: 0.2);

            // Set filepath

            string Filepath = _outputFolderPath ?? Directory.GetCurrentDirectory();

            // Set filename
            switch (Format)
            {
                case Formats.png:
                    myPlot.SavePng(Path.Combine(Filepath, $"{filename}.png"), width, height);
                    break;
                case Formats.jpg:
                    myPlot.SaveJpeg(Path.Combine(Filepath, $"{filename}.jpeg"), width, height);
                    break;
                case Formats.jpeg:
                    myPlot.SaveJpeg(Path.Combine(Filepath, $"{filename}.jpg"), width, height);
                    break;
                case Formats.bmp:
                    myPlot.SaveBmp(Path.Combine(Filepath, $"{filename}.bmp"), width, height);
                    break;
                case Formats.svg:
                    myPlot.SaveSvg(Path.Combine(Filepath, $"{filename}.svg"), width, height);
                    break;
                default:
                    myPlot.SavePng(Path.Combine(Filepath, $"{filename}.png"), width, height);
                    break;
            }
        }
        else
        {
            throw new ArgumentException("Error: Values and labels must be equal.");
        }
    }
}


