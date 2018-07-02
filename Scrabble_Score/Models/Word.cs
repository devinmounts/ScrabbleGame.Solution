using System;
using System.Collections.Generic;
using System.Linq;

namespace ScrabbleScore.Models
{
    public class Word
    {
        private string _wordToScore;
        private int _wordScore;
        private Dictionary<char, int> _letterValues = new Dictionary<char, int>() { };
        private List<char> _onePointLetters = new List<char>() { 'a', 'e', 'i', 'o', 'u', 'l', 'n', 'r', 's', 't' };
        private List<char> _twoPointLetters = new List<char>() { 'd', 'g' };
        private List<char> _threePointLetters = new List<char>() { 'b', 'c', 'm', 'p' };
        private List<char> _fourPointLetters = new List<char>() { 'f', 'h', 'v', 'w', 'y' };
        private List<char> _fivePointLetters = new List<char>() { 'k' };
        private List<char> _eightPointLetters = new List<char>() { 'j', 'x' };
        private List<char> _tenPointLetters = new List<char>() { 'q', 'z' };
        private static List<Word> _enteredWord = new List<Word> {};

        public Word()
        {
            this.BuildLetterValueDictionary(_onePointLetters, 1);
            this.BuildLetterValueDictionary(_twoPointLetters, 2);
            this.BuildLetterValueDictionary(_threePointLetters, 3);
            this.BuildLetterValueDictionary(_fourPointLetters, 4);
            this.BuildLetterValueDictionary(_fivePointLetters, 5);
            this.BuildLetterValueDictionary(_eightPointLetters, 8);
            this.BuildLetterValueDictionary(_tenPointLetters, 10);
        }

        public void BuildLetterValueDictionary(List<char> pointList, int pointValue)
        {
            for (int i = 0; i < pointList.Count; ++i)
            {
                _letterValues[pointList[i]] = pointValue;
            }
        }
        public void  SetWordScore(int startingScore)
        {
            _wordScore = startingScore;
        }

        public void SetWordToScore(string usersWord)
        {
            _wordToScore = usersWord;
        }

        public string GetWordToScore()
        {
            return _wordToScore;
        }

        public int GetWordScore()
        {
            return _wordScore;
        }

        public void SaveWord()
        {
            _enteredWord.Add(this);
        }

        public static List<Word> GetAll()
        {
            return _enteredWord;
        }

        public int GetLetterValue(char letter)
        {
            return _letterValues[letter];
        }

        public char[] ConvertWordToArrayAndLower()
        {
            string lowerWordToScore = _wordToScore.ToLower();
            char[] letterArray = lowerWordToScore.ToCharArray();
            CalculateWordScore(letterArray);
            return letterArray;
        }

        public void CalculateWordScore(char[] letterArray)
        {
            for (int i = 0; i < letterArray.Length; ++ i)
            {
                _wordScore = _wordScore + (_letterValues[letterArray[i]]);
            }
        }

    }
}
