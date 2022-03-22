using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    //UserId,CompanyName
    public class Customer:User,IEntity
    {
        
        public string CompanyName { get; set; }
    }
}
