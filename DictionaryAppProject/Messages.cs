namespace DictionaryAppProject
{
    public static class Messages
    {
        public static string WelcomeMessage()
        {
            return "MERRIAM-WEBSTER'S DICTIONARY\nAPI: https://dictionaryapi.com/";
        }
        public static string Menu()
        {
            return "\n1. Meaning\t2. Synonym\n3. Antonym\t4. All\n5. Exit";
        }

        public static string InputMessage()
        {
            return "\nEnter the word: ";
        }

        public static string ChoiceMessage()
        {
            return "\nEnter your choice: ";
        }

        public static string InvalidArgument()
        {
            return "The word you entered is not valid!";
        }

        public static string InvalidChoice()
        {
            return "Invalid choice!";
        }

        public static string TryAgain()
        {
            return "Do you want to try again? [Y/N]: ";
        }

        public static string ExitMessage()
        {
            return "Thank you for using the Application";
        }
    }
}
