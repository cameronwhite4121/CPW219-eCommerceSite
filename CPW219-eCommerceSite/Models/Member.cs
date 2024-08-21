﻿using System.ComponentModel.DataAnnotations;

namespace CPW219_eCommerceSite.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string Phone { get; set; }
    }
}
