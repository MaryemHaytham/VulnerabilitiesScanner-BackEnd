using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Services.IServices
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
