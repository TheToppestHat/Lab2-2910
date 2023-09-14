/* Made by Joey Whitmire, 9/6/2023
 * For Mr. Rochelle's 2910 Class
 * Assignment 1
 */

using Assignment1_CSCI_2910;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Schema;
using static System.Formats.Asn1.AsnWriter;

char directorySep = Path.DirectorySeparatorChar;

//Locates the file used in the assignment
string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
string filePath = projectFolder + Path.DirectorySeparatorChar + "videogames.csv";
List<VideoGames> myVideoGames = new List<VideoGames>();

//Opens the reader for the file and makes the data viable
using (StreamReader reader = new StreamReader(filePath))
{
    reader.ReadLine();

    while (!reader.EndOfStream)
    {
        string currentgame = reader.ReadLine();
        string[] internaldata = currentgame.Split(','); 
        VideoGames nextgame = new VideoGames(internaldata[0], internaldata[1], Convert.ToInt32(internaldata[2]), internaldata[3], internaldata[4], Convert.ToDouble(internaldata[5]), Convert.ToDouble(internaldata[6]), Convert.ToDouble(internaldata[7]), Convert.ToDouble(internaldata[8]), Convert.ToDouble(internaldata[9]));
        myVideoGames.Add(nextgame);
    }

    reader.Close();
}

//Sorts the list of games
myVideoGames.Sort();

List<string> inputs = new List<string>();

//Creates the publisher list without user input
var publish = myVideoGames.Where(p => p.Publisher == "Nintendo");
foreach (var p in publish) Console.WriteLine(p);

double totalGameCount = myVideoGames.Count();
double totalpublishCount = publish.Count();

Console.Write($"\n\nOut of {totalGameCount} games, {totalpublishCount} are developed by Nintendo, which is {Math.Round((totalpublishCount/totalGameCount)*100, 2)}%");



//Creates the genre list without user input
var genre = myVideoGames.Where(g => g.Genre == "Shooter");
foreach (var g in genre) Console.WriteLine(g);

double totalGenreCount =  genre.Count();
Console.Write($"\n\nOut of {totalGameCount} games, {totalGenreCount} are developed as a Shooter, which is {Math.Round((totalGenreCount / totalGameCount) * 100, 2)}%");


PublisherData(myVideoGames);

//Method to use user input to find games
static void PublisherData(List<VideoGames> myVideoGames)
{
    Console.Write("\n\n\nWhat is the publisher you want to use?  ");
    var input = Console.ReadLine();
    

    List<VideoGames> Publishlist = new List<VideoGames>();

    foreach(var video in myVideoGames)
    {
        if (video.Publisher.ToUpper() == input.ToUpper())
        {
            Publishlist.Add(video);
        }
    }

    double totalPublishCount = Publishlist.Count();
    double totalCount = myVideoGames.Count();

    foreach(var video in  Publishlist)
    {
        Console.WriteLine(video);
    }

    Console.Write($"\n\nOut of {totalCount} games, {totalPublishCount} are developed by {input}, which is {Math.Round(totalPublishCount/totalCount * 100, 2)}%");

}

GenreData(myVideoGames);


//Method used to find user inputted genre and display results
static void GenreData(List<VideoGames> myVideoGames)
{
    Console.Write("\n\n\nWhat is the genre of games you want to see?  ");
    var input = Console.ReadLine();

    List<VideoGames> Genrelist = new List<VideoGames>();

    foreach (var video in myVideoGames)
    {
        if (video.Genre.ToUpper() == input.ToUpper())
        {
            Genrelist.Add(video);
        }
    }

    double totalGenreCount = Genrelist.Count();
    double totalCount = myVideoGames.Count();

    foreach (var video in Genrelist)
    {
        Console.WriteLine(video);
    }

    Console.Write($"\n\nOut of {totalCount} games, {totalGenreCount} are developed by {input}, which is {Math.Round(totalGenreCount / totalCount * 100, 2)}%");

}


//Dictionary Example
Console.Write("\nWhat developer would you like to see from? ");
string uDev = Console.ReadLine();
Console.Write("\nWhat genre would you like to see from? ");
string uShoot = Console.ReadLine();

Dictionary<int, string> GameNames = new Dictionary<int, string>();
int i = 0;
foreach (var game in myVideoGames)
{
    GameNames.Add(i, game.Genre.ToLower());
    GameNames[i] += ", " + game.Publisher.ToLower();
    i += 1;
}

int count = 0;
foreach(var game in GameNames) 
{
    if (game.Value == (uShoot.ToLower() + ", " + uDev.ToLower())) {
        count++;
    } 
}


int devCount = myVideoGames.Where(p => p.Publisher.ToLower() == uDev.ToLower()).Count();

Console.WriteLine($"\nOut of the {devCount} games made by {uDev}, {count} of them were {uShoot} games");

Console.ReadLine();

//Stack Example
Stack<VideoGames> gameStack = new Stack<VideoGames>();

myVideoGames.Sort((a, b) => a.Year.CompareTo(b.Year));

foreach (var game in myVideoGames)
{
    gameStack.Push(game);
}

int yearcount = 1980;

while(yearcount < 2020)
{
    Console.WriteLine($"Here are the games for {yearcount}: ");
    foreach (var game in gameStack)
    {
        if (game.Year == yearcount)
        {
            Console.WriteLine($"'{game.Name}', created by {game.Publisher} for the {game.Platform}");
        }
    }
    Console.Write("\nPress enter to continue...\n" +
        "If you want to skip to a specific year, enter 1." +
        "\nIf you want to skip over a year, press 2." +
        "\nIf you want to skip over 5 years, press 3" +
        "\nIf you want to skip a decade, press 4" +
        "\nIf you want to know who my favorite teacher is, press 5" +
        "\nIf you want to move on to the Queue example, please enter Next: ");
    var consoleinput = Console.ReadLine();
    if(consoleinput == "1")
    {
        yearcount = Convert.ToInt32(Console.ReadLine());
        if (yearcount < 1980)
        {
            while(yearcount < 1980)
            {
                Console.Write("This is not a valid year, please try again. ");
                Console.ReadLine();
            }
        }
        else if (yearcount > 2020)
        {
             while (yearcount < 2020)
             {
                Console.Write("This is not a valid year, please try again. ");
                Console.ReadLine();
             }
        }
        else { continue; }
    }
    
    else if (consoleinput == "2")
    {
        yearcount += 2;
        if (yearcount > 2020)
        {
            Console.WriteLine("\nYou have went over the years in the database, going to the queue example...");
        }
    }
    else if (consoleinput == "3")
    {
        yearcount += 5;
        if (yearcount > 2020)
        {
            Console.WriteLine("\nYou have went over the years in the database, going to the queue example...");
        }
    }
    else if (consoleinput == "4")
    {
        yearcount += 10;
        if (yearcount > 2020)
        {
            Console.WriteLine("\nYou have went over the years in the database, going to the queue example...");
        }
    }
    else if (consoleinput == "5")
    {
        Console.WriteLine("Made you look :)");
        Process.GetCurrentProcess().Kill();
    }
    else if (consoleinput == "Next")
    {
        yearcount = 2021;
    }
    else 
    { 
        Console.WriteLine("Displaying next year...");
        yearcount++;
    }
}

//Queue
Queue<VideoGames> gameQueue = new Queue<VideoGames>();

myVideoGames.Sort((a, b) => a.Year.CompareTo(b.Year));

foreach (var game in myVideoGames)
{
    gameQueue.Enqueue(game);
}

Console.Write("What is the platform you would like to see?  ");
string platinput = Console.ReadLine();

Console.Write($"\nHere is the current lineup of games by year for the {platinput.ToUpper()}");
Console.ReadLine();

foreach (var game in gameQueue)
{
    if (game.Platform.ToLower() == platinput.ToLower())
    {
        Console.WriteLine(game);
    }
}
