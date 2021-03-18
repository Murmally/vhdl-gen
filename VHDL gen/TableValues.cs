using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VHDL_gen
{
    public static class TableValues
    {
        public static List<List<int>> AesSBoxInv()
        {
            return ReadData("AesSboxInv.txt", true);
        }

        public static List<List<int>> AesSBox()
        {
            return ReadData("AesSbox.txt", true);
        }

        public static List<List<int>> P()
        {
            return ReadData("P.txt");
        }

        public static List<List<int>> PC1()
        {
            return ReadData("PC1.txt");
        }

        public static List<List<int>> PC2()
        {
            return ReadData("PC2.txt");
        }

        public static List<List<int>> IP()
        {
            return ReadData("IP.txt");
        }

        public static List<List<int>> IPInv()
        {
            return ReadData("IPInv.txt");
        }

        public static List<List<int>> DesSBox(int number)
        {
            // number = <1; 8>
            return ReadData($"Des{number}.txt");
        }

        public static List<List<int>> EBitSelection()
        {
            return ReadData("EBitSelection.txt");
        }

        private static List<List<int>> ReadData(string filename, bool isHex = false)
        {
            var result = new List<List<int>>();
            var file = File.ReadAllLines(@"C:\Users\Marek\source\repos\vhdl-gen\VHDL gen\Raw Values\" + filename);
            foreach (string line in file)
            {
                var newRow = new List<int>();
                foreach (string value in line.Split('\t'))
                {
                    if (isHex)
                    {
                        newRow.Add(int.Parse(value, System.Globalization.NumberStyles.HexNumber));
                    }
                    else
                    {
                        newRow.Add(int.Parse(value));
                    }
                }

                result.Add(newRow);
            }

            return result;
        }
    }
}
