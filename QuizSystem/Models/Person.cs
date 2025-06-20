﻿namespace QuizSystem.Models
{
    public abstract class Person:BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email     { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
