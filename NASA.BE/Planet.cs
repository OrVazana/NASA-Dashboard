using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NASA.BE
{
    [Table("Planets")]
    public class Planet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Column("varchar(50")]
        [Required]
        public string Name { get; set; }
        [Column("varchar(200")]
        [Required]
        public string Description { get; set; }
        
        public string ImageSource { get; set; }

        public Planet(int id,string name, string Description, string ImageSource)
        {
            this.id = id;
            this.Name = name;
            this.Description = Description;
            this.ImageSource = ImageSource;
        }

        public Planet()
        {
        }
    }
}
