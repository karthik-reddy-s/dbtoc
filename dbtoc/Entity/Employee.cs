using System;
using System.Collections.Generic;

#nullable disable

namespace dbtoc.Entity
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Place { get; set; }
        public string Phone { get; set; }
    }
}
