namespace Challenge1
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Profession { get; set; }

        public Person(string name, int age, string profession)
        {
            Name = name;
            Age = age;
            Profession = profession;
        }

        public override string ToString()
        {
            return $"{Name} (Age: {Age}, Profession: {Profession})";
        }

    }
}
