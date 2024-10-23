using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class RowReader
    {
        public int mapSizeY;
        public int mapSizeX;

        public int appleX;
        public int appleY;

        public void CreateApple()
        {
            Random rand= new Random();
            appleX = rand.Next(1, mapSizeX);
            appleY = rand.Next(1, mapSizeY);
        }
        public void WriteRow()
        {
            Console.Clear();
            for (int i = 0; i < mapSizeY; i++) {
                if (i == 0 || i == mapSizeY - 1)
                {
                    Console.Write(new string('#', mapSizeX));
                    Console.WriteLine("");
                }
                else
                {
                    Console.Write('#');

                    for (int j = 0; j < mapSizeX; j++)
                    {
                        if (j == appleX && i == appleY)
                        {
                            if (appleX == Program.x && appleY == Program.y)
                            {
                                Console.Write('O');
                                Program.tailSize++;
                                CreateApple();
                            }
                            else
                            {
                                Console.Write('A');

                            }


                        }
                        else if (j == Program.x && i == Program.y)
                        {
                            Console.Write('O');
                            if(CheckForTailPos(j, i))
                            {
                                Program.Death();
                            }
                        }
                        else if (CheckForTailPos(j, i))
                        {
                            Console.Write('X');
                        } else { 
                            Console.Write(' ');
                        }
                    }
                
                    Console.Write('#');
                    Console.WriteLine();
                }
                
            }
            if (Program.y == 0 || Program.y == mapSizeY - 1 || Program.x == 0 || Program.x == mapSizeX + 0)
            {
                Program.Death();
            }
        }

        public bool CheckForTailPos(int x, int y) { 
            for(int i = 0; i < Program.tailX.Count; i++)
            {
                if(x == Program.tailX[i] && y == Program.tailY[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
