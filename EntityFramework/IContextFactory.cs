namespace Hospital.EntityFramework
{
    public interface IContextFactory
    {
        Context CreateContext();
    }
}
