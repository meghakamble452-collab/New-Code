namespace NEXUS;

public class AuthServiceResponse
{
	public Claims_Token claims_token { get; set; }

	public string refresh_token { get; set; }
}
