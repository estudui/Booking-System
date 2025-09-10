namespace BookSystemApi.Dto.Room
{
    public class ReqRoom
    {
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}