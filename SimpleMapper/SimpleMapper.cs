namespace SimpleMapper
{
    public class SimpleMapper : ISimpleMapper
    {
        private readonly Dictionary<Tuple<Type, Type>, Func<object, object>> _fromSourceTargetDictionary = [];
        private readonly Dictionary<Type, Func<object, object>> _fromSourceDictionary = [];
        private readonly SimpleMapperOptions _options;

        public SimpleMapper(SimpleMapperOptions? options)
        {
            _options = options ?? new SimpleMapperOptions();
        }

        public SimpleMapper() : this(null) { }

        public void Bind<TSource>(Func<TSource, object> bindFn)
            => _fromSourceDictionary.Add(typeof(TSource), CreateBinder(bindFn));

        public void Bind<TSource, TTarget>(Func<TSource, object> bindFn)
            => _fromSourceTargetDictionary.Add(Tuple.Create(typeof(TSource), typeof(TTarget)), CreateBinder(bindFn));

        public TTarget? Map<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class
        {
            try
            {
                if (FindMapperFn<TSource, TTarget>(out Func<object, object>? mapperFn))
                {
                    return (TTarget)mapperFn!(source);
                }
            }
            catch (Exception)
            {
                return HandlerError<TTarget>(new Exception("Unexpected error"));
            }
            return HandlerError<TTarget>(new NotSupportedException("Mapper function not found"));
        }

        private bool FindMapperFn<TSource, TTarget>(out Func<object, object>? mapperFn)
            where TSource : class
            where TTarget : class =>
            _fromSourceTargetDictionary.TryGetValue(Tuple.Create(typeof(TSource), typeof(TTarget)), out mapperFn)
            || _fromSourceDictionary.TryGetValue(typeof(TSource), out mapperFn);

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
