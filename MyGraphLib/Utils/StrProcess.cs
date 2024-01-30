namespace MyGraphLib.Utils
{
    using System;

    public class StrProcess
    {
        public static StrProcess 
            Instance { get; private set; } = new StrProcess();

        private StrProcess() { }

        public string GetSubStringData(string[] splitedStr, int index)
        {
            return splitedStr[index];
        }
        public string[] GetSubString(int index, string[] strings, char[] tokens)
        {
            return strings[index].
                Split(tokens, StringSplitOptions.RemoveEmptyEntries);
        }
        public string[] GetStrArray(string data, char[] tokens)
        {
            return data.Split(tokens, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
