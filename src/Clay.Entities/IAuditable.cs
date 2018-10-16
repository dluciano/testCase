using Clay.WebApi;

namespace Clay.Entities
{
    public interface IAuditable
    {
        Audit Audit { get; set; }
    }
}
