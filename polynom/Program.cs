using System;


namespace polynom
{

    class Polynomial
    {
      private   int m;
      private double[] c;
     

        public Polynomial(int m,double[] c)
        {
            
            this.m = m;
            this.c = new double[m];
            for(int i = 0; i < m; ++i)
            {
                this.c[i] = c[i];
            }
        }
        public Polynomial()
        {

            this.m = 1;
            this.c = new double[m];
            this.c[0] = 0;
        }

        public Polynomial Plus(Polynomial a)
        {
            
            if (m == a.m)
            {
                double[] res = new double[m];
                for (int i = 0; i < m; ++i)
                {
                    res[i] = this.c[i] + a.c[i];
                }
                return new Polynomial(m, res);
            
            }

            return new Polynomial();
        }

        public Polynomial Minus(Polynomial a)
        {

            if (m == a.m)
            {
                double[] res = new double[m];
                for (int i = 0; i < m; ++i)
                {
                    res[i] = this.c[i] - a.c[i];
                }
                return new Polynomial(m, res);

            }

            return new Polynomial();
        }

        public Polynomial Subtraction(Polynomial a)
        {
           int length = (c.Length >= a.c.Length ? c.Length : a.c.Length);
            double[] res = new double[length];
            for (int i = 0; i < (c.Length < a.c.Length ? c.Length : a.c.Length); i++)
            {
                res[i] = c[i] - a.c[i];
            }
            double[] r = c.Length > a.c.Length ? c : a.c;
            for (int i = (c.Length < a.c.Length ? c.Length : a.c.Length) - 1; i < r.Length; i++)
            {
                if (c.Length > a.c.Length)
                    res[i] = r[i];
                else if (c.Length < a.c.Length)
                    res[i] = -r[i];
            }
            return new Polynomial(length, res);
        }

        public Polynomial Parse(string str)
        {
            
            string[] subs = str.Split("+");
            double[] res = new double[subs.Length];
            res[0] = Convert.ToDouble(subs[0]);
            for (int i = 1; i < subs.Length; ++i)
            {
                res[i] = Convert.ToDouble((subs[i].Split("x"))[0]);
            }
            return new Polynomial(subs.Length, res);
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < m; ++i)
            {
                str += $"{c[i]}x^{i}+";
            }
            return str;
        }

        public double Polynome(double x)
        {
            double res = 0;
            for(int i = 0; i < m; ++i)
            {
                res += this.c[i] * Math.Pow(x, i);
            }
            return res;
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial a = new Polynomial();
            a = a.Parse("1+2x+3x^2");
            Console.WriteLine(a);

        }
    }
}
