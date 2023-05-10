using Microsoft.AspNetCore.Mvc;
using Sarina_API.Models;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;
using Microsoft.AspNetCore.Hosting;
using Sarina_API.Models.Enum;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Sarina_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        public IConfiguration Configuration { get; set; }

        private IdentityModel db;
        private readonly ILogger _logger;
        public static IHostingEnvironment _environment;

        public ProductController(IdentityModel dbContext, IConfiguration configuration, ILogger<CategoryController> logger, IHostingEnvironment environment)
        {
            db = dbContext;
            Configuration = configuration;
            _logger = logger;
            _environment = environment;

        }


        [HttpGet("getallproducts")]
        public IActionResult getallproducts(int companyid)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("ConnStr"));
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("dbo.EcomGetProducts", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@companyId", companyid));
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                var response = new
                {
                    produts = ds.Tables[0]
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 0,
                    msg = "Something went wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                };
                return Ok(response);
            }
        }

        //public string ImageUpload(int companyid, IFormFile file)
        //{
        //    try
        //    {
        //        //long size = file.Sum(f => f.Length);

        //        // full path to file in temp location
        //        // var filePath = "https://biz1app.azurewebsites.net/Images/3";
        //        string subdir = "\\images\\" + companyid + "\\";
        //        if (!Directory.Exists(Environments.WebRootPath + subdir))
        //        {
        //            Directory.CreateDirectory(_environment.WebRootPath + subdir);
        //        }
        //        using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + subdir + file.FileName))
        //        {
        //            file.CopyTo(filestream);
        //            filestream.Flush();
        //            var response = new
        //            {
        //                url = "https://biz1pos.azurewebsites.net/images/" + companyid + "/" + file.FileName
        //            };
        //            return response.url;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var error = new
        //        {
        //            status = 0,
        //            msg = new Exception(ex.Message, ex.InnerException)
        //        };
        //        return "";
        //    }
        //}

        [HttpPost("AddProductLink")]
        public IActionResult AddProductLink([FromBody] ProductImage productImage)
        {
            try
            {
                db.ProductImages.Add(productImage);
                db.SaveChanges();
                var response = new
                {
                    status = 200,
                    msg = "product added successfully"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = 0,
                    msg = "OOPS! Something went wrong",
                    error = new Exception(ex.Message, ex.InnerException)
                };
                return Ok(response);
            }
        }




        //public string ImageUpload(int companyid, IFormFile file)
        //{
        //    try
        //    {

        //        string subdir = "\\images\\" + companyid + "\\";
        //        if (!Directory.Exists(_environment.WebRootPath + subdir))
        //        {
        //            Directory.CreateDirectory(_environment.WebRootPath + subdir);
        //        }
        //        using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + subdir + file.FileName))
        //        {
        //            file.CopyTo(filestream);
        //            filestream.Flush();
        //            var response = new
        //            {
        //                url = "https://biz1pos.azurewebsites.net/images/" + companyid + "/" + file.FileName
        //            };
        //            return response.url;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var error = new
        //        {
        //            status = 0,
        //            msg = new Exception(ex.Message, ex.InnerException)
        //        };
        //        return "";
        //    }
        //}


        public IActionResult Index()
        {
            return View();
        }
    }

    internal class _environment
    {
    }
}
