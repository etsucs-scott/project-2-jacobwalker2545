using System.Collections.Generic;

namespace WarGame.Core
{
//creates the hand of the player
public class Hand
{
	//goes through the cards 
	private Queue<Card> cards = new Queue<Card> ();

	public int Count => cards.Count;

	public void AddCard(Card card)
	{
		cards.Enqueue(card);
	}
	//plays the cards 
	public Card PlayCard()
	{
		return cards.Dequeue();
	}
}
}
