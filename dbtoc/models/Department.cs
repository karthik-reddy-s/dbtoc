using System;
using System.Collections.Generic;



namespace dbtoc.models
{
    public partial class Department
    {
        internal int deptId;

        public int DeptId { get; set; }
        public string Nameofemployee { get; set; }
        public string Dateofjoining { get; set; }
        public string Depart { get; set; }
        public int? Price { get; set; }
    }
}
