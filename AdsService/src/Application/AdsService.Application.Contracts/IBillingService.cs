namespace AdsService.Application.Contracts;

using AdsService.Application.Models.ValueObjects;

public interface IBillingService
{
    void TopUpBalance(Jwt jwt, Money amount);
}