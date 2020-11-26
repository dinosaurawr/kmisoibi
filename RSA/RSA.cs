using System;
using System.Numerics;

namespace KMISOIBI
{
    class RSA
    {
        string Message, EncryptedMessage, DecryptedMessage;
        public int P { get; }
        public int Q { get; }
        public int D { get; }
        public int N { get; }
        public int Phi { get; }
        public int E { get; }

        public string PublicKey => $"({E}, {N})";
        public string PrivateKey => $"({D}, {N})";

        public RSA(string message, int p, int q, int d)
        {
            Message = message;
            P = p;
            Q = q;
            D = d;

            N = p * q;
            Phi = (p - 1) * (q - 1);

            E = FindE();
        }

        public string Encrypt()
        {
            var maxCharCode = 0;
            foreach(var ch in Message)
            {
                int charIndex = Alphabet.GetCharCodeRSA(ch);
                maxCharCode = charIndex > maxCharCode ? charIndex : maxCharCode;
                if (maxCharCode >= N) throw new Exception($"Индекс буквы {Alphabet.GetCharRSA(maxCharCode)} = {maxCharCode} больше/равно n = {N}");
                var res = BigInteger.ModPow(charIndex, E, N);
                EncryptedMessage += res + " ";
            }
            return EncryptedMessage;
        }

        public string Decrypt()
        {
            foreach (var ch in EncryptedMessage.Trim().Split(' '))
            {
                var res = BigInteger.ModPow(int.Parse(ch), D, N);
                DecryptedMessage += Alphabet.GetCharRSA(((int)res + N) % N);
            }
            return DecryptedMessage;
        }

        private int FindE()
        {
            int e = 0;
            while ((D * e - 1) % Phi != 0)
            {
                e++;
            }
            return e;
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
