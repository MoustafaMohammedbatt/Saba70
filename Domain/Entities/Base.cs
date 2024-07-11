﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Base
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
