namespace CalculatorApp
{
    public class Calculator
    {
        public int Square(int n)
        {
            return n * n;
        }

        public bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Divide(int a, int b)
        {
            if (b == 0) throw new DivideByZeroException("Nem lehet 0-val osztani.");
            return a / b;
        }

        public bool IsAdult(int age)
        {
            if (age < 0 || age > 150) throw new ArgumentOutOfRangeException("Nem jó életkor.");
            return age >= 18;
        }
    }
}
