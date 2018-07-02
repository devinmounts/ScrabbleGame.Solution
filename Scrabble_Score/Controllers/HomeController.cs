using Microsoft.AspNetCore.Mvc;
using ScrabbleScore.Models;
using System.Collections.Generic;

namespace ScrabbleScore.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public ActionResult Form()
        {
            return View();
        }

        [Route("/save_word")]
        public ActionResult SaveToWordList()
        {
            Word newWord = new Word();
            newWord.SetWordToScore(Request.Query["word"]);
            newWord.ConvertWordToArrayAndLower();
            newWord.SaveWord();
            return View("Form");
        }


        [Route("/word_score")]
        public ActionResult WordScorer()
        {
            Word newWord1 = new Word();
            newWord1.SetWordToScore(Request.Query["word01"]);
            newWord1.ConvertWordToArrayAndLower();
            newWord1.SaveWord();
            Word newWord2 = new Word();
            newWord2.SetWordToScore(Request.Query["word02"]);
            newWord2.ConvertWordToArrayAndLower();
            newWord2.SaveWord();
            Word newWord3 = new Word();
            newWord3.SetWordToScore(Request.Query["word03"]);
            newWord3.ConvertWordToArrayAndLower();
            newWord3.SaveWord();
            List<Word> result = Word.GetAll();
            return View("GameScore", result); 
        }


    }
}