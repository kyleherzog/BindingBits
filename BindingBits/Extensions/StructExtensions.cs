namespace BindingBits.Extensions;

/// <summary>
/// Provides extension methods for structs.
/// </summary>
public static class StructExtensions
{
    /// <summary>
    /// Checks to see if a given struct value is the default value of the struct.
    /// </summary>
    /// <typeparam name="T">The struct <see cref="Type"/>.</typeparam>
    /// <param name="value">The value to compare against the default struct value.</param>
    /// <returns><c>true</c> if the value is the default value of the struct, otherwise <c>false</c>.</returns>
    public static bool IsDefault<T>(this T value)
        where T : struct
    {
        return value.Equals(default(T));
    }
}