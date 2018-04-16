using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using MySql.Data.MySqlClient;
using searchuser.DBModel;

namespace searchuser.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpGet]
        public string Get()
        {
            // create some users
            FileInfo file = new FileInfo("./chiese name.txt");
            if (file.Exists)
            {
                List<string> names = new List<string>();
                using (var stream = file.OpenRead())
                {
                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        var output = reader.ReadToEnd();
                        string[] namelist = output.Split(new char[] { '\r', '\n', ' ' });
                        names.AddRange(namelist);
                    }
                }

                if (names != null && names.Count > 0)
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=kindlepush;uid=root;pwd=shabi;charset='gbk';SslMode=None");
                    names = names.Where(name => !string.IsNullOrEmpty(name)).ToList();
                    StringBuilder sb = new StringBuilder();
                    foreach (string name in names)
                    {
                        var id = con.QueryFirst<int>(
                            string.Format("insert into tbl_user(`name`, `age`, `create_time`) values('{0}', {2}, '{1}');select last_insert_id();", name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), new Random(10).Next()));
                        sb.AppendFormat("{0} : {1} <br />", id, name);
                    }
                    return sb.ToString();
                }
                return "no names";
            }
            else
                return "no such file called chiesename.txt";
        }
    }
}
