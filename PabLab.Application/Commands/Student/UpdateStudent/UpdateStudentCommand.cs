﻿using MediatR;

namespace PabLab.Application.Commands.Student.UpdateStudent
{
    public class UpdateStudentCommand : IRequest
    {
        public int StudentId { get; set; }
        
        public string FirstName { get; set; }
    
        public string LastName { get; set; }
    
        public DateTime DateOfBirth { get; set; }
    }
}
