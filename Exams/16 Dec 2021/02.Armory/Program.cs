using System;

namespace Armory
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()!);
            char[,] armory = new char[n, n];
            int armyRow = 0;
            int armyCol = 0;
            int gold = 0;
            bool isInArmory = true;
            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    armory[row, col] = line[col];
                    if (armory[row, col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            while (isInArmory && gold < 65 )
            {
                string command = Console.ReadLine()!;
                armory[armyRow, armyCol] = '-';
                if (!CanMove(n,armyRow,armyCol,command))
                {
                    isInArmory = false;
                    Console.WriteLine("I do not need more swords!");

                    break;
                }

                if (command == "up")
                {
                    armyRow--;
                    if (armory[armyRow, armyCol] == 'M')
                    {
                        armory[armyRow, armyCol] = '-';
                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (armory[row, col] == 'M')
                                {
                                    armyRow = row;
                                    armyCol = col;
                                }
                            }
                        }

                        armory[armyRow, armyCol] = 'A';
                    }
                    else if (Char.IsDigit(armory[armyRow, armyCol]))
                    {
                        gold += int.Parse(armory[armyRow, armyCol].ToString());
                        armory[armyRow, armyCol] = 'A';

                    }
                    else
                    {
                        armory[armyRow, armyCol] = 'A';
                    }

                }
                if (command == "down")
                {
                    armyRow++;
                    if (armory[armyRow, armyCol] == 'M')
                    {
                        armory[armyRow , armyCol] = '-';
                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (armory[row, col] == 'M')
                                {
                                    armyRow = row;
                                    armyCol = col;
                                }
                            }
                        }

                        armory[armyRow, armyCol] = 'A';
                    }
                    else if (Char.IsDigit(armory[armyRow, armyCol]))
                    {
                        gold += int.Parse(armory[armyRow, armyCol].ToString());
                        armory[armyRow, armyCol] = 'A';

                    }
                    else
                    {
                        armory[armyRow, armyCol] = 'A';
                    }

                }
                if (command == "left")
                {
                    armyCol--;
                    if (armory[armyRow, armyCol] == 'M')
                    {
                        armory[armyRow, armyCol] = '-';
                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (armory[row, col] == 'M')
                                {
                                    armyRow = row;
                                    armyCol = col;
                                }
                            }
                        }

                        armory[armyRow, armyCol] = 'A';
                    }
                    else if (Char.IsDigit(armory[armyRow, armyCol]))
                    {
                        gold += int.Parse(armory[armyRow, armyCol].ToString());
                        armory[armyRow, armyCol] = 'A';

                    }
                    else
                    {
                        armory[armyRow, armyCol] = 'A';
                    }

                }
                if (command == "right")
                {
                    armyCol++;
                    if (armory[armyRow, armyCol] == 'M')
                    {
                        armory[armyRow, armyCol] = '-';
                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (armory[row, col] == 'M')
                                {
                                    armyRow = row;
                                    armyCol = col;
                                }
                            }
                        }

                        armory[armyRow, armyCol] = 'A';
                    }
                    else if (Char.IsDigit(armory[armyRow, armyCol]))
                    {
                        gold += int.Parse(armory[armyRow, armyCol].ToString());
                        armory[armyRow, armyCol] = 'A';

                    }
                    else
                    {
                        armory[armyRow, armyCol] = 'A';
                    }

                }

            }

            if (gold >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {gold} gold coins.");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(armory[row,col]);
                }

                Console.WriteLine();
            }
        }

        public static bool CanMove (int n, int row, int col, string command)
        {
            if (command == "up" && row - 1 >= 0)
            {
                return true;
            }
            if (command == "down" && row + 1 < n)
            {
                return true;
            }
            if (command == "right" && col + 1 < n)
            {
                return true;
            }
            if (command == "left" && col - 1 >= 0)
            {
                return true;
            }

            return false;
        }

        
    }
}
//100
