namespace SimpleMapper
{
    public interface ISimpleMapper
    {
        void Bind<TSource>(Func<TSource, object> bindFn);
    }
}
