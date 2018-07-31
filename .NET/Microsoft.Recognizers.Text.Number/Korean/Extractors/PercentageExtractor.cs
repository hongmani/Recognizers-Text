using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

using Microsoft.Recognizers.Definitions.Korean;

namespace Microsoft.Recognizers.Text.Number.Korean
{
    public class PercentageExtractor : BaseNumberExtractor
    {
        internal sealed override ImmutableDictionary<Regex, string> Regexes { get; }

        protected sealed override string ExtractType { get; } = Constants.SYS_NUM_PERCENTAGE;

        public PercentageExtractor()
        {
            var regexes = new Dictionary<Regex, string>()
            {
                {
                    //百パーセント 十五パーセント
                    new Regex(NumbersDefinitions.SimplePercentageRegex, RegexOptions.Singleline),
                              "PerJpn"
                },
                {
                    //19パーセント　１パーセント
                    new Regex(NumbersDefinitions.NumbersPercentagePointRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline),
                              "PerNum"
                },
                {
                    //3,000パーセント  １，１２３パーセント
                    new Regex(NumbersDefinitions.NumbersPercentageWithSeparatorRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline),
                              "PerNum"
                },
                {
                    //3.2 k パーセント
                    new Regex(NumbersDefinitions.NumbersPercentageWithMultiplierRegex, RegexOptions.Singleline),
                              "PerNum"
                }
                ,
                {
                    //15kパーセント 
                    new Regex(NumbersDefinitions.SimpleNumbersPercentageWithMultiplierRegex, RegexOptions.Singleline),
                              "PerNum"
                },
                {
                // @TODO Example missing
                new Regex(NumbersDefinitions.SimpleIntegerPercentageRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline),
                              "PerNum"
                }
            };

            Regexes = regexes.ToImmutableDictionary();
        }
    }
}
