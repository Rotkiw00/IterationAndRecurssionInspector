using System.Diagnostics;
using System.Windows;
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
            long resultIterationForN = 0;

            Stopwatch stopwatchIteration = new();
            double iterationTime = 0;
            Stopwatch stopwatchRecursive = new();
            double recursiveTime = 0;
            #endregion

            #region Main logic
            bool isParseableFibonacciInputParameter = long.TryParse(inputParametrFibonacciTxt.Text, out long inputFibonacciParameter);
            if (!isParseableFibonacciInputParameter)
            {
                MessageBox.Show("Nie można zamienić na wartość liczbową.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (inputFibonacciParameter < 0 || inputFibonacciParameter > 1_00)
                {
                    MessageBox.Show("Parametr wejściowy powinien może być tylko z zakresu:\n(0; 100), bo powyżej to już będzie bardzo długo.", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string msg1 = $"Wartość dla {inputFibonacciParameter}-tego wyrazu ciągu:";
                    string msg2 = $"Suma ciągu Fibonacciego od 1 do {inputFibonacciParameter}:";

                    labelFibonacci1.Text = msg1;
                    labelFibonacci2.Text = msg2;

                    await Task.Run(() =>
                    {
                        stopwatchIteration.Start();
                        resultIterationForN = FibonacciSolver.Iteration(inputFibonacciParameter);
                        stopwatchIteration.Stop();

                        stopwatchRecursive.Start();
                        _ = FibonacciSolver.Recursion(inputFibonacciParameter);
                        stopwatchRecursive.Stop();
                    });
                    iterationTime = stopwatchIteration.Elapsed.TotalMilliseconds / 1_000;
                    recursiveTime = stopwatchRecursive.Elapsed.TotalMilliseconds / 1_000;

                    outputResultValueFibonacciTxt.Text = resultIterationForN.ToString();

                    sumOfFibonacciSeries = FibonacciSolver.SumOfFibonacciSequence(inputFibonacciParameter);
                    outputResultSumFibonacciTxt.Text = sumOfFibonacciSeries.ToString();

                    timeMeasuredIterationFibonacciTxt.Text = iterationTime.ToString("0.###############") + " s";
                    timeMeasuredRecurssionFibonacciTxt.Text = recursiveTime.ToString("0.###############") + " s";
                }
            }
            ResetInputTextFibonacci();
            #endregion
        }

        private void ResetTextControlsFibonacci()
        {
            labelFibonacci1.Text = "Wartość dla n-tego wyrazu ciągu:";
            labelFibonacci2.Text = "Suma ciągu Fibonacciego od 1 do n:";

            outputResultValueFibonacciTxt.Text = "";
            outputResultSumFibonacciTxt.Text = "";
            timeMeasuredIterationFibonacciTxt.Text = "";
            timeMeasuredRecurssionFibonacciTxt.Text = "";
        }

        private void ResetInputTextFibonacci()
        {
            inputParametrFibonacciTxt.Text = "";
        }

        private void ClearFibonacciOutputsButton_Click(object sender, RoutedEventArgs e)
        {
            ResetTextControlsFibonacci();
        }
        #endregion

        #region QUICKSORT
        private void CountQuicksortButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearQuicksortOutputsButton_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region TOWER OF HANOI

        #endregion
    }
}