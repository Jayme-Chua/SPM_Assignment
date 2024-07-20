using System;
using System.IO;
using System.Linq;
using System.Globalization;

using SPM_Assignment;
using System.Data.Common;

Dictionary<string, Building> buildingsDictionary = new Dictionary<string, Building>();
buildingsDictionary.Add("Residential", new Residential());
buildingsDictionary.Add("Industry", new Industry());
buildingsDictionary.Add("Commercial", new Commercial());
buildingsDictionary.Add("Park", new Park());
buildingsDictionary.Add("Road", new Road());

int currentTurn = 1;
const string arcadeFilePath = "arcade_scores.csv";
const string freePlayFilePath = "freeplay_scores.csv";

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
                ArcadeMode(CreateEmptyBoard(20,20), 16, 0, 1);
                Console.WriteLine("Press [0] to exit.");
            }
            else if (gameOption == 2)
            {
                Console.WriteLine("Starting Free Play Mode...");
                FreePlayMode(CreateEmptyBoard(5,5), 0, 0, 1,0);
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
        var result = LoadGame();
        if (result.Item1 != null)
        {
            if (result.Item1 == "Arcade")
            {
                ArcadeMode(result.Item2, result.Item5, result.Item4, result.Item3);
            }
            else
            {
                FreePlayMode(result.Item2, result.Item4, result.Item6, result.Item3, result.Item4);
            }
        }
    }
    else if (option == 3)
    {
        Console.WriteLine("Viewing High Scores...");
        Console.WriteLine("Select Mode to View High Scores:");
        Console.WriteLine("1. Arcade Mode");
        Console.WriteLine("2. Free Play Mode");
        var viewChoice = Console.ReadLine();

        if (viewChoice == "1")
        {
            DisplayHighScores(arcadeFilePath);
        }
        else if (viewChoice == "2")
        {
            DisplayHighScores(freePlayFilePath);
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
        
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

void ArcadeMode(Building[,] board, int coins, int score, int currentTurn)
{
    bool firstTurn = true;
    while (true)
    {
        Console.WriteLine("\x1b[3J");
        Console.Clear();

        DisplayGrid(board);
        Console.WriteLine("\nCoins: " + coins + "\tScore: " + score);

        string[] buildings = { "Residential", "Industry", "Commercial", "Park", "Road" };
        Random random = new Random();
        string[] validChoices = { buildings[random.Next(0, buildings.Length)], buildings[random.Next(0, buildings.Length)] };
        Console.WriteLine($"[1] {buildingsDictionary[validChoices[0]]} ({validChoices[0]})\n[2] {buildingsDictionary[validChoices[1]]} ({validChoices[1]})\n[3] Demolish building\n[4] Save Game");
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
                Console.WriteLine("Select a location (e.g. E7)");
                while (true)
                {
                    Console.Write("> ");
                    input = Console.ReadLine();
                    try
                    {
                        int row = Convert.ToInt32(input.Substring(1, input.Length - 1)) - 1;
                        int column = Convert.ToChar(input.ToUpper()[0]) - 'A';

                        bool north = true;
                        bool south = true;
                        bool east = true;
                        bool west = true;
                        bool northEast = true;
                        bool southEast = true;
                        bool northWest = true;
                        bool southWest = true;

                        if (row == 0 || board[row - 1, column] == null)
                        {
                            north = false;
                        }
                        if ((row == 0 || column == 0) || board[row - 1, column - 1] == null)
                        {
                            northWest = false;
                        }
                        if ((row == 0 || column == 19) || board[row - 1, column + 1] == null)
                        {
                            northEast = false;
                        }
                        if (row == 19 || board[row + 1, column] == null)
                        {
                            south = false;
                        }
                        if ((row == 19 || column == 0) || board[row + 1, column - 1] == null)
                        {
                            southWest = false;
                        }
                        if ((row == 19 || column == 19) || board[row + 1, column + 1] == null)
                        {
                            southEast = false;
                        }
                        if (column == 0 || board[row, column - 1] == null)
                        {
                            west = false;
                        }
                        if (column == 19 || board[row, column + 1] == null)
                        {
                            east = false;
                        }
                        if (firstTurn || north || northWest || northEast || south || southWest || southEast || west || east)
                        {

                            if (board[row, column] == null)
                            {
                                if (row + 1 != 1)
                                {
                                    building.North = board[row - 1, column];

                                    if (board[row - 1, column] != null)
                                    {
                                        board[row - 1, column].South = building;
                                    }

                                    if (column + 1 != 1)
                                    {
                                        building.NorthWest = board[row - 1, column - 1];

                                        if (board[row - 1, column - 1] != null)
                                        {
                                            board[row - 1, column - 1].SouthEast = building;
                                        }
                                    }

                                    if (column + 1 != 20)
                                    {
                                        building.NorthEast = board[row - 1, column + 1];

                                        if (board[row - 1, column + 1] != null)
                                        {
                                            board[row - 1, column + 1].SouthWest = building;
                                        }
                                    }
                                }
                                if (row + 1 != 20)
                                {
                                    building.South = board[row + 1, column];

                                    if (board[row + 1, column] != null)
                                    {
                                        board[row + 1, column].North = building;
                                    }

                                    if (column + 1 != 1)
                                    {
                                        building.SouthWest = board[row + 1, column - 1];

                                        if (board[row + 1, column - 1] != null)
                                        {
                                            board[row + 1, column - 1].NorthEast = building;
                                        }
                                    }

                                    if (column + 1 != 20)
                                    {
                                        building.SouthEast = board[row + 1, column + 1];

                                        if (board[row + 1, column + 1] != null)
                                        {
                                            board[row + 1, column + 1].NorthWest = building;
                                        }
                                    }
                                }
                                if (input.ToUpper()[0] != 'T')
                                {
                                    building.East = board[row, column + 1];

                                    if (board[row, column + 1] != null)
                                    {
                                        board[row, column + 1].West = building;
                                    }
                                }
                                if (input.ToUpper()[0] != 'A')
                                {
                                    building.West = board[row, column - 1];

                                    if (board[row, column - 1] != null)
                                    {
                                        board[row, column - 1].East = building;
                                    }
                                }
                                //Console.WriteLine(building.North);
                                //Console.WriteLine(building.South);
                                //Console.WriteLine(building.East);
                                //Console.WriteLine(building.West);
                                board[row, column] = building;
                                coins--;
                                score += CalculateScore(building, board);
                                currentTurn++;
                                int generatedCoins = CalculateCoinsGeneratedARC(board);
                                int upkeepCost = CalculateUpkeepCostARC(board);
                                coins += generatedCoins - upkeepCost;
                                if (coins <= 0 || IsBoardFull(board))
                                {
                                    //code to run when game end
                                    //save high score
                                    EndGame(arcadeFilePath, score);
                                    return;
                                }
                                break;
                            }
                            else Console.WriteLine("Tile is already occupied. Try again.");
                        }
                        else Console.WriteLine("Building must be placed adjacent to another building. Try again.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid input. Try again.");
                        Console.WriteLine(e);
                    }
                }
                break;
            }
            else if (input == "3")
            {
                if (BoardEmpty(board))
                {
                    Console.WriteLine("No buildings to demolish!");
                }
                else
                {
                    Console.WriteLine("Select a building to demolish (e.g. E7)");
                    while (true)
                    {
                        Console.Write("> ");
                        input = Console.ReadLine();
                        try
                        {

                            int row = Convert.ToInt32(input.Substring(1, input.Length - 1)) - 1;
                            int column = Convert.ToChar(input.ToUpper()[0]) - 'A';
                            if (board[row, column] == null)
                            {
                                Console.WriteLine("There's nothing to demolish, try again.");
                            }
                            else
                            {
                                // De-link surrounding buildings
                                if (row != 1)
                                {
                                    if (board[row, column].North != null) board[row, column].North.South = null;
                                    if (board[row, column].NorthEast != null) board[row, column].NorthEast.SouthWest = null;
                                    if (board[row, column].NorthWest != null) board[row, column].NorthWest.SouthEast = null;
                                }

                                if (row != 20)
                                {
                                    if (board[row, column].South != null) board[row, column].South.North = null;
                                    if (board[row, column].SouthEast != null) board[row, column].SouthEast.NorthWest = null;
                                    if (board[row, column].SouthWest != null) board[row, column].South.NorthEast = null;
                                }

                                if (input.ToUpper()[0] != 'T')
                                {
                                    if (board[row, column].East != null) board[row, column].East.West = null;
                                }

                                if (input.ToUpper()[0] != 'A')
                                {
                                    if (board[row, column].West != null) board[row, column].West.East = null;
                                }
                                board[row, column] = null;
                                coins--;
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid input. Try again.");
                        }
                    }
                    break;
                }
            }
            else if(input == "4")
            {
                Console.WriteLine("Saving Game...");
                SaveGame("Arcade", board, currentTurn, score, coins, 0);
                Console.WriteLine("Game Saved!");
                return;
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        firstTurn = false;
    }
}


void FreePlayMode(Building[,] board, int score, int lostCount, int currentTurn, int coins)
{
    Console.Clear();
    int startRow = 0;
    int startCol = 0;
    int viewRows = 25;
    int viewCols = 25;
    string expandGridMessage = null;
    string shiftBuildingMessage = null;
    bool showBorderMessage = false;
    bool scrollMessage = false;

    int generatedCoins = 0;
    int upkeepCost = 0;

    while (true)
    {
        Console.Clear();
        Console.WriteLine("\x1b[3J");
        Console.Clear();

        DisplayGridFreePlay(board, startRow, startCol, viewRows, viewCols);

        int profit = generatedCoins - upkeepCost;
        if (profit < 0)
        {
            profit = 0;
        }

        Console.WriteLine("\nCoins: " + "Unlimited" + "\tScore: " + score + "\tProfit: " + profit + "\tUpkeep: " + upkeepCost + "\tLosses: " + lostCount);

        string[] buildings = { "Residential", "Industry", "Commercial", "Park", "Road" };
        Random random = new Random();
        string[] validChoices = { buildings[random.Next(0, buildings.Length)], buildings[random.Next(0, buildings.Length)] };
        Console.WriteLine($"[1] {buildingsDictionary[validChoices[0]]} ({validChoices[0]})\n[2] {buildingsDictionary[validChoices[1]]} ({validChoices[1]})\n[3] Demolish building\n[4] Save Game");
        Console.WriteLine("Press [0] to exit to the Main Menu.");
        Building building;

        if (expandGridMessage != null)
        {
            Console.WriteLine(expandGridMessage);
            expandGridMessage = null; // Clear the message after displaying
        }
        if (shiftBuildingMessage != null)
        {
            Console.WriteLine(shiftBuildingMessage);
            shiftBuildingMessage = null; // Clear the message after displaying
        }

        if (!scrollMessage && (board.GetLength(0) > 25 || board.GetLength(1) > 25))
        {
            Console.WriteLine("\nGrid has expanded beyond 25x25. You can start scrolling by using W, A, S, or D to move around.");
            scrollMessage = true;
        }

        if (showBorderMessage)
        {
            Console.WriteLine("\nYou have reached the border of the grid, use W, A, S or D to scroll around.");
            showBorderMessage = false; // Reset flag after displaying the message
        }
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
                Console.WriteLine("Select a location (e.g. E7)");
                while (true)
                {
                    Console.Write("> ");
                    input = Console.ReadLine().ToUpper();
                    try
                    {
                        //int row = Convert.ToInt32(input.Substring(1)) - 1;
                        //int col = Convert.ToChar(input.ToUpper()[0]) - 'A';
                        int firstDigitIndex = input.IndexOfAny("0123456789".ToCharArray());
                        string columnInput = input.Substring(0, firstDigitIndex);
                        string rowInput = input.Substring(firstDigitIndex);
                        int column = GetColumnIndex(columnInput);
                        int row = Convert.ToInt32(rowInput) - 1;

                        //int row = Convert.ToInt32(input.Substring(1, input.Length - 1)) - 1;
                        //int column = Convert.ToChar(input.ToUpper()[0]) - 'A';

                        if (board[row, column] == null)
                        {
                            if (row + 1 != 1)
                            {
                                building.North = board[row - 1, column];

                                if (board[row - 1, column] != null)
                                {
                                    board[row - 1, column].South = building;
                                }

                                if (column + 1 != 1)
                                {
                                    building.NorthWest = board[row - 1, column - 1];

                                    if (board[row - 1, column - 1] != null)
                                    {
                                        board[row - 1, column - 1].SouthEast = building;
                                    }
                                }

                                if (column + 1 != board.GetLength(1))
                                {
                                    building.NorthEast = board[row - 1, column + 1];

                                    if (board[row - 1, column + 1] != null)
                                    {
                                        board[row - 1, column + 1].SouthWest = building;
                                    }
                                }
                            }
                            if (row + 1 != board.GetLength(0))
                            {
                                building.South = board[row + 1, column];

                                if (board[row + 1, column] != null)
                                {
                                    board[row + 1, column].North = building;
                                }

                                if (column + 1 != 1)
                                {
                                    building.SouthWest = board[row + 1, column - 1];

                                    if (board[row + 1, column - 1] != null)
                                    {
                                        board[row + 1, column - 1].NorthEast = building;
                                    }
                                }

                                if (column + 1 != board.GetLength(1))
                                {
                                    building.SouthEast = board[row + 1, column + 1];

                                    if (board[row + 1, column + 1] != null)
                                    {
                                        board[row + 1, column + 1].NorthWest = building;
                                    }
                                }
                            }
                            if (column != GetColumnIndex(GetColumnName(board.GetLength(1) - 1)) && column + 1 < board.GetLength(1))
                            {
                                building.East = board[row, column + 1];

                                if (board[row, column + 1] != null)
                                {
                                    board[row, column + 1].West = building;
                                }
                            }
                            if (column != GetColumnIndex(GetColumnName(0)) && column - 1 >= 0)
                            {
                                building.West = board[row, column - 1];

                                if (board[row, column - 1] != null)
                                {
                                    board[row, column - 1].East = building;
                                }
                            }

                            if (OnBorder(board, row, column))
                            {
                                board = ExpandGrid(board, 10);

                                //The point of doing this is to shift the newly built building to its proper position after the grid expands.
                                row += 5;
                                column += 5;

                                expandGridMessage = "\nYou placed a building at the border, the grid has expanded.";
                                shiftBuildingMessage = string.Format("The building you placed at {0}{1}, will now be shifted to its respective position at {2}{3}", GetColumnName(column -5), row - 4, GetColumnName(column), row + 1);
                            }

                            board[row, column] = building;
                            score += CalculateScore(building, board);
                            currentTurn++;
                            //Console.ReadLine();
                            coins--;
                            generatedCoins = CalculateCoinsGeneratedFP(board);
                            upkeepCost = CalculateUpkeepCostFP(board);

                            if (upkeepCost > generatedCoins)
                            {
                                lostCount++;

                                if (lostCount >= 20)
                                {
                                    //code to run if game end
                                    //Save high score
                                    EndGame(freePlayFilePath, score);
                                    return;
                                }
                            }
                            else
                            {
                                lostCount = 0;
                            }
                            break;

                        }
                        else Console.WriteLine("Tile is already occupied. Try again.");

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid input. Try again.");
                        //Console.WriteLine(e);
                    }

                }
                break;
            }
            else if (input == "3")
            {
                if (BoardEmpty(board))
                {
                    Console.WriteLine("No buildings to demolish!");

                }
                else
                {
                    Console.WriteLine("Select a building to demolish (e.g. E7)");
                    while (true)
                    {

                        Console.Write("> ");
                        input = Console.ReadLine().ToUpper();
                        try
                        {
                            int firstDigitIndex = input.IndexOfAny("0123456789".ToCharArray());
                            string columnInput = input.Substring(0, firstDigitIndex);
                            string rowInput = input.Substring(firstDigitIndex);
                            int column = GetColumnIndex(columnInput);
                            int row = Convert.ToInt32(rowInput) - 1;
                            if (board[row, column] == null)
                            {
                                Console.WriteLine("There's nothing to demolish, try again.");
                            }
                            else
                            {
                                // De-link surrounding buildings
                                if (row != 1)
                                {
                                    if (board[row, column].North != null) board[row, column].North.South = null;
                                }

                                if (row != board.GetLength(0))
                                {
                                    if (board[row, column].South != null) board[row, column].South.North = null;
                                }

                                if (column != GetColumnIndex(GetColumnName(board.GetLength(1) - 1)))
                                {
                                    if (board[row, column].East != null) board[row, column].East.West = null;
                                }

                                if (column != GetColumnIndex(GetColumnName(0)))
                                {
                                    if (board[row, column].West != null) board[row, column].West.East = null;
                                }
                                board[row, column] = null;
                                coins--;
                                break;
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid input. Try again.");
                        }

                    }
                    break;
                }
            }
            else if (input == "4")
            {
                Console.WriteLine("Saving Game...");
                SaveGame("FreePlay", board, currentTurn, score, 0, lostCount);
                Console.WriteLine("Game Saved!");
                return;
            }
            //Scrolling inputs section
            else if (input.ToUpper() == "W")
            {
                if (startRow > 0)
                {
                    startRow -= 10; //Scrolls up by 10 rows
                }
                else
                {
                    showBorderMessage = true; // Set flag to show message
                }
                break;
            }
            else if (input.ToUpper() == "S")
            {
                if (startRow + viewRows < board.GetLength(0))
                {
                    startRow += 10; //Scrolls down by 10 rows
                }
                else
                {
                    showBorderMessage = true; // Set flag to show message
                }
                break;
            }
            else if (input.ToUpper() == "A")
            {
                if (startCol > 0)
                {
                    startCol -= 10; //Scrolls left by 10 columns
                }
                else
                {
                    showBorderMessage = true; // Set flag to show message
                }
                break;
            }
            else if (input.ToUpper() == "D")
            {
                if (startCol + viewCols < board.GetLength(1))
                {
                    startCol += 10; //Scrolls right by 10 columns
                }
                else
                {
                    showBorderMessage = true; // Set flag to show message
                }
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        
    }
}

void DisplayGridFreePlay(Building[,] board, int startRow, int startCol, int viewRows, int viewCols)
{
    int rows = board.GetLength(0);
    int cols = board.GetLength(1);

    Console.Write("     ");
    for (int c = startCol; c < Math.Min(startCol + viewCols, cols); c++)
    {
        string columnLabel = GetColumnName(c);
        Console.Write($" {columnLabel,-2} ");

        //Console.Write(" " + GetColumnName(c) + "  ");
    }
    Console.WriteLine();

    Console.Write("    ");
    for (int c = startCol; c < Math.Min(startCol + viewCols, cols); c++)
    {
        Console.Write("+---");
    }
    Console.WriteLine("+");

    for (int r = startRow; r < Math.Min(startRow + viewRows, rows); r++)
        {
        string rowNumber = (r + 1).ToString();
        if (rowNumber.Length < 3)
        {
            Console.Write(" " + (r + 1).ToString("D2") + " ");
        }
        else
        {
            Console.Write(" " + (r + 1).ToString("D2"));
        }

        for (int c = startCol; c < Math.Min(startCol + viewCols, cols); c++)
        {
            if (board[r, c] == null)
            {
                Console.Write("| " + " " + " ");
            }
            else
            {
                Console.Write("| ");
                SetConsoleColor(board[r, c]);
                Console.Write(board[r, c] + " ");
                Console.ResetColor();
            }
        }
        Console.WriteLine("|");

        Console.Write("    ");
        for (int c = startCol; c < Math.Min(startCol + viewCols, cols); c++)
        {
            Console.Write("+---");
        }
        Console.WriteLine("+");
    }
}

string GetColumnName(int columnIndex)
{
    string columnName = string.Empty;
    while (columnIndex >= 0)
    {
        columnName = (char)('A' + (columnIndex % 26)) + columnName;
        columnIndex = (columnIndex / 26) - 1;
    }
    return columnName;
}

int GetColumnIndex(string columnName)
{
    int columnIndex = 0;
    foreach (char c in columnName)
    {
        columnIndex = columnIndex * 26 + (c - 'A' + 1);
    }
    return columnIndex - 1;
}

bool BoardEmpty(Building[,] board)
{
    int rows = board.GetLength(0);
    int columns = board.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (board[i, j] != null) return false;
        }
    }
    return true;
}

//Method to check if a building is built on the border of the grid
bool OnBorder(Building[,] board, int row, int col)
{
    return row == 0 || col == 0 || row == board.GetLength(0) - 1 || col == board.GetLength(1) - 1;
}

Building[,] ExpandGrid(Building[,] oldBoard, int expansionSize)
{
    int oldRows = oldBoard.GetLength(0);
    int oldCols = oldBoard.GetLength(1);
    int newRows = oldRows + expansionSize;
    int newCols = oldCols + expansionSize;

    Building[,] newBoard = new Building[newRows, newCols];

    //The point of this is to shift the buildings to their proper positions once the grid expands.
    //Say, for instance, a building is built on A1, it shifts to F6 once the grid has expanded because that's exactly where it's built as the grid expanded.
    int rowOffset = (newRows - oldRows) / 2;
    int colOffset = (newCols - oldCols) / 2;

    for (int i = 0; i < oldRows; i++)
    {
        for (int j = 0; j < oldCols; j++)
        {
            newBoard[i + rowOffset, j + colOffset] = oldBoard[i, j];
        }
    }

    return newBoard;
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
            else 
            {
                Console.Write("| ");
                SetConsoleColor(board[r, c]);
                Console.Write(board[r, c] + " ");
                Console.ResetColor(); // Reset color after printing each cell
            }
            
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
static int CalculateScore(Building building, Building[,] board)
{
    int score = 0;
    int rows = board.GetLength(0);
    int cols = board.GetLength(1);

    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < cols; c++)
        {
            if (board[r, c] == building)
            {
                // Check surrounding buildings
                if (r > 0 && board[r - 1, c] != null) // North
                    score += building.ProvidePoints(board[r - 1, c]);

                if (r < rows - 1 && board[r + 1, c] != null) // South
                    score += building.ProvidePoints(board[r + 1, c]);

                if (c > 0 && board[r, c - 1] != null) // West
                    score += building.ProvidePoints(board[r, c - 1]);

                if (c < cols - 1 && board[r, c + 1] != null) // East
                    score += building.ProvidePoints(board[r, c + 1]);

                // Diagonal checks
                if (r > 0 && c < cols - 1 && board[r - 1, c + 1] != null) // Northeast
                    score += building.ProvidePoints(board[r - 1, c + 1]);

                if (r > 0 && c > 0 && board[r - 1, c - 1] != null) // Northwest
                    score += building.ProvidePoints(board[r - 1, c - 1]);

                if (r < rows - 1 && c < cols - 1 && board[r + 1, c + 1] != null) // Southeast
                    score += building.ProvidePoints(board[r + 1, c + 1]);

                if (r < rows - 1 && c > 0 && board[r + 1, c - 1] != null) // Southwest
                    score += building.ProvidePoints(board[r + 1, c - 1]);
            }
        }
    }

    return score;
}

static int CalculateCoinsGeneratedARC(Building[,] board)
{
    int coinsGenerated = 0;
    int rows = board.GetLength(0);
    int cols = board.GetLength(1);

    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < cols; c++)
        {
            Building building = board[r, c];
            if (building != null)
            {
                // Check surrounding buildings
                if (r > 0 && board[r - 1, c] != null) // North
                    coinsGenerated += building.GenerateCoinsARC(board[r - 1, c]);

                if (r < rows - 1 && board[r + 1, c] != null) // South
                    coinsGenerated += building.GenerateCoinsARC(board[r + 1, c]);

                if (c > 0 && board[r, c - 1] != null) // West
                    coinsGenerated += building.GenerateCoinsARC(board[r, c - 1]);

                if (c < cols - 1 && board[r, c + 1] != null) // East
                    coinsGenerated += building.GenerateCoinsARC(board[r, c + 1]);

                // Diagonal checks
                if (r > 0 && c < cols - 1 && board[r - 1, c + 1] != null) // Northeast
                    coinsGenerated += building.GenerateCoinsARC(board[r - 1, c + 1]);

                if (r > 0 && c > 0 && board[r - 1, c - 1] != null) // Northwest
                    coinsGenerated += building.GenerateCoinsARC(board[r - 1, c - 1]);

                if (r < rows - 1 && c < cols - 1 && board[r + 1, c + 1] != null) // Southeast
                    coinsGenerated += building.GenerateCoinsARC(board[r + 1, c + 1]);

                if (r < rows - 1 && c > 0 && board[r + 1, c - 1] != null) // Southwest
                    coinsGenerated += building.GenerateCoinsARC(board[r + 1, c - 1]);
            }
        }
    }

    return coinsGenerated;
}

static int CalculateCoinsGeneratedFP(Building[,] board)
{
    int coinsGenerated = 0;
    int rows = board.GetLength(0);
    int cols = board.GetLength(1);

    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < cols; c++)
        {
            Building building = board[r, c];
            if (building != null)
            {
                // Check surrounding buildings
                if (r > 0 && board[r - 1, c] != null) // North
                    coinsGenerated += building.GenerateCoinsFP(board[r - 1, c]);

                if (r < rows - 1 && board[r + 1, c] != null) // South
                    coinsGenerated += building.GenerateCoinsFP(board[r + 1, c]);

                if (c > 0 && board[r, c - 1] != null) // West
                    coinsGenerated += building.GenerateCoinsFP(board[r, c - 1]);

                if (c < cols - 1 && board[r, c + 1] != null) // East
                    coinsGenerated += building.GenerateCoinsFP(board[r, c + 1]);

                // Diagonal checks
                if (r > 0 && c < cols - 1 && board[r - 1, c + 1] != null) // Northeast
                    coinsGenerated += building.GenerateCoinsFP(board[r - 1, c + 1]);

                if (r > 0 && c > 0 && board[r - 1, c - 1] != null) // Northwest
                    coinsGenerated += building.GenerateCoinsFP(board[r - 1, c - 1]);

                if (r < rows - 1 && c < cols - 1 && board[r + 1, c + 1] != null) // Southeast
                    coinsGenerated += building.GenerateCoinsFP(board[r + 1, c + 1]);

                if (r < rows - 1 && c > 0 && board[r + 1, c - 1] != null) // Southwest
                    coinsGenerated += building.GenerateCoinsFP(board[r + 1, c - 1]);
            }
        }
    }

    return coinsGenerated;
}

static int CalculateUpkeepCostARC(Building[,] board)
{
    int upkeepCost = 0;
    foreach (Building building in board)
    {
        if (building != null)
        {
            upkeepCost += building.calculateUpkeepCostARC(building);
        }
    }
    return upkeepCost;
}

static int CalculateUpkeepCostFP(Building[,] board)
{
    int upkeepCost = 0;
    foreach (Building building in board)
    {
        if (building != null)
        {
            upkeepCost += building.calculateUpkeepCostFP(building);
        }
    }
    return upkeepCost;
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
        Console.Write("\nEnter [0] to return to main menu: ");
        string input = Console.ReadLine();
        if (input == "0")
        {
            return;
        }
    }
}

void SetConsoleColor(Building building)
{
    switch (building)
    {
        case Residential:
            Console.ForegroundColor = ConsoleColor.Green;
            break;
        case Industry:
            Console.ForegroundColor = ConsoleColor.Red;
            break;
        case Commercial:
            Console.ForegroundColor = ConsoleColor.Blue;
            break;
        case Park:
            Console.ForegroundColor = ConsoleColor.Magenta;
            break;
        case Road:
            Console.ForegroundColor = ConsoleColor.Yellow;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.White;
            break;
    }
}

// Method to read high scores from a CSV file
List<Tuple<string, int>> LoadHighScores(string filePath)
{
    var highScores = new List<Tuple<string, int>>();
    var lines = File.ReadAllLines(filePath);

    foreach (var line in lines.Skip(1)) // Skip header
    {
        var parts = line.Split(',');

        highScores.Add(new Tuple<string, int>(
            parts[0],
            int.Parse(parts[1])
        ));
    }

    return highScores;
}

void DisplayHighScores(string filePath)
{
    if (!File.Exists(filePath))
    {
        // If the file does not exist, create an empty file
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write header
            writer.WriteLine("Name,Score");
        }
    }
    var highScores = LoadHighScores(filePath);
    Console.WriteLine("High Scores:");
    foreach (var score in highScores.OrderByDescending(s => s.Item2).Take(10))
    {
        Console.WriteLine($"{score.Item1} - {score.Item2}");
    }
    

    while (true)
    {
        Console.Write("\nEnter [0] to return to main menu: ");
        string input = Console.ReadLine();
        if (input == "0")
        {
            return;
        }
    }
}


void EndGame(string filePath, int score)
{
    // Ensure the file exists
    if (!File.Exists(filePath))
    {
        // Create the file with an empty high score list
        var lines = new List<string> { "Name,Score" };
        File.WriteAllLines(filePath, lines);
    }

    Console.WriteLine($"Game over. Your final score is {score}.");

    var highScores = LoadHighScores(filePath);
    if (highScores.Count < 10 || score > highScores.Last().Item2)
    {
        Console.Write("Congratulations! You made it to the top 10. Enter your name: ");
        string playerName = Console.ReadLine();
        highScores.Add(new Tuple<string, int>(playerName, score));
        highScores = highScores.OrderByDescending(s => s.Item2).Take(10).ToList(); // Keep top 10 scores

        var lines = new List<string> { "Name,Score" }; // Add the header
        lines.AddRange(highScores.Select(score => $"{score.Item1},{score.Item2}"));
        File.WriteAllLines(filePath, lines);
    }
}

//Function to check if the board if full
bool IsBoardFull(Building[,] board)
{
    for (int i = 0; i < board.GetLength(0); i++)
    {
        for (int j = 0; j < board.GetLength(1); j++)
        {
            if (board[i, j] == null)
            {
                return false; //return false if any element is null
            }
        }
    }
    return true;
}

void SaveGame(string mode, Building[,] board, int turn, int score, int coins, int lostCount)
{
    Console.Write("Enter a name for the save file (leave empty for default): ");
    string inputFileName = Console.ReadLine();
    string defaultFileName = "save";
    string fileName = string.IsNullOrEmpty(inputFileName) ? defaultFileName : inputFileName;

    string folderPath = Path.Combine("saves", mode == "FreePlay" ? "FreePlay" : "Arcade");
    string filePath = Path.Combine(folderPath, fileName + ".txt");
    Directory.CreateDirectory(folderPath); // Ensure the directory exists   

    using (StreamWriter writer = new StreamWriter(filePath))
    {
        writer.WriteLine(mode);
        writer.WriteLine(turn);
        writer.WriteLine(score);
        writer.WriteLine(coins);
        writer.WriteLine(lostCount);
        int size = board.GetLength(0);
        writer.WriteLine(size);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (board[i, j] == null)
                {
                    writer.Write(" ");
                }
                else if (board[i, j] is Residential)
                {
                    writer.Write("R");
                }
                else if (board[i, j] is Industry)
                {
                    writer.Write("I");
                }
                else if (board[i, j] is Commercial)
                {
                    writer.Write("C");
                }
                else if (board[i, j] is Park)
                {
                    writer.Write("O");
                }
                else if (board[i, j] is Road)
                {
                    writer.Write("*");
                }
            }
            writer.WriteLine();
        }
    }
}

(string, Building[,], int, int, int, int) LoadGame()
{
    Console.WriteLine("Available save files:");
    ListSaveFiles();
    Console.Write("\nEnter the name of the save file to load (without extension): ");
    var inputFileName = Console.ReadLine();

    if (string.IsNullOrEmpty(inputFileName))
    {
        Console.WriteLine("Invalid file name.");
        while (true)
        {
            Console.WriteLine("Enter [0] to return to main menu: ");
            string input = Console.ReadLine();
            if (input == "0")
            {
                return (null, null, 0, 0, 0, 0);
            }
        }
    }
    string arcadeFilePath = Path.Combine("saves", "Arcade", inputFileName + ".txt");
    string freePlayFilePath = Path.Combine("saves", "FreePlay", inputFileName + ".txt");

    string fileName = null;
    if (File.Exists(arcadeFilePath))
    {
        fileName = arcadeFilePath;
    }
    else if (File.Exists(freePlayFilePath))
    {
        fileName = freePlayFilePath;
    }
    else
    {
        Console.WriteLine("Save file not found.");
        while (true)
        {
            Console.WriteLine("Enter [0] to return to main menu: ");
            string input = Console.ReadLine();
            if (input == "0")
            {
                return (null, null, 0, 0, 0, 0);
            }
        }
    }


    using (StreamReader reader = new StreamReader(fileName))
    {
        string mode = reader.ReadLine();
        int turn = int.Parse(reader.ReadLine());
        int score = int.Parse(reader.ReadLine());
        int coins = int.Parse(reader.ReadLine());
        int lostCount = int.Parse(reader.ReadLine());
        int size = int.Parse(reader.ReadLine());

        Building[,] board = new Building[size, size];

        for (int i = 0; i < size; i++)
        {
            string line = reader.ReadLine();
            for (int j = 0; j < size; j++)
            {
                switch (line[j])
                {
                    case 'R':
                        board[i, j] = new Residential();
                        break;
                    case 'I':
                        board[i, j] = new Industry();
                        break;
                    case 'C':
                        board[i, j] = new Commercial();
                        break;
                    case 'O':
                        board[i, j] = new Park();
                        break;
                    case '*':
                        board[i, j] = new Road();
                        break;
                    default:
                        board[i, j] = null;
                        break;
                }
            }
        }
 
        return (mode, board, turn, score, coins, lostCount);
    }
}

void ListSaveFiles()
{
    string arcadeFolder = Path.Combine("saves", "Arcade");
    Directory.CreateDirectory(arcadeFolder); // Ensure the directory exists  
    string[] arcadeFiles = Directory.GetFiles(arcadeFolder, "*.txt");
    
    Console.WriteLine("Arcade save files:");
    if (arcadeFiles.Length == 0)
    {
        Console.WriteLine("No Arcade save files found.");
    }
    else
    {
        foreach (string file in arcadeFiles)
        {
            Console.WriteLine(Path.GetFileNameWithoutExtension(file));
        }
    }

    string freePlayFolder = Path.Combine("saves", "FreePlay");
    Directory.CreateDirectory(freePlayFolder); // Ensure the directory exists   
    string[] freePlayFiles = Directory.GetFiles(freePlayFolder, "*.txt");

    Console.WriteLine("FreePlay save files:");
    if (freePlayFiles.Length == 0)
    {
        Console.WriteLine("No FreePlay save files found.");
    }
    else
    {
        foreach (string file in freePlayFiles)
        {
            Console.WriteLine(Path.GetFileNameWithoutExtension(file));
        }
    }
}
