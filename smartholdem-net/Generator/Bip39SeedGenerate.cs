using System;
using NBitcoin;

namespace SmartHoldemNet.Generator
{
    public class Bip39SeedGenerate : ISeedGenerate<string>
    {
        private Wordlist WordList { get; }
        private WordCount WordCount { get; }

        public Bip39SeedGenerate(Wordlist wordList, WordCount wordCount)
        {
            if (wordList == null) throw new ArgumentNullException(nameof(wordList));
            if (!Enum.IsDefined(typeof(WordCount), wordCount)) throw new ArgumentOutOfRangeException(nameof(wordCount));
            
            WordList = wordList;
            WordCount = wordCount;
        }

        public string Generate()
        {
            var mnemonic = new Mnemonic(WordList, WordCount);
            return string.Join(" ", mnemonic.Words);
        }
    }
}