using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleMapper.Console
{
    internal class DateStringMapper : IClassMapper
    {
        public void Bind(ISimpleMapper mapper)
        {
            mapper.Bind<DateTime>((DateTime date) => date.ToString());
        }
    }
}
