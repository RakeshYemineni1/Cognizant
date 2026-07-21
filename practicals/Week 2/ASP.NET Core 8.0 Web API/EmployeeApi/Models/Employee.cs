using System;
using System.Collections.Generic;

namespace EmployeeApi.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Salary { get; set; }
        public bool Permanent { get; set; }
        public Department Department { get; set; } = null!;
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public DateTime DateOfBirth { get; set; }
    }
}
