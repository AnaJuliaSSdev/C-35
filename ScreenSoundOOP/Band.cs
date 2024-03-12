namespace ScreenSoundOOP
{
    class Band
    {
        private List<Album> albums = new List<Album>();
        public string Name { get; set; }

        public Band(string name)
        {
            this.Name = name;
        }

        public void AddAlbum(Album album)
        {
            this.albums.Add(album);
        }

        public void DisplayDiscography()
        {
            Console.WriteLine($"\nDiscography of the band {Name}: ");
            foreach(Album album in this.albums)
            {
                Console.WriteLine($"-{album.Name} ({album.TotalDuration} seconds)\n");
            }
        }
    }
}
