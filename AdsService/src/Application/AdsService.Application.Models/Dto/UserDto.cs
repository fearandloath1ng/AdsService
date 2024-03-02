namespace AdsService.Application.Models.Dto;

public record UserDto(Guid Id, UserMail Mail, UserName Name, UserBalance Balance);