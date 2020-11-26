using System;
using System.Numerics;

namespace KMISOIBI
{
    class DigitalSignature
    {
        public int Hash { get; }
        public int[] PrivateKey;
        public int[] PublicKey;
        private int s;
        private int h;

        public DigitalSignature(int hash, string privateKey, string publicKey)
        {
            Hash = hash;
            PrivateKey = Array.ConvertAll(privateKey.Split(' '), int.Parse);
            PublicKey = Array.ConvertAll(publicKey.Split(' '), int.Parse);
        }

        public int Encrypt()
        {
            return (int)BigInteger.ModPow(Hash, PrivateKey[0], PrivateKey[1]);
        }

        public int Decrypt()
        {
            h = (int)BigInteger.ModPow(s, PublicKey[0], PublicKey[1]);

            return h;
        }
    }
}
