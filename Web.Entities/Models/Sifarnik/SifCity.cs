using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Web.Entities.Models.Sifarnik
{
    public class SifCity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(256)]
        public string City { get; set; }
        public virtual ICollection<Client> Client {get; set;}

    }
}