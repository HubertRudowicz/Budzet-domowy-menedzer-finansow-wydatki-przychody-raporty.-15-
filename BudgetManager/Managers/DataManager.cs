using projekttest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace projekttest.Managers
{
    public static class DataManager
    {

        public static void ExportData()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Plik JSON (*.json)|*.json)";
            saveFileDialog.Title = "Eksportuj dane";
            saveFileDialog.FileName = $"Finanse_Backup_{DateTime.Now:yyyy-MM-dd}.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var dataToSave = new AppData
                    {
                        Incomes = GlobalData.AllIncomes,
                        Expenses = GlobalData.AllExpenses,
                        Categories = GlobalData.Categories,
                        People = GlobalData.People,
                        Goals = GlobalData.Goals
                    };

                    var options = new JsonSerializerOptions { WriteIndented = true };

                    string jsonString = JsonSerializer.Serialize(dataToSave, options);

                    File.WriteAllText(saveFileDialog.FileName, jsonString);

                    MessageBox.Show("Dane zostały pomyślnie wyeksportowane!", "Sukces!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas zapisu: \n {ex.Message}", "Błąd", MessageBoxButtons.OK , MessageBoxIcon.Error);
                }
            }
        }

        public static void ImportData()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Plik JSON (*.json)|*.json";
            openFileDialog.Title = "Importuj dane";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string jsonString = File.ReadAllText(openFileDialog.FileName);

                    var loadedData = JsonSerializer.Deserialize<AppData>(jsonString);

                    if (loadedData != null)
                    {
                        GlobalData.AllIncomes.Clear();
                        if (loadedData.Incomes != null) GlobalData.AllIncomes.AddRange(loadedData.Incomes);

                        GlobalData.AllExpenses.Clear();
                        if (loadedData.Expenses != null) GlobalData.AllExpenses.AddRange(loadedData.Expenses);

                        GlobalData.Categories.Clear();
                        if(loadedData.Categories != null) GlobalData.Categories.AddRange(loadedData.Categories);

                        GlobalData.People.Clear();
                        if (loadedData.People != null) GlobalData.People.AddRange(loadedData.People);

                        GlobalData.Goals.Clear();
                        if (loadedData.Goals != null) GlobalData.Goals.AddRange(loadedData.Goals);

                        MessageBox.Show("Dane zostały pomyślnie wczytane!", "Sukces!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił problem podczas odczytu: \n {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
