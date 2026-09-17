using System.Globalization;

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

        /*
            return n switch
            {
                1 => "elégtelen",
                _ => throw new ArgumentException()
            };
         */
        public string GetGrade(int n)
        {
            if (n < 1 || n > 5) throw new ArgumentException("Nincs ilyen jegy.");
            string[] grades = ["elégtelen", "elégséges", "közepes", "jó", "jeles"];
            return grades[n - 1];

            /*
            if (grade == 1) return "elégtelen";
            else if (grade == 2) return "elégséges";
            else if (grade == 3) return "közepes";
            else if (grade == 4) return "jó";
            else if (grade == 5) return "jeles";
            else throw new ArgumentException("Nincs ilyen jegy.");
            */
        }

        // 0-nál kisebb: "hideg"
        // 0 és 30 között: "normál"
        // 30 felett: "meleg"
        public string GetTemperatureType(int temp)
        {
            if (temp < 0) return "hideg";
            else if (temp > 30) return "meleg";
            else return "normál";
        }

        public bool CanPlayGTAVI(int age, bool hasGame)
        {
            if (IsAdult(age) && hasGame) return true;
            else return false;
            // return IsAdult(age) && hasGame
        }
    }
}
