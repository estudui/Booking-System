namespace BookSystemApi.Dto.Book
{
    public class ReqBookJson
    {
        public int Room_Id { get; set; }
        public string Start_Time { get; set; } = string.Empty;
        public string End_Time { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
    }
}