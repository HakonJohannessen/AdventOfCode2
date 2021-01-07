using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.App.Solved
{
    class Program
    {
        static void Main(string[] args) {
            List<string> frequencyChanges = Resources.FrequencyChanges;

            // Problem 1 (answer 543):
            int resultingFrequency = frequencyChanges.Sum(fc => int.Parse(fc));
            Console.WriteLine(resultingFrequency);

            // Problem 2 (answer 621):
            int firstDuplicateFrequency = frequencyChanges.Select(fc => int.Parse(fc)).FindFirstDuplicate();
            Console.WriteLine(firstDuplicateFrequency);

            Console.ReadKey();
        }
    }

    public static class ExtentionMethods
    {
        public static int FindFirstDuplicate(this IEnumerable<int> freqChanges, HashSet<int> freqSeen = null, int subtotal = 0) {
            freqSeen = freqSeen ?? new HashSet<int>();
            foreach (var fc in freqChanges) {
                subtotal += fc;
                if (!freqSeen.Add(subtotal)) {
                    return subtotal;
                }
            }
            return freqChanges.FindFirstDuplicate(freqSeen, subtotal);
        }
    }
}
