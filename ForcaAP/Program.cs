using System.Reflection.Metadata.Ecma335;

namespace ForcaAP
{
    internal class Program
    {
        
        static void MainProgram()
        {
            Console.WriteLine("Jogo da Forca\n\n1.Jogar\n2.Sair");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                Game();
            } else if (answer == "2")
            {
                Environment.Exit(0);
            }
        }
        
        
        static void Game()
        {
            string chosenWord = Forca.WordSelector();

            char[] foundChars = new char[chosenWord.Length];

            for (int currentChar = 0; currentChar < foundChars.Length; currentChar++)
            {
                foundChars[currentChar] = '_';
            }


            int wrongGuesses = 0;
            bool rightGuessWord = false;
            bool gameOver = false;

            do
            {
                string finalFoundChars = string.Join("", foundChars);


                string headIcon = wrongGuesses >= 1 ? " 0 " : "";
                string bodyIcon = wrongGuesses >= 2 ? " X" : "";
                string body1Icon = wrongGuesses >= 2 ? " x " : "";
                string leftArmIcon = wrongGuesses >= 3 ? "/" : "";
                string rightArmIcon = wrongGuesses >= 4 ? " \\" : "";
                string legsIcon = wrongGuesses >= 5 ? "/ \\" : "";


                Console.Clear();
                Console.WriteLine("Jogo da Forca\n\n");
                Console.WriteLine(" ___________           ");
                Console.WriteLine(" |/        |           ");
                Console.WriteLine(" |        {0}          ", headIcon);
                Console.WriteLine(" |       {0}{1}{2}     ", leftArmIcon, bodyIcon, rightArmIcon);
                Console.WriteLine(" |        {0}          ", body1Icon);
                Console.WriteLine(" |        {0}          ", legsIcon);
                Console.WriteLine(" |                     ");
                Console.WriteLine(" |                     ");
                Console.WriteLine("_|____                 ");
                Console.WriteLine("Erros = " + wrongGuesses + "\n");
                Console.WriteLine("A Palavra É: " + finalFoundChars);


                Console.WriteLine("Digite uma letra:\n");
                string initialInput = Console.ReadLine()!.ToUpper();

                if (initialInput.Length > 1)
                {
                    Console.WriteLine("Informe apenas uma letra.");
                    continue;
                }

                char guess = initialInput[0];

                bool charWasFound = false;

                for (int charCounter = 0; charCounter < chosenWord.Length; charCounter++)
                {
                    char currentChar = chosenWord[charCounter];


                    if (guess == currentChar)
                    {
                        foundChars[charCounter] = currentChar;
                        charWasFound = true;

                    }

                }

                if (charWasFound == false)
                {
                    wrongGuesses++;
                }


                string fullWordFound = String.Join("", foundChars);

                rightGuessWord = fullWordFound == chosenWord;

                if (rightGuessWord)
                {
                    Console.WriteLine($"A Palavra {chosenWord} foi encontrada!\nPressione Enter para sair\n");
                }

                gameOver = wrongGuesses > 5;
                if (gameOver)
                {
                    Console.WriteLine($"A Palavra era {chosenWord}\nPressione Enter para sair\n");
                }





            } while (rightGuessWord != true && gameOver != true);
            Console.WriteLine("Jogo Finalizado, Deseja Jogar Novamente? (y/n)");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                Game();
            } else if (answer == "n")
            {
                Environment.Exit(0);
            } else
            {
                Console.WriteLine("Opção Inválida");
                answer = Console.ReadLine();
            }
        }
        
        
        
        
        
        static void Main(string[] args)
        {
            MainProgram();
          
        }
    }
}
