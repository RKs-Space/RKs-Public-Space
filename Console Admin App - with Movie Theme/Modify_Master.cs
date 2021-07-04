using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_Admin
{
    class Modify_Master : Lister
    {
        public void mod_mov()
        {
            Console.WriteLine("Modify a movie: ");
            //Console.WriteLine("bYEFORNOW:");
            foreach (Master_Movie item in l1)
            {

                Console.WriteLine("The Movie in the list are: ");
                Console.WriteLine("The Details of the searched Movie_Admin are: ");

                //Console.WriteLine("The movie id: "+item.movie_id);
                Console.WriteLine("Movie Title: " + item.movie_title);
                //Console.WriteLine("Movie Language: "+item.language);

            }

            Console.WriteLine("Enter the Movie_id you want to Modify");
            int mod = int.Parse(Console.ReadLine());

            int temp = 0;
            Master_Movie m2 = new Master_Movie();
            foreach (Master_Movie movs in l1)
            {
                if (movs.movie_id == mod)
                {
                    Console.WriteLine("Ener the Details");
                    Console.WriteLine("The new id is: ");
                    l1[mod - 1].movie_id = int.Parse(Console.ReadLine());
                    Console.WriteLine("The new Movie Title :");
                    l1[mod - 1].movie_title = Console.ReadLine();
                    Console.WriteLine("The new language :");
                    l1[mod - 1].language = Console.ReadLine();




                    Console.WriteLine("The new id is: " + movs.movie_id);
                    Console.WriteLine("The new Movie Title :" + movs.movie_title);
                    Console.WriteLine("The new language :" + movs.language);
                    temp = 1;
                }

            }
            if (temp == 0)
            {
                Console.WriteLine("The Movie is not available to modify");
            }


            
        }
    }
}

