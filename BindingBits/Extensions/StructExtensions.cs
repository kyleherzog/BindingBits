namespace BindingBits.Extensions
{
    internal static class StructExtensions
    {
        internal static bool IsDefault<T>(this T value)
            where T : struct
        {
            return value.Equals(default(T));
        }
    }
}
