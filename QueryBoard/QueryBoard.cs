using System;
using System.IO;

namespace QueryBoard
{
    class QueryBoard
    {
        static int[,] matrix = new int[256, 256];

        static int Main(string[] args)
        {
            // Check the argument and file exists
            if (args.Length == 0 || !File.Exists(args[0]))
            {
                Console.Write("You failed to specify the file to read, or entered a non existant file path.\nPlease try again with the file name as the first argument.");
                return 0;
            }

            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (null == line) continue;

                    if ("" == line) continue;

                    PerformQuery(line);
                }
            }

            return 0;
        }

        static void PerformQuery(string query)
        {
            int sumOfQuery = 0;
            string[] numberBlocks = query.Split(' ');

            if (numberBlocks.Length != 0)
            {
                switch (numberBlocks[0])
                {
                    case "SetRow":
                        {
                            int row = Convert.ToInt32(numberBlocks[1]);
                            int value = Convert.ToInt32(numberBlocks[2]);

                            for (int column = 0; column < matrix.GetLength(1); ++column)
                            {
                                matrix[row, column] = value;
                            }

                            break;
                        }
                    case "SetCol":
                        {
                            int column = Convert.ToInt32(numberBlocks[1]);
                            int value = Convert.ToInt32(numberBlocks[2]);

                            for (int row = 0; row < matrix.GetLength(0); ++row)
                            {
                                matrix[row, column] = value;
                            }

                            break;
                        }
                    case "QueryRow":
                        {
                            int row = Convert.ToInt32(numberBlocks[1]);

                            for (int column = 0; column < matrix.GetLength(1); ++column)
                            {
                                sumOfQuery += matrix[row, column];
                            }

                            Console.WriteLine(sumOfQuery);
                            break;
                        }
                    case "QueryCol":
                        {
                            int column = Convert.ToInt32(numberBlocks[1]);

                            for (int row = 0; row < matrix.GetLength(0); ++row)
                            {
                                sumOfQuery += matrix[row, column];
                            }

                            Console.WriteLine(sumOfQuery);
                            break;
                        }

                    default:
                        break;
                }
            }
        }
    }
}
