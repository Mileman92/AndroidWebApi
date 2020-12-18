using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AndroidWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        AMEDContext dbContext = new AMEDContext();

        // POST api/<lOGINController>
        [HttpPost]
        public string Post([FromBody] UserTbl value)
        {
            //chech exists
            //First, we need chechk User have existing in db?
            if (dbContext.UserTbl.Any(user => user.StrPeWinUser.Equals(value.StrPeWinUser)))
            {
                UserTbl user = dbContext.UserTbl.Where(u => u.StrPeWinUser.Equals(value.StrPeWinUser)).First();

                var client_post_hash_password = value.StrPeAccPasswort;


                if (client_post_hash_password.Equals(user.StrPeAccPasswort))
                {
                    return JsonConvert.SerializeObject(user);
                }
                else
                {
                    return JsonConvert.SerializeObject("Wrong password");
                }

            }
            else
            {
                return JsonConvert.SerializeObject("User not existing in Database");
            }
        }


    }
}
