namespace OutputConsole
{
    using System.IO;
    using MyGraphLib.Utils;
    using MyGraphLib.Models;
    using System.Configuration;
    using System.Collections.Generic;

    public class Program
    {
        // PATH constants 
        private static readonly string INP_PATH = ConfigurationManager.AppSettings["path_inp_b2"];
        private static readonly string OUT_PATH = ConfigurationManager.AppSettings["path_out_b2"];


        public static void TestB1()
        {
            // Get FileStream of I/O
            FileStream myOut = MyFileAccess.Instance.
                GetFileStream(OUT_PATH, FileMode.Create, FileAccess.Write);
            // Init Graph element
            AdjecencyMatrix obj = new AdjecencyMatrix();
            // Read file contents
            obj.ReadMatrix(INP_PATH);
            // Prepare the output
            List<string> listOutput = new List<string>
            {
                $"{obj.N}",
                obj.BacVoHuong()
            };
            // Write content to output file
            MyFileAccess.Instance.WriteContents(myOut, listOutput.ToArray());
        }
        public static void TestB2()
        {
            // Get FileStream of I/O
            FileStream myOut = MyFileAccess.Instance.
                GetFileStream(OUT_PATH, FileMode.Create, FileAccess.Write);
            // Init Graph element
            AdjecencyMatrix obj = new AdjecencyMatrix();
            // Read file contents
            obj.ReadMatrix(INP_PATH);
            // Prepare the output
            List<string> listOutput = new List<string>
            {
                $"{obj.N}",
                obj.BacVaoRa()
            };
            // Write content to output file
            MyFileAccess.Instance.WriteContents(myOut, listOutput.ToArray());
        }
        public static void TestB3()
        {
            // Get FileStream of I/O
            FileStream myOut = MyFileAccess.Instance.
                GetFileStream(OUT_PATH, FileMode.Create, FileAccess.Write);
            // Init Graph element
            AdjecencyList obj = new AdjecencyList();
            // Read file contents
            obj.ReadList(INP_PATH);
            // Prepare the output
            List<string> listOutput = new List<string>
            {
                $"{obj.N}",
                obj.BacCuaDinh()
            };
            // Write content to output file
            MyFileAccess.Instance.WriteContents(myOut, listOutput.ToArray());
        }
        public static void Main(string[] args)
        {
            // TestB1();
            TestB2();
            // TestB3();
        }
    }
}
