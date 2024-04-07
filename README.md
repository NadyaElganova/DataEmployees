Приложение разработано с использованием архитектуры MVC .NET. Контроллеры отвечают за обработку запросов пользователя и взаимодействие с моделью данных. Представления отображают данные пользователю, а модель представляет собой структуру данных и бизнес-логику приложения.

Примечания

Резервная копия базы данных.
К проекту приложена резервная копия базы данных в файле с расширением .bak. 
В случае необходимости восстановления данных из резервной копии, следуйте инструкциям ниже:
1. Создайте новую базу данных на вашем сервере SQL Server.
2. Восстановите данные из резервной копии базы данных, используя инструменты администрирования SQL Server.
3. Убедитесь, что строка подключения к базе данных в приложении указывает на восстановленную базу данных.

Файлы для тестирования.
Для тестирования импорта данных в базу данных в проект были загружены файлы в формате CSV. Эти файлы содержат тестовые данные, которые могут быть использованы для проверки функциональности импорта. Перед использованием убедитесь, что данные в файлах соответствуют требованиям приложения.
Формат данных в файлах CSV:
- Файл employees.csv содержит информацию о сотрудниках в следующем формате: Имя,Фамилия,Серия паспорта,Номер паспорта,Дата рождения,Идентификатор организации.
Обратите внимание, Дата рождения представлена в формате: yyyy-MM-dd HH:mm:ss.fffffff
- Файл organizations.csv содержит информацию об организациях в следующем формате: Название,ИНН,Юридический адрес,Фактический адрес.
