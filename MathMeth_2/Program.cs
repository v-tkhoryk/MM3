using QueueingSystem;

namespace MathMeth_2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region First task
            
            var queue1 = new MonoChannel(0.1, 9, 10);
            queue1.PrintResults();

            /*
            var queue2 = new MonoChannel(0.1, 5);
            queue2.PrintResults();

            var queue3 = new MonoChannel(0.1, 9);
            queue3.PrintResults();

            var queue4 = new MonoChannel(0.2, 1);
            queue4.PrintResults();

            var queue5 = new MonoChannel(0.5, 1);
            queue5.PrintResults();

            var queue6 = new MonoChannel(0.9, 1);
            queue6.PrintResults();

            var queue7 = new MonoChannel(2, 0.1);
            queue7.PrintResults();

            var queue8 = new MonoChannel(5, 0.1);
            queue8.PrintResults();

            var queue9 = new MonoChannel(9, 0.1);
            queue9.PrintResults();
            */
            #endregion

            /*
            #region Second task
            var multi = new MultiChannel(4, 2, 10);
            multi.PrintResults();

            var multi2 = new MultiChannel(1, 5, 10);
            multi2.PrintResults();

            var multi3 = new MultiChannel(0.3, 9, 10);
            multi3.PrintResults();

            var multi4 = new MultiChannel(4, 1, 5);
            multi4.PrintResults();

            var multi5 = new MultiChannel(3, 1, 5);
            multi5.PrintResults();

            var multi6 = new MultiChannel(1, 1, 5);
            multi6.PrintResults();

            var multi7 = new MultiChannel(190, 0.1, 20);
            multi7.PrintResults();

            var multi8 = new MultiChannel(100, 0.1, 20);
            multi8.PrintResults();

            var multi9 = new MultiChannel(20, 0.1, 20);
            multi9.PrintResults();
            #endregion
            */
            System.Console.ReadLine();
        }
    }
}
