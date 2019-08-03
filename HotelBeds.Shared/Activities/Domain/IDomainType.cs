namespace HotelBeds.Shared.Activities.Domain
{
    public interface IDomainType
    {
        IDomainType Default { get; }
        string GetCode();
    }
}