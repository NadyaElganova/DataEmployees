Описание:

Приложение "Управление сотрудниками и организациями" предназначено для хранения информации о сотрудниках и организациях, а также обеспечивает возможность экспорта и импорта данных в формате CSV. Пользователи могут добавлять новых сотрудников и организации в базу данных через интерфейс приложения. 

Технологии:

- Для разработки приложения используется язык программирования C# и фреймворк ASP.NET MVC для создания веб-приложения.
- Для хранения данных используется реляционная база данных, такая как SQL Server, с использованием Entity Framework для работы с базой данных.
- При создании базы данных использовался подход Code-First. 
- Веб-интерфейс разрабатывается с использованием HTML, CSS и JavaScript для обеспечения удобного пользовательского опыта.

Примечания:

К проекту приложен скрипт создания и первоначального заполнения базы данных в формате .sql.

Также к проекту приложена резервная копия базы данных в файле с расширением .bak. 
В случае необходимости восстановления данных из резервной копии, следуйте инструкциям ниже:
1. Создайте новую базу данных на вашем сервере SQL Server.
2. Восстановите данные из резервной копии базы данных, используя инструменты администрирования SQL Server.
3. Убедитесь, что строка подключения к базе данных в приложении указывает на восстановленную базу данных.

Для тестирования импорта данных в базу данных в проект были загружены файлы в формате CSV. Эти файлы содержат тестовые данные, которые могут быть использованы для проверки функциональности импорта. Перед использованием убедитесь, что данные в файлах соответствуют требованиям приложения.
Формат данных в файлах CSV:
- Файл employees.csv содержит информацию о сотрудниках в следующем формате: Имя,Фамилия,Серия паспорта,Номер паспорта,Дата рождения,Идентификатор организации.
Обратите внимание, Дата рождения представлена в формате: yyyy-MM-dd HH:mm:ss.fffffff
- Файл organizations.csv содержит информацию об организациях в следующем формате: Название,ИНН,Юридический адрес,Фактический адрес.
