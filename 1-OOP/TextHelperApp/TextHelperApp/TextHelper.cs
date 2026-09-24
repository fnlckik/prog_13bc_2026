namespace TextHelperApp
{
    public class TextHelper
    {
        // palindrom: "indul a görög aludni"
        // "racecar", "level", "kék"
        public bool IsPalindrome(string s)
        {
            s = s.Replace(" ", "").ToUpper();
            string reversed = String.Join("", s.Reverse());
            return s == reversed;
        }

        public string FirstWithE(string[] words)
        {
            return words.First(w => w.ToUpper().Contains("E"));
        }
    }
}
