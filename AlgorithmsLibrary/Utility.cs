namespace AlgorithmsLibrary
{
    public static class Utility
    {
        public static void Swap(int[] arr, int i, int j)
        {
            (arr[j], arr[i]) = (arr[i], arr[j]);
        }

        public static int[] GetSortingData(int length)
        {
            int[] data = new int[length];
            for (int i = 0; i < length; i++)
            {
                Random random = new();
                data[i] = random.Next(1, length + 1);
            }
            return data;
        }

        public static void PrintDataInConsole(int[] data)
        {
            Console.WriteLine(string.Join(" ", data));
        }
    }
}
