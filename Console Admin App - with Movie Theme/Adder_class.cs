using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_Admin
{
    class Adder_class : Lister
    {

        public void check_id()
        {
            foreach (Master_Movie item in l1)
            {

                Console.WriteLine("\n          Enter the movie id:");
                int id = int.Parse(Console.ReadLine());
                if (id == item.movie_id)
                {
                    Console.WriteLine("\n      Please enter a Different Movie-Id: It should Be UNIQUE");
                }
            }

        }
        public void add_mov()
        {
            if (l1.Count != 0)
            {
                check_id();
            }
            else
            {
                
                    Master_Movie m1 = new Master_Movie();


                    Console.WriteLine("\n          Enter the movie id:");
                    m1.movie_id = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n          Enter movie title");
                    m1.movie_title = Console.ReadLine();
                    Console.WriteLine("\n          Enter Movie Language");
                    m1.language = Console.ReadLine();
                    l1.Add(m1);

                    
                    Console.WriteLine("\n\n        DO YOU WANT TO ADD MORE: y or n");
                    string s = Console.ReadLine();
                    string temp = "y";
                    if (s.ToUpper() == temp.ToUpper())
                    {

                        Console.WriteLine("\n\n           How much more details u want to add");
                        int n = int.Parse(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            m1 = null;
                            m1 = new Master_Movie();
                            Console.WriteLine("\n          Enter the movie id:");
                            m1.movie_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("\n          Enter movie title");
                            m1.movie_title = Console.ReadLine();
                            Console.WriteLine("\n          Enter Movie Language");
                            m1.language = Console.ReadLine();
                            l1.Add(m1);

                        }

                    }
                    else
                    {
                        Console.WriteLine("\n           Thanks for Adding Details:\n");
                    }




                    Console.WriteLine("\n             Do you Want to see the entire details of the MOVIS WORLD AFTER YOUR NEW Addition");
                    string show_all_detail = Console.ReadLine();
                    string q = "y";
                    if (show_all_detail.ToUpper() == q.ToUpper())
                    {
                        Console.WriteLine("       Movie-id                  MovieTitle                     Movie-Language");
                        foreach (Master_Movie item in l1)
                        {

                            Console.WriteLine("\n             {0}                       {1}                               {2}", item.movie_id, item.movie_title, item.language);


                        }

                        Console.WriteLine("\n               Items in Movie World List: after updation: " + l1.Count);
                    }
                    else
                    {
                        Console.WriteLine("\n\n               Going Back to Main Menu");
                    }
                


               
                           
                

            }
        }
    }
}

