namespace Contracts.Request;

public class TokenRequestDto
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<PairClaim> CustomClaims { get; set; }
}

public class PairClaim : Dictionary<string, object>
{
    public string Key
    {
        get => this.Keys.FirstOrDefault()!; 
        set => this.Add(value, this.Value);
    }

    public object Value
    {
        get => this.Values.FirstOrDefault()!; 
        set => this.Add(this.Key, value);
    }
}