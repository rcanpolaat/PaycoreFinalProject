using System;

namespace FinalProject.Data
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime LastActivity { get; set; }
    }
}