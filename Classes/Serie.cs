using System;

namespace DIO.Series
{
    public class Serie : BaseType
    {
        private int FinishedYear;
        private int NumberOfSeasons;
        public Serie(int id, Gender gender, string title, string description, int releasedYear, int finishedYear, int numberOfSeasons)
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = releasedYear;
            this.FinishedYear = finishedYear;
            this.NumberOfSeasons = numberOfSeasons;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string str = "";
            str += "Gender: " + this.Gender + Environment.NewLine;
            str += "Title: " + this.Title + Environment.NewLine;
            str += "Description: " + this.Description + Environment.NewLine;
            str += "Year of release: " + this.Year + Environment.NewLine;
            str += "Finished at: " + this.FinishedYear + Environment.NewLine;
            str += "Number of seasons: " + this.NumberOfSeasons + Environment.NewLine;
            str += "Deleted: " + this.Deleted + Environment.NewLine;
            return str;
        }
    }
}