using System.Management.Automation;

namespace AsBuiltReportChart.PowerShell
{
    [Cmdlet(VerbsCommon.New, "BarChart")]
    public class NewBarChartCommand : Cmdlet
    {
        // Declare the parameters for the cmdlet.
        [Parameter(Mandatory = true)]
        public double[]? Values { get; set; }
        [Parameter(Mandatory = true)]
        public string[]? Labels { get; set; }

        [Parameter(Mandatory = true)]
        public string? Title { get; set; }

        [Parameter(Mandatory = true)]
        public Formats Format { get; set; }
        protected override void ProcessRecord()
        {
            if (Values != null && Labels != null)
            {
                Chart.Title = Title;
                Chart.Format = Format;
                Bar myBar = new();
                myBar.Chart(Values, Labels);
            }
            else
            {
                WriteObject("Please provide both Values and Labels parameters.");
            }
        }
    }
}