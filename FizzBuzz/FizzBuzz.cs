using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace FizzBuzz
{
	class FizzBuzz
	{
		static void Main(string[] args)
		{
			//Write a program that prints the numbers from 1 to 100. But for multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”. For numbers which are multiples of both three and five print “FizzBuzz “
			string ans = "";

			for (int i = 1; i <= 100; i++)
			{
				if (i % 3 == 0)
					ans += "Fizz";

				if (i % 5 == 0)
					ans += "Buzz";

				if (ans == "")
					Console.WriteLine(i);
				else
					Console.WriteLine(ans);

				ans = "";
			}

			//loop through int ++, 
			//check if int % 3 = 0; +fizz to string 
			//else check if int % 5 = 0; +buzz to string.
			//print and empty string.
			//else print int;


			Console.WriteLine("\nConverting 2006 into roman numerals for unit test.");
			//int convert = int.Parse(Console.ReadLine());
			int convert = 2006;

			//enter a number
			string ans2 = NumeralConverter(convert);

			Console.WriteLine(ans2);

			//Console.WriteLine("\nPlease enter a string you wish to word wrap.");
			//string input = Console.ReadLine();

			//Console.WriteLine("\nPlease enter a row length you wish to use for your word wrap.");
			//int rowlength = int.Parse(Console.ReadLine());

			Console.WriteLine("\nTesting for word wrapping. Press Enter to continue." );
			Console.ReadLine();

			Console.WriteLine("Input: abcdefghijklmnopqrstuvwxyz1234 \nRow Length: 60");

			string input = "abcdefghijklmnopqrstuvwxyz1234";
			int rowlength = 60;
			WordWrapping(input, rowlength);

			Console.WriteLine("Input: abcdef\nRow Length: 3");
			input = "abcdef";
			rowlength = 3;
			WordWrapping(input, rowlength);

			Console.WriteLine("Input: abc def\nRow Length: 3");
			input = "abc def";
			rowlength = 3;
			WordWrapping(input, rowlength);

			Console.WriteLine("Input: abcdef abc\nRow Length: 3");
			input = "abcdef abc";
			rowlength = 3;
			WordWrapping(input, rowlength);

			Console.WriteLine("Input: a b c d e f\nRow Length: 3");
			input = "a b c d e f";
			rowlength = 3;
			WordWrapping(input, rowlength);

			Console.WriteLine("Testing complete. By Tom Smith");

		}


		static string NumeralConverter(int Number)
		{

			//Write a program that converts any number into roman numerals. The chart for roman numerals is below
			//Generally, Roman numerals are written in descending order from left to right, and are added sequentially, for example MMVI (2006) is interpreted as 1000 + 1000 + 5 + 1.

			//Numerals and Number counterparts, map number to letter
			string[] Roman = {"M", "D", "C", "L", "X", "V", "I" };
			int[] Numbers = {1000, 500, 100, 50, 10, 5, 1 };
			//Do the maths, convert to roman numerals. This was confusing at first. Reverse the process. M + M + V + I = 2006. Using numerals 2000 - 1000 - 1000 - 5 - 1 = 0.

			//End result we are looking for.
			int y = 0;
			string ans = "";

			//Looking to get down to 0
			while(Number > 0)
				if (Number - Numbers[y] >= 0)		
				{
					ans += Roman[y];		//Add Numeral to final result
					Number -= Numbers[y];	//Take away the Number to move onto the remainder of the number. (2000 - 1000 results in M, cycles back round to do another 2000 - 1000 in another M)
				}
				else
					y++;   //Find the initial tenth/hundredth/thousandth of the number, also moves onto the next digits tenth/hundredth/thousandth.

			return ans; //Return numerals.

			/////////Not sure how to go about the special cases such as IV and IX, 4 and 9. Getting the letters to switch sides could get messy. Will come back to this.

		}


		//In text editors you can usually find a configuration setting named "Word wrap". When checked, lines that do not fit horizontally in the editor window are "wrapped" to several lines, thus removing the need for a horizontal scroll bar in the window.Develop a word-wrapping algorithm, which is given a string and a row-length, and returns a list of word-wrapped-rows.
		/*If the row-length is 60, and the input string is 30, the result is just the input string			//// Done
		If the row-length is 3, and the input string is "abc def" the result is "abc", "def"				//// Done
		If the row-length is 3, and the input string is "abcdef" the result is "abc", "def"					//// Done
		If the row-length is 3, and the input string is "abcdef abc" the result is "abc", "def", "abc"		//// Done
		With row length 3 and "a b c d e f" the result is "a b", "c d", "e f"*/								//// DONE

		static void WordWrapping(string input, int rowlength)
        {
			//separate input into character array, then form new strings the length of the rowlength, could use \n every rowlength amount of characters in a string to move it onto the next line for the word wrap.
			int start = 0;
			//Console.WriteLine("String length = " + inputlength);
			int inputlength = input.Length;
			List<char> templist;
			char[] temparray = {' '};
			char[] chararray;
			//If the rowlength is great than input length.
			if (rowlength > input.Length)
				Console.WriteLine(input);
			else
			{
				//Take away from string, measuring stringlength and whilst stringlength is > 0 keep creating new chararrays.
				while (inputlength > 0)
				{

					

					//Create character array of input based on length of string and length of row.
					chararray = input.ToCharArray(start, rowlength);


					//Account for the removal of the first space and "move" array down 1 char. To avoid "a b", "c (d", "d) e" etc.
					if (chararray[0] == temparray[0] && chararray[0] != ' ')
					{
						templist = chararray.ToList();
						templist.RemoveAt(0);
						temparray = input.ToCharArray(start + rowlength, 1); //Create new char array just to add on the new final char in the array.
						templist.Add(temparray[0]);
						chararray = templist.ToArray<char>();
						//chararray = SpaceRemoval(chararray, input, start, rowlength, out temparray);
					}

					//If first char is a space. Convert to a list to remove space and add what would be the final character ignoring the space. Then minus the input length by 1 to account for the removed space.
					if (chararray[0] == ' ')
                    {
						templist = chararray.ToList();
						templist.RemoveAt(0); //Remove space
						temparray = input.ToCharArray(start+rowlength, 1);//Create new char array just to add on the new final char in the array.

						while(temparray[0] == ' ')			//Cycle removing spaces until you reach the next character.
							temparray = input.ToCharArray(start + rowlength + 1, 1);
						
						templist.Add(temparray[0]);
						chararray = templist.ToArray<char>();
						//chararray = SpaceRemoval(chararray, input, start, rowlength, out temparray);
						inputlength -= 1;

					}

					start += rowlength; //Start the next row from the end of the previous row. 
										   //Console.WriteLine("Start: " + start);

					inputlength -= rowlength; //Decrease inputlength until it's done.
											  //Console.WriteLine("inputlength: " + inputlength);

					Console.WriteLine(chararray);


					//Accounting for awkward row lengths, such as 6 length input string with a 4 row length. Gives "abcd", "ef". 
					if (inputlength < rowlength)
					{
						rowlength = inputlength;
					}

				}
			}

			Console.WriteLine("\nPress enter to continue to next test.");
			Console.ReadLine();
		}

		//Doesn't work as intended, would use this to clean up text.

		/*static char[] SpaceRemoval(char[] chararray, string input, int start, int rowlength, out char[] temparray)
        {
			List<char> templist;
			templist = chararray.ToList();
						templist.RemoveAt(0); //Remove space
						temparray = input.ToCharArray(start+rowlength, 1);//Create new char array just to add on the new final char in the array.

						while(temparray[0] == ' ')			//Cycle removing spaces until you reach the next character.
							temparray = input.ToCharArray(start + rowlength + 1, 1);
						
						templist.Add(temparray[0]);

						return templist.ToArray<char>();
		}*/




	}

}



