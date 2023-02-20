using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCITE.Repository.DTOs
{
    public class LoginResponseDTO
    {
        public DataAccessUserDTO User { get; set; }
        public List<WebMenuDTO> WebMenus { get; set; }
        public List<WebMenuTypeDTO> WebMenuTypes { get; set; }

        public AppSettingsDTO AppSettings { get; set; }

    }
}
