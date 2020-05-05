using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace dip.web.Data.Entities
{
    public class UserGroupEntity

    {
        public int Id { get; set; }

        public UserEntity User { get; set; }

        public ICollection<UserEntity>  Users{ get; set; }
    }
}
