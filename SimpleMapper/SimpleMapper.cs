namespace SimpleMapper
{
    public class SimpleMapper : ISimpleMapper
    {
        private readonly Dictionary<Type, Func<object, object>> _mapperFunctions = [];
        private readonly SimpleMapperOptions _options;

        public SimpleMapper(SimpleMapperOptions? options)
        {
            _options = options ?? new SimpleMapperOptions();
        }

        public SimpleMapper() : this(null) { }

        public void Bind<TSource>(Func<TSource, object> bindFn)
            => _mapperFunctions.Add(typeof(TSource), CreateBinder(bindFn));

        public TTarget? Map<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class
        {
            try
            {
                if (_mapperFunctions.TryGetValue(typeof(TSource), out var mapperFn))
                {
                    return (TTarget)mapperFn(source);
                }
            }
            catch (Exception)
            {
                return HandlerError<TTarget>(new Exception("Unexpected error"));
            }
            return HandlerError<TTarget>(new NotSupportedException("Mapper function not found"));
        }

        private static Func<object, object> CreateBinder<TSource>(Func<TSource, object> bindFn)
            => (object o) => bindFn((TSource)o);

        private TTarget? HandlerError<TTarget>(Exception expection)
            where TTarget : class
        {
            if (_options.ExceptionHandling)
            {
                return default;
            }
            throw expection;
        }
    }
}
