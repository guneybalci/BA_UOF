using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUOF.Data.Models
{
  public abstract  class ModelBase
    {
        public /*virtual*/ DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
