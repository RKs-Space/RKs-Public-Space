using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_Admin
{
    class Display_Master : Lister
    {
        public void disp_mov()
        {
            Console.WriteLine("Welcome to Movie Database Application:");
            foreach (Master_Movie movies in l1)
            {
                Console.WriteLine("Movie-id: " + movies.movie_id);
                Console.WriteLine("Movie-Title: " + movies.movie_title);
                Console.WriteLine("Movie-Language: " + movies.language);
            }

            Console.WriteLine("Total Movies in MOVIES WORLD ARE : " + l1.Count);
            
        }
    }
}

