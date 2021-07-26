using System.Collections.Generic;
using funAPI.Models;

namespace funAPI.Services.StatisticsService
{
    public class StatisticsCalculator
    {
        public static double AverageNameLengthCalculator(List<Names> dbNames)
        {
            double averageNameLength = 0;
            int sum = 0;
            foreach (var name in dbNames)
                sum += name.Name.Length;
            averageNameLength = sum / dbNames.Count;
            return averageNameLength;
        }
    }
}