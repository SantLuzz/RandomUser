namespace RandomUser.Api.Data.Models.UsersExternals;

public class Name
{
    public string? Title { get; set; }
    public string? First { get; set; }
    public string? Last { get; set; }

    public override string ToString()
        => $"{First} {Last}";
}