using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ML.Domain.Entities
{
    public class AccountModels
    {
        
    }
    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        public string ExternalLoginData { get; set; }

        public string photo_50 { get; set; }
        public string status { get; set; }
        public string music { get; set; }
        public string accesstoken { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string photo_50 { get; set; }
        public string music { get; set; }
        public string status { get; set; }
        public string accesstoken { get; set; }
    }
}