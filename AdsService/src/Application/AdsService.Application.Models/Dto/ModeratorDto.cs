namespace AdsService.Application.Models.Dto;

public record ModeratorDto(Guid Id, UserMail Mail, PasswordHash Password);