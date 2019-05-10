using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoUploadMvc5.Models
{
    public class tblFile
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public Byte[] Data { get;
            set;
        }



    }
}