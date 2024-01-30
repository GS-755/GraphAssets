namespace MyGraphLib.Models
{
    using System;
    using System.IO;
    using MyGraphLib.Utils;

    public class AdjecencyMatrix
    {
        private char[] tokens;
        public int N { get; set; }
        public int[,] Matrix { get; set; }

        public AdjecencyMatrix() 
        {
            this.tokens = new char[] { ' ' };
            this.Matrix = new int[,] {  };
        }

        public bool ReadMatrix(string path)
        {
            if(MyFileAccess.Instance.IsFileExists(path))
            {
                FileStream fileStream = MyFileAccess.Instance.
                    GetFileStream(path, FileMode.Open, FileAccess.Read);
                string readContents = MyFileAccess.Instance.GetReadContent(fileStream);
                string[] arrContents = MyFileAccess.Instance.GetSplitedContents(readContents);
                this.N = Convert.ToInt32(StrProcess.Instance.GetSubStringData(arrContents, 0));
                this.Matrix = new int[this.N, this.N];
                for(int i = 0; i < this.N; i++)
                {
                    string[] subStr = StrProcess.Instance.
                        GetSubString(i + 1, arrContents, this.tokens); 
                    for(int j = 0; j < this.N; j++)
                    {
                        this.Matrix[i, j] = Convert.ToInt32(subStr[j]);
                    }
                }

                return true;
            }

            return false;
        }
        public int SumIn(int col)
        {
            int sum = 0;
            for (int i = 0; i < this.N; i++)
            {
                if (this.Matrix[i, col] == 1)
                {
                    sum++;
                }
            }

            return sum;
        }
        public int SumOut(int row)
        {
            int sum = 0;
            for (int i = 0; i < this.N; i++)
            {
                if (this.Matrix[row, i] == 1)
                {
                    sum++;
                }
            }

            return sum;
        }

        public string BacVoHuong()
        {
            string result = "";
            for (int i = 0; i < this.N; i++)
            {
                result += $"{SumOut(i)} ";
            }

            return result;
        }
        public string BacVaoRa()
        {
            string result = "";
            for (int i = 0; i < this.N; i++)
            {
                int sum = 0;
                for (int j = 0; j < this.N; j++)
                {
                    if (this.Matrix[i, j] == 1)
                    {
                        sum += 1;
                    }

                }
                result += $"{this.SumIn(i)} {this.SumOut(i)}\n";
            }

            return result;
        }
    }
}
