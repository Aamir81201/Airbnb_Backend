using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.ViewModels
{
    public class UserStateModel
    {
        public string State { get; set; }
        public string? Token { get; set; }
        public UserProfileModel? UserProfile { get; set; }
    }
}
