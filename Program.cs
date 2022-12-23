using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    internal class Program
    {
        public static String pName;
        static void Main(string[] args)
        {
            int pNum1, pNum2, pTotal;
            int psubTotal = 0;
            int eNum1, eNum2, eTotal;
            int esubTotal = 0;

            int pPoints;
            int ePoints;

            Random random=new Random();

        restart:
            pPoints = 0;
            ePoints = 0;

            Menu();

            for(int i = 0; i < 100; i++)
            {
                Console.WriteLine("Press any key to roll the dice.");
                Console.ReadKey();

                //Player Turn=============================================

                pNum1 = random.Next(1, 7);
                pNum2 = random.Next(1, 7);
                Console.WriteLine("You rolled {0} and {1} ",pNum1,pNum2);
                pTotal = pNum1 + pNum2;

                if(pNum1==pNum2 && pNum1==1 && pNum2 == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("*****BUSTED*****");
                    pTotal = 0;
                    pPoints = 0;
                }
                else if(pNum1 == pNum2 && pNum1 != 1 && pNum2 != 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("~~~~~Double Bonus~~~~");
                    Console.WriteLine("You Get Another Chance");
                    Console.WriteLine("Press any key to roll the dice.");
                    Console.ReadKey();
                    Console.WriteLine();

                    pNum1 = random.Next(1, 7);
                    pNum2 = random.Next(1, 7);
                    Console.WriteLine("You rolled {0} and {1} ", pNum1, pNum2);
                    psubTotal = pNum1 + pNum2;

                }
                pTotal += psubTotal;
                Console.WriteLine("Your Points This Round: " + pTotal );

                Console.WriteLine(".......");
                System.Threading.Thread.Sleep(1000);

                //Enemy Turn======================================================

                eNum1 = random.Next(1, 7);
                eNum2 = random.Next(1, 7);
                Console.WriteLine("Enemy rolled {0} and {1} ", eNum1, eNum2);
                eTotal = eNum1 + eNum2;

                if (eNum1 == eNum2 && eNum1 == 1 && eNum2 == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("*****BUSTED*****");
                    eTotal = 0;
                    ePoints = 0;
                }
                else if (eNum1 == eNum2 && eNum1 != 1 && eNum2 != 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("~~~~~Double Bonus~~~~");
                    Console.WriteLine("Enemy Get Another Chance");
                    Console.WriteLine();

                    eNum1 = random.Next(1, 7);
                    eNum2 = random.Next(1, 7);
                    Console.WriteLine("Enemy rolled {0} and {1} ", eNum1, eNum2);
                    esubTotal = eNum1 + eNum2;

                }
                eTotal += esubTotal;
                Console.WriteLine("Enemy Points This Round: " + eTotal);
                Console.WriteLine();

                //Compare Points======================================================

                if (pTotal > eTotal)
                {
                    Console.WriteLine("{0} Win This Round!",pName);

                }
                else if(pTotal < eTotal)
                {
                    Console.WriteLine("Enemy Win This Round!");
                }
                else
                {
                    Console.WriteLine("Draw");
                }

                pPoints += pTotal;
                ePoints += eTotal;

                Console.WriteLine("The Score:-  {0} : {1} and Enemy : {2}",pName,pPoints,ePoints);
                Console.WriteLine("=============================================================");
                Console.WriteLine();

                //End Points Conditions====================================================

                if(pPoints>=100 || ePoints >= 100)
                {
                    Console.WriteLine("___GAME OVER___");

                    if(pTotal > eTotal)
                    {
                        if(pTotal>=100 && eTotal >= 100)
                        {
                            Console.WriteLine("Two Players Reach 100 Scores Together But {0} Get Highest Score",pName);
                            Console.WriteLine("Congratulations!!! You Win The Game");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("You Reach 100 Scores");
                            Console.WriteLine("Congratulations!!! You Win The Game");
                            Console.WriteLine();
                        }
                        
                    }
                    else
                    {
                        if(eTotal >= 100 && eTotal >= 100)
                        {
                            Console.WriteLine("Two Players Reach 100 Scores Together But Enemy Get Highest Score");
                            Console.WriteLine("Enemy Win The Game, Try Next Time.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Enemy Reach 100 Scores");
                            Console.WriteLine("Enemy Win The Game, Try Next Time.");
                            Console.WriteLine();
                        }
                        
                    }
                    Console.Write("Do you want to Restart the Game?(y/n): ");
                    String response = Console.ReadLine();


                    try
                    {
                        if (response == "y" || response == "Y")
                        {
                            goto restart;
                        }
                        else if (response == "n" || response == "N")
                        {
                            return;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Enter Valid Input!!!");

                    }
                }
                


            }




        }

        static void Menu()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("=========== Dice Game ===========");
            Console.WriteLine("=================================");
            Console.WriteLine();

            Console.Write("Enter Player Name: ");
            pName=Console.ReadLine();
            Console.WriteLine();

            
        }
    }
}
