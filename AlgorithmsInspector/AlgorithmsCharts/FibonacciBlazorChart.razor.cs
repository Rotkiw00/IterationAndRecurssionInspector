using PSC.Blazor.Components.Chartjs;
using PSC.Blazor.Components.Chartjs.Models.Line;

namespace AlgorithmsInspector.AlgorithmsCharts
{
    public partial class FibonacciBlazorChart
    {
        private LineChartConfig _config1;
        private Chart _chart1;

        public List<string> LineChartLabels =
        [
            "n = 0",
            "n = 5",
            "n = 10",
            "n = 15",
            "n = 20",
            "n = 25",
            "n = 30",
            "n = 35",
            "n = 40",
            "n = 45",
            "n = 50"
        ];
        public List<decimal?> LineDataIteration =
        [
            0m,
            0.0000004m,
            0.0000003m,
            0.0000002m,
            0.0000002m,
            0.0000003m,
            0.0000002m,
            0.0000002m,
            0.0000004m,
            0.0000003m,
            0.0000003m
        ];
        public List<decimal?> LineDataRecursion =
        [

            0m,
            0.0000001m,
            0.0000004m,
            0.0000027m,
            0.0002976m,
            0.000285m,
            0.031m,
            0.034m,
            0.376m,
            4.17m,
            46.23m
        ];
    }
}
