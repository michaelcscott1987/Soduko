using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduko
{
    class Program
    {
        static void Main(string[] args)         // Main method to test
        {
            int[,] array = new int[9, 9];       // Array for sudoku Puzzle
            array = ReadFile();                 // Function to read from file
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    Console.Write(array[i, j] + " | ");
                }
                Console.WriteLine();
            }// Loops to write array

            CheckHorizontal(array);         // Checking for horizontal equality
            CheckVertical(array);           // Checking for vertical equality
            CheckBlock(array);              // Checking for blocks equality
        }

        // Function to read from file
        public static int[,] ReadFile()
        {
            int[,] array = new int[9, 9];
            StreamReader reader = new StreamReader("../../sudoku-3.txt");   // File to read
            string line = reader.ReadLine();                                // Reading file line by line
            int j = 0;
            while (line != null)                                            // While not end of file
            {
                string[] str = line.Split(',');                             // Splitting string by ,
                for(int i = 0; i < str.Length; i++)
                {
                    array[j, i] = Convert.ToInt16(str[i]);                  // Writing values in array
                }
                j++;
                line = reader.ReadLine();
            }
            reader.Close();
            return array;
        }

        // Function to check if horizontal same
        public static bool CheckHorizontal(int[,] array)
        {
            int row, column;
            int flag = 0;
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    for(int k = j+1; k < array.GetLength(1); k++)
                    {
                        if(array[i, j] == array[i, k])      // If equal elements found
                        {
                            flag = 1;
                            row = i;
                            column = j;
                            Console.WriteLine("Invalid");
                            Console.WriteLine("Row: " + row);
                            Console.WriteLine("Column: " + column);
                            break;
                        }
                    }
                    if (flag == 1)
                        break;
                }
                if (flag == 1)
                    break;
            }
            if (flag == 1)
                return true;
            else
                return false;
        }

        // Function to check if vertical same
        public static bool CheckVertical(int[,] array)
        {
            int row, column;
            int flag = 0;
            for (int j = 0; j < array.GetLength(0); j++)
            {
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    for (int k = i + 1; k < array.GetLength(0); k++)
                    {
                        if (array[i, j] == array[i, k])      // If equal elements found
                        {
                            flag = 1;
                            row = i;
                            column = j;
                            Console.WriteLine("Invalid");
                            Console.WriteLine("Row: " + row);
                            Console.WriteLine("Column: " + column);
                            break;
                        }
                    }
                    if (flag == 1)
                        break;
                }
                if (flag == 1)
                    break;
            }
            if (flag == 1)
                return true;
            else
                return false;
        }

        // Function to check blocks
        public static bool CheckBlock(int[,] array)
        {
            bool result = false;

            // Making block and checking horizontal and vertical similarity
            int[,] block1 = new int[3, 3];
            block1[0, 0] = array[0, 0];
            block1[0, 1] = array[0, 1];
            block1[0, 2] = array[0, 2];
            block1[1, 0] = array[1, 0];
            block1[1, 1] = array[1, 1];
            block1[1, 2] = array[1, 2];
            block1[2, 0] = array[2, 0];
            block1[2, 1] = array[2, 2];
            block1[2, 2] = array[2, 2];

            if (!CheckHorizontal(block1))
                CheckVertical(block1);
            if (CheckHorizontal(block1) || CheckVertical(block1))
            {
                Console.WriteLine("Invalid");
                Console.WriteLine("Block: 1");
                result = true;
                return result;
            }

            // Making block and checking horizontal and vertical similarity
            int[,] block2 = new int[3, 3];
            block1[0, 0] = array[0, 3];
            block1[0, 1] = array[0, 4];
            block1[0, 2] = array[0, 5];
            block1[1, 0] = array[1, 3];
            block1[1, 1] = array[1, 4];
            block1[1, 2] = array[1, 5];
            block1[2, 0] = array[2, 3];
            block1[2, 1] = array[2, 4];
            block1[2, 2] = array[2, 5];

            if (!CheckHorizontal(block2))
                CheckVertical(block2);
            if (CheckHorizontal(block2) || CheckVertical(block2))
            {
                Console.WriteLine("Invalid");
                Console.WriteLine("Block: 2");
                result = true;
                return result;
            }

            // Making block and checking horizontal and vertical similarity
            int[,] block3 = new int[3, 3];
            block1[0, 0] = array[0, 6];
            block1[0, 1] = array[0, 7];
            block1[0, 2] = array[0, 8];
            block1[1, 0] = array[1, 6];
            block1[1, 1] = array[1, 7];
            block1[1, 2] = array[1, 8];
            block1[2, 0] = array[2, 6];
            block1[2, 1] = array[2, 7];
            block1[2, 2] = array[2, 8];

            if (!CheckHorizontal(block3))
                CheckVertical(block3);
            if (CheckHorizontal(block3) || CheckVertical(block3))
            {
                Console.WriteLine("Invalid");
                Console.WriteLine("Block: 3");
                result = true;
                return result;
            }

            // Making block and checking horizontal and vertical similarity
            int[,] block4 = new int[3, 3];
            block1[0, 0] = array[3, 0];
            block1[0, 1] = array[3, 1];
            block1[0, 2] = array[3, 2];
            block1[1, 0] = array[4, 0];
            block1[1, 1] = array[4, 1];
            block1[1, 2] = array[4, 2];
            block1[2, 0] = array[5, 0];
            block1[2, 1] = array[5, 2];
            block1[2, 2] = array[5, 2];

            if (!CheckHorizontal(block4))
                CheckVertical(block4);
            if (CheckHorizontal(block4) || CheckVertical(block4))
            {
                Console.WriteLine("Invalid");
                Console.WriteLine("Block: 4");
                result = true;
                return result;
            }

            // Making block and checking horizontal and vertical similarity
            int[,] block5 = new int[3, 3];
            block1[0, 0] = array[3, 3];
            block1[0, 1] = array[3, 4];
            block1[0, 2] = array[3, 5];
            block1[1, 0] = array[4, 3];
            block1[1, 1] = array[4, 4];
            block1[1, 2] = array[4, 5];
            block1[2, 0] = array[5, 3];
            block1[2, 1] = array[5, 4];
            block1[2, 2] = array[5, 5];

            if (!CheckHorizontal(block5))
                CheckVertical(block5);
            if (CheckHorizontal(block5) || CheckVertical(block5))
            {
                Console.WriteLine("Invalid");
                Console.WriteLine("Block: 5");
                result = true;
                return result;
            }

            // Making block and checking horizontal and vertical similarity
            int[,] block6 = new int[3, 3];
            block1[0, 0] = array[3, 6];
            block1[0, 1] = array[3, 7];
            block1[0, 2] = array[3, 8];
            block1[1, 0] = array[4, 6];
            block1[1, 1] = array[4, 7];
            block1[1, 2] = array[4, 8];
            block1[2, 0] = array[5, 6];
            block1[2, 1] = array[5, 7];
            block1[2, 2] = array[5, 8];

            if (!CheckHorizontal(block6))
                CheckVertical(block6);
            if (CheckHorizontal(block6) || CheckVertical(block6))
            {
                Console.WriteLine("Invalid");
                Console.WriteLine("Block: 6");
                result = true;
                return result;
            }

            // Making block and checking horizontal and vertical similarity
            int[,] block7 = new int[3, 3];
            block1[0, 0] = array[6, 0];
            block1[0, 1] = array[6, 1];
            block1[0, 2] = array[6, 2];
            block1[1, 0] = array[7, 0];
            block1[1, 1] = array[7, 1];
            block1[1, 2] = array[7, 2];
            block1[2, 0] = array[8, 0];
            block1[2, 1] = array[8, 2];
            block1[2, 2] = array[8, 2];

            if (!CheckHorizontal(block7))
                CheckVertical(block7);
            if (CheckHorizontal(block7) || CheckVertical(block7))
            {
                Console.WriteLine("Invalid");
                Console.WriteLine("Block: 7");
                result = true;
                return result;
            }

            // Making block and checking horizontal and vertical similarity
            int[,] block8 = new int[3, 3];
            block1[0, 0] = array[6, 3];
            block1[0, 1] = array[6, 4];
            block1[0, 2] = array[6, 5];
            block1[1, 0] = array[7, 3];
            block1[1, 1] = array[7, 4];
            block1[1, 2] = array[7, 5];
            block1[2, 0] = array[8, 3];
            block1[2, 1] = array[8, 4];
            block1[2, 2] = array[8, 5];

            if (!CheckHorizontal(block8))
                CheckVertical(block8);
            if (CheckHorizontal(block8) || CheckVertical(block8))
            {
                Console.WriteLine("Invalid");
                Console.WriteLine("Block: 8");
                result = true;
                return result;
            }

            // Making block and checking horizontal and vertical similarity
            int[,] block9 = new int[3, 3];
            block1[0, 0] = array[6, 6];
            block1[0, 1] = array[6, 7];
            block1[0, 2] = array[6, 8];
            block1[1, 0] = array[7, 6];
            block1[1, 1] = array[7, 7];
            block1[1, 2] = array[7, 8];
            block1[2, 0] = array[8, 6];
            block1[2, 1] = array[8, 7];
            block1[2, 2] = array[8, 8];

            if (!CheckHorizontal(block9))
                CheckVertical(block9);
            if (CheckHorizontal(block9) || CheckVertical(block9))
            {
                Console.WriteLine("Invalid");
                Console.WriteLine("Block: 9");
                result = true;
                return result;
            }
            return result;
        }
    }
}
