using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Web.Entities.Models.Sifarnik;

namespace Web.Entities.Models
{
    public class Client
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Index(IsUnique = true), StringLength(256)]
        public string CompanyName { get; set; }


        public int CityId { get; set; }
        public virtual SifCity City { get; set; }

        [StringLength(256)]
        public string Address { get; set; }

        public string Contract { get; set; }
        public DateTime? ContractDateStart { get; set; }
        public DateTime? ContractDateEnd { get; set; }

        [StringLength(32)]
        public string Phone { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(256)]
        public string ContactPerson { get; set; }

        public bool Status { get; set; }    





    }
}