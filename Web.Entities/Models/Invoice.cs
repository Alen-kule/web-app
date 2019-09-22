using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Web.Entities.Models.Sifarnik;

namespace Web.Entities.Models
{
    public class Invoice
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Index("InvoiceNumberAndCompanyName", 1, IsUnique = true), StringLength(256)]
        public string InvoiceNumber { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Index("InvoiceNumberAndCompanyName", 2, IsUnique = true), StringLength(256)]
        public string CompanyName { get; set; }



    }
}