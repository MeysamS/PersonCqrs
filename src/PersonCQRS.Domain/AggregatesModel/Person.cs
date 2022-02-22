using System;
using System.Net.Mail;
using PersonCQRS.Domain.Common;

namespace PersonCQRS.Domain.AggregatesModel
{
    public class Person:Entity,IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; }

        public Person(string firstName, string lastName, string email, DateTime dateOfBirth, string phoneNumber)
        {
            FirstName = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            LastName = !string.IsNullOrWhiteSpace(lastName) ? lastName : throw new ArgumentNullException(nameof(lastName));
            Email = !string.IsNullOrWhiteSpace(email) ? email : throw new ArgumentNullException(nameof(email));
            DateOfBirth = dateOfBirth;
            PhoneNumber = !string.IsNullOrWhiteSpace(phoneNumber) ? phoneNumber : throw new ArgumentNullException(nameof(phoneNumber));
            
            EmailIsValid(email);
        }

        public bool EmailIsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                throw new FormatException(nameof(emailaddress));
            }
        }
        
        protected Person(){}
    

    }
    
    
}