using System.ComponentModel.Design;
using System.Data;
using System.Runtime.CompilerServices;

namespace RockPaperScissorsGame
{

    public class Game
    {
        private int _playerScore = 0;
        private int _computerScore = 0;

        private bool _quit = false;

        public void Start()
        {
            while (!_quit)
            {
                Console.WriteLine($"Score: Player1 :{_playerScore} | COmputer: {_computerScore}");
                Console.WriteLine("Choose your option: ");
                Console.WriteLine("1. Rock");
                Console.WriteLine("2. Paper");
                Console.WriteLine("2. Scissors");
                int userOption;
                try
                {
                    userOption = GetUserInput();
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return;
                }
                int computerResponse = GenerateComputerResponse();

                Console.WriteLine($"You chose {(Option) userOption}, computer chose {(Option) computerResponse}");

                var gameResult = EvaluateOptions((Option)userOption, (Option) computerResponse);

                UpdateScore(gameResult);

                DisplayEndGameMessage(gameResult);

                PlayAgain();
            }
        }
        private static int GetUserInput()
        {
            var userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out var userOption))
            {
                throw new InvalidUserInputException("Input was not numeric");
            }
            return userOption;
        }

        private int GenerateComputerResponse()
        {
            var random = new Random();
            return random.Next(1, 3);
        }

        private static Result EvaluateOptions(Option userOption, Option computerOption)
        {
            if (userOption == computerOption) return Result.Draw;
            
            if(userOption == Option.Rock)
            {
                return computerOption == Option.Paper ? Result.Loss : Result.Win;
            }
            else if(userOption == Option.Paper)
            {
                return computerOption == Option.Scissors ? Result.Loss : Result.Win;
            }
            else
            {
                return computerOption == Option.Rock ? Result.Loss : Result.Win;
            }
        }

        private void UpdateScore(Result gameResult)
        {
            if(gameResult == Result.Win)
            {
                _playerScore++;
            }
            else if(gameResult == Result.Loss)
            {
                _playerScore++;
            }
        }

        private static void DisplayEndGameMessage(Result gameResult)
        {
            if(gameResult == Result.Win)
            {
                Console.WriteLine("You Won!");
            }
            else if(gameResult == Result.Draw)
            {
                Console.WriteLine("Draw!");
            }
            else
            {
                Console.WriteLine("You lost");
            }
        }
        private void PlayAgain()
        {
            Console.WriteLine("Play again? (y/n):");
            var playAgainResponse = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(playAgainResponse) || string.Equals(playAgainResponse, "n", StringComparison.OrdinalIgnoreCase))
            {
                _quit = true;
                Console.WriteLine($"Final Score: Player: {_playerScore}, Computer: {_computerScore}");
            }
        }

    }
}