using PSC.Blazor.Components.Chartjs;
using PSC.Blazor.Components.Chartjs.Models.Line;

namespace AlgorithmsInspector.AlgorithmsCharts
{
    public partial class QuicksortBlazorChart
    {
        private LineChartConfig _config1;
        private Chart _chart1;

        public List<string> LineChartLabels =
        [
            "n = 5",
            "n = 10",
            "n = 50",
            "n = 100",
            "n = 500",
            "n = 5000",
            "n = 10000",
            "n = 50000",
            "n = 100000",
            "n = 500000",
            "n = 1000000"
        ];
        // PIVOT => SKRAJNY
        public List<decimal?> LineDataIteration_2 =
        [
            0.0000034m,
            0.0000031m,
            0.0000061m,
            0.0000099m,
            0.0001602m,
            0.0009191m,
            0.0018255m,
            0.0106773m,
            0.021104m,
            0.1041441m,
            0.2111618m
        ];
        public List<decimal?> LineDataRecursion_2 =
        [
            0.0000003m,
            0.0000008m,
            0.0000111m,
            0.0001438m,
            0.0009397m,
            0.0710363m,
            0.2330122m
        ];
    }
}