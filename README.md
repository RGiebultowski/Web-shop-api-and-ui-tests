
# QA - Web UI & API Tests

Projekt testowy aplikacji **Saucedemo** oraz API **Reqres**


Projekt zawiera zestaw testów automatycznych dla aplikacji:

API tests – weryfikacja poprawności endpointów REST API (GET, POST)

UI tests – testy interfejsu użytkownika (logowanie, koszyk, proces zakupu) z wykorzystaniem Selenium WebDriver i wzorca Page Object Model (POM).
## Wymagania

```bash
  - .NET SDK 8.0+
  - NUnit
  - Google Chrome
  - ChromeDriver -> NuGet (Selenium.WebDriver.ChromeDriver)
  - NuGet DotNetSeleniumExtras.WaitHelpers
  - NuGet Selenium.WebDriver
  - NuGet Selenium.Support
  - NuGet RestSharp
```
    
## Przygotowanie Configs

Przed uruchomieniem testów należy utworzyć folder **Configs** z plikami  **apiconfig.json** oraz **webconfig.json**

```bash
  apiconfig.json
  {
    "ApiKey": "klucz-api",
    "BaseUrl": "url"
  }
```
```bash
  webconfig.json
  {
    "LoginURL": "url",
    "ValidUsername": "standard_user",
    "ValidPassword": "secret_sauce",
    "InvalidPassword": "12345",
    "InvalidUsername": "invalid_user",
    "InventoryEndpoint": "/inventory.html",
    "CartEndpoint": "/cart.html",
    "CheckoutEndpoint": "/checkout-step-one.html",
    "CheckoutTwoEndpoint": "/checkout-step-two.html",
    "CheckoutCompleteEndpoint": "/checkout-complete.html"
  }
```


## Uruchomienie Testów

Testy można uruchomić przez **Test Explorer**

Otwórz zakładkę **Test Explorer**

Kliknij **Run All Tests**
lub uruchom konkretny test


## RESULTS

![App Screenshot](./screenshots/report_summary.png)

