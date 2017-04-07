using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperEx.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = new DapperEx.Web.Models.UserModel();
            return View(user);
        }

        public ActionResult SaveUser(Web.Models.UserModel userModel)
        {
            var userEntity = new DapperEx.Entity.User
            {
                Userid = userModel.USERID,
                UserPswd = userModel.USER_PSWD,
                Lastname = userModel.LASTNAME,
                Firstname = userModel.FIRSTNAME,
                Email = userModel.EMAIL,
                PswdExpire = DateTime.Now.AddYears(1)
            };
            Business.UserBusiness userDal = new Business.UserBusiness();
            var conn = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"]);
            userDal.InsertUser(userEntity, conn);
            var userById = userDal.GetByUserId("GetUserById", userModel.USERID, conn);
            var usrModel = new DapperEx.Web.Models.UserModel
            {
                USERID = userById.Userid,
                USER_PSWD = userById.UserPswd,
                LASTNAME = userById.Lastname,
                FIRSTNAME = userById.Firstname,
                EMAIL = userById.Email,
                PSWD_EXPIRE = userById.PswdExpire
            };
            return View(usrModel);
        }

        public ActionResult About()
        {
            Business.UserBusiness userDal = new Business.UserBusiness();
            var conn = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"]);
            var users = userDal.GetAllUser("", conn);
            List<DapperEx.Web.Models.UserModel> usersModel = new List<DapperEx.Web.Models.UserModel>();
            foreach(var user in users)
            {
                var userModel = new DapperEx.Web.Models.UserModel
                {
                    USERID = user.Userid,
                    USER_PSWD = user.UserPswd,
                    LASTNAME = user.Lastname,
                    FIRSTNAME = user.Firstname,
                    EMAIL = user.Email,
                    PSWD_EXPIRE = user.PswdExpire
                };
                usersModel.Add(userModel);
            }
            return View(usersModel);
        }

    }
}