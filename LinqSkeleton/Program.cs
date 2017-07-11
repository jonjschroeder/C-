using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist FromMtVernon = Artists.Where(artist => artist.Hometown == "Mount Vernon").Single();
            Console.WriteLine($"The artist {FromMtVernon.ArtistName} from Mt Vernon is {FromMtVernon.Age} years old");
            //Who is the youngest artist in our collection of artists?
            Artist YoungestAr = Artists.OrderBy(artist => artist.Age).First();
            System.Console.WriteLine($"{YoungestAr.ArtistName} is the youngest artist, and his age is {YoungestAr.Age}");

            //Display all artists with 'William' somewhere in their real name
            
            List<Artist> ContainsWill = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
            foreach(var x in ContainsWill){
                System.Console.WriteLine(x.ArtistName + "" + x.RealName);
            }
            //Display the 3 oldest artist from Atlanta
            List<Artist> OldestFromAtlanta = Artists.Where(artist => artist.Hometown == "Atlanta")
            .OrderByDescending(artist => artist.Age)
            .Take(3)
            .ToList();

            foreach(var x in OldestFromAtlanta){
                System.Console.WriteLine(x.ArtistName + ", " + x.Age);
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
