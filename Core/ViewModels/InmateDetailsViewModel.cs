﻿using PrisonAdministrationFramework.Core.Models;

namespace PrisonAdministrationFramework.Core.ViewModels
{
    public class InmateDetailsViewModel
    {
        public Inmate Inmate { get; set; }
        public ApplicationUser User { get; set; }
        public string Query { get; set; }
    }
}