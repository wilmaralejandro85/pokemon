using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Entities
{
    public partial class BaseResponseDTO
    {
        public string time { get; set; } = "0 ms";
        public bool result { get; set; } = false;
        public string errors { get; set; } = "";
        public int status { get; set; } = 500;
    }

    public partial class BaseResponseDTOToken
    {
        public string time { get; set; } = "0 ms";
        public string result { get; set; } = "";
        public string errors { get; set; } = "";
        public int status { get; set; } = 500;
        public string token_type { get; set; } = "bearer";
        public string expires_in { get; set; } = "1200";
    }
}
