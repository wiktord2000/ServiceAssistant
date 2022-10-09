using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Status
    {
        public int Id { get; set; }
        [Required]
        public int Position { get; set; }
        [Required]
        public string Name { get; set; }
        public bool? Finished { get; set; } = false;
        public bool? IsPaid { get; set; } = false;
        public bool? HasInvoice { get; set; } = false;
        public bool? EmailSend { get; set; } = false;
    }
}