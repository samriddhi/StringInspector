using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncromaticsTest
{
	class Program
	{
		static void Main(string[] args)
		{


			var articles = GetArticles(@"./Articles");
			int index = 0;

			//Get overall most used character in all articles
			var parse = new Parse(articles);
			Console.WriteLine("Overall most used character in articles: " + parse.GetCharacter());
			Console.WriteLine("Character was used: " + parse.GetNumber());


			//Get overall most used character in each articles
			var text = GetNextArticle(articles);
			while (text != null)
			{
				index++;
				var mostUsed = new Parse(text);

				Console.WriteLine("The most used character in article " + index + " : " + mostUsed.GetCharacter() + " repeated " + mostUsed.GetNumber() + " times");

				text = GetNextArticle(articles);
			}


			Console.WriteLine("Press any key to quit");
			Console.ReadLine();

		}

		//Using streamreader to read the sample articles added. 
		//Searched google to do this so could add saample within the project.
		public static List<string> GetArticles(string url)
		{
			//List of all sample articles added.
			List<string> article = new List<string>();

			try
			{
				//Gets all file and directory statistics. Can use to get attributes of file or directory.
				DirectoryInfo directory = new DirectoryInfo(url);
				foreach (FileInfo file in directory.EnumerateFiles("*.txt"))
				{
					using (StreamReader reader = file.OpenText())
					{
						StringBuilder builder = new StringBuilder();
						string s = "";
						
						while ((s = reader.ReadLine()) != null)
							builder.Append(s);

						article.Add(builder.ToString());
						//Console.WriteLine(reader.ReadToEnd());

					}

				}

			}
			//Used generic exception to catch all could catch only IO exceptions if needed.
			catch (Exception ex)
			{
				throw ex;
			}



			return article;
		}

		//Resuable function to get next article in List instead of rewriting.
		public static string GetNextArticle(List<String> article){
			var text = article.FirstOrDefault();
			article.Remove(text);

			return text;
		}
	}
}
