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
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            List<Artist> FromMV = Artists.Where(a => a.Hometown == "Mount Vernon").ToList();
            System.Console.WriteLine($"There are {FromMV.Count} artists from Mount Vernon.");
            
            //Who is the youngest artist in our collection of artists?
            List<Artist> OldestToYoungest = Artists.OrderByDescending(a=>a.Age).ToList();
            Artist YoungestArtist = OldestToYoungest.Last();
            System.Console.WriteLine($"{YoungestArtist.ArtistName} is the youngest artist on the list.");

            //Display all artists with 'William' somewhere in their real name
            List<Artist> Williams = Artists.Where(a=>a.RealName.Contains("William")).ToList();
            System.Console.WriteLine($"Here are real names all of the artists named 'William' or with a last name of 'Williams' in the original list:");
            foreach(Artist a in Williams)
                System.Console.WriteLine($"{a.RealName}");

            //Display the 3 oldest artist from Atlanta
            List<Artist> FromATL = Artists.Where(a => a.Hometown == "Atlanta").ToList();
            List<Artist> OldestToYoungestATL = FromATL.OrderByDescending(a=>a.Age).ToList();
            System.Console.WriteLine("The three oldest artists on the original list who are from Atlanta are:");
            for(int i = 0; i <= 2; i++)
                System.Console.WriteLine($"{OldestToYoungest[i].RealName}");

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
	        Console.WriteLine($"There are {Groups.Count} groups, apparently.");

            System.Console.WriteLine("One of these groups is worth particular note, as it is said they are not to be challenged or confronted lightly.");
            System.Console.WriteLine("Their names are:");
            List<Artist> WuTangClan = Artists.Where(a => a.GroupId == 1).ToList();
            foreach(Artist a in WuTangClan)
                System.Console.WriteLine($"{a.ArtistName}");
            System.Console.WriteLine("Together, they are known as 'The Wu-Tang Clan.'");
        }
    }
}
