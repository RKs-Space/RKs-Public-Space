using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Movie_Admin
{
    class Switching_Class : Lister
    {

        public void Loader()
        {
            Console.WriteLine("\n\n\n\n\n\n                Loading ---------------> Addition Menu: Please Wait, Thank You ");
            Console.WriteLine("\n\n");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public void option()
        {
            //Console.BackgroundColor = ConsoleColor.White;
            //Console.ForegroundColor = ConsoleColor.Black;
            //Console.ResetColor();



            //Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\n                                   WELCOME TO MOVIE'S WORLD SERVER-ADMIN                                         ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\n                         What Do you Want to Do on the ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("MOVIES WORLD");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" Application");
            Console.ResetColor();

            Console.WriteLine("\n                          1.Adding Movie");
            Console.WriteLine("\n                          2.Searching From Existing Movies");
            Console.WriteLine("\n                          3.Modifying the Existing Movies");
            Console.WriteLine("\n                          4.Deletion of any Exiting Movie");
            Console.WriteLine("\n                          5.Display All Movies in Application:");
            Console.WriteLine("\n                          6.Move MOVIES WORLD datas to File:(Please enter only after performing all operations required");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n                          7.Exit\n\n");
            Console.ResetColor();

            Console.WriteLine("                       Currently The Number of Movies in the Application is: "+l1.Count);
            if (l1.Count!=0)
            {
                foreach (Master_Movie mov_avail in l1)
	               {
		                   Console.Write("\n\n                        The movie id: "+mov_avail.movie_id);
                           Console.WriteLine("    The movie Title: " + mov_avail.movie_title);
	                }
                
            }
            string c = Console.ReadLine();

            Adder_class ac = new Adder_class();
            Search_for sf = new Search_for();
            Modify_Master mm = new Modify_Master();
            Delete_Master dm = new Delete_Master();
            Display_Master dpm = new Display_Master();
            File_Storer st = new File_Storer();

            switch (c)
            {
                case "1":
                  
                    Loader();

                    Console.WriteLine("\n\n\n\n                       Welcome to ADD DETAIL MENU ");
                    ac.add_mov();
                    option();
                    break;
                case "2":
                    Console.WriteLine("\n\n\n\n                       Welcome to SEARCH Menu");
                    sf.search_mov();
                    option();
                    break;
                case "3":
                    Console.WriteLine("\n\n\n\n                       Welcome to MODIFY Menu");
                    mm.mod_mov();
                    option();
                    break;
                case "4":
                    Console.WriteLine("\n\n\n\n                        Welcome to DELETE Menu");
                    dm.Del_mov();
                    option();
                    break;
                case "5":
                    Console.WriteLine("\n\n\n\n                        Welcome to DISPLAY Menu:");
                    dpm.disp_mov();
                    option();
                    break;
                case "6":
                    Console.WriteLine("\n\n\n\n\n                      Welcome To File Storer Menu");
                    st.add_list_2_file();
                    option();
                    break;
                case "7":
                    //Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\n\n\n\n\n\n\n\n                                   Thanks for Using The Application VISIT-AGAIN                                  \n");
                    Console.ResetColor();

                    Console.WriteLine("                                   ______________________________________________");
                    Console.WriteLine("                       ______________________________________________________________________");
                    Console.WriteLine("___________________________________________________________________________________________________________________\n\n\n");
                    break;
                default:
                    Console.WriteLine("\n\n\n                         Wrong choice----> Please Enter from Available Options");

                    option();
                    
                    break;
            }
        }
    }
}

