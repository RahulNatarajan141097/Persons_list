using log4net;
using Microsoft.AspNetCore.Mvc;
using Persons_list.Data;
using Persons_list.EncDec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace Persons_list.Controllers
{
    [Route("api/login")] 
    [ApiController]
    public class RegisterPersonController : ControllerBase
    {
        DataContext RP = new DataContext();

        [HttpPost]
        [Route("registration")]
        public async Task<ActionResult> Post([FromBody] RegisterPersons registerPersons) 
        {
            try
            {
                registerPersons.Password = Encry_Decry.Encrypass(registerPersons.Password);
                RP.RegisterPersons.Add(registerPersons);
                RP.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e); 
            }
            return Ok("Person Added sucesfully");
        }

        [HttpPost]
        [Route("check")]
        public int check (RegisterPersons checkPersons)
        {
            try
            {
                var checkdata = RP.RegisterPersons.Where(x => x.UserName == checkPersons.UserName).FirstOrDefault();
                
                if (checkdata != null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 1; 
            }
        }

        [HttpPost]
        [Route("logincheck")]
        public int loginsuccess (RegisterPersons checkPersons)
        {
            try
            {
                var checkdata = RP.RegisterPersons.Where(x => x.UserName == checkPersons.UserName).FirstOrDefault();
                if (checkdata != null)
                {
                    var find = Encry_Decry.Decrypass(checkdata.Password);
                    if ((checkdata != null) && (find == checkPersons.Password))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 2;
                }
            }
            catch (Exception ex)
            {
                return 0; 
            }
        }
    }
}
