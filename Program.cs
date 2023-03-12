using System.Diagnostics;

namespace prov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
        }
        static void Start()
        {
            Console.CursorVisible = false;
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                Console.WriteLine("  " + drive + " " + drive.TotalSize + " байт свободно из " + drive.AvailableFreeSpace + " байт");
            }
            Class1 arrowMenu = new Class1(drives.Length);
            arrowMenu.DrawArrow(0);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        arrowMenu.Down();
                        break;
                    case ConsoleKey.UpArrow:
                        arrowMenu.Up();
                        break;
                    case ConsoleKey.Enter:
                        ShowDirectory(drives[arrowMenu.position].RootDirectory);
                        break;

                }


            }


        }

        static void ShowDirectory(DirectoryInfo root)
        {

            FileSystemInfo[] infos = root.GetFileSystemInfos();
            Console.SetCursorPosition(0, 0);
            foreach (var info in infos)
            {
                Console.WriteLine("  " + info);
            }
            Class1 Menu = new Class1(infos.Length);
            Menu.DrawArrow(0);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        Menu.Down();
                        break;
                    case ConsoleKey.UpArrow:
                        Menu.Up();
                        break;
                    case ConsoleKey.Enter:
                        FileSystemInfo info = infos[Menu.position];
                        if (info is DirectoryInfo directory)
                        {
                            Console.Clear();
                            GowDirectory(directory);
                        }
                        else
                        {
                            Process.Start(info.FullName);
                        }
                        break;
                    case ConsoleKey.Escape:
                        string path = root.FullName;
                        Console.SetCursorPosition(0, 0);
                        Console.Clear();
                        Console.WriteLine("  " + path);

                        break;
                }


            }
        }
        static void GowDirectory(DirectoryInfo root)
        {

            FileSystemInfo[] inf = root.GetFileSystemInfos();
            Console.SetCursorPosition(0, 0);
            foreach (var info in inf)
            {
                Console.WriteLine("  " + info);
            }
            Class1 aMenu = new Class1(inf.Length);
            aMenu.DrawArrow(0);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        aMenu.Down();
                        break;
                    case ConsoleKey.UpArrow:
                        aMenu.Up();
                        break;
                    case ConsoleKey.Enter:
                        FileSystemInfo info = inf[aMenu.position];
                        if (info is DirectoryInfo directory)
                        {
                            GowDirectory(directory);
                        }
                        else
                        {
                            Process.Start(info.FullName);
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Start();
                        break;
                }


            }
        }
    }
}