using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AISV1.Models
{
    public class FileRemark
    {
       public int FileRemarkID { get; set; }
       public int FileID { get; set; }
       public string Remark { get; set; }
       public File File{ get; set; }
    }
}
