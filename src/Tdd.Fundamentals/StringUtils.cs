using System;

namespace Tdd.Fundamentals
{
    public class StringUtils
    {
        private readonly ILogger logger;

        public StringUtils(ILogger logger)
        {
            this.logger = logger;
        }

        public int FindNumberOfOccurrences(string sentence, string character)
        {
            if (character.Length != 1)
                throw new ArgumentException("Must be one character length", nameof(character));

            int numberOfOccurrencies = 0;
            var characterToSearchFor = char.Parse(character);

            foreach (char c in sentence)
            {
                if (c == characterToSearchFor) numberOfOccurrencies++;
            }

            this.logger.LogMemberCalled(nameof(FindNumberOfOccurrences), sentence, character);

            return numberOfOccurrencies;
        }
    }
}
