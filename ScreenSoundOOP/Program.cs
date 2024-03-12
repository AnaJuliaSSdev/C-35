using ScreenSoundOOP;

Genre rock = new Genre("Rock");

Band cascavelletes = new Band("Cascavelletes");

Album rockaula = new Album("Rock'a'ula");

cascavelletes.AddAlbum(rockaula);

Music gatoPreto = new Music(cascavelletes, "Gato Preto", 270, rock);
Music jessicaRose = new Music(cascavelletes, "Jessica Rose", 268, rock);
Music cao = new Music(cascavelletes, "Cão e Cadela", 184, rock); 

rockaula.AddMusic(gatoPreto);
rockaula.AddMusic(jessicaRose);
rockaula.AddMusic(cao);

cascavelletes.DisplayDiscography();
rockaula.DisplaySongs(); 

