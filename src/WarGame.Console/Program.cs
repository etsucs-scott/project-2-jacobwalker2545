using System;
using WarGame.Core;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Welcome to War Game");

		int playerCount = 2;
		if (args.Length > 0 && int.TryParse(args[0], out int count))
		{
			if (count >= 2 && count <= 4)
			playerCount = count;
		}
		else 
		{
			//this will ask the user for the player amount 
			while (true)
			{
				Console.Write("Enter number of players (2-4): ");
				var input = Console.ReadLine();
				if (int.TryParse(input, out int num) && num >= 2 && num <= 4)
				{
					playerCount = num;
					break;
				}
				Console.WriteLine("Invalid, try again.");
			}
		}
		Console.WriteLine($"\nStarting game with {playerCount} players...");

		//this will iniate the game
		Game game = new Game(playerCount);
		// this will run the game
		game.PlayGame();

		Console.WriteLine("\nThanks for playing War");
	}
}
