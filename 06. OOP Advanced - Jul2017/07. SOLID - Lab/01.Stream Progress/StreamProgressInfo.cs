namespace _01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamable streamableFile;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamable streamableFile)
        {
            this.streamableFile = streamableFile;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamableFile.BytesSent * 100) / this.streamableFile.Length;
        }
    }
}