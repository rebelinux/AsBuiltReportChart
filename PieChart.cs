using HarfBuzzSharp;
using ScottPlot;
namespace AsBuiltReportChart;

public class Pie : Chart
{
    public static void Chart(double[] values, string[] labels, string filename = "output", int width = 400, int height = 300, string format = "png")
    {
        if (values.Length == labels.Length)
        {
            Plot myPlot = new();

            // myPlot.Add.Palette = new ScottPlot.Palettes.DarkPastel();
            string[] customColors = { "#ddf6ed", "#c3e2d7", "#aacec2", "#90bbad", "#77a898", "#5e9584", "#458370", "#2a715d", "#005f4b" };
            myPlot.Add.Palette = new ScottPlot.Palettes.Custom(customColors);

            var pie = myPlot.Add.Pie(values);
            // pie.ExplodeFraction = .1;
            pie.SliceLabelDistance = _labelDistance;

            // set each slice value to its label
            for (int i = 0; i < pie.Slices.Count; i++)
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
                    BorderStyle.Solid => ScottPlot.LinePattern.Solid,
                    BorderStyle.Dashed => ScottPlot.LinePattern.Dashed,
                    BorderStyle.Dotted => ScottPlot.LinePattern.Dotted,
                    BorderStyle.DenselyDashed => ScottPlot.LinePattern.DenselyDashed,
                    _ => ScottPlot.LinePattern.Solid,
                };

                myPlot.Legend.Orientation = legendOriantation = LegendOriantation switch
                {
                    Orientation.Horizontal => ScottPlot.Orientation.Horizontal,
                    Orientation.Vertical => ScottPlot.Orientation.Vertical,
                    _ => ScottPlot.Orientation.Vertical,
                };

                myPlot.Legend.Alignment = legendAlignment = LegendAlignment switch
                {
                    Alignment.LowerCenter => ScottPlot.Alignment.LowerCenter,
                    Alignment.LowerLeft => ScottPlot.Alignment.LowerLeft,
                    Alignment.LowerRight => ScottPlot.Alignment.LowerRight,
                    Alignment.MiddleCenter => ScottPlot.Alignment.MiddleCenter,
                    Alignment.MiddleLeft => ScottPlot.Alignment.MiddleLeft,
                    Alignment.MiddleRight => ScottPlot.Alignment.MiddleRight,
                    Alignment.UpperCenter => ScottPlot.Alignment.UpperCenter,
                    Alignment.UpperLeft => ScottPlot.Alignment.UpperLeft,
                    Alignment.UpperRight => ScottPlot.Alignment.UpperRight,
                    _ => ScottPlot.Alignment.LowerRight,
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
                        BorderStyle.Solid => ScottPlot.LinePattern.Solid,
                        BorderStyle.Dashed => ScottPlot.LinePattern.Dashed,
                        BorderStyle.Dotted => ScottPlot.LinePattern.Dotted,
                        BorderStyle.DenselyDashed => ScottPlot.LinePattern.DenselyDashed,
                        _ => ScottPlot.LinePattern.Solid,
                    },
                };
            }

            // Set title properties
            if (Title != null)
            {
                myPlot.Title(Title);
                myPlot.Axes.Title.Label.FontSize = TitleFontSize;
                myPlot.Axes.Title.Label.ForeColor = TitleFontColor ;
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


