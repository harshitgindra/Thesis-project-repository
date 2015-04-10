using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thesis_project_Repository.Modals
{
    public class FacultyModels
    {
        private string userName;
        private string password;
        private char accountType;
        private string randomString;
        private string adminApproval;
        private string secQuestion;
        private string secAnswer;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string carrier;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public char AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }

        public string RandomString
        {
            get { return randomString; }
            set { randomString = value; }
        }

        public string AdminApproval
        {
            get { return adminApproval; }
            set { adminApproval = value; }
        }

        public string SecQuestion
        {
            get { return secQuestion; }
            set { secQuestion = value; }
        }

        public string SecAnswer
        {
            get { return secAnswer; }
            set { secAnswer = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
      
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        
        public string Carrier
        {
            get { return carrier; }
            set { carrier = value; }
        }
    }
}