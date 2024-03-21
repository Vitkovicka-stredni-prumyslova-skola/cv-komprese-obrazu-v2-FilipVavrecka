
using System;
using System.Collections.Generic;
using System.IO;

namespace Komprese
{
    public class Obrazek
    {
        private int[,] obrazek = null;

        public Obrazek(string filePath)
        {
            readImg(filePath);
        }

        public int CountLines(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                int i = 0;
                while (sr.ReadLine() != null)
                {
                    i++;
                }
                return i;
            }
        }

        public int CountSymbolInLine(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                int i = 0;
                String[] line = sr.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (string item in line)
                {
                    i++;
                }
                return i;
            }
        }

        private void readImg(String filePath)
        {
            StreamReader sr = null;
            String[] line = null;
            String row;
            obrazek = new int[CountSymbolInLine(filePath), CountLines(filePath)];

            try
            {
                using (sr = new StreamReader(filePath))
                {
                    int j = 0;

                    while ((row = sr.ReadLine()) != null)
                    {
                        line = row.Split(";", StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < obrazek.GetLength(0); i++)
                        {
                            obrazek[i, j] = Int32.Parse(line[i]);
                        }
                        j++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Soubor nelze načíst:");
                Console.WriteLine(e.Message);
            }
        }

        public List<int> PaletaBarevObrazku()
        {
            List<int> result = new List<int>();

            for (int j = 0; j < obrazek.GetLength(1); j++)
            {
                for (int i = 0; i < obrazek.GetLength(0); i++)
                {
                    if (!result.Contains(obrazek[i, j]))
                    {
                        result.Add(obrazek[i, j]);
                    }
                }
            }
            return result;
        }

        public Dictionary<int, int> CountColors()
        {
            Dictionary<int, int> colorCount = new Dictionary<int, int>();

            for (int j = 0; j < obrazek.GetLength(1); j++)
            {
                for (int i = 0; i < obrazek.GetLength(0); i++)
                {
                    int color = obrazek[i, j];
                    if (colorCount.ContainsKey(color))
                    {
                        colorCount[color]++;
                    }
                    else
                    {
                        colorCount[color] = 1;
                    }
                }
            }

            return colorCount;
        }

        public void vypisImg()
        {
            for (int j = 0; j < obrazek.GetLength(1); j++)
            {
                for (int i = 0; i < obrazek.GetLength(0); i++)
                {
                    Console.Write("{0}, ", obrazek[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}