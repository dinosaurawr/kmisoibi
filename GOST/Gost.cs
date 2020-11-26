using System;
using System.Text;

namespace KMISOIBI
{
    class Gost
    {
        private string Message;
        private string Key;

        private readonly int[,] SubstituteTable = new int[,]
        {
            { 1, 13, 4, 6, 7, 5, 14, 4 },
            { 15, 11, 11, 12, 13, 8, 11, 10 },
            { 13, 4, 10, 7, 10, 4, 4, 9 },
            { 0, 1, 0, 1, 1, 13, 12, 2 },
            { 5, 3, 7, 5, 0, 10, 6, 13 },
            { 7, 15, 2, 15, 8, 3, 13, 8 },
            { 10, 5, 1, 13, 9, 4, 15, 0 },
            { 4, 9, 13, 8, 15, 2, 10, 14 },
            { 9, 0, 3, 4, 14, 14, 2, 6 },
            { 2, 10, 6, 10, 4, 15, 3, 11 },
            { 3, 14, 8, 9, 6, 12, 8, 1 },
            { 14, 7, 5, 14, 12, 7, 1, 12 },
            { 6, 6, 9, 0, 11, 6, 0, 7 },
            { 11, 8, 12, 3, 2, 0, 7, 15 },
            { 8, 2, 15, 11, 5, 9, 5, 5 },
            { 12, 12, 14, 2, 3, 11, 9, 3 }
        };

        public string LeftPart, RightPart, KeyX0, RightWithKey, Substituted, Shifted, Result;
        public Gost(string message, string key)
        {
            Message = message;
            Key = key;

            RightPart = Utills.StickedBinaryMsg(Message.Substring(Message.Length / 2, Message.Length / 2));
            LeftPart = Utills.StickedBinaryMsg(Message.Substring(0, Message.Length / 2));

            KeyX0 = Utills.StickedBinaryMsg(Key);

            RightWithKey = Utills.Modulo2Pow32(RightPart, KeyX0);

            Substituted = SubstituteElements(RightWithKey);

            Shifted = Utills.Shift(Substituted, -11);

            Result = Utills.Modulo2(LeftPart, Shifted);
        }

        private string SubstituteElements(string str)
        {
            StringBuilder substitutedStr = new StringBuilder();
            string[] blocks = Utills.BinaryFormat(str, 4).Split(' ');
            int col = 0;
            int row;
            foreach (var b in blocks)
            {
                row = Convert.ToInt32(b, 2);
                substitutedStr.Append(Utills.BinaryFormat(Convert.ToString(SubstituteTable[row, col], 2), 4));
                col++;
            }
            return substitutedStr.ToString();
        }
    }
}
