using EpidemicTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public class LoginRepository:ILoginRepository
    {
        private EpidemicTrackerContext _context;
        public LoginRepository(EpidemicTrackerContext context)
        {
            _context = context;
        }
        public Login SignIn(Login login)
        {
            var obj = _context.Login.Where(e => e.UserName == login.UserName && e.Password == login.Password).FirstOrDefault();
            if (obj != null)
            {
                return obj;
            }
            return null;
        }
    }
}
