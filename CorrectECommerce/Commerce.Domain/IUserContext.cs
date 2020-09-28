namespace Commerce.Domain
{
    public interface IUserContext
    {
        bool IsInRole(Role role);
    }
}