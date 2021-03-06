﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Services.Models
{
    public class PropertyBooking
    {
        public string PropertyName { get; set; }

        public int PropertyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please provide Guest Count")]
        public int GuestNo { get; set; }

        public int AdultNo { get; set; }

        public int ChildNo { get; set; }

        public decimal AprroxPrice { get; set; }
    }
}
