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

        public Fraction(long x, long y=1)
        {
            Numerator = x;
            Denominator = y;
            long gcd = GCD(x, y);
            Numerator /= gcd;
            Denominator /= gcd;
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
            return Numerator + " " + Denominator;
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

        private static long GCD(long x, long y)
        {
            if(x==y) return x;
            if (x >= y) return GCD(x - y, y);
            else return GCD(x, y - x);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fraction x = new Fraction(3);
            Fraction y = new Fraction(6, 2);

            Console.Write((x == y) +" "+x*y+" ");
        }
    }
}
