using System;


public static class DateTimeExtensions
{
    public static string FormatToSmartTimeSpan(this DateTime dateTime)
    {
        return DateTime.Now.Subtract(dateTime).ToFormattedString();
    }

    public static string FormatToSmartTimeSpan(this DateTime? dateTime)
    {
        return dateTime.HasValue ? dateTime.Value.FormatToSmartTimeSpan() : string.Empty;
    }

    public static string FormatToDateAndTime(this DateTime dateTime)
    {
        return dateTime.ToString("dd/MM/yyyy HH:mm");
    }

    public static string FormatToDateAndTime(this DateTime? dateTime)
    {
        return dateTime.HasValue ? dateTime.Value.FormatToDateAndTime() : string.Empty;
    }

    public static string FormatToDate(this DateTime date)
    {
        return date.ToString("dd/MM/yyyy");
    }

    public static string Date(DateTime? date)
    {
        return date == null
                ? string.Empty
                : date.Value.FormatToDate();
    }
}