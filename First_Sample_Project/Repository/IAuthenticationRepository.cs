using First_Sample_Project.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace First_Sample_Project.Repository
{
    public interface IAuthenticationRepository
    {
        UserRegistration GetUsersbyId(int? id);
        IEnumerable<UserRegistration> GetUsers();

        int AddUsers(UserRegistration user);

        bool AuthenticatedUser(string? email, string? password);

        int DeleteUser(int id);

        void UpdateUsers(int id,UserRegistration user);
    }
}

