namespace RetrieveWorkerData
{
    public static worker FindWorkerDataInString(string text)
        {
            //Replace every "_" with " " to distinguish words
            text = Regex.Replace(text, "_", " ");

            //Find first name, surname and a number in string
            Regex regex = new Regex(@"(?i)"+ //Ignore case
                @"(?<name>\w[A-Ząćęéèłńóśżź]+\w[-]?[A-Ząćęéèłńóśżź]*)[\s_-]+" +
                @"(?<surname>\w[-'A-Ząćęéèłńóśżź]+\w)\D*" + 
                @"(?<number>\d+)?");

            int number;
            var worker = new worker();

            var match = regex.Match(text); //Find pattern in the text

            //Save retrived data, make every word start with upper case
            worker.name = match.Groups["name"].Value.SurnameNameFormat();
            worker.surname = match.Groups["surname"].Value.SurnameNameFormat();

            //Try to get number of department 
            if (Int32.TryParse(match.Groups["number"].Value, out number)
                && number > 0)
                    worker.dep_no = number;

            return worker;
        }
   }
