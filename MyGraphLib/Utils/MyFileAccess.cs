namespace MyGraphLib.Utils
{
    using System;
    using System.IO;

    public class MyFileAccess
    {
        // Singleton Instance init
        public static MyFileAccess Instance
            { get; private set; } = new MyFileAccess();
        private MyFileAccess() { }

        // Function(s)
        public bool IsFileExists(string path)
        {
            if(File.Exists(path.Trim())) 
            {
                return true;
            }

            return false;
        }
        public FileStream GetFileStream(string path, FileMode fileMode, FileAccess fileAccess)
        {
            if (this.IsFileExists(path))
            {
                FileStream fs = new FileStream(path, fileMode, fileAccess);
                Console.WriteLine($"File {Path.GetFileName(path)} opened in {fileAccess} mode.");

                return fs;
            }
            else if (fileAccess == FileAccess.Read)
            {
                Console.WriteLine("Insert data into created text file!");

                return new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite); 
            }
            else
            {
                Console.WriteLine($"Created {Path.GetFileName(path)} with {fileMode} mode!");

                return new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            }
        }
        public string GetReadContent(FileStream fileStream)
        {
            try
            {
                string readBuffer = "";
                StreamReader sr = new StreamReader(fileStream);
                readBuffer = sr.ReadToEnd(); 
                sr.Close(); 

                return readBuffer;
            }
            catch(Exception ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
        }
        public string[] GetSplitedContents(string contents) 
        {
            try
            {
                string[] strTrimmed = StrProcess.Instance.
                    GetStrArray(contents, new char[] { '\r', '\n' });

                return strTrimmed;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        // WriteContents() overload #1
        public bool WriteContents(FileStream fileStream, string content)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileStream);
                sw.Write($"{content}\n");
                sw.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
        }
        // WriteContents() overload #2
        public bool WriteContents(FileStream fileStream, string[] contents)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileStream);
                int contentLength = contents.Length;
                for(int i = 0; i < contentLength; i++)
                {
                    sw.Write($"{contents[i]}\n");
                }
                sw.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
        }
    }
}
