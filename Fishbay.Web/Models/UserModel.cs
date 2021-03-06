﻿using System;
using System.Collections.Generic;
using Fishbay.Core;
using Newtonsoft.Json;

namespace Fishbay.Web.Models
{
    public class UserModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid UserUid { get; set; }
        public Roles Role { get; set; }
        public UserState UserState { get; set; }
        public int FailedAttemptCount { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime Created { get; set; }
        public bool RememberMe { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}