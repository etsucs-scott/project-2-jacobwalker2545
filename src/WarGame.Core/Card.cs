
using System;

namespace WarGame.Core
{
	//This will create all the cards
public enum Suit 
{
	Hearts,
	Diamonds,
	Clubs,
	Spades
}
public enum Rank 
{
	Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
}
//This class will create the suits, and ranks
public class Card : IComparable<Card>
{
	public Suit Suit {get; set;}
	public Rank Rank {get; set;}

	public Card(Suit  suit, Rank rank)
	{
		Suit = suit;
		Rank = rank;
	}
	//goes between the cards to see who wins the round 

	public int CompareTo (Card other)
	{
		return this.Rank.CompareTo(other.Rank);
	}
	public override string ToString()
	{
		return $"{Rank}";
	}
}
}
