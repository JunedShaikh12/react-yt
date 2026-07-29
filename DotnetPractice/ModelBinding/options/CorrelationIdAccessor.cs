namespace ModelBinding.options
{
    public class CorrelationIdAccessor : ICorrelationIdAccessor
    {
        public string getCorrelationId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
