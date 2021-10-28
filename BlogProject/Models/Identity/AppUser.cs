using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models.Identity
{
    // users tablomuzun primary key'i int olması için ....
    // public class Appuser :D IdentityUser // default key string oluştutacakttır.. 
    public class AppUser : IdentityUser<int>
    {
    }
}
