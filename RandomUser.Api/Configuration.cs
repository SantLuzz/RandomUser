namespace RandomUser.Api;

public static class Configuration
{
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 25;
    public const int DefaultStatusCode = 200;
    public const string DefaultNationality = "br";
    public const int DefaultQuantity = 15;
    public const string HttpRandonUserName = "randomUser";
    public const string CorsPolicyName = "testeApi";
    
    public static string ConnectionString { get; set; } = null!;
    public static string ApiUrl { get; set; } = null!;
    

}