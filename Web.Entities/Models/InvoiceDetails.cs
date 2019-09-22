using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Web.Entities.Models.Sifarnik;

namespace Web.Entities.Models
{
    public class InvoiceDetails
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public int ChargeId { get; set; }
        public virtual SifCharge Charge { get; set; }

        public float Rate { get; set; }

        public int Units { get; set; }

        public float Tax { get; set; }
    }
}