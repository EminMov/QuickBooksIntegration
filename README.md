QuickBooks Integration App

Это веб-приложение на основе ASP.NET MVC для взаимодействия с QuickBooks Desktop с использованием QuickBooks SDK (QBFC). Приложение позволяет выполнять запросы к QuickBooks и отображать данные на веб-страницах в удобном формате.

Функционал

Поддерживаемые запросы:
Company Info
Получение информации о компании (название, юридический адрес, телефон и т.д.).
Invoices
Запрос списка счетов (Invoices).
Bills
Запрос списка счетов (Bills).
Checks
Запрос списка чеков (Checks).
Item Sales Tax
Получение информации о налогах с продаж.

Установка и настройка

Требования:
QuickBooks Desktop (любой версии, совместимой с SDK).
QuickBooks SDK (например, QBFC16).
Visual Studio 2022 или выше.
.NET Framework 4.8.

Использование

Запустите QuickBooks Desktop с открытой тестовой компанией.
Запустите приложение.

Перейдите на страницу в браузере:
/QuickBooks/QueryCompany – для информации о компании.
/QuickBooks/QueryInvoice – для списка счетов.
/QuickBooks/QueryBill – для списка счетов (Bills).
/QuickBooks/QueryCheck – для списка чеков.
/QuickBooks/QueryItemSalesTax – для списка налогов с продаж.

Пример результата:
![image](https://github.com/user-attachments/assets/94dff429-153c-4cb1-842f-cd2c81dc14db)
