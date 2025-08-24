using System;
using System.Collections.Generic;

namespace FileSystem
{
    internal class Program
    {
        private const string COMMAND_CD = "cd";
        private const string COMMAND_PWD = "pwd";
        private const string BACK_SLASH = "/";

        private static void Main()
        {
            Program program = new Program();

            string[] strInput1 =
            {
                "cd /home",
                "cd user",
                "pwd",
                "cd ..",
                "pwd",
                "cd ./projects/../code",
                "pwd"
            };
            program.ExecuteCommand(strInput1);

            string[] strInput2 =
            {
                "cd /",
                "cd home",
                "cd ./user//",
                "cd ../..",
                "cd ../..",
                "cd var/log",
                "pwd",
                "cd /etc/./nginx/../ssh",
                "pwd",
                "cd ..",
                "pwd"
            };
            program.ExecuteCommand(strInput2);

            string[] strInput3 =
            {
                "cd Program files/./dotnet",
                "cd ../mssql/./backup",
                "cd ../",
                "pwd",
                "cd ../",
                "cd ./windows",
                "pwd",
                "cd ..",
                "pwd"
            };
            program.ExecuteCommand(strInput3);

            Console.ReadKey();
        }

        private void ExecuteCommand(string[] strInput)
        {
            List<string> liPath = new List<string>();

            foreach(string strCommand in strInput)
            {
                if(strCommand.Equals(COMMAND_PWD))
                {
                    Console.WriteLine(string.Join(string.Empty, liPath) + BACK_SLASH);
                    continue;
                }

                string strPath = strCommand.Replace(COMMAND_CD, string.Empty).Trim();
                if(strPath.StartsWith(BACK_SLASH)) liPath = new List<string>();

                foreach(string strFolderName in strPath.Split('/'))
                {
                    if(strFolderName.Equals(".") || string.IsNullOrWhiteSpace(strFolderName)) continue;

                    if(strFolderName.Equals("..") && liPath.Count > 0) liPath.RemoveAt(liPath.Count - 1);
                    else liPath.Add(strFolderName.StartsWith(BACK_SLASH) ? strFolderName : BACK_SLASH + strFolderName);
                }
            }

            Console.WriteLine();
        }
    }
}