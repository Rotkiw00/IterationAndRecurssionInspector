namespace AlgorithmsLibrary
{
    public class QuicksortSolver
    {
        static int Partition(int[] arr, int low, int high)
        {
            // Choosing the pivot
            int pivot = arr[high];

            // Index of smaller element and indicates
            // the right position of pivot found so far
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {

                // If current element is smaller than the pivot
                if (arr[j] < pivot)
                {

                    // Increment index of smaller element
                    i++;
                    Utility.Swap(arr, i, j);
                }
            }
            Utility.Swap(arr, i + 1, high);
            return i + 1;
        }

        /* The main function that implements 
        QuickSort() arr[] --> Array to be  
        sorted, 
        low --> Starting index, 
        high --> Ending index */
        public static void Recursion(int[] arr, int low, int high)
        {
            if (low < high)
            {

                // pi is partitioning index, arr[p]
                // is now at right place
                int pi = Partition(arr, low, high);

                // Separately sort elements before
                // and after partition index
                Recursion(arr, low, pi - 1);
                Recursion(arr, pi + 1, high);
            }
        }

        public static void Iteration(int[] arr, int l, int h)
        {
            // Create an auxiliary stack 
            int[] stack = new int[h - l + 1];

            // initialize top of stack 
            int top = -1;

            // push initial values of l and h to 
            // stack 
            stack[++top] = l;
            stack[++top] = h;

            // Keep popping from stack while 
            // is not empty 
            while (top >= 0)
            {
                // Pop h and l 
                h = stack[top--];
                l = stack[top--];

                // Set pivot element at its 
                // correct position in 
                // sorted array 
                int p = Partition(arr, l, h);

                // If there are elements on 
                // left side of pivot, then 
                // push left side to stack 
                if (p - 1 > l)
                {
                    stack[++top] = l;
                    stack[++top] = p - 1;
                }

                // If there are elements on 
                // right side of pivot, then 
                // push right side to stack 
                if (p + 1 < h)
                {
                    stack[++top] = p + 1;
                    stack[++top] = h;
                }
            }
        }
    }
}
