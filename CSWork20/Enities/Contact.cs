namespace CSWork20.Enities
{
    public class Contact
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ThirdName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Desc { get; set; }

        public Contact() { }

        public Contact(string lastName, string firstName, string thirdName, string phone, string address, string desc)
        {
            LastName = lastName;
            FirstName = firstName;
            ThirdName = thirdName;
            Phone = phone;
            Address = address;
            Desc = desc;
        }

        public Contact(int id, string lastName, string firstName, string thirdName, string Phone, string address, string desc) : this(lastName, firstName, thirdName, Phone, address, desc)
        {
            Id = id;
        }
    }
}
