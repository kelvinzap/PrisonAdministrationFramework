﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrisonAdministrationSystem.Models
{
    public class InmatesViewModel
    {
        public IEnumerable<Inmate> Inmates { get; set; }
    }
}