using System;
using System.Collections.Generic;

public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));    
        Console.WriteLine(englishToGerman.Translate("Plane"));  
        Console.WriteLine(englishToGerman.Translate("Train")); 
    }

    private Dictionary<string, string> _words = new();
    /// Add the translation from 'fromWord' to 'toWord'
   
    public void AddWord(string fromWord, string toWord)
    {
        // Add or update the translation in the dictionary
        _words[fromWord] = toWord;
    }

    /// Translates the from word into the word that this stores as the translation
   
    public string Translate(string fromWord)
    {
        // Return the translation if it exists; otherwise return "???"
        if (_words.ContainsKey(fromWord))
        {
            return _words[fromWord];
        }
        else
        {
            return "???";
        }
    }
}
