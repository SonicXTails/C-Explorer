using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

namespace Explorer
{
    static class MainMenu
    {
        public static int ChooseDisk()
        {
            int NumForArrows = 0;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("------------------------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t\t\t<Этот компьютер>");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("-----------------------------------------------------------------------------------------------------------------------\n\n");

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"  Название диска или тома: {drive.Name} ");

                if (drive.IsReady)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Размер диска: {drive.TotalSize / 1024 / 1024 / 1024} ГБ. Свободно: {drive.TotalFreeSpace / 1024 / 1024 / 1024} ГБ\n");
                    NumForArrows += 1;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            string pass = "";
            var pos = Arrows.Arrow(4, NumForArrows);
            switch (pos)
            {
                case 4:
                    var path = Check_Index_of_Drive.Way_to_Folders_in_Drive(drives, 0);
                    OpenDrive(path);
                    break;
                case 5:
                    path = Check_Index_of_Drive.Way_to_Folders_in_Drive(drives, 1);
                    OpenDrive(path);
                    break;
                case 6:
                    path = Check_Index_of_Drive.Way_to_Folders_in_Drive(drives, 2);
                    OpenDrive(path);
                    break;
                case 7:
                    path = Check_Index_of_Drive.Way_to_Folders_in_Drive(drives, 3);
                    OpenDrive(path);
                    break;
                case 8:
                    path = Check_Index_of_Drive.Way_to_Folders_in_Drive(drives, 4);
                    OpenDrive(path);
                    break;
            }
            return NumForArrows;
        }

        private static void OpenDrive(string p)
        {
            while (true)
            {
                Console.Clear();
                string[] files = Directory.GetFiles(p);
                string[] dirs = Directory.GetDirectories(p);

                var ii = 0;
                foreach (string path in dirs)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("  " + path);
                    FileInfo dir = new FileInfo(path);
                    Console.SetCursorPosition(60, ii);
                    Console.WriteLine(dir.CreationTime);
                    ii++;
                }
                if (files != null)
                {
                    var i = dirs.Length;
                    foreach (string PathForFiles in files)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  " + PathForFiles);
                        FileInfo file = new FileInfo(PathForFiles);
                        Console.SetCursorPosition(60, i);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(file.CreationTime);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(100, i);
                        Console.WriteLine(file.Extension);
                        i++;
                    }
                }
                SecondMenu();
                int pos = Arrows.Arrow(0, dirs.Length + files.Length);

                var CountDirectories = 0;

                CountDirectories = dirs.Length;
                if (dirs.Length + files.Length != 0)
                {
                    if (pos < dirs.Length)
                    {
                        OpenDrive(dirs[pos]);
                    }
                    else
                    {
                        pos -= CountDirectories;
                        OpenFile(files[pos]);
                    }
                }
            }
        }

        private static void OpenFile(string files)
        {
            Process.Start(new ProcessStartInfo {FileName = files, UseShellExecute = true});
        }

        private static void SecondMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n|---------------------------------------------------------------------------------------------------------------------|");
            Console.Write("\n|*****↑**************************************************************↑********************************↑***************|");
            Console.Write("\n| Файл/Папка                                                    Дата создания                     Тип файла           |");
            Console.Write("\n|*********************************************************************************************************************|");
            Console.Write("\n|---------------------------------------------------------------------------------------------------------------------|\n");
        }
    }
}
