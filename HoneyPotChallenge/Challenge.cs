﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneyPotChallenge
{
    public class Challenge
    {
        private static readonly string[] validSubjects = new[] { "Physics", "Chemistry", "Math", "Botany", "Zoology" };

        public static int MinPossibleClasses(string skills)
        {
            if (string.IsNullOrEmpty(skills))
                return default;

            var validSkills = validSubjects.Select(vs => vs.Substring(0, 1).ToLower());
            var availableSkills = skills
                .Select(skill => skill.ToString().ToLower())
                .Where(skill => validSkills.Contains(skill));

            if (!validSkills.All(skill => availableSkills.Contains(skill)))
                return default;

            return availableSkills
                .GroupBy(skill => skill)
                .Min(g => g.Count());
        }

        public static int MinCans(List<int> used, List<int> total)
        {
            if (total.Count != used.Count)
                throw new ArgumentException($"{nameof(total)} number of cans must be the same as {nameof(used)} number of cans.", nameof(total));
            if (!total.Any() || !used.Any())
                return default(int);

            //var remainingSpaces = total.Zip(used, (t, u) => t - u);
            //if (remainingSpaces.Any(rs => rs < 0))
            //    throw new ArgumentException($"{nameof(used)} amount cannot be more than total amount", nameof(used));

            var totalRequiredSpace = used.Sum();
            var totalCansNeeded = 0;

            foreach (var availableSpace in total.OrderByDescending(space => space))
            {
                totalRequiredSpace -= availableSpace;
                totalCansNeeded++;
                if (totalRequiredSpace <= 0)
                    break;
            }
            return totalCansNeeded;
        }
    }
}
