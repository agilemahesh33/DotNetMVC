namespace EMPDEPTPROJECT.Interfaces
{
    public interface IFactory
    {
        IRepository<T> GetRepository<T>() where T : class;
    }

}
