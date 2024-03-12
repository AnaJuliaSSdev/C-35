namespace ScreenSoundOOP
{
    class Music
    {
        public string Name { get; }
        public Band Band { get; }
        public int Duration { get; }
        public bool Disponibility { get; set; }
        public string Description => $"The music {Name} belongs to the band {Band.Name}";
        public Genre Genre { get; set; }

        public Music(Band band, string name, int duration, Genre genre)
        {
            this.Band = band;
            this.Name = name;
            this.Duration = duration;
            this.Genre = genre;
        }

        public void DataSheet()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Band: {Band.Name}");
            Console.WriteLine($"Duration: {Duration} seconds");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine(Disponibility ? "Available." : "Purchase the plus plan.");

        }
    }
}
