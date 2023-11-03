namespace SimpleCRUDApp.Models
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }

        public User(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }

        public void Update(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }

        public void Delete()
        {
            Deleted = true;
        }
    }
}
