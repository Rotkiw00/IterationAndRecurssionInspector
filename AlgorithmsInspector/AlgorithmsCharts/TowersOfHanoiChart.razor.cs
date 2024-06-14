using PSC.Blazor.Components.Chartjs;
using PSC.Blazor.Components.Chartjs.Models.Line;

namespace AlgorithmsInspector.AlgorithmsCharts;

public partial class TowersOfHanoiChart
{
    private LineChartConfig _config1;
    private Chart _chart1;

    public List<string> LineChartLabels =
        [
            "n = 3",
            "n = 5",
            "n = 8",
            "n = 10",
            "n = 15",
            "n = 20",
            "n = 25"
        ];

    public List<decimal?> LineDataIteration_2 =
        [
            0.0001133m,
            0.0001253m,
            0.0005044m,
            0.0001747m,
            0.0047718m,
            0.2826553m,
            9.1790667m
        ];
    public List<decimal?> LineDataRecursion_2 =
    [
            0.0000135m,
            0.0000367m,
            0.000115m,
            0.0006298m,
            0.0075043m,
            0.183197m,
            5.7424711m
    ];
}
