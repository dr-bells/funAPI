using System;
using System.Collections.Generic;
using System.Linq;
using funAPI.Models;
using FunAPICore.Data;

namespace funAPI
{
    public static class NameGenerator
    {
        private static Random _random = new Random();
        public static string RandomNameGenerator(List<Names> dbNames)
        {
            string newGeneratedName = "";
            bool nameExists = false;

            do
            {
                Names newName = new Names();
                newGeneratedName = GenerateName(Constants.BigCharacters, Constants.SmallCharacters);
                newName.Name = newGeneratedName;
                if (dbNames.Contains(newName))
                    nameExists = true;
            } while (nameExists);
            return newGeneratedName;
        }

        private static string GenerateName(string bigChars, string smallChars)
        {
            int length = _random.Next(3, 49);

            string newGenName = new string(Enumerable.Repeat(bigChars, 1)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
            newGenName += new string(Enumerable.Repeat(smallChars, length)
                  .Select(s => s[_random.Next(s.Length)]).ToArray());
            return newGenName;
        }
    }
}