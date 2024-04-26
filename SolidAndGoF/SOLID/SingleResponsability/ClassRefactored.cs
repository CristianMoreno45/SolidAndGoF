namespace SolidAndGoF.SOLID.SingleResponsability
{
    public class ClassRefactored
    {
        // Define a Objects (domain)
        public class Account
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }

        // Define DTO's
        public class AccountValidatorResult()
        {
            public List<string> Messages { get; set; } = new List<string>();
            public bool IsValid { get { return !Messages.Any(); } }
        }

        // Separe Validator responibility
        public class AccountValidator
        {
            public AccountValidatorResult Validate(Account account)
            {
                var result = new AccountValidatorResult();
                if (string.IsNullOrEmpty(account.FirstName))
                    result.Messages.Add("The parameter 'First Name' is mandatory.");

                if (string.IsNullOrEmpty(account.LastName))
                    result.Messages.Add("The parameter 'Last Name' is mandatory.");

                if (account.Age < 1)
                    result.Messages.Add("The parameter 'age' is mandatory and it should be greater than zero.");

                return result;
            }
        }


        // Separe Report manager responibility
        public class ReportManager
        {
            public void DownLoadReport(string fileName, List<string> records)
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);

                using StreamWriter writer = new StreamWriter(fileName);
                foreach (string record in records)
                {
                    writer.WriteLine(record);
                }
            }
        }

        public class AccountService
        {
            public readonly List<string> Accounts = new List<string>();
            public void Create(Account account)
            {
                string result;
                var validator = new AccountValidator();
                var validatorResult = validator.Validate(account);
                if (validatorResult.IsValid)
                    result = $"The account has been created ({account.FirstName},{account.LastName},{account.Age})";
                else
                    result = string.Join(Environment.NewLine, validatorResult.Messages);
                Accounts.Add(result);
            }
        }

        public void Handle1(string fileName)
        {
            AccountService service = new AccountService();
            service.Create(new Account() { FirstName = "Jhon", LastName = "Doe", Age = 24 });
            service.Create(new Account() { FirstName = "Juan", LastName = "Rodriguez", Age = 38 });
            service.Create(new Account() { FirstName = "Emily", LastName = "Smith", Age = 38 });
            ReportManager report = new ReportManager();
            report.DownLoadReport(fileName, service.Accounts);
        }
        public void Handle2(string fileName)
        {
            AccountService service = new AccountService();
            service.Create(new Account() { FirstName = "", LastName = "Doe", Age = 24 });
            ReportManager report = new ReportManager();
            report.DownLoadReport(fileName, service.Accounts);
        }
        public void Handle3(string fileName)
        {
            AccountService service = new AccountService();
            service.Create(new Account() { FirstName = "Jhon", LastName = "", Age = 24 });
            ReportManager report = new ReportManager();
            report.DownLoadReport(fileName, service.Accounts);
        }
        public void Handle4(string fileName)
        {
            AccountService service = new AccountService();
            service.Create(new Account() { FirstName = "Jhon", LastName = "Doe", Age = 0 });
            ReportManager report = new ReportManager();
            report.DownLoadReport(fileName, service.Accounts);
        }

    }
}
