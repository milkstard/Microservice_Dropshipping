using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthJWTClassLibrary
{
    public class CustomedAuthenticationToken
    {
        public string? Token { get; set; }
        public int? ExpiresIn { get; set; }
    }
}
