namespace Thesis_project_Repository.Models
{
    public class UserModels
    {
        public UserModels(string userName, string password, char accountType, string randomString, string adminApproval,
            string secQuestion, string secAnswer, string firstName, string lastName, string phoneNumber, string carrier)
        {
            UserName = userName;
            Password = password;
            AccountType = accountType;
            RandomString = randomString;
            AdminApproval = adminApproval;
            SecQuestion = secQuestion;
            SecAnswer = secAnswer;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Carrier = carrier;
        }

        public UserModels(string userName, string password, string secQuestion, string secAnswer, string firstName, string lastName, string phoneNumber, string carrier)
        {
            UserName = userName;
            Password = password;
            SecQuestion = secQuestion;
            SecAnswer = secAnswer;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Carrier = carrier;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public char AccountType { get; set; }
        public string RandomString { get; set; }
        public string AdminApproval { get; set; }
        public string SecQuestion { get; set; }
        public string SecAnswer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Carrier { get; set; }
    }


}