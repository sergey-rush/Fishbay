using System;
using Newtonsoft.Json;

namespace Fishbay.Core
{
    // Name, Phone, Email, UserUid
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public Guid UserUid { get; set; }
        [JsonIgnore]
        public Roles Role { get; set; }
        public AccountState AccountState { get; set; }
        [JsonIgnore]
        public UserState UserState { get; set; }
        [JsonIgnore]
        public int FailedAttemptCount { get; set; }
        [JsonIgnore]
        public DateTime LastLoginDate { get; set; }
        [JsonIgnore]
        public DateTime Created { get; set; }
        public bool RememberMe { get; set; }

        public bool IsAuthenticated { get; set; }

        public static string FormatName(string firstName, string middleName, string lastName)
        {
            return String.Format("{0} {1} {2}", firstName, middleName, lastName);
        }

        public static string FormatName(User user)
        {
            return String.Format("{0} {1} {2}", user.FirstName, user.MiddleName, user.LastName);
        }
    }
}
