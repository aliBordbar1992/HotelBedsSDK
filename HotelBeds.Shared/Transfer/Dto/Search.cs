namespace HotelBeds.Shared.Transfer.Dto
{
    public class Search
    {
        public ComeBack ComeBack { get; set; }
        public ComeBack Departure { get; set; }
        public TransferPoint From { get; set; }
        public string Language { get; set; }
        public Occupancy Occupancy { get; set; }
        public TransferPoint To { get; set; }
    }
}