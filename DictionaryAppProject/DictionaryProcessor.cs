using System;
using System.Threading.Tasks;

namespace DictionaryAppProject
{
    public class DictionaryProcessor
    {
        private ILanguageValidator languageValidator;
        private ILogger logger;
        private IAPIRequests apiRequests;
        private IAPIRunner apiRunner;

        public DictionaryProcessor(
                                    ILanguageValidator languageValidator,
                                    ILogger logger,
                                    IAPIRequests apiRequests,
                                    IAPIRunner apiRunner)
        {
            this.languageValidator = languageValidator;
            this.logger = logger;
            this.apiRequests = apiRequests;
            this.apiRunner = apiRunner;
        }

        public async Task Process()
        {
            string word;
            int choice;

            logger.LogMessage(Messages.WelcomeMessage());

            while (true)
            {
                logger.LogMessage(Messages.Menu());
                logger.LogMessage(Messages.InputMessage());

                word = Console.ReadLine();
                word = word.Trim().ToLower();

                try
                {
                    if (!languageValidator.isValid(word))
                    {
                        throw new ArgumentException();
                    }

                    logger.LogMessage(Messages.ChoiceMessage());
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            await apiRunner.GetMeanings(word);
                            break;
                        case 2:
                            await apiRunner.GetSynonyms(word);
                            break;
                        case 3:
                            await apiRunner.GetAntonyms(word);
                            break;
                        case 4:
                            await apiRunner.GetAll(word);
                            break;
                        case 5:
                            logger.LogMessage(Messages.ExitMessage());
                            Environment.Exit(0);
                            break;
                        default:
                            logger.LogError(Messages.InvalidChoice());
                            break;
                    }
                }
                catch (ArgumentException)
                {
                    logger.LogError(Messages.InvalidArgument());
                }
                catch (FormatException)
                {
                    logger.LogError(Messages.InvalidChoice());
                }
                catch (WordNotFoundException ex)
                {
                    logger.LogError(ex.Message);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }

                logger.LogMessage(Messages.TryAgain());
                string tryAgain = Console.ReadLine().ToUpper();

                if(!tryAgain.Equals("Y"))
                {
                    logger.LogMessage(Messages.ExitMessage());
                    break;
                }
            }
        }
    }
}
