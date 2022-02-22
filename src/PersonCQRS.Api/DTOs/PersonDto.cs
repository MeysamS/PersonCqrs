﻿using System;

namespace PersonCQRS.Api.DTOs
{
    public class PersonDto
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
        public DateTime DateOfBirth { get;  set; }
        public string PhoneNumber { get;  set; }
    }
}