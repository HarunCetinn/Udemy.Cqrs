﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udemy.Cqrs.CQRS.Commands
{
    public class CreateStudentCommand :IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }


    }
}
