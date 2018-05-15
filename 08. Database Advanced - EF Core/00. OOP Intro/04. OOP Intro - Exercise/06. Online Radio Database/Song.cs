public class Song
{
    private string artist;
    private string title;
    private int minutes;
    private int seconds;
    private string totalDuration;

    public Song(string artist, string title, int minutes, int seconds)
    {
        this.Artist = artist;
        this.Title = title;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }
    
    public int Seconds
    {
        get { return this.seconds; }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }
            this.seconds = value;
        }
    }

    public int Minutes
    {
        get { return this.minutes; }
        set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }
            this.minutes = value;
        }
    }

    public string Title
    {
        get { return this.title; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSSongNameException();
            }
            this.title = value;
        }
    }

    public string Artist
    {
        get { return this.artist; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }
            this.artist = value;
        }
    }
}