using System;
using System.Collections.Generic;

#nullable disable

namespace dbtoc.models
{
    public partial class UserLogin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
