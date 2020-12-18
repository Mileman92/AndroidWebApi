using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AndroidWebApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AndroidWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        AMEDContext dbContext = new AMEDContext();

        // POST api/<ValuesController1>
        [HttpPost]
        public string Post([FromBody] UserTbl value)
        {
            if (!dbContext.UserTbl.Any(user => user.StrPeWinUser.Equals(value.StrPeWinUser)))
            {
                UserTbl user = new UserTbl();
                user.StrPeWinUser = value.StrPeWinUser; //assign value from post to user
                user.StrPeAccPasswort = value.StrPeAccPasswort;
                user.Salt = Convert.ToBase64String(Common.GetRandomSalt(16));

                //add to DB
                try
                {
                    dbContext.Add(user);
                    dbContext.SaveChanges();
                    return JsonConvert.SerializeObject("Register succesfully");
                }
                catch (Exception ex)
                {
                    return JsonConvert.SerializeObject(ex.Message);
                }
            }
            else
            {
                return JsonConvert.SerializeObject("User is existing in Database");
            }
        }

    }
}
