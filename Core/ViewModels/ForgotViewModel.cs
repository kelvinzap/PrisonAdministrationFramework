﻿using System.ComponentModel.DataAnnotations;

namespace PrisonAdministrationFramework.Core.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}