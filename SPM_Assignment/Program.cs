// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//For board 1
Console.WriteLine("     A   B   C   D   E   F   G   H   I   J  ");
Console.WriteLine("   +---+---+---+---+---+---+---+---+---+---+");

/*Board1 = { 
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, 
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
        };
*/
//For board 2   
Console.WriteLine("     A   B   C   D   E   F   G   H   I   J   K   L   M   N   O   P   Q   R   S   T");
Console.WriteLine("   +---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+");

/*Board2 = {
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
        };

*/
//Commented out the board because it created 1000 errors

while (true)
{
    MainMenu();
    int option = Convert.ToInt32(Console.ReadLine());

    if (option == 0)
    {
        Console.WriteLine("Quitting game. Thanks for playing!");
        break;
    }

    else if (option == 1)
    {
        GameMenu();

        int gameOption = Convert.ToInt32(Console.ReadLine());

        if (gameOption == 0)
        {
            Console.WriteLine("Quitting game. Thanks for playing!");
            return;
        }

        else if (gameOption == 1)
        {
            Console.WriteLine("Starting Arcade Mode...");
        }
        else if (gameOption == 2)
        {
            Console.WriteLine("Starting Free Play Mode...");
        }
        else if (gameOption == 3)
        {
            Console.WriteLine("Returning to Main Menu");
            break;
        }

    }
    else if (option == 2)
    {
        Console.WriteLine("Loading game...");
    }
    else
    {
        Console.WriteLine("Invalid option. Please select a valid option.");
    }
}

void MainMenu()
{
    Console.WriteLine("Welcome to Ngee Ann City! Indulge in the creation of a happy and prosperous city!");
    Console.WriteLine("---------------------------------------------------------------------------------");
    Console.WriteLine("[1] New Game");
    Console.WriteLine("[2] Load Game");
    Console.WriteLine("[0] Quit Game");
}

void GameMenu()
{
    Console.WriteLine("Choose your game mode: Arcade or Free Play");
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("[1] Arcade Mode");
    Console.WriteLine("[2] Free Play Mode");
    Console.WriteLine("[3] Back to Main Menu");
    Console.WriteLine("[0] Quit Game");
}
