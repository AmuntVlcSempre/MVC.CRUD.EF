using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Peliculas.CRUD.EF.Models
{
    public class Film
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
