﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMeeting.Core.Domain.Models
{
    public class User
    {
        public User() { }
        public User(string username, string password)
        {
            Id = Guid.NewGuid();
            UserName = username;
            Password = password;
            CreatedAt = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }    
        public DateTime CreatedAt { get; set; }
    }
}
