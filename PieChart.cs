using HarfBuzzSharp;
using ScottPlot;
namespace AsBuiltReportChart;

public class Chart
{
    public static bool? EnableLegend { get; set; }
    public static string? Title { get; set; }

    public static void PieChart(double[] values, string[] labels, string filename = "output", int width = 400, int height = 300, string format = "png")
    {
        if (values.Count() == labels.Count())
        {
            Plot myPlot = new();

            bool checkEnableLegend = EnableLegend ?? false;

            var pie = myPlot.Add.Pie(values);
            pie.ExplodeFraction = .1;
            pie.SliceLabelDistance = 0.5;

            // set each slice value to its label
            for (int i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].LabelText = labels[i];
                pie.Slices[i].LabelFontSize = 20;
                pie.Slices[i].LabelBold = true;
                pie.Slices[i].LabelFontColor = Colors.Magenta;

                if (checkEnableLegend)
                {
                    pie.Slices[i].LegendText = labels[i];
                }
            }

            // hide unnecessary plot components
            myPlot.Axes.Frameless();
            myPlot.HideGrid();

            // set title
            if (Title != null)
            {
                myPlot.Title(Title);
            }

            // set filename
            myPlot.SavePng(filename + ".png", width, height);
        }
        else
        {
            throw new ArgumentException("Error: Values and labels must be equal.");
        }
    }
}


