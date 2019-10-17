namespace ApiTests.Utilities.Helpers
{
    using System;
    using System.Linq;

    public enum RndType
    {
        UPPER,
        LOWER,
        DIGITS,
        ADDRESS
    }

    public class RandomString
    {
        private const string UPPER = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LOWER = "abcdefghijklmnopqrstuvwxyz";
        private const string DIGITS = "0123456789";
        private const string ADDRESS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789/";

        public RandomString(RndType type, int length)
        {
            Random random = new Random();
            string chars = this.GetChars(type);

            this.Value = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string Value { get; private set; }

        private string GetChars(RndType type)
        {
            switch (type)
            {
                case RndType.UPPER:
                    return UPPER;

                case RndType.LOWER:
                    return LOWER;

                case RndType.ADDRESS:
                    return ADDRESS;

                default:
                    return DIGITS;
            }
        }
    }
}
