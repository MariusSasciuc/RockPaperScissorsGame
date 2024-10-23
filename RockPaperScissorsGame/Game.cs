using System.Data;
using System.Runtime.CompilerServices;

namespace RockPaperScissorsGame;

    public class Game
    {
        private int _playerScore =0;
        private int _computerScore = 0;

        private bool _quit = false;

        public void Start()
        {  
            while(!_quit)
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

    }

