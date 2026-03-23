
using System;
using System.Collections.Generic;
using System.Linq;

namespace WarGame.Core
{

public class Game
{
    public Dictionary<string, Hand> PlayerHands = new();
    private List<Card> pot = new();

    public Game(int playerCount)
    {
        for (int i = 1; i <= playerCount; i++)
        {
            PlayerHands.Add($"Player {i}", new Hand());
        }

        DealCards();
	//This will deal the cards to the player

    }

    private void DealCards()
    {
        Deck deck = new Deck();
        var players = PlayerHands.Keys.ToList();
        int index = 0;

        while (deck.HasCards())
        {
            PlayerHands[players[index]].AddCard(deck.Draw());
            index = (index + 1) % players.Count;
        }
    }
public void PlayGame()
{ 
	int round = 0;

	while (PlayerHands.Count(p => p.Value.Count > 0) > 1 && round < 10000)
	{
		round++;
		Console.WriteLine($"\nRound {round}");
		PlayRound();
	}

	var winner = PlayerHands.OrderByDescending(p => p.Value.Count).First();
	Console.WriteLine($"\nGame Over the Winner is: {winner.Key}");
}
private void PlayRound()
{
	Dictionary<string, Card> played = new();
	foreach (var player in PlayerHands)
	{
		if (player.Value.Count > 0)
		{
			var card = player.Value.PlayCard();
			played[player.Key] = card;
			pot.Add(card);

			Console.WriteLine($"{player.Key}: {card}");
		}
	}
	var highest = played.Values.Max();

	var winners = played
		.Where(p => p.Value.CompareTo(highest) == 0)
		.Select(p => p.Key)
		.ToList();

	if (winners.Count == 1)
	{ AwardPot(winners[0]);
	}
	else
	{
		HandleTie(winners);
	}
}
private void AwardPot(string winner)
{
	Console.WriteLine($"Winner: {winner}");

	foreach (var card in pot)
	{
		PlayerHands[winner].AddCard(card);
	}
	pot.Clear();

	PrintCounts();
}
private void PrintCounts()
{
	foreach (var player in PlayerHands)
	{
		Console.Write($"{player.Key}={player.Value.Count} ");
	}
	Console.WriteLine();
}
private void HandleTie(List<string> tiedPlayers)
{
	Console.WriteLine($"Tie between {string.Join(",", tiedPlayers)}!");

	while (tiedPlayers.Count > 1)
	{
		Dictionary<string, Card> tiebreak = new();
		
		foreach (var player in tiedPlayers.ToList())
		{
			if (PlayerHands[player].Count == 0)
			{
				tiedPlayers.Remove(player);
				continue;
			}
			var card = PlayerHands[player].PlayCard();
			pot.Add(card);
			tiebreak[player] = card;

			Console.WriteLine($"Tiebreaker: {player}: {card}");
		}
		var highest = tiebreak.Values.Max();

		tiedPlayers = tiebreak 
			.Where(p => p.Value.CompareTo(highest) == 0)
			.Select(p =>p.Key)
			.ToList();
	}
	if (tiedPlayers.Count == 1)
	{
		AwardPot(tiedPlayers[0]);
	}
}
}
}
