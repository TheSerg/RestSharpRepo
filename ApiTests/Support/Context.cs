namespace ApiTests.Utilities.ScenarioSupport
{
    using System.Collections.Generic;
    using ApiTests.Utilities.Enums;

    public class Context<T>
    {
        public static readonly Dictionary<ContextKeys, T> Directory = new Dictionary<ContextKeys, T>();

        public static void Add(ContextKeys key, T value)
        {
            Directory.Add(key, value);
        }

        public static T GetValue(ContextKeys key)
        {
            var currentKey = Directory[key];
            RemoveKey(key);
            return currentKey;
        }

        public static void RemoveKey(ContextKeys key)
        {
            Directory.Remove(key);
        }
    }
}
