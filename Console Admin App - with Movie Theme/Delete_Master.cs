using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_Admin
{
    class Delete_Master : Lister
    {


        public void Del_mov()
        {

            Console.WriteLine("Deleteing a movie");
            Console.WriteLine("Enter the Movie name you want to Delete: ");



            string so = Console.ReadLine();
            int a = 0;


            foreach (Master_Movie item in l1)
            {
                if (item.movie_title == so)
                {
                    a = 1;
                    Console.WriteLine("The Movie is Found for Deletion");

                    Console.WriteLine("The movie id: " + item.movie_id);
                    Console.WriteLine("Movie Title: " + item.movie_title);
                    Console.WriteLine("Movie Language: " + item.language);
                    Console.WriteLine("Now the movies in list are: " + l1.Count);


                }
            }
            if (a == 0)
            {
                Console.WriteLine("The movie u asked is NOT FOUND for Deletion:");
            }
            else
            {
                int x;
                Console.WriteLine("Enter the movie id to delete");
                x = int.Parse(Console.ReadLine());
                l1.RemoveAt(x - 1);
            }



            foreach (Master_Movie leftover in l1)
            {
                Console.WriteLine("The movie id: " + leftover.movie_id);
                Console.WriteLine("Movie Title: " + leftover.movie_title);
                Console.WriteLine("Movie Language: " + leftover.language);
                Console.WriteLine("Now the movies in list are: " + l1.Count);
            }



            
        }
    }
}

