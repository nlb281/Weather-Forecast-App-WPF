
# 🌦️ Weather App

![Platform](https://img.shields.io/badge/Platform-Windows-0078D6?style=for-the-badge&logo=windows)
![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet)
![WPF](https://img.shields.io/badge/UI-WPF-0C54C2?style=for-the-badge)
![Architecture](https://img.shields.io/badge/Architecture-MVVM-FF6F61?style=for-the-badge)

Приложение для просмотра текущей погоды, разработанное на **C#** с использованием **WPF** и паттерна **MVVM**.

## 📌 О проекте

Приложение позволяет получать актуальную информацию о погоде по названию города.

### Основной функционал:
- поиск города;
- отображение температуры, влажности, давления и скорости ветра;
- добавление городов в избранное;
- сохранение последнего просмотренного города.

## 🌐 Используемые API

- **Geoapify API** — получение координат по названию города;
- **Yandex Weather API** — получение данных о погоде.

## 🖼️ Скриншоты

### Главное окно
<img width="586" height="793" alt="image" src="https://github.com/user-attachments/assets/f7b7b5b5-e73a-4aef-80b3-adb62b2f5445" />

### Избранные города
<img width="586" height="793" alt="image" src="https://github.com/user-attachments/assets/da8060af-dd67-4563-96a7-33228950dd59" />

## 🚀 Запуск проекта

1. Склонировать репозиторий:

```bash
git clone https://github.com/nlb281/Weather-Forecast-App-WPF.git
````

2. Открыть проект в **Visual Studio** или **Rider**.

3. Создать файл `.env` по пути \weatherApp\weatherApp\bin\Debug\net9.0-windows:

```env
GEOCODE_API_KEY=ваш_ключ_geoapify
WEATHER_API_KEY=ваш_ключ_yandex_weather
```

4. Запустить приложение.

## 📋 Требования

* **Windows 10 / 11**
* **.NET 9.0**
* подключение к интернету
