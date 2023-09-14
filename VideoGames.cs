using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_CSCI_2910
{
    public class VideoGames : IComparable<VideoGames>
    {
        public string Name { get; set; }
        public string Platform { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public double NA_Sales { get; set; } 
        public double EU_Sales { get; set; }
        public double JP_Sales { get; set; }
        public double Other_Sales { get; set; }
        public double Global_Sales { get; set; }

        public VideoGames(string name, string platform, int year, string genre, string publisher, double na_sales, double eu_sales, double jp_sales, double other_sales, double global_sales) 
        {
            Name = name;
            Platform = platform;
            Year = year;
            Genre = genre;
            Publisher = publisher;
            NA_Sales = na_sales;
            EU_Sales = eu_sales;
            JP_Sales = jp_sales;
            Other_Sales = other_sales;
            Global_Sales = global_sales;
        }

        public VideoGames() { }

        public int CompareTo(VideoGames otherGame)
        {
            if (otherGame == null)
            {
                return 1;
            }
            if(otherGame.Name != null)
            {
                return Comparer<string>.Default.Compare(Name, otherGame.Name);
            }
            else
            {
                throw new ArgumentException("This game does not exist");
            }
        }


        //ToString for use in displaying a games information
        public override string ToString()
        {
            string msg = $"\nName: {Name}";
            msg += $"\nPublisher: {Publisher}";
            msg += $"\nPlatform: {Platform}";
            msg += $"\nGenre: {Genre}";
            msg += $"\nYear: {Year}";
            return msg;
        }

    }
}
