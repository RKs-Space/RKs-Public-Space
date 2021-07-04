using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_Admin
{
    class Search_for : Lister
    {
        public void search_mov()
        {
            Console.WriteLine("Movies in list are while searching :" + l1.Count);

            Console.WriteLine("Welcome to Search Menu: ");
            //Console.WriteLine("Enter the Movie_id:");
            Console.WriteLine("Enter the name you want to search: ");
            string so = Console.ReadLine();
            int a = 0;

            foreach (Master_Movie item in l1)
            {
                if (item.movie_title == so)
                {
                    Console.WriteLine("The Movie is found man");
                    Console.WriteLine("The Details of the searched Movie_Admin are: ");

                    Console.WriteLine("The movie id: " + item.movie_id);
                    Console.WriteLine("Movie Title: " + item.movie_title);
                    Console.WriteLine("Movie Language: " + item.language);
                    a = 1;

                }

                //else 
                //{
                //    Console.WriteLine("The movie u asked is NOT FOUND:");
                //}
            }
            if (a == 0)
            {
                Console.WriteLine("The movie u asked is NOT FOUND:");
            }


           
        }

    }
}

