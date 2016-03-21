using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VHS.Core
{
    public  class Document
    {
        [Key]
        public int DocId { get; set; }
        public string FileName { get; set; }


        //StdId is not following code first conventions name]
        public int LoginId { get; set; }
        [ForeignKey("LoginId")]
        public  UserLogin UserLogin { get; set; }

    }
}
