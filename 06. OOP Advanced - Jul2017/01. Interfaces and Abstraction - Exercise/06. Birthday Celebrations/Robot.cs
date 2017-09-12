public class Robot : ISubject, ISubjectWithId
{
    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }

    public string Model { get; set; }

    public string Id { get; set; }
}