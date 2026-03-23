using System;
using System.Collections.Generic;

namespace WarGame.Core
{
public class Deck
{
	private Stack<Card> cards;
	private Random rng =  new Random();

	public Deck ()
	{
		var temp = new List<Card>();

		foreach (Suit suit in Enum.GetValues (typeof(Suit)))
		{
			foreach (Rank rank in Enum.GetValues(typeof(Rank)))
			{
				temp.Add(new Card(suit, rank));
			}
		}
		//this will be used to shuffle the cards
		for (int i = temp.Count - 1; i>0; i--)
		{
			int j = rng.Next(i + 1);
			(temp[i], temp[j]) = (temp[j], temp[i]);
		}

		cards = new Stack<Card>(temp);
	}
	public bool HasCards() => cards.Count > 0;
	public Card Draw() => cards.Pop();
}
}
