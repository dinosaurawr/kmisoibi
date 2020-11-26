using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KMISOIBI
{
    class HashFunction
    {
        private string Message;
        public int P { get; }
        public int Q { get; }
        public int N { get; }
        public int H { get; }
        public HashFunction(string message, int p, int q, int h)
        {
            Message = message;
            P = p;
            Q = q;
            H = h;

            N = p * q;
        }

        private int ModulusByN(int a, int b) 
        {
            return (int)BigInteger.ModPow(a + b, 2, N);
        }

        public int Hash()
        {
            var hash = ModulusByN(H, Alphabet.GetCharCodeRSA(Message[0]));

            foreach(var ch in Message.Substring(1))
            {
                hash = ModulusByN(hash, Alphabet.GetCharCodeRSA(ch));
            }
            return hash;
        }
    }
}
