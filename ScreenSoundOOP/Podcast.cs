namespace ScreenSoundOOP
{
    class Podcast
    {
        public string Name { get; }
        public string Host { get; }
        public int TotalEpisodes => episodes.Count;
        private List<Episode> episodes;

        public Podcast(string name, string host)
        {
            this.Name = name;
            this.Host = host;
        }

        public void AddEpisode(Episode episode)
        {
            episodes.Add(episode);
        }

        public void DataSheet()
        {
            Console.WriteLine($"Podcast {Name} presented by {Host}\n");
            foreach(Episode episode in episodes.OrderBy(e => e.Order))
            {
                Console.WriteLine(episode.Summary);
            }
            Console.WriteLine($"This podcast have {TotalEpisodes} episodes\n.");
        }
    }
}
