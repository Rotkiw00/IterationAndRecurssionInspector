namespace AlgorithmsLibrary
{
    public class QuicksortSolver
    {
        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];

            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {

                if (arr[j] < pivot)
                {

                    i++;
                    Utility.Swap(arr, i, j);
                }
            }
            Utility.Swap(arr, i + 1, high);
            return i + 1;
        }

        public static void Recursion(int[] arr, int low, int high)
        {
            if (low < high)
            {

                int pi = Partition(arr, low, high);

                Recursion(arr, low, pi - 1);
                Recursion(arr, pi + 1, high);
            }
        }

        public static void Iteration(int[] arr, int l, int h)
        {
            int[] stack = new int[h - l + 1];

            int top = -1;

            stack[++top] = l;
            stack[++top] = h;

            while (top >= 0)
            {
                h = stack[top--];
                l = stack[top--];

                int p = Partition(arr, l, h);

                if (p - 1 > l)
                {
                    stack[++top] = l;
                    stack[++top] = p - 1;
                }

                if (p + 1 < h)
                {
                    stack[++top] = p + 1;
                    stack[++top] = h;
                }
            }
        }
    }
}
