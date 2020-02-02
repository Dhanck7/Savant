namespace Savant.Api.Services
{
    public interface IStringTypeParser
    {
        (DataType type, object value) FromString(string value, DataType heuristic = DataType.Unknown);
    }
}