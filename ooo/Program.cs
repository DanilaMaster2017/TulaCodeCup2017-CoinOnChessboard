using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooo
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            long[] mainSum = new long[2 * N - 1];
            long[] sideSum = new long[2 * N - 1];
            int[,] cellMoney = new int[N, N];

            long whiteMaxSum = 0;
            long blackMaxSum = 0;


            for (int i = 0; i < N; i++ )
            {
                string[] st = Console.ReadLine().Split();
                for (int j = 0; j < N; j++)
                {
                    cellMoney[i, j] = int.Parse(st[j]);
                    mainSum[i + j] += cellMoney[i, j];
                    sideSum[i - j + N - 1] += cellMoney[i, j]; 
                }
            }

            for (int i = 0; i < N; i++)
            {
                long currentSum = 0;
                for (int j = 0; j < N; j++)
                {
                    currentSum = mainSum[i + j] + sideSum[i - j + N - 1] - cellMoney[i, j];

                    if ((i % 2) == (j % 2))
                    {
                        if (currentSum > blackMaxSum) blackMaxSum = currentSum;
                    }
                    else
                    {
                        if (currentSum > whiteMaxSum) whiteMaxSum = currentSum;
                    } 
                }
            }

            long result = blackMaxSum + whiteMaxSum;

            Console.WriteLine(result);
            Console.ReadLine();
           
        }
    }
}
