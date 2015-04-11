using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thesis_project_Repository.Modals
{
    public class FacultyModels
    {
        private string _userName;
        private string _password;
        private char _accountType;
        private string _randomString;
        private string _adminApproval;
        private string _secQuestion;
        private string _secAnswer;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _carrier;

        public FacultyModels(string userName, string password, char accountType, string randomString, string adminApproval, string secQuestion, string secAnswer, string firstName, string lastName, string phoneNumber, string carrier)
        {
            _userName = userName;
            _password = password;
            _accountType = accountType;
            _randomString = randomString;
            _adminApproval = adminApproval;
            _secQuestion = secQuestion;
            _secAnswer = secAnswer;
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _carrier = carrier;
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public char AccountType
        {
            get { return _accountType; }
            set { _accountType = value; }
        }

        public string RandomString
        {
            get { return _randomString; }
            set { _randomString = value; }
        }

        public string AdminApproval
        {
            get { return _adminApproval; }
            set { _adminApproval = value; }
        }

        public string SecQuestion
        {
            get { return _secQuestion; }
            set { _secQuestion = value; }
        }

        public string SecAnswer
        {
            get { return _secAnswer; }
            set { _secAnswer = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Carrier
        {
            get { return _carrier; }
            set { _carrier = value; }
        }
    }
}