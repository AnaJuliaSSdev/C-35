
namespace ScreenSoundOOP
{
    class Album
    {
        private List<Music> musics = new List<Music>();
        public string Name { get; }

        public Album(string name)
        {
            this.Name = name;
        }

        public int TotalDuration => musics.Sum(m => m.Duration); 

        public void AddMusic(Music music)
        {
            musics.Add(music); 
        }

        public void DisplaySongs()
        {
            Console.WriteLine($"List of songs from the album {Name}:\n");
            foreach (Music music in musics)
            {
                Console.WriteLine($"-{music.Name} ({music.Duration} seconds)\n");
            }
        }
    }
}
