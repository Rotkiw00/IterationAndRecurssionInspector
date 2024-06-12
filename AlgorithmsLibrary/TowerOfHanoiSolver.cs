namespace AlgorithmsLibrary
{
    public static class TowerOfHanoiSolver
    {
        public static (int, List<string>) Recursion(int n, string from, string to, string via)
        {
            int numberOfMoves = 0;
            List<string> moves = [];

            if (n is 0)
            {
                numberOfMoves++;
                moves.Add($"Przenieś krążek 1 z wieży: [{from}] na wieże: [{to}]. Ruch: [{numberOfMoves}]");
            }
            else
            {
                Recursion(n - 1, from, via, to);
                numberOfMoves++;
                moves.Add($"Przenieś krążek {n} z wieży: [{from}] na wieże: [{to}]. Ruch: [{numberOfMoves}]");
                Recursion(n - 1, via, to, from);
            }

            return (numberOfMoves, moves);
        }
    }
}
