using System;

namespace TumakovLab9
{
    internal class Song
    {
        string name;
        string author;
        Song prev;

        public Song()
        {
            name = "";
            author = "";
            prev = null;
        }

        public Song(string name, string author)
        {
            this.name = name;
            this.author = author;
            prev = null;
        }

        public Song(string name, string author, Song prev)
        {
            this.name = name;
            this.author = author;
            this.prev = prev;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetPrev(Song prev)
        {
            this.prev = prev;
        }

        public string Title()
        {
            return this.name + " - " + this.author;
        }

        public override bool Equals(object d)
        {
            Song otherSong = d as Song;
            if (otherSong != null && (otherSong.name == name) && (otherSong.author == author))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
