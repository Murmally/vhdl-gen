using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace VHDL_gen
{
    class Program
    {
        public enum SBox { AesSbox, AesSboxInv, Des1, Des2, Des3, Des4, Des5, Des6, Des7, Des8 }

        public enum PermutationTable { IP, IPInv, PC1, PC2, P }


        static string _path = @"C:\Users\Marek\source\repos\vhdl-gen\VHDL gen\Output\";

        #region "Substitution tables"

        static void GenerateSubstitutionTable(
            SBox name, 
            string switchVariable = "INPUT", 
            string assignVariable = "OUTPUT",
            string entityName = "ENTITY_NAME",
            string architectureName = "ARCHITECTURE_NAME")
        {
            byte mask = 15; // 0b00001111
            var result = InitSBoxHeader(switchVariable, entityName, architectureName);
            int counter = 0;
            switch (name)
            {
                case SBox.AesSbox:
                    var aesSbox = TableValues.AesSBox();
                    foreach (var row in aesSbox)
                    {
                        foreach (var number in row)
                        {
                            int columnIndex = counter & mask;
                            int rowIndex = (counter >> 4) & mask;
                            string newValue = GetBinaryValue(aesSbox[rowIndex][columnIndex], 8);
                            string counterValue = GetBinaryValue(counter++, 8);
                            result.Add($"\t\twhen \"{counterValue}\" => {assignVariable} <= \"{newValue}\";");
                        }
                    }

                    result.Add("end case;");
                    result.Add("end process;");
                    result.Add($"end {architectureName};");
                    File.WriteAllLines(_path + "AesSbox.vhd", result);
                    break;
                case SBox.AesSboxInv:
                    var aesSboxInv = TableValues.AesSBoxInv();
                    foreach (var row in aesSboxInv)
                    {
                        foreach (var number in row)
                        {
                            int columnIndex = counter & mask;
                            int rowIndex = (counter >> 4) & mask;
                            string newValue = GetBinaryValue(aesSboxInv[rowIndex][columnIndex], 8);
                            string counterValue = GetBinaryValue(counter++, 8);
                            result.Add($"\twhen \"{counterValue}\" => {assignVariable} <= \"{newValue}\";");
                        }
                    }

                    result.Add("end case;");
                    result.Add("end process;");
                    result.Add($"end {architectureName};");
                    File.WriteAllLines(_path + "AesSboxInv.vhd", result);
                    break;
                case SBox.Des1:
                    var des1 = TableValues.DesSBox(1);
                    GenerateDesSbox(des1, "Des1", assignVariable, entityName, architectureName: architectureName);
                    break;
                case SBox.Des2:
                    var des2 = TableValues.DesSBox(2);
                    GenerateDesSbox(des2, "Des2", assignVariable, architectureName);
                    break;
                case SBox.Des3:
                    var des3 = TableValues.DesSBox(3);
                    GenerateDesSbox(des3, "Des3", assignVariable, architectureName);
                    break;
                case SBox.Des4:
                    var des4 = TableValues.DesSBox(4);
                    GenerateDesSbox(des4, "Des4", assignVariable, architectureName);
                    break;
                case SBox.Des5:
                    var des5 = TableValues.DesSBox(5);
                    GenerateDesSbox(des5, "Des5", assignVariable, architectureName);
                    break;
                case SBox.Des6:
                    var des6 = TableValues.DesSBox(6);
                    GenerateDesSbox(des6, "Des6", assignVariable, architectureName);
                    break;
                case SBox.Des7:
                    var des7 = TableValues.DesSBox(7);
                    GenerateDesSbox(des7, "Des7", assignVariable, architectureName);
                    break;
                case SBox.Des8:
                    var des8 = TableValues.DesSBox(8);
                    GenerateDesSbox(des8, "Des8", assignVariable, entityName, architectureName: architectureName);
                    break;
            }
        }

        static void GenerateDesSbox(
            List<List<int>> sbox,
            string filename,
            string assignVariable = "OUTPUT",
            string entityName = "ENTITY_NAME",
            string switchVariable = "INPUT",
            string architectureName = "ARCHITECTURE_NAME")
        {
            var result = InitSBoxHeader(switchVariable, entityName, architectureName);
            int counter = 0;
            byte rowMask = 33;      // 100001
            byte columnMask = 30;   // 011110
            foreach (var row in sbox)
            {
                foreach (var number in row)
                {
                    int columnIndex = (counter & columnMask) >> 1;
                    string aux = GetBinaryValue(counter, 6);
                    int rowIndex = Convert.ToInt32($"{aux[0]}{aux[5]}", 2);
                    string newValue = GetBinaryValue(sbox[rowIndex][columnIndex], 4);
                    string counterValue = GetBinaryValue(counter++, 6);
                    result.Add($"\t\twhen \"{counterValue}\" => {assignVariable} <= \"{newValue}\";");
                }
            }
            result.Add($"\t\twhen others => {assignVariable} <= \"000000\";");
            result.Add("\tend case;");
            result.Add("end process;");
            result.Add($"end {architectureName};");
            File.WriteAllLines(_path + filename + ".vhd", result);
        }

        static void GenerateAllSubstitutionTables()
        {
            GenerateSubstitutionTable(SBox.AesSbox, "INPUT", "OUTPUT", entityName: "Sbox", architectureName: "Sbox_architecture");
            GenerateSubstitutionTable(SBox.AesSboxInv);
            GenerateSubstitutionTable(SBox.Des1, entityName: "DES1_Sbox", architectureName: "DES1_Sbox_architecture");
            GenerateSubstitutionTable(SBox.Des2, entityName: "DES2_Sbox", architectureName: "DES2_Sbox_architecture");
            GenerateSubstitutionTable(SBox.Des3, entityName: "DES3_Sbox", architectureName: "DES3_Sbox_architecture");
            GenerateSubstitutionTable(SBox.Des4, entityName: "DES4_Sbox", architectureName: "DES4_Sbox_architecture");
            GenerateSubstitutionTable(SBox.Des5, entityName: "DES5_Sbox", architectureName: "DES5_Sbox_architecture");
            GenerateSubstitutionTable(SBox.Des6, entityName: "DES6_Sbox", architectureName: "DES6_Sbox_architecture");
            GenerateSubstitutionTable(SBox.Des7, entityName: "DES7_Sbox", architectureName: "DES7_Sbox_architecture");
            GenerateSubstitutionTable(SBox.Des8, entityName: "DES8_Sbox", architectureName: "DES8_Sbox_architecture");
        }

        static List<string> InitSBoxHeader(
            string switchVariable = "SWITCH_PLACEHOLDER",
            string entityName = "ENTITY_NAME",
            string architectureName = "ARCHITECTURE_NAME")
        {
            var result = new List<string>();
            result.Add("library IEEE;\nuse IEEE.STD_LOGIC_1164.all;\n");
            result.Add($"entity {entityName} is");
            result.Add($"port (");
            result.Add($"\tINPUT : in std_logic_vector(7 downto 0);");
            result.Add($"\tOUTPUT: out std_logic_vector(7 downto 0));");
            result.Add($"end {entityName};\n");
            result.Add($"architecture {architectureName} of {entityName} is");
            result.Add("begin");
            result.Add("process (INPUT)");
            result.Add("begin");
            result.Add($"\tcase {switchVariable} is");
            return result;
        }

        #endregion

        #region "Permutation tables"

        static List<string> InitPermutationTableHeader(
            int inputBits,
            int outputBits,
            string entityName = "ENTITY_NAME",
            string architectureName = "ARCHITECTURE_NAME")
        {
            var result = new List<string>();
            result.Add("library IEEE;\nuse IEEE.STD_LOGIC_1164.all;\n");
            result.Add($"entity {entityName} is");
            result.Add($"port (");
            result.Add($"\tINPUT : in std_logic_vector(1 to {inputBits});");
            result.Add($"\tOUTPUT: out std_logic_vector(1 to {outputBits}));");
            result.Add($"end {entityName};\n");
            result.Add($"architecture {architectureName} of {entityName} is");
            result.Add("begin");
            return result;
        }


        static void GeneratePermutationTable(
            PermutationTable table,
            string entityName = "ENTITY_NAME",
            string architectureName = "ARCHITECTURE_NAME")
        {
            switch (table) 
            {
                case PermutationTable.IP:
                    var ip = TableValues.IP();
                    var ipResult = InitPermutationTableHeader(64, 64, entityName, architectureName);
                    ipResult = GeneratePermutationTableAssignments(ip, ipResult);
                    ipResult.Add($"end {architectureName};");
                    File.WriteAllLines(_path + "IP.vhd", ipResult);
                    break;
                case PermutationTable.IPInv:
                    var ipInv = TableValues.IPInv();
                    var ipInvResult = InitPermutationTableHeader(64, 64, entityName, architectureName);
                    ipInvResult = GeneratePermutationTableAssignments(ipInv, ipInvResult);
                    ipInvResult.Add($"end {architectureName};");
                    File.WriteAllLines(_path + "IPInv.vhd", ipInvResult);
                    break;
                case PermutationTable.P:
                    var p = TableValues.P();
                    var pResult = InitPermutationTableHeader(32, 32, entityName, architectureName);
                    pResult = GeneratePermutationTableAssignments(p, pResult);
                    pResult.Add($"end {architectureName};");
                    File.WriteAllLines(_path + "P.vhd", pResult);
                    break;
                case PermutationTable.PC1:
                    var pc1 = TableValues.PC1();
                    var pc1Result = InitPermutationTableHeader(64, 56, entityName, architectureName);
                    pc1Result = GeneratePermutationTableAssignments(pc1, pc1Result);
                    pc1Result.Add($"end {architectureName};");
                    File.WriteAllLines(_path + "PC1.vhd", pc1Result);
                    break;
                case PermutationTable.PC2:
                    var pc2 = TableValues.PC2();
                    var pc2Result = InitPermutationTableHeader(56, 48, entityName, architectureName);
                    pc2Result = GeneratePermutationTableAssignments(pc2, pc2Result);
                    pc2Result.Add($"end {architectureName};");
                    File.WriteAllLines(_path + "PC2.vhd", pc2Result);
                    break;
            }
        }

        static List<string> GeneratePermutationTableAssignments(List<List<int>> table, List<string> text)
        {
            int counter = 1;
            foreach (var row in table)
            {
                foreach (int value in row)
                {
                    text.Add($"\tOUTPUT({counter++}) <= INPUT({value});");
                }
            }

            return text;
        }

        static void GenerateAllPermutationTables()
        {
            GeneratePermutationTable(PermutationTable.IP, "IPtable", "IPtable_architecture");
            GeneratePermutationTable(PermutationTable.IPInv, "IPtableInv", "IPtableInv_architecture");
            GeneratePermutationTable(PermutationTable.P, "Ptable", "Ptable_architecture");
            GeneratePermutationTable(PermutationTable.PC1, "PC1table", "PC1table_architecture");
            GeneratePermutationTable(PermutationTable.PC2, "PC2table", "PC2table_architecture");
        }

        #endregion

        #region "Shift rows"

        static void GenerateShiftRows(
            string entityName = "ENTITY_NAME",
            string architectureName = "ARCHITECTURE_NAME")
        {
            var result = new List<string>();
            result.Add("library IEEE;\nuse IEEE.STD_LOGIC_1164.all;\n");
            result.Add($"entity {entityName} is");
            result.Add($"port (");
            result.Add($"\tINPUT : in std_logic_vector(0 to 127);");
            result.Add($"\tOUTPUT: out std_logic_vector(0 to 127));");
            result.Add($"end {entityName};\n");
            result.Add($"architecture {architectureName} of {entityName} is");
            result.Add("begin");
            var mapping = GetShiftRowsMapping();

            for (int i = 0; i < 16; i++)
            {
                for (int bytePosition = 0; bytePosition < 8; bytePosition++)
                {
                    result.Add($"\tOUTPUT({(mapping[i][1] * 8) + bytePosition}) <= INPUT({(i * 8) + bytePosition});");
                }
            }

            result.Add($"end {architectureName};");
            File.WriteAllLines(_path + "ShiftRows.vhd", result);
        }

        static List<int[]> GetShiftRowsMapping()
        {
            var result = new List<int[]>();
            result.Add(new int[] { 0, 0 });
            result.Add(new int[] { 1, 13 });
            result.Add(new int[] { 2, 10 });
            result.Add(new int[] { 3, 7 });
            result.Add(new int[] { 4, 4 });
            result.Add(new int[] { 5, 1 });
            result.Add(new int[] { 6, 14 });
            result.Add(new int[] { 7, 11 });
            result.Add(new int[] { 8, 8 });
            result.Add(new int[] { 9, 5 });
            result.Add(new int[] { 10, 2 });
            result.Add(new int[] { 11, 15 });
            result.Add(new int[] { 12, 12 });
            result.Add(new int[] { 13, 9 });
            result.Add(new int[] { 14, 6 });
            result.Add(new int[] { 15, 3 });
            return result;
        }
        
        static string GetBinaryValue(int number, int totalChars)
        {
            string result = Convert.ToString(number, 2);
            int zeroesToAdd = totalChars - result.Length;
            for (int i = 0; i < zeroesToAdd; i++)
            {
                result = "0" + result;
            }

            return result;
        }

        #endregion

        #region "AES function g"

        static void GenerateAesFunctionGShift(
            string entityName = "ENTITY_NAME",
            string architectureName = "ARCHITECTURE_NAME")
        {
            var result = new List<string>();
            result.Add("library IEEE;\nuse IEEE.STD_LOGIC_1164.all;\n");
            result.Add($"entity {entityName} is");
            result.Add($"port (");
            result.Add($"\tINPUT : in std_logic_vector(0 to 31);");
            result.Add($"\tOUTPUT: out std_logic_vector(0 to 31);");
            result.Add($"end {entityName};\n");
            result.Add($"architecture {architectureName} of {entityName} is");
            result.Add("begin");
            for (int i = 0; i < 8; i++)
            {
                result.Add($"\tOUTPUT({i}) <= INPUT({i + 24});");
            }

            for (int i = 0; i < 24; i++)
            {
                result.Add($"\tOUTPUT({i + 8}) <= INPUT({i});");
            }

            result.Add($"end {architectureName};");
            File.WriteAllLines(_path + "AesFunctionGShift.vhd", result);
        }

        #endregion

        static void GenerateXor(
            int bits,
            string filename,
            string entityName = "ENTITY_NAME",
            string architectureName = "ARCHITECTURE_NAME")
        {
            var result = new List<string>();
            result.Add("library IEEE;\nuse IEEE.STD_LOGIC_1164.all;\n");
            result.Add($"entity {entityName} is");
            result.Add($"port (");
            result.Add($"\tINPUT1 : in std_logic_vector(0 to {bits - 1});");
            result.Add($"\tINPUT2 : in std_logic_vector(0 to {bits - 1});");
            result.Add($"\tOUTPUT: out std_logic_vector(0 to {bits - 1});");
            result.Add($"end {entityName};\n");
            result.Add($"architecture {architectureName} of {entityName} is");
            result.Add("begin");
            for (int i = 0; i < bits; i++)
            {
                result.Add($"\tOUTPUT({i}) <= INPUT1({i}) XOR INPUT2({i});");
            }

            result.Add($"end {architectureName};");
            File.WriteAllLines(_path + filename + ".vhd", result);
        }

        static void Main(string[] args)
        {
            GenerateShiftRows("ShiftRows", "ShiftRows_architecture");
            GenerateXor(32, "AesFunctionGXor");
            GenerateAesFunctionGShift();
            GenerateAllSubstitutionTables();
            GenerateAllPermutationTables();
            Console.WriteLine("Done");
        }
    }
}

