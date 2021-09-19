namespace DIO.Series
{
    public abstract class BaseType : BaseEntity
    {
        protected Gender Gender { get; set; }
        protected string Title { get; set; }
        protected string Description { get; set; }
        protected int Year { get; set; }
        protected bool Deleted { get; set; }

        public override abstract string ToString();

        public string getTitle()
        {
            return this.Title;
        }

        public int getId()
        {
            return this.Id;
        }

        public bool getDeleted()
        {
            return this.Deleted;
        }

        public void Delete()
        {
            this.Deleted = true;
        }
    }
}