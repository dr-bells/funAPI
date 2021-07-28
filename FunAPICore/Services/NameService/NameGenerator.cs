using System;
using System.Collections.Generic;
using System.Linq;
using funAPI.Models;

namespace funAPI
{
    public class NameGenerator
    {
        private static Random random = new Random();
        public static string RandomNameGenerator(List<Names> dbNames)
        {
            string newGeneratedName = "";
            const string bigChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string smallChars = "abcdefghijklmnopqrstuvwxyz";
            bool nameExists = false;

            do
            {
                newGeneratedName = NameGen(bigChars, smallChars);
                foreach (var name in dbNames)
                    if (name.Name == newGeneratedName)
                        nameExists = true;
            } while (nameExists);
            return newGeneratedName;
        }

        private static string NameGen(string bigChars, string smallChars)
        {
            string newGenName = new string(Enumerable.Repeat(bigChars, 1)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            int length = random.Next(3, 49);
            newGenName += new string(Enumerable.Repeat(smallChars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            return newGenName;
        }
    }
}