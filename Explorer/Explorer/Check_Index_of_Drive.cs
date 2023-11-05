namespace Explorer
{
    internal class Check_Index_of_Drive
    {
        public static string Way_to_Folders_in_Drive(DriveInfo[] drives, int IndexOfDrive)
        {
            var NameOfDrive = drives[IndexOfDrive];
            string path = NameOfDrive + "\\";
            Console.WriteLine(path);
            return path;
        }
    }
}
