namespace MyGraphLib.Models
{
    using System;
    using System.IO;
    using MyGraphLib.Utils;
    using System.Collections.Generic;

    public class AdjecencyList
    {
        public int N { get; set; }
        private char[] tokens;

        public AdjecencyList() 
        {
            this.tokens = new char[] { ' ' };
        }

        public List<int>[] List { get; set; }

        public bool ReadList(string path)
        {
            try
            {
                if(MyFileAccess.Instance.IsFileExists(path))
                {
                    FileStream fileStream = MyFileAccess.Instance.
                        GetFileStream(path, FileMode.Open, FileAccess.Read);
                    string readContents = MyFileAccess.Instance.GetReadContent(fileStream);
                    string[] arrContents = MyFileAccess.Instance.GetSplitedContents(readContents);
                    this.N = Convert.ToInt32(arrContents[0]);
                    this.List = new List<int>[N];
                    for (int i = 0; i < this.N; i++)
                    {
                        string[] subStr = StrProcess.Instance.
                            GetSubString(i + 1, arrContents, this.tokens);
                        int subStrLen = subStr.Length;
                        this.List[i] = new List<int>(subStrLen);
                        for (int j = 0; j < subStrLen; j++)
                        {
                            this.List[i].Add(Convert.ToInt32(subStr[j]));
                        }
                    }

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public string BacCuaDinh()
        {
            string result = "";
            for (int i = 0; i < this.N; i++)
            {
                result += $"{this.List[i].Count} ";
            }

            return result;
        }
    }
}
