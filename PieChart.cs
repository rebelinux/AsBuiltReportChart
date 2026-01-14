using ScottPlot;
using AsBuiltReportChart.Enums;
namespace AsBuiltReportChart;

public class Pie : Chart
{
    public Pie() { }
    public void Chart(double[] values, string[] labels, string filename = "output", int width = 400, int height = 300)
    {
        if (values.Length == labels.Length)
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

            var pie = myPlot.Add.Pie(values);
            pie.ExplodeFraction = _areaExplodeFraction;
            pie.SliceLabelDistance = _labelDistance;

            // set each slice value to its label
            for (var i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].LabelText = values[i].ToString();
                pie.Slices[i].LabelFontSize = LabelFontSize;
                pie.Slices[i].LabelFontColor = GetDrawingColor(LabelFontColor);
                pie.Slices[i].LabelBold = LabelBold;
                pie.Slices[i].LabelFontName = FontName;

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
                    _ => Alignment.LowerRight
                };
            }

            if (EnableChartBorder)
            {
                myPlot.FigureBorder = new()
                {
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


