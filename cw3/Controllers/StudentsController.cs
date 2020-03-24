using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using cw3.DAL;
using cw3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace cw3.Controllers
{
    [ApiController]
    [Route(template:"api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }
        /*
        [HttpGet]
        public IActionResult GetStudent()

        {
            return Ok(_dbService.GetStudent());
        }
        */

        
                [HttpGet]
                public IActionResult GetStudent() 
                {

                    var list = new List<Student>();
                        using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s13777;Integrated Security=True"))
                        using(var com = new SqlCommand())
                    {
                        com.Connection = con;
                        com.CommandText = "SELECT * FROM Student";

                        con.Open();
                        SqlDataReader dr = com.ExecuteReader();
                        while (dr.Read())
                        {
                            var st = new Student();
                         st.FirstName = dr["FirstName"].ToString();
                         st.LastName = dr["LastName"].ToString();
                         st.StudiesName = dr["Name"].ToString();
                         st.Semester = dr["Semester"].ToString();
                         list.Add(st);
                        }
                    }
                    return Ok(list);
                }
                

        [HttpGet("{indexNumber}")]
        public IActionResult GetStudent(String indexNumber)
        {

            var lista = new List<Student>();
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s13777;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT Student.FirstName, Student.LastName, Studies.Name, Enrollment.Semester FROM Student, Studies, Enrollment WHERE Student.IdEnrollment = Enrollment.IdEnrollment AND Studies.IdStudy = Enrollment.IdStudy AND IndexNumber=@index";
                com.Parameters.AddWithValue("index", indexNumber);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.StudiesName = dr["Name"].ToString();
                    st.Semester = dr["Semester"].ToString();
                    lista.Add(st);
                    return Ok(lista);
                }
            }
            return NotFound();
        }
        
       

/*
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            //... add to database
            //... generating index number
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);

        }
        

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id == 1 || id == 2 || id == 3)
            {
                return Ok("Usuwanine ukończone.");

            }
            return NotFound("Nie ma takiego studenta.");
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            if (id == 1 || id == 2 || id == 3)
            {
                return Ok("Aktualizacja dokończona.");

            }
            return NotFound("Nie ma takiego studenta.");
        }
        */

    }
}