﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.DTO
{
    public class AddToCartDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]

        public int Count { get; set; }

    }
}
