namespace BookSystemApi.Entities
{
    public class Rooms
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool Is_Active { get; set; } = true;
    }
}