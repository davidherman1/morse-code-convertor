using System;
using System.Collections.Generic;

class MorseCodeConverter
{
    private static readonly Dictionary<char, string> charToMorse = new Dictionary<char, string>()
    {
        {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
        {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
        {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
        {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
        {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
        {'Z', "--.."}, {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
        {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."},
        {'9', "----."}
    };

    private static readonly Dictionary<string, char> morseToChar = new Dictionary<string, char>();

    static MorseCodeConverter()
    {
        foreach (KeyValuePair<char, string> pair in charToMorse)
        {
            morseToChar[pair.Value] = pair.Key;
        }
    }

    public static string TextToMorse(string text)
    {
        text = text.ToUpper();
        string morseCode = "";
        foreach (char c in text)
        {
            if (charToMorse.ContainsKey(c))
            {
                morseCode += charToMorse[c] + " ";
            }
            else if (c == ' ')
            {
                morseCode += "/ ";
            }
        }
        return morseCode.Trim();
    }

    public static string MorseToText(string morse)
    {
        string[] words = morse.Split(new[] { " / " }, StringSplitOptions.None);
        string text = "";
        foreach (string word in words)
        {
            string[] letters = word.Split(' ');
            foreach (string letter in letters)
            {
                if (morseToChar.ContainsKey(letter))
                {
                    text += morseToChar[letter];
                }
            }
            text += " ";
        }
        return text.Trim();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for input
        Console.WriteLine("Enter the text to convert to Morse Code:");
        string inputText = Console.ReadLine();

        // Convert text to Morse code
        string morseCode = MorseCodeConverter.TextToMorse(inputText);
        Console.WriteLine("Text to Morse: " + morseCode);

        // Ask the user for Morse code to convert to text
        Console.WriteLine("\nEnter the Morse code to convert to text (use spaces between letters and '/' for spaces between words):");
        string inputMorse = Console.ReadLine();

        // Convert Morse code to text
        string normalText = MorseCodeConverter.MorseToText(inputMorse);
        Console.WriteLine("Morse to Text: " + normalText);
    }
}
