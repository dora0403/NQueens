using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            EightQueens.Test();
        }
    }

    public class EightQueens
    {
        //定義皇后數
        static int gridSize = 8;

        //定義陣列表示皇后放置位置 例如queen={0,4,7,5,2,6,1,3}
        //表示Q在的格子(行，列) queen[i]= val 索引i表示第i+1皇后 = 在第i+1行; 在第val+1列
        static int[] queen = new int[gridSize];

        //初始化解法次數
        static int count = 0;

        public static void Test()
        {
            EightQueens.RunQueen(0);
            Console.WriteLine($"一共有{count}種解法");
            Console.ReadLine();
        }

        /// <summary>
        /// 從第一行依序放置第n個皇后(第n行)
        /// </summary>
        /// <param name="n"></param>
        private static void RunQueen(int n)
        {
            if (n == gridSize) //當n=8,表示index從0到7已經擺了8位皇后
            {
                Print();
                return;
            }

            //依次(依行的順序)放入皇后，並判斷是否有衝突
            for (int i = 0; i < gridSize; i++)
            {
                //先把當前這個皇后n,放到該行的第1列(val=0)
                queen[n] = i;

                //判斷當放置第n個皇后到i列時，是否衝突
                if (CheckQPosition(n))
                {
                    //如果不衝突，接著放n+1個皇后，即開始遞迴
                    RunQueen(n + 1);
                }

                //如果衝突，就繼續執行queen[n]=i,即將第n個皇后，放置在本行原本放的下一個位置
            }
        }

        /// <summary>
        /// 檢查該皇后是否和前面已經放的皇后衝突
        /// </summary>
        /// <param name="n">表示第n個皇后</param>
        /// <returns></returns>
        private static bool CheckQPosition(int n)
        {
            for (int i = 0; i < n; i++) //此處迴圈的i是n之前的皇后
            {
                //兩個判斷條件
                //1.判斷是否同列: queen[i] == queen[n] 表示判斷第n個皇后，是否和前面的n-1個皇后在同一列(val相同表示在同一列)
                //2.如果兩點的行之差等於列之差(絕對值) 表示兩點在同一對角線上

                if (queen[i] == queen[n] || Math.Abs(n - i) == Math.Abs(queen[n] - queen[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 印出皇后
        /// </summary>
        private static void Print()
        {
            count++;
            Console.WriteLine("//Solution " + count);
            for (int i = 0; i < queen.Length; i++)
            {
                for (int j = 0; j < queen.Length; j++)
                {
                    Console.Write(queen[i] == j ? 'Q' : '.');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
