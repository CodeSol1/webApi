using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static List<Student> list = null;
        public StudentController()
        {
            if (list == null)
            {
                list = new List<Student>()
                {
                    new Student() { Id=1,Name="AJay", Batch="B001", DOJ= Convert.ToDateTime("12/12/2021")},

                    new Student() { Id=2,Name="Vijay", Batch="B001", DOJ= Convert.ToDateTime("12/12/2021")},

                    new Student() { Id=3,Name="Jay", Batch="B001", DOJ= Convert.ToDateTime("12/12/2021")}
                };
            }

        }
        [HttpGet]
        public List<Student> Get()
        {
            return list.ToList();
        }



        [HttpGet]

        [Route("{id:int}")]
        public Student Get(int id)
        {
            return list.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public void Create(Student student)
        {
            list.Add(student);
        }

        [HttpPut]
        [Route("{id:int}")]
        public void Edit(int id, Student student)
        {

            Student obj = list.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                foreach (Student temp in list)
                {
                    if (temp.Id == id)
                    {
                        temp.Batch = student.Batch;
                        temp.DOJ = student.DOJ;
                    }
                }
            }
        }



        [HttpDelete]
        [Route("{id:int}")]
        public void Delete(int id)
        {

            Student obj = list.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                list.Remove(obj);
            }
        }

    }
}

