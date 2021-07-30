using System;
using System.Collections.Generic;
using funAPI.Models;

namespace funAPI.Services.StatisticsService
{
    public class StatisticsCalculator
    {
        public static double AverageNameLengthCalculator(List<Names> dbNames)
        {
            double averageNameLength = 0;
            double sum = 0;
            foreach (var name in dbNames)
                sum += name.Name.Length;
            averageNameLength = sum / dbNames.Count;
            return averageNameLength;
        }

        public static string LongestGeneratedName(List<Names> dbNames)
        {
            var longestName = "";
            foreach (var name in dbNames)
                if (name.Name.Length > longestName.Length)
                    longestName = name.Name;
            return longestName;
        }

        public static string ShortestGeneratedName(List<Names> dbNames)
        {
            var longestName = LongestGeneratedName(dbNames);
            var shortestName = longestName;
            foreach (var name in dbNames)
                if (name.Name.Length < shortestName.Length)
                    shortestName = name.Name;
            return shortestName;
        }
    }
}