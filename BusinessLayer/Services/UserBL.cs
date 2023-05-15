using BusinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL iUserRL;
        public UserBL(IUserRL iUserRL)
        {
            this.iUserRL = iUserRL;
        }

        public ProfileModel UserLogin(LoginModel loginModel)
        {
            try
            {
                return iUserRL.UserLogin(loginModel);
            }
            catch(Exception ex)
            {
                throw(ex);
            }
        }
    }
}
