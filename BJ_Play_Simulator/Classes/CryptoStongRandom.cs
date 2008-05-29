using System;
using System.Security.Cryptography;

public class CryptoStongRandom
{
    RNGCryptoServiceProvider RNG;
    public CryptoStongRandom()
    {
        RNG = new RNGCryptoServiceProvider();
    }
    public int Next(int maxValue)
    {
        Byte[] randBytes = new Byte[4];
        int rand;
        int tries = 0;
        int result = 0;
        //need get and check maximum rand value to prevent modulo bias
        int maxrand = int.MaxValue - (int.MaxValue % maxValue);
        while (result == 0 && tries < 100)
        {
            RNG.GetBytes(randBytes);
            rand = Math.Abs(BitConverter.ToInt32(randBytes, 0));
            if (rand <= maxrand)
                result = rand % maxValue;
            tries++;
        }
        if (tries == 100)
            throw new TimeoutException("Error in the random number generator");

        return result;
    }
}