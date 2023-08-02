namespace WpfApp.Configurations
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}
