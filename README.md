# VerstaTestTask startup instructions

Тестовое задание для компании "Верста".

## Требования

Перед запуском проекта убедитесь, что у вас установлены следующие компоненты:

- [ASP.NET Core SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/)
- [MS SQL Server](https://www.microsoft.com/sql-server/)

## Установка

1. Склонируйте репозиторий на локальную машину:

    ```bash
    git clone https://github.com/Shmonyajik/VerstaTestTask.git
    ```

2. Перейдите в каталог проекта:

    ```bash
    cd ваш-репозиторий
    ```

3. Откройте проект в Visual Studio.

4. В Visual Studio откройте файл `appsettings.json` и настройте строку подключения к базе данных MS SQL:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=ваш_сервер;Database=ваша_бд;User Id=ваш_пользователь;Password=ваш_пароль;"
      },
      // Другие настройки...
    }
    ```

    Замените `ваш_сервер`, `ваша_бд`, `ваш_пользователь` и `ваш_пароль` на соответствующие значения для вашей базы данных.

5. Запустите проект:

    В Visual Studio выберите `Debug` -> `Start Debugging` или просто нажмите `F5`. Это автоматически восстановит зависимости, скомпилирует и запустит приложение.

## Использование

После успешного запуска приложения вы можете перейти по следующим путям в вашем браузере:
- список заказов: http://localhost:5047/
- создание заказа: http://localhost:5047/Home/CreateOrder
- проспотр заказа: http://localhost:5047/Home/OrderDetails/1

