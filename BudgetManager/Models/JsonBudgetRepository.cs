using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using projekttest.Models; // Ensure we are in the correct namespace

namespace projekttest.Models
{
    public class JsonBudgetRepository : IBudgetRepository
    {
        private readonly string _filePath;
        
        // Data containers
        public List<Income> AllIncomes { get; private set; } = new List<Income>();
        public List<Expense> AllExpenses { get; private set; } = new List<Expense>();
        public List<SavingGoal> Goals { get; private set; } = new List<SavingGoal>();
        public List<Category> Categories { get; private set; } = new List<Category>();
        public List<Person> People { get; private set; } = new List<Person>();

        public JsonBudgetRepository(string fileName = "budget_data.json")
        {
            // Save in MyDocuments to avoid permission issues
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _filePath = Path.Combine(docPath, fileName);
            
            Load();
        }

        public void Save()
        {
            var data = new BudgetDataWrapper
            {
                Incomes = AllIncomes,
                Expenses = AllExpenses,
                Goals = Goals,
                Categories = Categories,
                People = People
            };

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public void Load()
        {
            if (!File.Exists(_filePath))
            {
                InitializeDefaults();
                return;
            }

            try
            {
                string json = File.ReadAllText(_filePath);
                var data = JsonConvert.DeserializeObject<BudgetDataWrapper>(json);

                if (data != null)
                {
                    AllIncomes = data.Incomes ?? new List<Income>();
                    AllExpenses = data.Expenses ?? new List<Expense>();
                    Goals = data.Goals ?? new List<SavingGoal>();
                    Categories = data.Categories ?? new List<Category>();
                    People = data.People ?? new List<Person>();
                }
                else
                {
                    InitializeDefaults();
                }
            }
            catch (Exception)
            {
                // In case of corruption, load defaults (or handle error)
                InitializeDefaults();
            }
        }

        private void InitializeDefaults()
        {
            // Default categories and people if new file
            People = new List<Person>
            {
                new Person("Tata"), new Person("Mama"), new Person("Syn"), new Person("Córka")
            };

            Categories = new List<Category>
            {
                 new Category("Jedzenie", true),
                 new Category("Dom", true),
                 new Category("Transport", true),
                 new Category("Rozrywka", true),
                 new Category("Zdrowie", true),
                 new Category("Edukacja", true),
                 new Category("Inne", true)
            };
            
            AllIncomes = new List<Income>();
            AllExpenses = new List<Expense>();
            Goals = new List<SavingGoal>();
        }

        // Helper class for serialization
        private class BudgetDataWrapper
        {
            public List<Income> Incomes { get; set; }
            public List<Expense> Expenses { get; set; }
            public List<SavingGoal> Goals { get; set; }
            public List<Category> Categories { get; set; }
            public List<Person> People { get; set; }
        }
    }
}
