using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncromaticsTest
{
	class Parse
	{
		//Global variables
		private bool _ignorWhiteSpace = true;
		private char _mostChar;
		private int _charTimes;
		Dictionary<char, int> CharacterCount = new Dictionary<char, int>();

		//private List<char> _sameMostChar = new List<char>();
		//private bool _multipleChar = false; 

		//Parsing of one article at a time. 
		public Parse(string text)
		{
			ParseAllString(text);

			//Linq statement to group the dictionary by highest value. 
			var item = from pair in CharacterCount orderby pair.Value descending select pair;
			_mostChar = item.FirstOrDefault().Key;
			_charTimes = item.FirstOrDefault().Value;
			

			//Some articles have more than one highest used char. 
			//Doesnt work right!!
			//var dublicate = CharacterCount.ToLookup(x => x.Value, x => x.Key).Where(x => x.Count() > 1);
			//foreach (var dub in dublicate)
			//{
			//	if(dub.Count() > 1)
			//	{
			//		_multipleChar = true;
			//		foreach (var d in dub)
			//			_sameMostChar.Add(d);
			//	}
			//}
				



		}

		//Parses all the articles and returns overall most used char.
		public Parse(List<String> articles)
		{
			//Reusuable function to parse the string and return the most used char.
			foreach (var a in articles)
				ParseAllString(a);

			//Linq statement to group the dictionary by highest value. 
			var item = from pair in CharacterCount orderby pair.Value descending select pair;
			_mostChar = item.FirstOrDefault().Key;
			_charTimes = item.FirstOrDefault().Value;

		}

		public string GetCharacter()
		{
			//if(_multipleChar)
			//{
			//	string result = "";
			//	foreach (var c in _sameMostChar)
			//		result += c.ToString() + " ";
			//	return result;
			//}
			return _mostChar.ToString();
		}

		public int GetNumber()
		{
			return _charTimes;
		}

		//parses string into character array and puts the char as key and times seen as value in dictionary.
		private void ParseAllString(string article)
		{
			string[] stringArray;

			//split strings and removes all the empty vaibales to ignore white space.
			if (_ignorWhiteSpace)
				stringArray = article.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			else
			//split strings and includes all white space.
				stringArray = article.Split(new char[] { ' ' }, StringSplitOptions.None);

			//adding to dictionary to keep track of the characters.
			foreach (var sa in stringArray)
			{
				char[] articleCharacter = sa.ToCharArray();

				foreach (var c in articleCharacter)
				{
					if (CharacterCount.ContainsKey(c))
					{
						CharacterCount[c] = CharacterCount[c] + 1;
					}
					else
					{
						CharacterCount.Add(c, 1);
					}
				}

			}
		}


	}
}
