using System.Text.Json;
using Utilities.Contracts;

namespace Utilities
{
    public class TypeConverter : ITypeConverter
    {
        public byte[] ToByteArray<T>(T data)
        {
            return JsonSerializer.SerializeToUtf8Bytes(data);
        }
    }
}
