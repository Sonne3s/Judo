namespace Judo.ViewModels.Interfaces
{
    public interface ICollapseModel<T, V>
    {
        T Head { get; set; }
        V Body { get; set; }
    }
}
