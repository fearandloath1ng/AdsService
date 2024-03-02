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


## Бизнес-процессы
### Регистрация клиента
Клиент отправляет в сервис свою почту и пароль, 
сервис доверяет клиенту что он честно отправил свою почту и регистрирует его
и возвращает токен, который используется для авторизации.

### Аутентификация клиента или модератора
Клиент отправляет в сервис свою почту и пароль. 
Если данные совпадают с тем что сохранено, 
то он получает JWT токен, который используется для авторизации. 
Если не совпадает, получает ответ о том что аутентификация не пройдена.

### Создание поста
Клиент создаёт пост в виде json. В пост можно вставить 
один текстовый элемент и одну картинку, опционально. 
Картинка вставляется как ссылка на саму картинку. 
Всё это клиент отправляет в сервис вместе со своим JWT. 
Если с данными всё ок и JWT валиден, то создаётся пост 
со статусом "На проверке" от имени этого пользователя. 
Этот пост должен быть проверен модератором.
Если проверка пройдена, то пост получает статус "Проверка пройдена"
и его можно использовать для рекламной кампании.
Если проверка не пройдена или получен статус "Отклонено", то использовать
пост для создания рекламной кампании нельзя.
Редактировать посты нельзя.

### Проверка поста
Модератор получает весь список постов которые нужно промодерировать, 
просматривает каждый пост и выставляет каждому посту статус "Пройдено" 
или "Отклонено". При отклонении, он указывает причину отклонения.

### Пополнение баланса
Клиент обращается в сервис и говорит что он положил на счёт сколько-то рублей, 
а сервис ему просто верит, ведь у нас нет реальной платёжной системы.

### Запуск рекламной кампании
Клиент выбирает среди своих постов тот, на который он хочет запустить кампанию,
выбирает настройки кампании, в том числе её стоимость и длительность. 
Если у него достаточно денег на счету, а пост успешно прошёл модерацию, 
то кампания запускается. 
Кампания автоматически остановится после того как закончится её время.
После запуска кампании часть денег на счету пользователя блокируется
для оплаты кампании.

### Остановка рекламной кампании
Любую активную рекламную кампанию можно остановить до её самостоятельного 
завершения. В таком случае неизрасходованные деньги будут разблокированы,
а те что уже были потрачены будут списаны. 
После этого кампания прекратит свою работу. Перезапустить её нельзя

### Просмотр аналитики кампании
Клиент может посмотреть аналитику для любой кампании, 
которую он когда-либо запускал.

![diagram](https://github.com/AngryRectangle/AdsService/assets/95246399/cf694d5c-7c6e-4c81-b3e9-1eb90ba56f1e)
