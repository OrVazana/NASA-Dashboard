namespace NASA.BE
{
    public class Planet
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public string IamgeSource { get; set; }

        public Planet(int id,string name, string Description)
        {
            this.id = id;
            this.Name = name;
            this.Description = Description;
        }

        public Planet()
        {
        }
    }
}
