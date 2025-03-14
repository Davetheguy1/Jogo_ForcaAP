using System.Reflection.Metadata.Ecma335;

namespace ForcaAP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] possibleWords =
            {
                "ABACATE",
                "ABACAXI",
                "ACEROLA",
                "ACAI",
                "ARACA",
                "ABACATE",
                "BACABA",
                "BACURI",
                "BANANA",
                "CAJA",
                "CAJU",
                "CARAMBOLA",
                "CUPUACU",
                "GRAVIOLA",
                "GOIABA",
                "JABUTICABA",
                "JENIPAPO",
                "MACA",
                "MANGABA",
                "MANGA",
                "MARACUJA",
                "MURICI",
                "PEQUI",
                "PITANGA",
                "PITAYA",
                "SAPOTI",
                "TANGERINA",
                "UMBU",
                "UVA",
                "UVAIA"
            };

            Random randGenerator = new Random();

            int chosenIdx = randGenerator.Next(possibleWords.Length);

            string chosenWord = possibleWords[chosenIdx];
           

            char[] foundChars = new char[chosenWord.Length];

            for(int currentChar = 0; currentChar < foundChars.Length; currentChar++)
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
            Console.WriteLine("Jogo Finalizado, Pressione Enter para sair");
            Console.ReadLine();
            
           
        }
    }
}
