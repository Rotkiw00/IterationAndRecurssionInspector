namespace AlgorithmsLibrary
{
    public static class TowerOfHanoiSolver
    {
        public static List<string> HanoiIterationMoves = [];

        public static void Recursion(int n, string from, string to, string via, ref List<string> moves)
        {
            if (n == 1)
            {
                string move = $"Przenieś dysk 1 z {from} do {to}";
                moves.Add(move);
            }
            else
            {
                Recursion(n - 1, from, via, to, ref moves);
                string move = $"Przenieś dysk {n} z {from} do {to}";
                moves.Add(move);
                Recursion(n - 1, via, to, from, ref moves);
            }
        }

        public class Stack
        {
            public int capacity;
            public int top;
            public int[] array;
        }

        public static Stack createStack(int capacity)
        {
            Stack stack = new Stack();
            stack.capacity = capacity;
            stack.top = -1;
            stack.array = new int[capacity];
            return stack;
        }

        public static Boolean isFull(Stack stack)
        {
            return (stack.top == stack.capacity - 1);
        }

        public static Boolean isEmpty(Stack stack)
        {
            return (stack.top == -1);
        }

        public static void push(Stack stack, int item)
        {
            if (isFull(stack))
            {
                return;
            }

            stack.array[++stack.top] = item;
        }

        public static int pop(Stack stack)
        {
            if (isEmpty(stack))
                return int.MinValue;
            return stack.array[stack.top--];
        }

        public static void moveDisksBetweenTwoPoles(Stack src, Stack dest,
                                char s, char d)
        {
            int pole1TopDisk = pop(src);
            int pole2TopDisk = pop(dest);

            if (pole1TopDisk == int.MinValue)
            {
                push(src, pole2TopDisk);
                moveDisk(d, s, pole2TopDisk);
            }

            else if (pole2TopDisk == int.MinValue)
            {
                push(dest, pole1TopDisk);
                moveDisk(s, d, pole1TopDisk);
            }

            else if (pole1TopDisk > pole2TopDisk)
            {
                push(src, pole1TopDisk);
                push(src, pole2TopDisk);
                moveDisk(d, s, pole2TopDisk);
            }

            else
            {
                push(dest, pole2TopDisk);
                push(dest, pole1TopDisk);
                moveDisk(s, d, pole1TopDisk);
            }
        }

        public static void moveDisk(char fromPeg, char toPeg, int disk)
        {
            HanoiIterationMoves.Add($"Przenieś dysk {disk} z {fromPeg} do {toPeg}");
        }

        public static void tohIterative(int num_of_disks, Stack
            src, Stack aux, Stack dest)
        {
            int i, total_num_of_moves;
            char s = 'S', d = 'D', a = 'A';

            if (num_of_disks % 2 == 0)
            {
                char temp = d;
                d = a;
                a = temp;
            }
            total_num_of_moves = (int)(Math.Pow(2, num_of_disks) - 1);

            for (i = num_of_disks; i >= 1; i--)
                push(src, i);

            for (i = 1; i <= total_num_of_moves; i++)
            {
                if (i % 3 == 1)
                    moveDisksBetweenTwoPoles(src, dest, s, d);

                else if (i % 3 == 2)
                    moveDisksBetweenTwoPoles(src, aux, s, a);

                else if (i % 3 == 0)
                    moveDisksBetweenTwoPoles(aux, dest, a, d);
            }
        }
    }
}