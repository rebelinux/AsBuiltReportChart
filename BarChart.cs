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
                    myPlot.Add.Palette = colorPalette;
                }
            }

            myPlot.Axes.Bottom.Label.Text = LabelXAxis;
            myPlot.Axes.Bottom.Label.FontSize = AxisLabelFontSize;
            myPlot.Axes.Bottom.Label.ForeColor = AxisLabelFontColor;
            myPlot.Axes.Bottom.Label.Bold = AxisLabelFontBold;
            myPlot.Axes.Bottom.Label.FontName = FontName;

            myPlot.Axes.Left.Label.Text = LabelYAxis;
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
            for (var i = 0; i < bar.Bars.Count; i++)
            {
                // set bar value as label
                bar.Bars[i].Label = values[i].ToString();
                // set bar orientation
                bar.Bars[i].Orientation = _areaOrientation;
                // set ticks
                tickGen.AddMajor(i, labels[i]);
            }
            myPlot.Axes.Bottom.TickGenerator = tickGen;


            // hide unnecessary plot components
            myPlot.HideGrid();
            myPlot.Axes.Top.IsVisible = false;
            myPlot.Axes.Right.IsVisible = false;

            // tell the plot to autoscale with no padding beneath the bars
            myPlot.Axes.Margins(bottom: 0);

            if (EnableLegend)
            {
                // Show legend
                myPlot.ShowLegend();

                myPlot.Legend.FontName = FontName;
                myPlot.Legend.FontSize = LegendFontSize;
                myPlot.Legend.FontColor = LegendFontColor;

                // Legend box Style Properties
                myPlot.Legend.OutlineColor = LegendBorderColor;
                myPlot.Legend.OutlineWidth = LegendBorderSize;

                myPlot.Legend.OutlinePattern = legendborderstyle;

                myPlot.Legend.Orientation = legendOrientation;

                myPlot.Legend.Alignment = legendAlignment;
            }

            if (EnableChartBorder)
            {
                myPlot.FigureBorder = new()
                {
                    Color = ChartBorderColor,
                    Width = ChartBorderSize,
                    Pattern = chartborderstyle
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


