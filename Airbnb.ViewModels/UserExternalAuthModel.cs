using Airbnb.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.ViewModels
{
    public class UserExternalAuthModel
    {
        public string TokenId { get; set; } = string.Empty;
        public string Provider { get; set; }
    }
}
