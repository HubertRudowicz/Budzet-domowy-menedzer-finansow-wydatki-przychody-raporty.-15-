# Diagram UML i Model Obiektowy

## Diagram Klas (UML)

```mermaid
classDiagram
    class GlobalData {
        +static List~Income~ AllIncomes
        +static List~Expense~ AllExpenses
        +static List~SavingGoal~ Goals
        +static List~Category~ Categories
        +static List~Person~ People
        +static User CurrentUser
    }

    class FinanceManager {
        -IBudgetRepository _repository
        +FinanceManager()
        +FinanceManager(IBudgetRepository repository)
        +void SaveData()
        +void LoadTestData()
        +int ProcessRecurringTransactions()
        +bool TryDeletePerson(string personName, out string errorMessage)
        +bool TryDeleteCategory(string categoryName, out string errorMessage)
        +List~Transaction~ GetRecentTransactions(int count, TimePeriod period)
        +decimal GetCurrentBalance(TimePeriod period)
        +List~T~ GetFilteredList~T~(List~T~ list, TimePeriod period)
        +void AddTransaction(Transaction transaction)
        +void DeleteTransaction(Transaction transaction)
        +void AddGoal(SavingGoal goal)
        +void DeleteGoal(SavingGoal goal)
        +int GetPersonTransactionCount(string personName)
        +int GetCategoryUsageCount(string categoryName)
        +void DeletePersonWithHistory(string personName)
        +void DeleteCategoryAndMigrate(string oldCategory, string newCategory)
        -int ProcessList~T~(...)
        -DateTime CalculateTargetDate(DateTime today, DateTime originalDate)
        -DateTime GetStartDate(TimePeriod period)
    }

    class IBudgetRepository {
        <<interface>>
        +List~Income~ AllIncomes
        +List~Expense~ AllExpenses
        +List~SavingGoal~ Goals
        +List~Category~ Categories
        +List~Person~ People
        +void Save()
    }

    class SqliteBudgetRepository {
        -int _currentUserId
        +SqliteBudgetRepository()
        +void Save()
        -void LoadFromDb()
        -void LoadDefaultCategories()
        -void LoadDefaultPeople()
    }
    
    class JsonBudgetRepository {
        +JsonBudgetRepository()
        +void Save()
    }

    class Transaction {
        <<abstract>>
        +int Id
        +DateTime Date
        +decimal Amount
        +Category Category
        +Person Person
        +bool isRecurring
        +int UserId
        +virtual string Title
        +static decimal operator +(Transaction a, Transaction b)
    }

    class Income {
        +string Source
        +Income()
        +Income(...)
        +string GetCSVFormat()
    }

    class Expense {
        +string Description
        +Expense()
        +Expense(...)
        +string GetCSVFormat()
    }

    class IExportable {
        <<interface>>
        +string GetCSVFormat()
    }

    class Category {
        +int Id
        +int UserId
        +string Name
        +bool IsSystem
        +Category(string name, bool isSystem)
    }

    class Person {
        +int Id
        +int UserId
        +string Name
        +Person(string name)
    }

    class SavingGoal {
        +int Id
        +int UserId
        +string Name
        +decimal TargetAmount
        +decimal CurrentAmount
        +int ProgressPercentage
        +string StatusText
    }

    class User {
        +int Id
        +string Username
        +string PasswordHash
    }

    class IAuthService {
        <<interface>>
        +bool Register(string username, string password, out string errorMessage)
        +User? Login(string username, string password)
        +void Logout()
        +User? CurrentUser
    }

    class AuthService {
        -BudgetDbContext _context
        +User? CurrentUser
        +AuthService(BudgetDbContext context)
        +bool Register(string username, string password, out string errorMessage)
        +User? Login(string username, string password)
        +void Logout()
        -string HashPassword(string password)
    }

    Transaction <|-- Income
    Transaction <|-- Expense
    IExportable <|.. Income
    IExportable <|.. Expense
    IBudgetRepository <|.. SqliteBudgetRepository
    IBudgetRepository <|.. JsonBudgetRepository
    FinanceManager --> IBudgetRepository : uses
    Transaction --> Category : has
    Transaction --> Person : has
    IAuthService <|.. AuthService
    AuthService --> User : uses
    FinanceManager ..> User : references via GlobalData
```

## Model Obiektowy - Analiza (Rozszerzona)

Projekt jest zbudowany zgodnie z zasadami programowania obiektowego (OOP), co zapewnia jego czytelność, łatwość w utrzymaniu i rozbudowie.

### 1. Dziedziczenie (Inheritance)
Klasa `Transaction` stanowi fundament dla wszystkich operacji finansowych.
- `Income` (przychód) i `Expense` (wydatek) dziedziczą po klasie `Transaction`.
- Pozwala to na współdzielenie kodu (np. właściwości `Date`, `Amount`) oraz polimorficzne traktowanie różnych typów transakcji w listach (np. w metodzie `GetRecentTransactions`).

### 2. Abstrakcja (Abstraction)
- **Klasa abstrakcyjna `Transaction`**: Nie można utworzyć samego obiektu "Transakcja" – musi to być konkretnie Przychód lub Wydatek. Wymusza to precyzję w modelu danych.
- **Interfejsy (`IBudgetRepository`, `IExportable`, `IAuthService`)**: Definiują kontrakt, czyli "co" klasa ma robić, ale nie "jak".
    - `IBudgetRepository`: Pozwala na łatwą zmianę sposobu zapisu danych (np. plik JSON vs baza SQLite) bez konieczności zmian w logice `FinanceManager`.
    - `IAuthService`: Oddziela logikę uwierzytelniania od reszty aplikacji.

### 3. Hermetyzacja (Encapsulation)
- Wszystkie pola danych w klasach (np. `Amount` w `Transaction`, `PasswordHash` w `User`) są ukryte za właściwościami publicznymi (Properties).
- Wewnętrzne metody pomocnicze w `FinanceManager` (np. `ProcessList`, `GenerateExpenseId`) są prywatne (`private`), co ukrywa skomplikowaną logikę przed światem zewnętrznym.
- Dostęp do bazy danych jest schowany w Repozytoriach (`SqliteBudgetRepository`), dzięki czemu warstwa prezentacji (Formularze) nie musi wiedzieć nic o SQL.

### 4. Polimorfizm (Polymorphism)
- Metoda `GetCSVFormat` z interfejsu `IExportable` działa inaczej dla `Income` (zapisuje źródło) i dla `Expense` (zapisuje opis), ale wywoływana jest w ten sam sposób.
- Użycie `List<Transaction>` w `FinanceManager` pozwala przechowywać na jednej liście oba typy obiektów.

### 5. Elementy Statyczne i Helpery
- Klasa `AppConstants` przechowuje stałe systemowe (np. nazwy kategorii).
- Metoda statyczna operatora `+` w `Transaction` pozwala na eleganckie sumowanie transakcji w kodzie: `suma = transakcja1 + transakcja2`.

### 6. Relacje
- **Kompozycja**: Obiekt `Transaction` zawiera obiekty `Category` i `Person`. Są one niezbędne do istnienia pełnej transakcji.
- **Asocjacja**: `FinanceManager` korzysta z `IBudgetRepository`.
