using System.Text.RegularExpressions;

namespace OldPhonePadTranslator
{
    public class OldPhonePadTranslator
    {
        static readonly string[][] numToCharMappings = [
            [" "],
            ["&", "'", "("],
            ["A", "B", "C"],
            ["D", "E", "F"],
            ["G", "H", "I"],
            ["J", "K", "L"],
            ["M", "N", "O"],
            ["P", "Q", "R", "S"],
            ["T", "U", "V"],
            ["W", "X", "Y", "Z"]
            ];

        /// <summary>
        /// Get string message from Phone Pad input
        /// </summary>
        /// <param name="input">Input in phone pad format</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public static String OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input) || !input.EndsWith('#')) throw new InvalidDataException();

            // regex pattern for matching groups of same repeated characters
            string pattern = @"(\d|\W)\1*";
            Regex regex = new Regex(pattern);
            var matchCollection = regex.Matches(input);

            if (matchCollection.Count == 0) throw new InvalidDataException();

            string result = "";
            foreach (Match match in matchCollection)
            {
                if (char.IsNumber(match.Value, 0))
                {
                    // get character from mappings by indexes
                    int index = int.Parse(match.Value[0].ToString());

                    if (match.Value.Length <= numToCharMappings[index].Length)
                    {
                        result += numToCharMappings[index][match.Value.Length - 1];
                    }
                    else
                    {
                        // in case value exceed acceptable length, we will assume that character is repeat from start again
                        // eg. 2222 => A
                        result += numToCharMappings[index][(match.Value.Length % numToCharMappings[index].Length) - 1];
                    }
                }
                // special cases
                else if (match.Value == "*")
                {
                    // remove last character
                    result = result.Substring(0, result.Length - 1);
                }
            }

            return result;
        }
    }
}
