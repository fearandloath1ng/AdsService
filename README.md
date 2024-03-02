## Команда №28 - "Сервис для создания рекламы в инстаграме и телеграме"

## Состав команды:
- Кахикало Кирилл Романович
- Бинов Даниил Евгеньевич
- Заблудовский Даниил Павлович
- Шишкина Анна Станиславовна
- Яковлева Таисия Данииловна
- Манукян Даниил Алексеевич

## Доменные сущности:
```
{
  "User": {
    "Id": ["guid", "not null", "length<30", "unique"],
    "Mail": ["string", "length<30"],
    "Name": ["string", "length<30"],
    "Balance": ["decimal", "balance>0"]
  },
  "Post": {
    "Id": ["guid", "not null", "length<30", "unique"],
    "UserId": ["guid", "not null", "length<30", "unique"],
    "Content": ["string", "length<500"],
    "ModerationStatus": ["string"]
  },
  "Moderator": {
    "Id": ["guid", "not null", "length<30", "unique"],
    "Mail": ["string", "length<30"],
    "Password": ["string", "length<30"]
  }
  "AdCampaign": {
    "Id": ["guid", "not null", "length<30", "unique"],
    "PostId": ["guid", "not null", "length<30", "unique"],
    "UserId": ["guid", "not null", "length<30", "unique"],
    "Cost": ["decimal", "balance>0"],
    "Duration": ["timespan"],
    "IsActive": ["bool"]
  },
  "Check": {
    "Id": ["guid", "not null", "length<30", "unique"],
    "ModeratorId": ["guid", "not null", "length<30", "unique"],
    "PostId": ["guid", "not null", "length<30", "unique"],
    "Result": ["bool"],
    "Reason": ["string", "length<100"]
  }
}
```

Регистрация клиента - `POST api/v1/users/registration`  
request - `{"userMail": "vasyavasin@gmail.com", "PasswordHash": "VerySafePassword1234!"}`  
response - `{"codeAnswer": "12345"}`

Проверка регистрации - `POST api/v1/users/code-check`  
request - `{"codeAnswer": "12345"}`  
response - `{"message": "You've successfully registered."}`

Аутентификация клиента - `POST api/v1/users/authentication`  
request - `{"userMail": "vasyavasin@gmail.com", "PasswordHash": "VerySafePassword1234!"}`  
response - `{"token": "xxxxx.yyyyy.zzzzz"}`

Создание поста - `POST api/v1/posts/create`  
request - `{"text": "blablabla", "picture": "imageUrl", "token": "xxxxx.yyyyy.zzzzz"}`  
response - `{"message": "The post is successfully created."}`

Проверка поста - `POST api/v1/posts/{postId}/list`  
request - `{"postId": "123abc"}`  
response - `{"message": "post approved"}`

Пополнение баланса - `POST api/v1/balance/replenish`  
request - `{"token": "xxxxx.yyyyy.zzzzz", "amount":100.00}`  
response - `{"message":"Balance successfully replenished."}`

Запуск рекламной кампании - `POST api/v1/ad-campaigns/start`  
request - `{"token": "xxxxx.yyyyy.zzzzz", "postId":"123cde", "price": 50.00, "duration": "24:00:00"}`  
response - `{"compaignId":"4w5l6jn4wlk5j6nw4lk56"}`

Остановка рекламной кампании - `POST api/v1/ad-campaigns/stop`  
request - `{"token": "xxxxx.yyyyy.zzzzz", "campaignId":"4w5l6jn4wlk5j6nw4lk56"}`  
response - `{"message":"Ad campaign successfully stopped."}`

Просмотр аналитики кампании - `GET api/v1/ad-campaigns/{campaignId}/analytics`
response - `{"campaignId": "4w5l6jn4wlk5j6nw4lk56", "views": 1000, "clicks": 500, "conversions": 50}`

