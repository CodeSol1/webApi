using System;
namespace WebApiDemo.Models
{
    public class Student
    {
        public int  Id { get; set; }

        public string Name { get; set; }
        public string Batch { get; set; }
        public DateTime  DOJ { get; set; }
    }
}
