namespace Utilities.Contracts
{
    public interface ITypeConverter
    {
        byte[] ToByteArray<T>(T data);
    }
}
