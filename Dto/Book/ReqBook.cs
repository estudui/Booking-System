namespace BookSystemApi.Dto.Book
{
    public class ReqBook
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
    }
}