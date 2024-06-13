using SPM_Assignment;

Dictionary<string, Building> buildingsDictionary = new Dictionary<string, Building>();
buildingsDictionary.Add("Residential", new Residential());
buildingsDictionary.Add("Industry", new Industry());
buildingsDictionary.Add("Commercial", new Commercial());
buildingsDictionary.Add("Park", new Park());
buildingsDictionary.Add("Road", new Road());


while (true)
{
    MainMenu();

    int option = -1; 
    try
    {
        option = Convert.ToInt32(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input format. Please enter a number.");
    }

    if (option == 0)
    {
        Console.WriteLine("Quitting game. Thanks for playing!");
        break;
    }

    else if (option == 1)
    {
        while (true)
        {
            GameMenu();

            int gameOption = -1;

            try
            {
                gameOption = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a number.");
            }

            if (gameOption == 0)
            {
                Console.WriteLine("Quitting game. Thanks for playing!");
                return;
            }

            else if (gameOption == 1)
            {
                Console.WriteLine("Starting Arcade Mode...");
                ArcadeMode(CreateEmptyBoard(20,20), 16, 0);
                Console.WriteLine("Press [0] to exit.");
            }
            else if (gameOption == 2)
            {
                Console.WriteLine("Starting Free Play Mode...");
                FreePlayMode(CreateEmptyBoard(5,5), 0);
            }
            else if (gameOption == 3)
            {
                Console.WriteLine("Returning to Main Menu");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option.");
                continue;
            }
        }
    }
    else if (option == 2)
    {
        Console.WriteLine("Loading game...");
    }
    else if (option == 3)
    {
        Console.WriteLine("Viewing High Scores...");
    }   
    else if(option == 4)
    {
        Console.WriteLine("Loading instructions...");
        Instructions();
    }
    else
    {
        Console.WriteLine("Invalid option. Please select a valid option.");
    }
}

void MainMenu()
{
    Console.Clear();
    Console.WriteLine("Welcome to Ngee Ann City! Indulge in the creation of a happy and prosperous city!");
    Console.WriteLine("---------------------------------------------------------------------------------");
    Console.WriteLine("[1] New Game");
    Console.WriteLine("[2] Load Game");
    Console.WriteLine("[3] View High Scores");
    Console.WriteLine("[4] Instructions");
    Console.WriteLine("[0] Quit Game");
    Console.Write("> ");
}

void GameMenu()
{
    Console.Clear();
    Console.WriteLine("Choose your game mode: Arcade or Free Play");
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("[1] Arcade Mode");
    Console.WriteLine("[2] Free Play Mode");
    Console.WriteLine("[3] Back to Main Menu");
    Console.WriteLine("[0] Quit Game");
    Console.Write("> ");
}

Building[,] CreateEmptyBoard(int rows, int cols) {

    Building[,] board = new Building[rows, cols];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            board[i, j] = null;
        }
    }

    return board;
}

void ArcadeMode(Building[,] board, int coins, int score)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("\x1b[3J");
        Console.Clear();


        //int rows = 20;
        //int cols = 20;

        //char[,] board = new char[rows, cols];

        //for (int i = 0; i < rows; i++)
        //{
        //    for (int j = 0; j < cols; j++)
        //    {
        //        board[i, j] = ' ';
        //    }
        //}

        DisplayGrid(board);

        Console.WriteLine("\nCoins: " + coins + "\tScore: " + score);

        string[] buildings = { "Residential", "Industry", "Commercial", "Park", "Road" };
        Random random = new Random();
        string[] validChoices = { buildings[random.Next(0, buildings.Length)], buildings[random.Next(0, buildings.Length)] };
        Console.WriteLine($"[1] {buildingsDictionary[validChoices[0]]} ({validChoices[0]})\n[2] {buildingsDictionary[validChoices[1]]} ({validChoices[1]})");
        Console.WriteLine("Press [0] to exit to the Main Menu.");
        Building building;

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (input == "0")
            {
                return;
            } 
            else if (input == "1" || input == "2")
            {
                building = buildingsDictionary[validChoices[Convert.ToInt32(input) - 1]];
                break;
            } 
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        Console.WriteLine("Select a location (e.g. E7)");
        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            try
            {
                if (board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A'] == null)
                {
                    if (Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) != 1)
                    {
                        building.North = board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 2, Convert.ToChar(input.ToUpper()[0]) - 'A'];

                        if (board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 2, Convert.ToChar(input.ToUpper()[0]) - 'A'] != null)
                        {
                            board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 2, Convert.ToChar(input.ToUpper()[0]) - 'A'].South = building;
                        }
                    }
                    if (Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) != 20)
                    {
                        building.South = board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 0, Convert.ToChar(input.ToUpper()[0]) - 'A'];

                        if (board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 0, Convert.ToChar(input.ToUpper()[0]) - 'A'] != null)
                        {
                            board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 0, Convert.ToChar(input.ToUpper()[0]) - 'A'].North = building;
                        }
                    }
                    if (input.ToUpper()[0] != 'T')
                    {
                        building.East = board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A' + 1];

                        if (board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A' + 1] != null)
                        {
                            board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A' + 1].West = building;
                        }
                    }
                    if (input.ToUpper()[0] != 'A')
                    {
                        building.West = board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A' - 1];

                        if (board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A' - 1] != null)
                        {
                            board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A' - 1].East = building;
                        }
                    }

                    

                    
                    
                    



                    //Console.WriteLine(building.North);
                    //Console.WriteLine(building.South);
                    //Console.WriteLine(building.East);
                    //Console.WriteLine(building.West);
                    board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A'] = building;
                    //Console.ReadLine();
                    break;
                }
                else Console.WriteLine("Tile is already occupied. Try again.");
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input. Try again.");
                Console.WriteLine(e);
            }

        }



    }
    
}


void FreePlayMode(Building[,] board, int score)
{
    
    Console.Clear();
    int rows = 5;
    int cols = 5;
    int expansionSize = 5;


    //char[,] board = new char[rows, cols];

    //for (int i = 0; i < rows; i++)
    //{
    //    for (int j = 0; j < cols; j++)
    //    {
    //        board[i, j] = ' ';
    //    }
    //}

    // Display the initial city grid
    //DisplayGrid(board);

    //Console.WriteLine("\nCoins: Unlimited" + "\tScore: " + score);
    //Console.WriteLine("Press [0] to exit to the Main Menu.");


    //while (true)
    //{
    //    Console.Write("> ");
    //    string input = Console.ReadLine();

    //    if (input == "0")
    //    {
    //        break;
    //    }
    //    else
    //    {
    //        Console.WriteLine("Invalid input. Try again.");
    //    }
    //}
    while (true)
    {

        Console.Clear();
        Console.WriteLine("\x1b[3J");
        Console.Clear();


        //int rows = 20;
        //int cols = 20;

        //char[,] board = new char[rows, cols];

        //for (int i = 0; i < rows; i++)
        //{
        //    for (int j = 0; j < cols; j++)
        //    {
        //        board[i, j] = ' ';
        //    }
        //}

        DisplayGrid(board);

        Console.WriteLine("\nCoins: " + "Unlimited" + "\tScore: " + score);

        string[] buildings = { "Residential", "Industry", "Commercial", "Park", "Road" };
        Random random = new Random();
        string[] validChoices = { buildings[random.Next(0, buildings.Length)], buildings[random.Next(0, buildings.Length)] };
        Console.WriteLine($"[1] {buildingsDictionary[validChoices[0]]} ({validChoices[0]})\n[2] {buildingsDictionary[validChoices[1]]} ({validChoices[1]})");
        Console.WriteLine("Press [0] to exit to the Main Menu.");
        Building building;

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (input == "0")
            {
                return;
            }
            else if (input == "1" || input == "2")
            {
                building = buildingsDictionary[validChoices[Convert.ToInt32(input) - 1]];
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        Console.WriteLine("Select a location (e.g. E7)");
        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            try
            {
                if (board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A'] == null)
                {
                    //NOT ENOUGH INFO
                    //building.North = board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 2, Convert.ToChar(input.ToUpper()[0]) - 'A'];
                    //building.South = board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 0, Convert.ToChar(input.ToUpper()[0]) - 'A'];
                    //building.East = board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A' + 1];
                    //building.West = board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A' - 1];

                    //if (board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 2, Convert.ToChar(input.ToUpper()[0]) - 'A'] != null)
                    //{
                    //    board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 2, Convert.ToChar(input.ToUpper()[0]) - 'A'].South = building;
                    //}

                    //if (board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 0, Convert.ToChar(input.ToUpper()[0]) - 'A'] != null)
                    //{
                    //    board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 0, Convert.ToChar(input.ToUpper()[0]) - 'A'].North = building;
                    //}
                    //if (board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A' + 1] != null)
                    //{
                    //    board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A' + 1].West = building;
                    //}
                    //if (board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A' - 1] != null)
                    //{
                    //    board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A' - 1].East = building;
                    //}



                    //Console.WriteLine(building.North);
                    //Console.WriteLine(building.South);
                    //Console.WriteLine(building.East);
                    //Console.WriteLine(building.West);
                    board[Convert.ToInt32(Convert.ToString(input.Substring(1, input.Length - 1))) - 1, Convert.ToChar(input.ToUpper()[0]) - 'A'] = building;
                    //Console.ReadLine();
                    break;
                }
                else Console.WriteLine("Tile is already occupied. Try again.");

            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input. Try again.");
                Console.WriteLine(e);
            }

        }
    }
}

void DisplayGrid(Building[,] board)
{
    int rows = board.GetLength(0);
    int cols = board.GetLength(1);

    Console.Write("     ");
    for (int c = 0; c < cols; c++)
    {
        Console.Write(" " + (char)('A' + c) + "  "); //Letters move to a new letter across the board horizontally
    }
    Console.WriteLine();

    Console.Write("    ");
    for (int c = 0; c < cols; c++)
    {
        Console.Write("+---");
    }
    Console.WriteLine("+");

    for (int r = 0; r < rows; r++)
    {
        Console.Write(" " + (r + 1).ToString("D2") + " ");

        for (int c = 0; c < cols; c++)
        {
            if (board[r,c] == null)
            {
                Console.Write("| " + " " + " ");
            }
            else Console.Write("| " + board[r, c] + " ");
        }
        Console.WriteLine("|");

        Console.Write("    ");
        for (int c = 0; c < cols; c++)
        {
            Console.Write("+---");
        }
        Console.WriteLine("+");
    }
}

void Instructions()
{
    Console.Clear();
    Console.WriteLine("Introductions");
    Console.WriteLine("Welcome to Ngee Ann City, a city-building strategy game where you play as the mayor.\nYour goal is to build the happiest and most prosperous city.");
    Console.WriteLine("\nGame Modes");
    Console.WriteLine("Arcade Mode: Start with 16 coins and a 20x20 grid. Each turn, choose one of two randomly selected buildings to construct for 1 coin.\nBuild adjacent to existing buildings after the first turn. The game ends when you run out of coins or fill the board.");
    Console.WriteLine("\nFree Play Mode: Begin with unlimited coins and a 5x5 grid. Construct any building on any cell, expanding the grid by 5 rows/columns when building on the border.\nThe game ends when the city incurs losses for 20 consecutive turns. Build at your own pace to create a large, prosperous city.");
    Console.WriteLine("\nBuilding Types and Scoring");
    Console.WriteLine("Residential (R): Scores 1 point per adjacent Residential (R) or Commercial (C), 2 points per adjacent Park (O), but only 1 point if adjacent to Industry (I).\nGenerates 1 coin per turn, with clusters requiring 1 coin per turn for upkeep.");
    Console.WriteLine("Industry (I): Scores 1 point per Industry (I) in the city. Generates 2 coins per turn, costing 1 coin per turn for upkeep, and generates 1 coin per adjacent Residential (R).");
    Console.WriteLine("Commercial (C): Scores 1 point per adjacent Commercial (C). Generates 3 coins per turn, costing 2 coins per turn for upkeep, and generates 1 coin per adjacent Residential (R).");
    Console.WriteLine("Park (O): Scores 1 point per adjacent Park (O). Costs 1 coin per turn for upkeep.");
    Console.WriteLine("Road (*): Scores 1 point per connected Road (*) in the same row. Each unconnected road segment costs 1 coin for upkeep.");
    Console.WriteLine("You can build or demolish buildings for 1 coin each");
    Console.WriteLine("\nHappy building!");
    Console.WriteLine("                                    +              #####");
    Console.WriteLine("                                   / \\");
    Console.WriteLine(" _____        _____     __________/ o \\/\\_________      _________");
    Console.WriteLine("|o o o|_______|    |___|               | | # # #  |____|o o o o  | /\\");
    Console.WriteLine("|o o o|  * * *|: ::|. .|               |o| # # #  |. . |o o o o  |//\\\\");
    Console.WriteLine("|o o o|* * *  |::  |. .| []  []  []  []|o| # # #  |. . |o o o o  |((|))");
    Console.WriteLine("|o o o|**  ** |:  :|. .| []  []  []    |o| # # #  |. . |o o o o  |((|))");
    Console.WriteLine("|_[]__|__[]___|_||_|__<|____________;;_|_|___/\\___|_.|_|____[]___|  |");
    while(true)
    {
        Console.Write("\nEnter [0] to return to main menu");
        string input = Console.ReadLine();
        if (input == "0")
        {
            return;
        }
    }
}
//Console.ForegroundColor = ConsoleColor.White;