using System;
using System.Collections.Generic;

//takes a users string and checks to see if its a palindrome ( the same spelled forwards and backwards )
namespace palindromeValidator
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//makes a list for good words and bad words
			List<string> goodWords = new List<string>();
			List<string> badWords = new List<string>();

			//holds the words characters for comparison
			Stack<char> wordStack = new Stack<char>();
			Queue<char> wordQueue = new Queue<char>();

			string word = "";
			while (word != "0")
			{
				Menu();

				word = Console.ReadLine();
				if (word != "0")
				{
					//here is where the magic happens and the string is split into characters
					char[] input = word.ToCharArray();

					//build a stack and a queue of the characters in the word
					foreach (char a in input)
					{
						wordStack.Push(a);
					}
					foreach (char a in input)
					{
						wordQueue.Enqueue(a);
					}
					//assume the word is a palindrome -- innocent until proven guilty
					bool bad = false;
					Console.WriteLine("Checking " + word);
					for (int i = 0; i < word.Length; i++)
					{
						if (wordStack.Pop() != wordQueue.Dequeue())
						{
							bad = true;
						}
					}
					if (bad)
					{
						Console.WriteLine(word + " is not a palindrome");
						badWords.Add(word);
					}
					else
					{
						Console.WriteLine(word + " is a palindrome");
						goodWords.Add(word);
					}

					// display the words in the list
					Console.WriteLine();
					Console.WriteLine("---------------------------");
					Console.WriteLine("Palindromes");
					foreach (string s in goodWords)
					{
						Console.WriteLine(s);
					}
					Console.WriteLine("---------------------------");
					Console.WriteLine("NOT Palindromes");
					foreach (string s in badWords)
					{
						Console.WriteLine(s);
					}
					Console.WriteLine();
					//clear the stack and que
					wordStack.Clear();
					wordQueue.Clear();
				}
			}

		}

		/// <summary>
		/// Menu this instance.
		/// </summary>
		public static void Menu()
		{
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine("Enter a word to check if its a palindrome!");
			Console.WriteLine("Press 0 to quit");
		}
	}
}
