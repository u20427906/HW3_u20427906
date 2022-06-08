using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW3_u20427906.Models
{
    public class FileModel
    {
        public string fileName { get; set; }
        
        public HttpPostedFileBase[] files { get; set; }

        public string Option { get; set; }
    }
}