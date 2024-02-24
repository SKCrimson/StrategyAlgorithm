using System;

namespace StrategyAlgorithm
{
    internal interface IAlgoritm
    {
        void Run(Context context);
    }

    internal class IncrementAlgorithm : IAlgoritm
    {
        public void Run(Context context)
        {
            Console.WriteLine($"Value: {context.Value}");
            context.Value++;
        }
    }

    internal class DicrementAlgorithm : IAlgoritm
    {
        public void Run(Context context)
        {
            Console.WriteLine($"Value: {context.Value}");
            context.Value--;
        }
    }

    internal class Context
    {
        internal Context(IAlgoritm algoritm)
        {
            Algoritm = algoritm;
            Console.WriteLine("algorithm started");
        }

        internal int Value = 0;
        internal IAlgoritm Algoritm;

        internal void ChangeAlgorithm()
        {
            if (Algoritm is IncrementAlgorithm)
                Algoritm = new DicrementAlgorithm();
            else
                Algoritm = new IncrementAlgorithm();

            Console.WriteLine();
            Console.WriteLine("algorithm changed");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Context context = new Context(new IncrementAlgorithm());

            do
            {
                context.Algoritm.Run(context);

            } while (context.Value < 10);

            context.ChangeAlgorithm();

            do
            {
                context.Algoritm.Run(context);

            } while (context.Value > 0);

            Console.ReadLine();
        }
    }
}
