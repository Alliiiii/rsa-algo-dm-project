using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace RSA_Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            int p = 7;
            int q = 11;
            while (p >= q)
            {
                q = randomGenertor();
            }
            int n = p * q;
            int phi = (p - 1) * (q - 1);

            int e = 17;
            while (e == p || e == q || e > phi || e < 3 || gcd(e, phi) != 1)
            {
                e++;
            }
            int checkd = D(phi, e);
            Console.WriteLine("p={0} ,q={1} ,e={2} ,phi={3}", p, q, e, phi);
            Console.WriteLine("D= "+D(+phi,e));
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine(encript(e, n));

            Console.WriteLine(decript(D(phi, e), n));

        }

        static double c;
        //Encript
        public static BigInteger encript(int e, int n)
        {
             c= (Math.Pow(1545, Convert.ToDouble(e))) % n;
             return Int64.Parse(c.ToString());
        }

        //Decript

        public static BigInteger decript(int d, int n)
        {
            BigInteger x=int.Parse(( ((Math.Pow(c, 37)) % n).ToString()));
            Console.WriteLine("------------" + x + "------------");
            return x; 
        }

        //Random Generator
        public static int randomGenertor()
        {

            bool isPrime = true;
            while (true)
            {
                Random rnd = new Random();
                int i = rnd.Next(1, 10);
                for (int j = 2; j <= i; j++)
                {

                    if (i != j && i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }

                }
                if (isPrime)
                {
                    return i;
                }
                isPrime = true;
            }
        }

        //GCD
        public static int gcd(int a, int b)
        {
            while (b != 0)
            {
                int c = a % b;
                a = b;
                b = c;
            }
            return a;

        }

        //D
        public static int D(int phi, int e)
        {
            int d = 1;
            while ((d * e) % phi != 1)
            {
                d++;
            }
            return d;
        }
    }

}