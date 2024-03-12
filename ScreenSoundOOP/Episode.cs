namespace ScreenSoundOOP
{
    class Episode
    {
        private List<string> guests = new(); 
        public int Order { get; }
        public string Title { get; }
        public int Duration { get; }
        public string Summary => $"{Order}. {Title} ({Duration} min) - " +
            $"{string.Join(", ", guests)}";

        public Episode(int order, string title, int duration)
        {
            this.Order = order;
            this.Title = title;
            this.Duration = duration; 
        }

        public void AddGuests(string guest)
        {
            guests.Add(guest);
        }

    }
}
