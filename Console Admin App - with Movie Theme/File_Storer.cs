using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Globalization;

namespace Movie_Admin
{
    class File_Storer:Lister
    {
        public void add_list_2_file()
        {
            Console.WriteLine("Press Enter to move all the datas in the list to the File database:");


            FileStream fs = new FileStream(@"E:\Endeavour\COGNIZANT\Post Joining\OOPS-Case Study\Database.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

            StreamWriter sw = new StreamWriter(fs);

            foreach (Master_Movie item in l1)
            {
                sw.Write(item.movie_id);
                sw.Write(item.movie_title);
                sw.Write(item.language);
            }
            Console.WriteLine("Written to the file-----> Go and Check it");

            sw.Close();
        }
    }
}
