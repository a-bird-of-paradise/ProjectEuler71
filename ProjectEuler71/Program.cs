using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler71
{

    class Fraction : Object
    {
        private long Numerator;
        private long Denominator;

        public Fraction(long x, long y = 1)
        {
            Numerator = x;
            Denominator = y;
            if (x == 0)
            {
                y = 0;
            }
            else
            {
                long gcd = GCD(x, y);
                Numerator /= gcd;
                Denominator /= gcd;
            }
        }

        public override bool Equals(Object obj)
        {
            Fraction personObj = obj as Fraction;
            if (personObj == null)
                return false;
            else
                return this == (Fraction)obj;
        }

        public override int GetHashCode()
        {
            return (int)(Numerator + Denominator);
        }

        public override string ToString()
        {
            return "[" + Numerator + "/" + Denominator + "]";
        }

        public static bool operator ==(Fraction one, Fraction two)
        {
            return one.Numerator == two.Numerator && one.Denominator == two.Denominator;
        }

        public static bool operator !=(Fraction one, Fraction two)
        {
            return one.Numerator != two.Numerator || one.Denominator != two.Denominator;
        }

        public static bool operator >(Fraction one, Fraction two)
        {
            return one.Numerator * two.Denominator > one.Denominator * two.Numerator;
        }

        public static bool operator <(Fraction one, Fraction two)
        {
            return one.Numerator * two.Denominator < one.Denominator * two.Numerator;
        }

        public static bool operator >=(Fraction one, Fraction two)
        {
            return one.Numerator * two.Denominator >= one.Denominator * two.Numerator;
        }

        public static bool operator <=(Fraction one, Fraction two)
        {
            return one.Numerator * two.Denominator <= one.Denominator * two.Numerator;
        }

        public static Fraction operator +(Fraction x, Fraction y)
        {
            return new Fraction(x.Numerator * y.Denominator + x.Denominator * y.Numerator, x.Denominator * y.Denominator);
        }

        public static Fraction operator -(Fraction x, Fraction y)
        {
            return new Fraction(x.Numerator * y.Denominator - x.Denominator * y.Numerator, x.Denominator * y.Denominator);
        }

        public static Fraction operator *(Fraction x, Fraction y)
        {
            return new Fraction(x.Numerator * y.Numerator, x.Denominator * y.Denominator);
        }

        public static Fraction operator /(Fraction x, Fraction y)
        {
            return new Fraction(x.Numerator * y.Denominator, x.Denominator * y.Numerator);
        }

        public long GCD(long n, long m)
        {
            if (m <= n && n % m == 0)
                return m;
            if (n < m)
                return GCD(m, n);
            return GCD(m, n % m);
        }     
    }    

    class Program
    {
        static void Main(string[] args)
        {
            Fraction max = new Fraction(3, 7);

            Fraction Candidate;
            Fraction Largest = new Fraction(1, 1000);
            for (int d = 8; d <= 1000000; d++)
            {
                Candidate = new Fraction(3*d/7, d);
                if (Candidate == max) continue;
                if (Candidate > Largest)
                {
                    Largest = Candidate;
                }
            }
            Console.WriteLine(Largest);
        }
    }
}
