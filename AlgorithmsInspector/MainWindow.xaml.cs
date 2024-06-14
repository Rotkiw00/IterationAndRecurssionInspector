using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using AlgorithmsLibrary;
using Microsoft.Extensions.DependencyInjection;

namespace AlgorithmsInspector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }

        #region FIBONACCI
        private async void CountFibonacciButton_Click(object sender, RoutedEventArgs e)
        {
            #region Clean before calculating
            ResetTextControlsFibonacci();
            #endregion

            #region Variables
            long sumOfFibonacciSeries = 0;
            List<long> fibonacciSequence = [];
            long resultIterationForN = 0;

            Stopwatch stopwatchFibonacciIteration = new();
            double iterationTime = 0;
            Stopwatch stopwatchFibonacciRecursive = new();
            double recursiveTime = 0;
            #endregion

            #region Main logic
            bool isParseableFibonacciInputParameter = long.TryParse(inputParametrFibonacciTxt.Text, out long inputFibonacciParameter);
            if (!isParseableFibonacciInputParameter)
            {
                LogParsingError();
            }
            else
            {
                if (inputFibonacciParameter < 0 || inputFibonacciParameter > 50)
                {
                    LogWarning("Parametr wejściowy powinien może być tylko z zakresu:\n(0; 100), bo powyżej to już będzie bardzo długo.");
                }
                else
                {
                    string msg1 = $"Wartość dla {inputFibonacciParameter}-tego wyrazu ciągu:";
                    string msg2 = $"Suma pierwszych {inputFibonacciParameter} elementów ciągu:";

                    labelFibonacci1.Text = msg1;
                    labelFibonacci3.Text = msg2;

                    await Task.Run(() =>
                    {
                        stopwatchFibonacciIteration.Start();
                        resultIterationForN = FibonacciSolver.Iteration(inputFibonacciParameter);
                        stopwatchFibonacciIteration.Stop();

                        stopwatchFibonacciRecursive.Start();
                        _ = FibonacciSolver.Recursion(inputFibonacciParameter);
                        stopwatchFibonacciRecursive.Stop();
                    });
                    iterationTime = stopwatchFibonacciIteration.Elapsed.TotalMilliseconds / 1_000;
                    recursiveTime = stopwatchFibonacciRecursive.Elapsed.TotalMilliseconds / 1_000;

                    outputResultValueFibonacciTxt.Text = resultIterationForN.ToString();

                    (sumOfFibonacciSeries, fibonacciSequence) = FibonacciSolver.GetSumAndFibonacciSequence(inputFibonacciParameter);
                    outputFibonacciSequenceTxt.Text = string.Join(", ", fibonacciSequence);
                    outputResultSumFibonacciTxt.Text = sumOfFibonacciSeries.ToString();

                    timeMeasuredIterationFibonacciTxt.Text = iterationTime.ToString("0.###############") + " s";
                    timeMeasuredRecurssionFibonacciTxt.Text = recursiveTime.ToString("0.###############") + " s";
                }
            }
            ResetInputText(inputParametrFibonacciTxt);
            #endregion
        }

        private void ResetTextControlsFibonacci()
        {
            labelFibonacci1.Text = "Wartość dla n-tego wyrazu ciągu:";
            labelFibonacci3.Text = "Suma pierwszych n elementów ciągu:";

            outputFibonacciSequenceTxt.Text = string.Empty;
            outputResultValueFibonacciTxt.Text = string.Empty;
            outputResultSumFibonacciTxt.Text = string.Empty;
            timeMeasuredIterationFibonacciTxt.Text = string.Empty;
            timeMeasuredRecurssionFibonacciTxt.Text = string.Empty;
        }

        private void ClearFibonacciOutputsButton_Click(object sender, RoutedEventArgs e)
        {
            ResetTextControlsFibonacci();
        }
        #endregion

        #region QUICKSORT
        private async void CountQuicksortButton_Click(object sender, RoutedEventArgs e)
        {
            #region Variables
            int selectedIndexOfSortedTable = 0;

            Stopwatch stopwatchQuicksortIteration = new();
            double iterationQuicksortTime = 0;
            Stopwatch stopwatchQuicksortRecursive = new();
            double recursiveQuicksortTime = 0;
            #endregion

            #region Main logic            
            bool isParseableLengthOfTable = int.TryParse(inputTabLenParametrQcksrtTxt.Text, out int tableLength);
            if (!isParseableLengthOfTable)
            {
                LogParsingError();
            }
            else
            {
                if (tableLength < 0 || tableLength > 1_000_000)
                {
                    LogWarning("Zalecana długość tablicy mieści się w zakresie\nod 0 do 1 000 000");
                }
                else
                {
                    int[] sortingData = Utility.GetSortingData(tableLength);
                    LogInformation($"Wygenerowano losowo dane dla tablicy o długości: {tableLength}.");

                    selectedIndexOfSortedTable = tableLength - 1;

                    if (tableLength <= 10_000)
                    {
                        tableToBeSortedQuicksortTxt.Text = string.Join(", ", sortingData);

                        await Task.Run(() =>
                        {
                            stopwatchQuicksortIteration.Start();
                            QuicksortSolver.Iteration(sortingData, 0, selectedIndexOfSortedTable);
                            stopwatchQuicksortIteration.Stop();

                            stopwatchQuicksortRecursive.Start();
                            QuicksortSolver.Recursion(sortingData, 0, selectedIndexOfSortedTable);
                            stopwatchQuicksortRecursive.Stop();
                        });

                        sortedTableQuicksortTxt.Text = string.Join(", ", sortingData);
                        iterationQuicksortTime = stopwatchQuicksortIteration.Elapsed.TotalMilliseconds / 1_000;
                        recursiveQuicksortTime = stopwatchQuicksortRecursive.Elapsed.TotalMilliseconds / 1_000;
                        timeMeasuredIterationQuicksortTxt.Text = iterationQuicksortTime.ToString("0.###############") + " s";
                        timeMeasuredRecurssionQuicksortTxt.Text = recursiveQuicksortTime.ToString("0.###############") + " s";
                    }
                    else
                    {
                        await Task.Run(() =>
                        {
                            stopwatchQuicksortIteration.Start();
                            QuicksortSolver.Iteration(sortingData, 0, selectedIndexOfSortedTable);
                            stopwatchQuicksortIteration.Stop();
                        });

                        sortedTableQuicksortTxt.Text = "Za duża tablica.";
                        iterationQuicksortTime = stopwatchQuicksortIteration.Elapsed.TotalMilliseconds / 1_000;
                        timeMeasuredIterationQuicksortTxt.Text = iterationQuicksortTime.ToString("0.###############") + " s";
                        timeMeasuredRecurssionQuicksortTxt.Text = "Nie można przeprowadzić pomiaru";
                    }

                }
                ResetInputText(inputTabLenParametrQcksrtTxt);
            }
            #endregion
        }

        private void ClearQuicksortOutputsButton_Click(object sender, RoutedEventArgs e)
        {
            inputTabLenParametrQcksrtTxt.Text = "";

            timeMeasuredIterationQuicksortTxt.Text = string.Empty;
            timeMeasuredRecurssionQuicksortTxt.Text = string.Empty;
            tableToBeSortedQuicksortTxt.Text = string.Empty;
            sortedTableQuicksortTxt.Text = string.Empty;
        }
        #endregion

        #region TOWER OF HANOI
        private async void SolveTowerOfHanoiButton_Click(object sender, RoutedEventArgs e)
        {
            #region Variables
            List<string> hanoiMoves = [];
            string fromA = "A";
            string toC = "C";
            string viaB = "B";

            Stopwatch stopwatchHanoiIteration = new();
            double iterationHanoiTime = 0;
            Stopwatch stopwatchHanoiRecursive = new();
            double recursiveHanoiTime = 0;

            TowerOfHanoiSolver.Stack src, dest, aux;
            #endregion

            bool isParseableHanoiInputParameter = int.TryParse(inputParameterHanoiTxt.Text, out int disksNumber);
            if (!isParseableHanoiInputParameter)
            {
                LogParsingError();
            }
            else
            {
                if (disksNumber <= 0 || disksNumber > 64)
                {
                    LogWarning("Błędny zakres. Ilość dysków powinna być między 0 a 64.\nPrzy czym powyżej 40 program może mieć problem z przetworzeniem.");
                }
                else
                {
                    src = TowerOfHanoiSolver.createStack(disksNumber);
                    dest = TowerOfHanoiSolver.createStack(disksNumber);
                    aux = TowerOfHanoiSolver.createStack(disksNumber);

                    await Task.Run(() =>
                    {
                        stopwatchHanoiRecursive.Start();
                        TowerOfHanoiSolver.Recursion(disksNumber, fromA, toC, viaB, ref hanoiMoves);
                        stopwatchHanoiRecursive.Stop();

                        stopwatchHanoiIteration.Start();
                        TowerOfHanoiSolver.tohIterative(disksNumber, src, dest, aux);
                        stopwatchHanoiIteration.Stop();
                    });

                    recursiveHanoiTime = stopwatchHanoiRecursive.Elapsed.TotalMilliseconds / 1_000;
                    iterationHanoiTime = stopwatchHanoiIteration.Elapsed.TotalMilliseconds / 1_000;

                    if (disksNumber < 15)
                    {
                        outputStepsSequenceHanoiTxt.Text = string.Join(",\n", hanoiMoves);
                    }
                    else
                    {
                        outputStepsSequenceHanoiTxt.Text = "Za dużo kroków do wyświetlenia.";
                    }

                    numberOfMovesHanoiTxt.Text = hanoiMoves.Count.ToString();

                    timeMeasuredRecurssionHanoiTxt.Text = recursiveHanoiTime.ToString("0.###############") + " s";
                    timeMeasuredIterationHanoiTxt.Text = iterationHanoiTime.ToString("0.###############") + " s";

                }
                ResetInputText(inputParameterHanoiTxt);
            }
        }
        private void ClearHanoiOutputsButton_Click(object sender, RoutedEventArgs e)
        {
            outputStepsSequenceHanoiTxt.Text = string.Empty;
            numberOfMovesHanoiTxt.Text = string.Empty;
            timeMeasuredRecurssionHanoiTxt.Text = string.Empty;
            timeMeasuredIterationHanoiTxt.Text = string.Empty;
        }
        #endregion

        #region  -- UTILS METHODS --
        private static void LogWarning(string message = "Ta operacja nie może zostać wykonana. Popraw parametry.")
        {
            MessageBox.Show(message, "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private static void LogParsingError(string message = "Nie można zamienić na wartość liczbową.")
        {
            MessageBox.Show(message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private static void LogInformation(string message)
        {
            MessageBox.Show(message, "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ResetInputText(TextBox controlTextBox)
        {
            controlTextBox.Text = string.Empty;
        }

        #endregion
    }
}