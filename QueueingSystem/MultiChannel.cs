using System;

namespace QueueingSystem
{
    public class MultiChannel
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
        /// Amount of channels
        /// </summary>
        int c;

        /// <summary>
        /// Expected service channel load
        /// </summary>
        double rho;

        double avgCallsPerAvgST;
        double avgCallsAmount;
        double avgCallsAmountInQueue;
        double avgTimeInSystem;
        double avgTimeInQueue;
        double avgBusySystemPeriod;
        double probOfQueue;
        double probSystemFree;
        double probSystemBusy;

        public MultiChannel(double _lambda, double _st, int _c)
        {
            lambda = _lambda;
            iat = 1 / lambda;
            st = _st;
            c = _c;
            rho = lambda * st / c;
            Calculation();
        }

        public void Calculation()
        {
            long Factorial(long x) => x == 0 ? 1 : x * Factorial(--x);

            double FreeSystemProb()
            {
                double p0 = 0;
                for (int s = 0; s < c; s++)
                {
                    p0 += Math.Pow(c * rho, s) / Factorial(s);
                }
                p0 += Math.Pow(c * rho, c) 
                    / (Factorial(c) * (1 - rho));
                return 1 / p0;
            }

            avgCallsPerAvgST = c * rho;
            //Console.WriteLine("5! = " + Factorial(5));
            probSystemFree = FreeSystemProb();
            probSystemBusy = 1 - probSystemFree;


            avgCallsAmountInQueue = Math.Pow(avgCallsPerAvgST, c) * rho * probSystemFree /
                                    (Factorial(c) * Math.Pow(1 - rho, 2)); 
            avgCallsAmount = avgCallsAmountInQueue + avgCallsPerAvgST;

            avgTimeInSystem = avgCallsAmount * iat;
            avgTimeInQueue = avgTimeInSystem - st;

            probOfQueue = Math.Pow(rho * c, c + 1) * probSystemFree /
                          Factorial(c) / (c - c * rho);

            avgBusySystemPeriod = 1 / (1 / st - lambda);
            
        }
        public void PrintResults()
        {
            Console.WriteLine();
            Console.WriteLine($"\t\t\tLAMBDA = {lambda}; st = {st}; c = {c}");
            Console.WriteLine(
                $"rho \t= {rho}\n" +
                $"r = {avgCallsPerAvgST}\n" +
                $"L \t= {avgCallsAmount:N3}\n" +
                $"Lq \t= {avgCallsAmountInQueue:N3}\n" +
                $"W \t= {avgTimeInSystem:N3}\n" +
                $"Wq \t= {avgTimeInQueue:N3}\n" +
                $"1 - Wq(0) \t= {probOfQueue:N5}\n");
        }
    }
}
