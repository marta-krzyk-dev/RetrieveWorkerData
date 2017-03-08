namespace RetrieveWorkerData
{
 public static class StringExtensions
    {
        public static string WordsStartWithUpper(this string str)
        {
            //delete unnecessary whitespaces
            str = Regex.Replace(str, @"\s+", " ");

            //start each word with upper case
            TextInfo text_info = new CultureInfo("us-US", false).TextInfo;
            return text_info.ToTitleCase(str.ToLower());
             
        }

        public static string SurnameNameFormat(this string str)
        {
            //Get all the words in the string
            Regex regex = new Regex(@"\w+");
            //Capitalize each word
            return regex.Replace(str, new MatchEvaluator(StringExtensions.CapitalizeText));    
        }

        static string CapitalizeText(Match m)
        {
            string s = m.ToString().Trim();

            if (string.IsNullOrEmpty(s))
                return null;

            return char.ToUpper(s[0]) + s.Substring(1, s.Length - 1).ToLower();
        }

        public static string FirstLetterToUpper(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return null;

            string copy = String.Copy(str);

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1).ToLower();

            bool before_a_word = true;
            int i = 0;
            foreach(char c in str)
            {
                if (char.IsLetterOrDigit(c) && before_a_word)
                    copy += char.ToUpper(str[i]);
                
                return char.ToUpper(str[0]) + str.Substring(1).ToLower();
            }

            return str.ToUpper();
        }

        public static string NameSurnameToUpper(this string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1).ToLower();

            return str.ToUpper();
        }

        public static int HasNumber(this string str)
        {
            return 0;
        }
    }
}
