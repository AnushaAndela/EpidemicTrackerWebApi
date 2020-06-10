using EpidemicTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public interface ILoginRepository
    {
        Login SignIn(Login login);

    }
}
