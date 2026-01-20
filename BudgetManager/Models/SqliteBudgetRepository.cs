using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace projekttest.Models
{
    public class SqliteBudgetRepository : IBudgetRepository
    {
        private readonly int _currentUserId;

        public SqliteBudgetRepository()
        {
            var user = GlobalData.CurrentUser;
            _currentUserId = user?.Id ?? 0;
            
            LoadFromDb();
        }

        private void LoadFromDb()
        {
            using (var context = new BudgetDbContext())
            {
                if (_currentUserId == 0) return;

                // Load Incomes
                GlobalData.AllIncomes.Clear();
                GlobalData.AllIncomes.AddRange(context.Incomes
                    .Where(x => x.UserId == _currentUserId)
                    .Include(x => x.Category)
                    .Include(x => x.Person)
                    .ToList());

                // Load Expenses
                GlobalData.AllExpenses.Clear();
                GlobalData.AllExpenses.AddRange(context.Expenses
                    .Where(x => x.UserId == _currentUserId)
                    .Include(x => x.Category)
                    .Include(x => x.Person)
                    .ToList());

                // Load Goals
                GlobalData.Goals.Clear();
                GlobalData.Goals.AddRange(context.SavingGoals
                    .Where(x => x.UserId == _currentUserId)
                    .ToList());

                // Load Categories
                var categories = context.Categories
                    .Where(x => x.UserId == _currentUserId)
                    .ToList();
                GlobalData.Categories.Clear();
                if (categories.Any())
                {
                    GlobalData.Categories.AddRange(categories);
                }
                else
                {
                   LoadDefaultCategories();
                }

                // Load People
                var people = context.People
                    .Where(x => x.UserId == _currentUserId)
                    .ToList();
                GlobalData.People.Clear();
                if (people.Any())
                {
                    GlobalData.People.AddRange(people);
                }
                else
                {
                    LoadDefaultPeople();
                }
            }
        }

        private void LoadDefaultCategories()
        {
             GlobalData.Categories.Add(new Category("Jedzenie", true));
             GlobalData.Categories.Add(new Category("Dom", true));
             GlobalData.Categories.Add(new Category("Transport", true));
             GlobalData.Categories.Add(new Category("Rozrywka", true));
             GlobalData.Categories.Add(new Category("Zdrowie", true));
             GlobalData.Categories.Add(new Category("Edukacja", true));
             GlobalData.Categories.Add(new Category("Inne", true));
        }

        private void LoadDefaultPeople()
        {
            GlobalData.People.Add(new Person("Tata"));
            GlobalData.People.Add(new Person("Mama"));
            GlobalData.People.Add(new Person("Syn"));
            GlobalData.People.Add(new Person("Córka"));
        }

        public List<Income> AllIncomes => GlobalData.AllIncomes;
        public List<Expense> AllExpenses => GlobalData.AllExpenses;
        public List<SavingGoal> Goals => GlobalData.Goals;
        public List<Category> Categories => GlobalData.Categories;
        public List<Person> People => GlobalData.People;

        public void Save()
        {
            if (_currentUserId == 0) return;

            using (var context = new BudgetDbContext())
            {
                // Sync Categories
                var dbCategories = context.Categories.Where(x => x.UserId == _currentUserId).ToList();
                var localCategories = GlobalData.Categories;
                
                // Remove deleted
                foreach (var dbItem in dbCategories)
                {
                    if (!localCategories.Any(l => l.Id == dbItem.Id && dbItem.Id != 0) && !localCategories.Any(l => l.Name == dbItem.Name)) 
                        context.Categories.Remove(dbItem);
                }

                // Add or Update
                foreach (var localItem in localCategories)
                {
                    localItem.UserId = _currentUserId;
                    
                    var existing = dbCategories.FirstOrDefault(d => d.Id == localItem.Id && localItem.Id != 0) 
                                   ?? dbCategories.FirstOrDefault(d => d.Name == localItem.Name);

                    if (existing != null)
                    {
                        existing.Name = localItem.Name;
                        existing.IsSystem = localItem.IsSystem;
                        // Map local ID back to ensure object consistency if needed
                        if (localItem.Id == 0) localItem.Id = existing.Id;
                    }
                    else
                    {
                        context.Categories.Add(localItem);
                    }
                }
                context.SaveChanges();

                // Sync People
                var dbPeople = context.People.Where(x => x.UserId == _currentUserId).ToList();
                var localPeople = GlobalData.People;
                
                foreach (var dbItem in dbPeople)
                {
                    if (!localPeople.Any(l => l.Name == dbItem.Name)) 
                        context.People.Remove(dbItem);
                }

                foreach (var localItem in localPeople)
                {
                    localItem.UserId = _currentUserId;
                    var existing = dbPeople.FirstOrDefault(d => d.Name == localItem.Name);
                    
                    if (existing != null)
                    {
                        if(localItem.Id == 0) localItem.Id = existing.Id;
                    }
                    else
                    {
                        context.People.Add(localItem);
                    }
                }
                context.SaveChanges();
                
                // Refetch dependencies to ensure they are attached for transactions
                var validCategories = context.Categories.Where(x => x.UserId == _currentUserId).ToList();
                var validPeople = context.People.Where(x => x.UserId == _currentUserId).ToList();

                // Sync Incomes
                var dbIncomes = context.Incomes.Where(x => x.UserId == _currentUserId).ToList();
                var localIncomes = GlobalData.AllIncomes;

                // Delete
                foreach(var dbItem in dbIncomes)
                {
                    if (!localIncomes.Any(l => l.Id == dbItem.Id)) 
                        context.Incomes.Remove(dbItem);
                }
                
                // Add/Update
                foreach(var localItem in localIncomes)
                {
                    localItem.UserId = _currentUserId;
                    
                    // Match dependency (Category/Person) by Name to valid DB entity
                    var cat = validCategories.FirstOrDefault(c => c.Name == localItem.Category.Name) ?? validCategories.FirstOrDefault(); 
                    var person = validPeople.FirstOrDefault(p => p.Name == localItem.Person.Name) ?? validPeople.FirstOrDefault();
                    
                    // If dependency missing, technically invalid state, but we attach null or default if possible.
                    // Or we let EF validation fail. 
                    
                    if (localItem.Id == 0)
                    {
                        // New
                        if(cat != null) localItem.Category = cat;
                        if(person != null) localItem.Person = person;
                        context.Incomes.Add(localItem);
                    }
                    else
                    {
                        var existing = dbIncomes.FirstOrDefault(e => e.Id == localItem.Id);
                        if (existing != null)
                        {
                            existing.Date = localItem.Date;
                            existing.Amount = localItem.Amount;
                            existing.Title = localItem.Source; // Map Source->Title
                            existing.isRecurring = localItem.isRecurring;
                            if(cat != null) existing.Category = cat;
                            if(person != null) existing.Person = person;
                        }
                    }
                }

                // Sync Expenses
                var dbExpenses = context.Expenses.Where(x => x.UserId == _currentUserId).ToList();
                var localExpenses = GlobalData.AllExpenses;

                foreach(var dbItem in dbExpenses)
                {
                    if (!localExpenses.Any(l => l.Id == dbItem.Id)) 
                        context.Expenses.Remove(dbItem);
                }

                foreach(var localItem in localExpenses)
                {
                    localItem.UserId = _currentUserId;
                    var cat = validCategories.FirstOrDefault(c => c.Name == localItem.Category.Name) ?? validCategories.FirstOrDefault(); 
                    var person = validPeople.FirstOrDefault(p => p.Name == localItem.Person.Name) ?? validPeople.FirstOrDefault();

                    if (localItem.Id == 0)
                    {
                        if(cat != null) localItem.Category = cat;
                        if(person != null) localItem.Person = person;
                        context.Expenses.Add(localItem);
                    }
                    else
                    {
                        var existing = dbExpenses.FirstOrDefault(e => e.Id == localItem.Id);
                        if (existing != null)
                        {
                            existing.Date = localItem.Date;
                            existing.Amount = localItem.Amount;
                            existing.Title = localItem.Description; // Map Desc->Title
                            existing.isRecurring = localItem.isRecurring;
                            if(cat != null) existing.Category = cat;
                            if(person != null) existing.Person = person;
                        }
                    }
                }

                // Sync Goals
                var dbGoals = context.SavingGoals.Where(x => x.UserId == _currentUserId).ToList();
                var localGoals = GlobalData.Goals;

                foreach(var dbItem in dbGoals)
                {
                    if (!localGoals.Any(l => l.Id == dbItem.Id)) 
                        context.SavingGoals.Remove(dbItem);
                }

                foreach(var localItem in localGoals)
                {
                    localItem.UserId = _currentUserId;
                    if (localItem.Id == 0)
                    {
                        context.SavingGoals.Add(localItem);
                    }
                    else
                    {
                        var existing = dbGoals.FirstOrDefault(e => e.Id == localItem.Id);
                        if (existing != null)
                        {
                            existing.Name = localItem.Name;
                            existing.TargetAmount = localItem.TargetAmount;
                            existing.CurrentAmount = localItem.CurrentAmount;
                        }
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
