using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace applicationusingcurd
{
    public class empclass
    {
        public string e_id { get; set; }
        public string e_name { get; set; }
        public string e_designation { get; set; }
    }
        public class EmpCollection : List<empclass>
        {
            //public void newdata(empclass st)
            //{
            //    base.Add(st);
            //}

        }
    }

