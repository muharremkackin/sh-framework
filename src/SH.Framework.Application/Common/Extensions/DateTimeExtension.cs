using System.Text.RegularExpressions;

namespace SH.Framework.Application.Common.Extensions;

public static partial class DateTimeExtension
{
    public static DateTime AddDuration(this DateTime dateTime, TimeSpan timeSpan)
    {
        return dateTime.Add(timeSpan);
    }

    public static DateTime SubDuration(this DateTime dateTime, TimeSpan timeSpan)
    {
        return dateTime.Subtract(timeSpan);
    }

    public static DateTime AddDuration(this DateTime dateTime, string pattern)
    {
        return Calculate(dateTime, pattern);
    }

    public static DateTime SubDuration(this DateTime dateTime, string pattern)
    {
        return Calculate(dateTime, pattern, Operation.Subtract);
    }

    private static DateTime Calculate(this DateTime dateTime, string pattern, Operation operation = Operation.Add)
    {
        if (string.IsNullOrWhiteSpace(pattern))
            throw new ArgumentException($"'{nameof(pattern)}' cannot be null or whitespace.", nameof(pattern));

        var regex = CalculationRegex();
        var matches = regex.Matches(pattern);

        foreach (Match match in matches)
        {
            if (!match.Success || match.Groups.Count != 3) continue;
            var value = int.Parse(match.Groups[1].Value);
            var unit = match.Groups[2].Value;

            dateTime = unit switch
            {
                "y" => operation == Operation.Add ? dateTime.AddYears(value) : dateTime.AddYears(-value),
                "m" => operation == Operation.Add ? dateTime.AddMonths(value) : dateTime.AddMonths(-value),
                "d" => operation == Operation.Add ? dateTime.AddDays(value) : dateTime.AddDays(-value),
                "h" => operation == Operation.Add ? dateTime.AddHours(value) : dateTime.AddHours(-value),
                "i" => operation == Operation.Add ? dateTime.AddMinutes(value) : dateTime.AddMinutes(-value),
                "s" => operation == Operation.Add ? dateTime.AddSeconds(value) : dateTime.AddSeconds(-value),
                _ => dateTime
            };
        }

        return dateTime;
    }

    [GeneratedRegex(@"(\d+)([ymdhis])")]
    private static partial Regex CalculationRegex();

    private enum Operation
    {
        Add,
        Subtract
    }
}