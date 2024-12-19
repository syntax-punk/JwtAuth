using System.Collections;

namespace Contracts.Request;

public class TokenRequestDto
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<ClaimPair> CustomClaims { get; set; }
}

public class ClaimPair
{
    public string Key { get; set; }
    public object Value { get; set; }
}