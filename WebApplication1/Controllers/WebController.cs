using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebController : ControllerBase
    {
        private IConfiguration _configuration;
        public WebController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetNotes")]
        public JsonResult GetNotes() 
        {
            string query = "select * from dbo.Notes";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon=new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query,myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        [Route("AddNotes")]
        public JsonResult AddNotes([FromForm] string newNotes)
        {
            string query = "insert into dbo.Notes values(@newNotes)";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@newNotes", newNotes);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPost]
        [Route("AddAddon")]
        public JsonResult AddAddon(int id, string name, float price)
        {
            string query = "insert into dbo.Add_on values(@id, @name, @price)";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myCommand.Parameters.AddWithValue("@name", name);
                    myCommand.Parameters.AddWithValue("@price", price);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpGet]
        [Route("GetAdmin")]
        public JsonResult GetAdminFName()
        {
            string query = "select * from dbo.Admin";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        /*
        [HttpGet]
        [Route("GetAdminFName")]
        public JsonResult GetAdminFName()
        {
            string query = "select * from dbo.Admin.fname";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        */

        [HttpPost]
        [Route("AddAdmin")]
        public JsonResult AddAdmin(int adminID, string fname, string lname)
        {
            string query = "insert into dbo.Admin values(@adminID, @fname, @lname)";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@adminID", adminID);
                    myCommand.Parameters.AddWithValue("@fname", fname);
                    myCommand.Parameters.AddWithValue("@lname", lname);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpGet]
        [Route("GetCustomer")]
        public JsonResult GetCustomer()
        {
            string query = "select * from dbo.Customer";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        [Route("AddCustomer")]
        public JsonResult AddCustomer([FromForm] string fname, [FromForm] string lname, [FromForm] string email, [FromForm] string address, [FromForm] string city, [FromForm] string state, [FromForm] int zip, [FromForm] string phone, [FromForm] string partyType)
        {
            string query = "insert into dbo.Customer values(@fname, @lname, @email, @address, @city, @state, @zip, @phone, @partyType)";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@fname", fname);
                    myCommand.Parameters.AddWithValue("@lname", lname);
                    myCommand.Parameters.AddWithValue("@email", email);
                    myCommand.Parameters.AddWithValue("@address", address);
                    myCommand.Parameters.AddWithValue("@city", city);
                    myCommand.Parameters.AddWithValue("@state", state);
                    myCommand.Parameters.AddWithValue("@zip", zip);
                    myCommand.Parameters.AddWithValue("@phone", phone);
                    myCommand.Parameters.AddWithValue("@partyType", partyType);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }        

        [HttpPost]
        [Route("AddHost")]
        public JsonResult AddHost([FromForm] string fname, [FromForm] string lname)
        {
            string query = "insert into dbo.Host values(@fname, @lname)";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    //myCommand.Parameters.AddWithValue("@id", id);
                    myCommand.Parameters.AddWithValue("@fname", fname);
                    myCommand.Parameters.AddWithValue("@lname", lname);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPost]
        [Route("AddMealDeal")]
        public JsonResult AddMealDeal(string name, float price, float retainer, string description)
        {
            string query = "insert into dbo.Meal_deal values(@name, @price, @retainer, @description)";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@name", name);
                    myCommand.Parameters.AddWithValue("@price", price);
                    myCommand.Parameters.AddWithValue("@retainer", retainer);
                    myCommand.Parameters.AddWithValue("@description", description);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPost]
        [Route("AddPartyRoom")]
        public JsonResult AddPartyRoom(int customerID, string room, DateTime dateTime, string floorNum, string capacity, string mealDealName, int addOnID)
        {
            string query = "insert into dbo.Party_room values(@cID, @room, @dateTime, @floorNum, @capacity, @mDName, @addonID)";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cID", customerID);
                    myCommand.Parameters.AddWithValue("@room", room);
                    myCommand.Parameters.AddWithValue("@dateTime", dateTime);
                    myCommand.Parameters.AddWithValue("@floorNum", floorNum);
                    myCommand.Parameters.AddWithValue("@capacity", capacity);
                    myCommand.Parameters.AddWithValue("@mDName", mealDealName);
                    myCommand.Parameters.AddWithValue("@addOnID", addOnID);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPost]
        [Route("AddQuestionnaire")]
        public JsonResult AddQuestionnaire(int questionID, string description, string type)
        {
            string query = "insert into dbo.Questionnaire values(@qID, @description, @type)";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@qID", questionID);
                    myCommand.Parameters.AddWithValue("@description", description);
                    myCommand.Parameters.AddWithValue("@type", type);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPost]
        [Route("AddQuestionnaireAnswers")]
        public JsonResult AddQuestionnaireAnswers([FromForm] int customerID, [FromForm] int questionID, [FromForm] string response)
        {
            string query = "insert into dbo.Questionnaire_answers values(@cID, @qID, @response)";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cID", customerID);
                    myCommand.Parameters.AddWithValue("@qID", questionID);
                    myCommand.Parameters.AddWithValue("@response", response);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpGet]
        [Route("GetGreaterGenericParty")]
        public JsonResult GetGreaterGenericParty()
        {
            string query = "SELECT * FROM dbo.Generic_party WHERE (date >= '2024-04-23 12:42:06.001')";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        [HttpGet]
        [Route("GetLesserGenericParty")]
        public JsonResult GetLesserGenericParty()
        {
            string query = "SELECT * FROM dbo.Generic_party WHERE (date <= '2024-04-23 12:42:06.001')";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        [HttpGet]
        [Route("GetGenericParty")]
        public JsonResult GetGenericParty()
        {
            string query = "SELECT * FROM dbo.Generic_party WHERE Party_name = 'Pauls Party'";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpDelete]
        [Route("DeleteNotes")]
        public JsonResult DeleteNotes(int id)
        {
            string query = "delete from dbo.Notes where id=@id";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("SMC_Booking_DatabaseCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
