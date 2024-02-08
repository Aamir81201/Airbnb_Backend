using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.ViewModels
{
    public class UserStateResponseDTO
    {
        public string State { get; set; }
        public string? Token { get; set; }
        public UserProfileResponseDTO? UserProfile { get; set; }
    }
}
