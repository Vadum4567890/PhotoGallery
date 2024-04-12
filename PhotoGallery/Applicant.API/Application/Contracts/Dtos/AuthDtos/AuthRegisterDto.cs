using System;
using System.ComponentModel.DataAnnotations;

namespace Applicant.API.Application.Contracts.Dtos.AuthDtos
{
    public class AuthRegisterDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        public int Code { get; set; }

        public string AdditionalInfo { get; set; }
    }
}