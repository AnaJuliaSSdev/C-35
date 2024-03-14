namespace Challenge1
{
    internal class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Person Owner { get; set; }

        public Car(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

        public void AssignOwner(Person person)
        {
            Owner = person;
        }

        public override string ToString()
        {
            string ownerInfo = Owner != null ? $"Owned by: {Owner.Name}" : "No owner assigned";
            return $"{Brand} {Model} ({Year}) - {ownerInfo}";
        }
    }
}
