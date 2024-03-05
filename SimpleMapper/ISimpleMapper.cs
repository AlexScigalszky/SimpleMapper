namespace SimpleMapper
{
    public interface ISimpleMapper
    {
        void Bind<TSource>(Func<TSource, object> bindFn);
        
        void Bind<TSource, TTarget>(Func<TSource, object> bindFn);

        TTarget? Map<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class;
    }
}
