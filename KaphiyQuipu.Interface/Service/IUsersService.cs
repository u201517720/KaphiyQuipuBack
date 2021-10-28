

using KaphiyQuipu.DTO;
using KaphiyQuipu.Models.User;
using System.Threading.Tasks;

namespace KaphiyQuipu.Interface.Service
{
    public interface IUsersService
    {
        LoginBE AuthenticateUsers(string username, string password);
        int RegistrarUsuario(User request);
        int RegistrarRolUsuario(int userId, int userRolId);
        int ValidarUsuario(string correo);
    }
}