using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class PropertyFixedPrice
    {
        [Key]
        public int id { get; set; }
        public string Currency { get; set; }
        public decimal PricePerNight { get; set; }
        public decimal PricePerWeek { get; set; }
        public decimal PricePerMonth { get; set; }
        public decimal CleaningFeeDaily { get; set; }
        public decimal CleaningFeeWeek { get; set; }
        public decimal CleaningFeeMonth { get; set; }
        public decimal OneTimeFee { get; set; }
        public string OtherFee { get; set; }
        public decimal Comision { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal PricePerAdult { get; set; }
        public decimal PricePerChild { get; set; }

        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
