using System;

namespace QueueingSystem
{
    public class MonoChannel
    {
        /// <summary>
        /// Average intensity of incoming calls flow
        /// </summary>
        double lambda;

        /// <summary>
        /// Average time between successful call income
        /// </summary>
        double iat;

        /// <summary>
        /// Average servicing time
        /// </summary>
        double st;

        /// <summary>
        /// Expected service channel load
        /// </summary>
        double rho;

        double r;

        int channels = 1;
        int queueMaxSize;

        double avgCallsAmount;
        double avgCallsAmountInQueue;
        double avgTimeInSystem;
        double avgTimeInQueue;
        double probMaxQueue;
        double probSystemFree;
        double probSystemBusy;

        public MonoChannel(double _lambda, double _st, int _queueSize, int _channels = 1)
        {
            lambda = _lambda;
            iat = 1 / lambda;
            st = _st;
            queueMaxSize = _queueSize;
            rho = lambda * st / _channels;
            r = lambda * st;

            Calculation();
        }

        public void Calculation()
        {
            for (int s = 0; s < channels; s++)
                probSystemFree += Math.Pow(channels * rho, s) / Factorial(s);
            probSystemFree += 
                (Math.Pow(channels * rho, channels) / Factorial(channels)) * (1 - Math.Pow(rho, queueMaxSize + 1)) / (1 - rho);
            probSystemFree = 1 / probSystemFree;
            for (int i = 0; i < channels; i++)
                avgCallsAmount += Math.Pow(r, i) / Factorial(i);
            avgCallsAmount *= r * probSystemFree;
            avgCallsAmount += (rho * ProbabilityOfCallsInSystem(channels) / Math.Pow(1 - rho, 2))
                * (1 + channels*(1 - rho) - (1 + Math.Pow(rho, queueMaxSize)*(1 - rho)*(channels + queueMaxSize)));

            avgCallsAmountInQueue = (rho * ProbabilityOfCallsInSystem(channels) / Math.Pow(1 - rho, 2))
                * (1 - Math.Pow(rho, queueMaxSize) * (1 + queueMaxSize * (1 - rho)));

            double a = (rho * ProbabilityOfCallsInSystem(channels) / Math.Pow(1 - rho, 2));
            double b = (1 - Math.Pow(rho, queueMaxSize) * (1 + queueMaxSize * (1 - rho)));

            avgCallsAmountInQueue = a * b;
            probMaxQueue = ProbabilityOfCallsInSystem(queueMaxSize);

            for (int k = 0; k < queueMaxSize; k++)
                avgTimeInQueue += k + 1;
            avgTimeInQueue *= ProbabilityOfCallsInSystem(channels + queueMaxSize) * st / channels;

            avgTimeInSystem = avgTimeInQueue + st;

        }

        private double ProbabilityOfCallsInSystem(int calls)
        {
            return calls < channels
                ? Math.Pow(channels * rho, calls) / Factorial(calls) * probSystemFree
                : Math.Pow(channels * rho, calls) / (Factorial(channels) * Math.Pow(channels, calls - channels)) * probSystemFree;
        }

        private long Factorial(int x) => x == 0 ? 1 : x * Factorial(--x);

        public void PrintResults()
        {
            Console.WriteLine();
            Console.WriteLine($"\t\t\tLAMBDA = {lambda}; st = {st}; K = {queueMaxSize}");
            Console.WriteLine(
                $"rho \t= {rho}\n" +
                $"L \t= {avgCallsAmount:N3}\n" +
                $"Lq \t= {avgCallsAmountInQueue:N3}\n" +
                $"W \t= {avgTimeInSystem:N3}\n" +
                $"Wq \t= {avgTimeInQueue:N7}\n" +
                $"p0 \t= {probSystemFree:N5}\n" +
                $"p(k) \t= {probMaxQueue:N7}\n");
        }
    }
}
