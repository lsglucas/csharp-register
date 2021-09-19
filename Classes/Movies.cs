using System;

namespace DIO.Series
{
    public class Movie : BaseType
    {
        private bool WasAvailableOnline;
        private int Duration;
        public Movie(int id, Gender gender, string title, string description, int year, bool wasAvailableOnline, int duration)
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.WasAvailableOnline = wasAvailableOnline;
            this.Duration = duration;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string str = "";
            str += "Gender: " + this.Gender + Environment.NewLine;
            str += "Title: " + this.Title + Environment.NewLine;
            str += "Description: " + this.Description + Environment.NewLine;
            str += "Year of release: " + this.Year + Environment.NewLine;
            str += "Was the movie available online: " + this.WasAvailableOnline + Environment.NewLine;
            str += "Duration: " + this.Duration + Environment.NewLine;
            str += "Deleted: " + this.Deleted + Environment.NewLine;
            return str; ;
        }
    }
}