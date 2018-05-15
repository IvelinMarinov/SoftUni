using System;
using System.Collections.Generic;

namespace _06.Online_Radio_Database
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                var songInfo = Console.ReadLine().Split(new[] { ';', ':' });
                var artist = songInfo[0];
                var title = songInfo[1];
                var minutes = songInfo[2];
                var seconds = songInfo[3];

                try
                {
                    CheckIfDurationIsValid(minutes, seconds);
                    var song = new Song(artist, title, int.Parse(minutes), int.Parse(seconds));
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            long totalDuration = 0;
            foreach (var song in songs)
            {
                totalDuration += song.Minutes * 60 + song.Seconds;
            }
            long totalMinutes = totalDuration / 60;
            long totalSeconds = totalDuration % 60;
            long totalHours = totalMinutes / 60;
            totalMinutes %= 60;

            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine($"Playlist length: {totalHours}h {totalMinutes}m {totalSeconds}s");
        }

        public static void CheckIfDurationIsValid(string minutes, string seconds)
        {
            int parse;
            if (!int.TryParse(minutes, out parse) || !int.TryParse(seconds, out parse))
            {
                throw new InvalidSongLengthException();
            }
        }
    }
}
