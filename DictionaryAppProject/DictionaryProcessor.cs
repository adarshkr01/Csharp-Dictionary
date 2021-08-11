using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DictionaryAppProject
{
    public class DictionaryProcessor
    {
        private ILanguageValidator _languageValidator;
        private ILogger _logger;
        private IAPIRunner _apiRunner;

        public DictionaryProcessor(
                                    ILanguageValidator languageValidator,
                                    ILogger logger,
                                    IAPIRunner apiRunner)
        {
            _languageValidator = languageValidator;
            _logger = logger;
            _apiRunner = apiRunner;
        }

        public async Task Process()
        {
            string word;
            int choice;

            _logger.LogMessage(Messages.WelcomeMessage());

            while (true)
            {
                _logger.LogMessage(Messages.Menu());
                _logger.LogMessage(Messages.InputMessage());

                word = Console.ReadLine();
                word = word.Trim().ToLower();

                try
                {
                    if (!_languageValidator.isValid(word))
                    {
                        throw new ArgumentException();
                    }

                    Task fetchAPIData = Task.Run(() => _apiRunner.MakeCalls(word));

                    _logger.LogMessage(Messages.ChoiceMessage());
                    choice = Convert.ToInt32(Console.ReadLine());


                    switch (choice)
                    {
                        case 1:
                            await fetchAPIData;
                            _apiRunner.GetMeanings();
                            break;
                        case 2:
                            await fetchAPIData;
                            _apiRunner.GetSynonyms();
                            break;
                        case 3:
                            await fetchAPIData;
                            _apiRunner.GetAntonyms();
                            break;
                        case 4:
                            await fetchAPIData;
                            _apiRunner.GetAll();
                            break;
                        case 5:
                            _logger.LogMessage(Messages.ExitMessage());
                            Environment.Exit(0);
                            break;
                        default:
                            _logger.LogError(Messages.InvalidChoice());
                            break;
                    }
                }
                catch (ArgumentException)
                {
                    _logger.LogError(Messages.InvalidArgument());
                }
                catch (FormatException)
                {
                    _logger.LogError(Messages.InvalidChoice());
                }
                catch (WordNotFoundException ex)
                {
                    _logger.LogError(ex.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

                _logger.LogMessage(Messages.TryAgain());
                string tryAgain = Console.ReadLine().ToUpper();

                if(!tryAgain.Equals("Y"))
                {
                    _logger.LogMessage(Messages.ExitMessage());
                    break;
                }
            }
        }
    }
}
