namespace Stations.DataProcessor.Dto
{
    public class TrainExportDto
    {
        public string TrainNumber { get; set; }

        public int DelayedTimes { get; set; }

        public string MaxDelayedTime { get; set; }
    }
}
