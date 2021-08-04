namespace DictionaryAppProject
{
    public class EnglishValidator : ILanguageValidator
    {
        public bool isValid(string word)
        {
            if (word.Length == 0)
            {
                return false;
            }
            char[] s = word.ToCharArray();

            foreach (char c in s)
            {
                if ((c < 'a' || c > 'z') && c != '-')
                    return false;
            }

            return true;
        }
    }
}
