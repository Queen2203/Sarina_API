using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sarina_API.Models;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;

namespace Sarina_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        public IConfiguration Configuration { get; set; }

        private IdentityModel db;
        private readonly ILogger _logger;

        public CategoryController(IdentityModel dbContext, IConfiguration configuration, ILogger<CategoryController> logger)
        {
            db = dbContext;
            Configuration = configuration;
            _logger = logger;

        }

        [HttpGet("getcategories")]
        public IActionResult getcategories(int companyid, string type)
        {
            try
            {
                //var category = db.Categories.Where(x => x.CompanyId == companyid).ToList();
                //return Ok(category);
                List<Category> categories;
                if (type == "S") categories = db.Categories.Where(x => x.CompanyId == companyid && x.ParentCategoryId != null).Include(x => x.ParentCategory).ToList();
                else if (type == "P") categories = db.Categories.Where(x => x.CompanyId == companyid && x.ParentCategoryId == null).Include(x => x.ParentCategory).ToList();
                else categories = db.Categories.Where(x => x.CompanyId == companyid).Include(x => x.ParentCategory).ToList();
                return Ok(categories);
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


        [HttpGet("getSubcategory")]
        public IActionResult getallproducts(int companyid)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(Configuration.GetConnectionString("ConnStr"));
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("dbo.EcomGetSubCategories", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@companyId", companyid));
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
                sqlAdp.Fill(ds);
                var response = new
                {
                    Categories = ds.Tables[0]
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

        //[HttpPost("SaveCategory")]
        //public IActionResult SaveCategory([FromBody] Category category)
        //{

        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
