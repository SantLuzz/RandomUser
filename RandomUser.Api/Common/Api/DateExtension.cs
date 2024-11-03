namespace RandomUser.Api.Common.Api;

public static class DateExtension
{
    private static TimeZoneInfo _localTimeZone = TimeZoneInfo.Local;
    public static DateTime ConvertDateFromUtc(this DateTime dateTime)
        => TimeZoneInfo.ConvertTimeFromUtc(dateTime, _localTimeZone);
    
    public static DateTime? ConvertDateFromUtc(this DateTime? dateTime)
        => TimeZoneInfo.ConvertTimeFromUtc(dateTime.HasValue 
            ? dateTime.Value 
            : DateTime.Now, 
            _localTimeZone);
}