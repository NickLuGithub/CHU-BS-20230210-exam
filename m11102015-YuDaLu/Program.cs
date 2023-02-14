using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace m11102015_YuDaLu
{

    internal class Program
    {
        private static int n = 4;
        static void Main(string[] args)
        {
            int[] number = new int[4];
            bool yesA = false;
            bool isPlay = false;

            var rand = new Random();

            while (!isPlay)
            {
                for (int i = 0; i < n; i++)
                {
                    number[i] = rand.Next(0, 10);
                    if (i > 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if ((j != i) & (number[i] == number[j])) i--;
                        }
                    }
                }

                Console.WriteLine("歡迎來到 1A2B 猜數字的遊戲～");

                yesA = false;

                while (!yesA)
                {
                    int[] input = new int[4];
                    int A = 0, B = 0, kn = 0;
                    Console.WriteLine("\n請輸入 4 個數字：");

                    int inputInt = Convert.ToInt16(Console.ReadLine());

                    /*
                    1234
                    0123
                    
                    元      /10  %10
                    1234    123  4
                    123     12   3
                    12      1    2
                    1            1

                    0456 456
                    0123
                    */

                    if (inputInt < 1000)
                    {
                        input[0] = 0;
                        kn = 1;
                    }

                    for (int i = n - 1; i >= 0 + kn; i--)
                    {
                        input[i] = inputInt % 10;
                        inputInt /= 10;
                    }

                    /*
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine(input[i]);
                    }
                    */
                    for (int i = 0; i < 4; i++)
                    {
                        if (input[i] == number[i])
                        {
                            A++;
                        }
                        else
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if ((i != j) & (input[i] == number[j]))
                                {
                                    B++;
                                }
                            }

                        }
                    }

                    Console.Write("判定結果是");
                    Console.Write(Convert.ToString(A) + "A");
                    Console.Write(Convert.ToString(B) + "B");
                    
                    // 開外掛
                    //Console.WriteLine("\n左邊 input, 右邊 number");
                    //for (int i = 0; i < 4; i++)
                    //{
                    //    Console.WriteLine($"\n{input[i]}, {number[i]}");
                    //}

                    if (A == 4)
                    {
                        Console.WriteLine("恭喜你！猜對了！！");

                        Console.WriteLine("你要繼續玩嗎？(y/n):");
                        string temp = Console.ReadLine();
                        yesA = true;
                        if ((temp == "n") | (temp == "N"))
                        {
                            isPlay = true;
                            Console.WriteLine("遊戲結束，下次再來玩喔～");
                        }
                    }

                }
            }

            Console.ReadLine();
        }
    }
}
