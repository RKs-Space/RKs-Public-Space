using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace Movie_Admin
{
    class Lister
    {
        public static List<Master_Movie> l1 = new List<Master_Movie>();


        static void Main(string[] args)
        {
            Console.WriteLine("_________________________________________________________________________________________________________________");
            Console.WriteLine("                       __________________________________________________________________");
            Console.WriteLine("                                ___________________________________________");

            DateTime dt;
            dt = DateTime.Now;
            Console.WriteLine("\n\n                                                                   Current Log Session: "+ dt);

            //FileStream fs = new FileStream(@"E:\Endeavour\COGNIZANT\Post Joining\OOPS-Case Study\Movie_Admin\Movie_Admin.csproj", FileMode.Open, FileAccess.Read);

            //FileInfo fi = new FileInfo(@"E:\Endeavour\COGNIZANT\Post Joining\OOPS-Case Study\Movie_Admin\Lister.cs");
            //touchfile(fi);
                    

            Switching_Class sc = new Switching_Class();
            sc.option();
            

        }
    //static void touchfile(FileSystemInfo fsi)
    //        {
    //            try
    //            {
    //                DateTime dl;
    //                //fsi.LastWriteTime = DateTime.Now;
    //                dl = fsi.LastWriteTime;
    //                Console.WriteLine("Last Acess Time is: " + dl);
    //            }
    //            catch (Exception e)
    //            {
    //                Console.WriteLine("The exception received: "+e.Message);
    //            }
        
    //        }

    }
}
