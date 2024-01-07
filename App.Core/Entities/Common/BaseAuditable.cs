using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Entities.Common
{
    public abstract class BaseAuditable:BaseEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
