﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core
{
    public class PropertyEnterElecMap : Base
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }

        [ForeignKey("EntertainmentElectronics")]
        public int EnterElecId { get; set; }
        public EntertainmentElectronics EntertainmentElectronics { get; set; }
    }
}