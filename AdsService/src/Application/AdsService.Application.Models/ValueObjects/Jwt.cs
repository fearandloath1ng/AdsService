namespace AdsService.Application.Models.ValueObjects;

public struct Jwt
{
    private readonly string _jwt;

    public Jwt(string jwt)
    {
        _jwt = jwt;
    }
}