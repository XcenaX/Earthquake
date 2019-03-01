using System;

namespace Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
