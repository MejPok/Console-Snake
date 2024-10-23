namespace Snake
{
    internal class Program
    {
        public static int direction; // -1 left 1 right 2 up -2 down

        public static int x;
        public static int y;

        public static List<int> tailX = new List<int>();
        public static List<int> tailY = new List<int>();

        public static int tailSize;

        public static bool death;
        static void Main(string[] args)
        {
            RowReader reader = new RowReader();
            reader.mapSizeY = 20;
            reader.mapSizeX = 40;

            x = 6;
            y = 6;
            direction = 1;
            death = false;
            reader.CreateApple();

            while (true)
            {
                if (death)
                {
                    return;
                }
                reader.WriteRow();

                if (Console.KeyAvailable)
                {
                    char key = Console.ReadKey().KeyChar;

                    switch (key)
                    {
                        case 'a':
                            direction = -1;
                            break;
                        case 'd':
                            direction = 1;
                            break;
                        case 's':
                            direction = -2;
                            break;
                        case 'w':
                            direction = 2;
                            break;
                    }
                }

                NewTailAtHead();
                if (tailX.Count > tailSize) { 
                    DeleteLastTail();
                }
                

                switch (direction)
                {
                    case -1:
                        x--;
                        break;
                    case 1:
                        x++;
                        break;
                    case -2:
                        y++;
                        break;
                    case 2:
                        y--;
                        break;

                }

                
                Thread.Sleep(100);
            }
        }

        public static void NewTailAtHead()
        {
            tailX.Add(x);
            tailY.Add(y);
        }
        public static void DeleteLastTail()
        {
            tailX.RemoveAt(0);
            tailY.RemoveAt(0);
        }
        public static void Death()
        {
            death = true;
            Console.WriteLine("You died");
        }

        }
    }
        


