﻿using System.ComponentModel.DataAnnotations;

namespace QueueMessageSender.Models
{
    /// <summary>
    /// Credential model
    /// </summary>
    public class AuthenticationModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
