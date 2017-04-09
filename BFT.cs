using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace 战绩追踪_C_Sharp
{
    class BFT
    {
        private static string game = "tunguska", Wfilename = "WeaponsTranslate.txt", Vfilename = "VehiclesTranslate.txt";

        [DllImport("BFT C++ DLL.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private unsafe extern static void BFT_CPP_CALL(char* input, char* output, int outputSize);

        private static string GetCommandStr(string ID, string stats)
        {
            string command = "STATS=";
            command += stats;
            command += " GAME=" + game + " ID=" + ID;
            return command;
        }

        private static string GetCommandStr(string ID, string stats, string translatefilename)
        {
            string command = "STATS=";
            command += stats;
            command += " GAME=" + game + " ID=" + ID + " TRANSLATEFILE=" + translatefilename;
            return command;
        }

        private static string[] GetLines(string origin, int inputSize)
        {
            var rv = new string[inputSize];
            string temp = "";
            int arrayIndex = 0;

            for (int i = 0; i < origin.Length; i++)
            {
                if (origin[i] != '\n') { temp += origin[i]; continue; }
                rv[arrayIndex] = temp;
                arrayIndex++;
                temp = "";
            }
            if (temp != "") rv[arrayIndex] = temp;

            return rv;
        }

        private static unsafe string[] GetStats(string ID, string stats, int inputSize, int resultSize)
        {
            string command = GetCommandStr(ID, stats);
            var res = new char[resultSize];
            fixed (char* input = &(command.ToCharArray()[0]), output = (&res[0]))
            {
                BFT_CPP_CALL(input, output, resultSize);
                var temp = GetLines(new string(output), inputSize);
                int tempRealSize = 0;
                for (; tempRealSize < temp.Length; tempRealSize++)
                {
                    if (temp[tempRealSize] == null) break;
                }
                var rv = new string[tempRealSize];
                for (int j = 0; j < rv.Length && j < tempRealSize; j++)
                {
                    rv[j] = temp[j];
                }
                return rv;
            }
        }

        private static unsafe string[] GetStats(string ID, string stats, string translatefilename, int inputSize, int resultSize)
        {
            string command = GetCommandStr(ID, stats, translatefilename);
            var res = new char[resultSize];
            fixed (char* input = &(command.ToCharArray()[0]), output = (&res[0]))
            {
                BFT_CPP_CALL(input, output, resultSize);
                var temp = GetLines(new string(output), inputSize);
                int tempRealSize = 0;
                for (; tempRealSize < temp.Length; tempRealSize++)
                {
                    if (temp[tempRealSize] == null) break;
                }
                var rv = new string[tempRealSize];
                for(int j = 0; j < rv.Length && j < tempRealSize; j++)
                {
                    rv[j] = temp[j];
                }
                return rv;
            }            
        }

        public static string[] GetBasicStats(string ID)
        {
            return GetStats(ID, "BasicStats", 11, 2048);
        }

        public static string[] GetDetailedStats(string ID)
        {
            return GetStats(ID, "DetailedStats", 40, 2048);
        }

        public static string[] GetWeaponsStats(string ID)
        {
            return GetStats(ID, "Weapons", Wfilename, 1500, 100000);
        }

        public static string[] GetVehiclesStats(string ID)
        {
            return GetStats(ID, "Vehicles", Vfilename, 372, 10000);
        }

        public static string[] GetKitRanks(string ID)
        {
            return GetStats(ID, "KitRanks", 7, 2048);
        }

        public static string[] GetDogTagImg(string ID)
        {
            return GetStats(ID, "DogTagImg", 2, 2048);
        }
    }
}
