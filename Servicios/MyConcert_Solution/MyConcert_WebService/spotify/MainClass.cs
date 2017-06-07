using SpotifyAPI.Web.Models;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using MyConcert_WebService.res;
using System.Collections.Generic;

namespace Sptfy
{
    public class MainClass
    {
        public static void Main(string[] args)
        {       

            List<string> _winner = new List<string>();
            List<string> _other = new List<string>();

            _winner.Add("The Doors");
            _winner.Add("Pink Floyd");
            _winner.Add("Metallica");

            _other.Add("Janis Joplin");
            _other.Add("Jefferson Airplane");
            _other.Add("Led Zeppelin");

            Chef _chef = new Chef();
            string res = _chef.chefAlgorythm(_winner, _other);

            Console.ReadLine();

        }
    }

}
