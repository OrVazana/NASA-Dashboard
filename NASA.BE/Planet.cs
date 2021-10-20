using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NASA.BE
{
    [Table("Planets")]
    public class Planet
    {
        //public int Id { get; set; }
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }

        public Planet(string name, string Description, string ImageSource)
        {
            //this.Id = Id;
            this.Name = name;
            this.Description = Description;
            this.ImageSource = ImageSource;
        }

        public Planet()
        {
        }
    }
}
