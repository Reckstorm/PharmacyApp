using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using PharmacyApp.Model;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PharmacyApp.ViewModel
{
    class DrugsModel : BindableBase
    {
        public ObservableCollection<Drug> Drugs = new ObservableCollection<Drug>();
        public List<Category> Categories;
        private Drug selectedDrug;
        private Context _context;

        public Drug SelectedDrug
        {
            get { return selectedDrug; }
            set
            {
                selectedDrug = value;
                RaisePropertyChanged(nameof(SelectedDrug));
            }
        }

        public DrugsModel()
        {
            GetAssetList();
            SelectedDrug = Drugs[0];
        }

        public void GetAssetList()
        {
            if(Categories != null) Categories.Clear();
            Drugs.Clear();
            using (_context = new Context())
            {
                Categories = _context.Categories.ToList();
                foreach (Drug drug in _context.Drugs)
                {
                    Drugs.Add(drug);
                }
            }
        }

        public void AddCommand(Drug drug)
        {
            Drugs.Add(drug);
            SelectedDrug = drug;
        }

        public void RemoveCommand(Drug drug)
        {
            Drugs.Remove(drug);
            if (!drug.Id.Equals(0)) Remove(drug);
            SelectedDrug = Drugs[0];
        }

        public void SaveCommad(Drug drug)
        {
            if (drug.Id.Equals(null)) Add(drug);
            else Update(drug);
        }

        public void PickImageCommand()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                SelectedDrug.DrugImgURL = openFileDialog.FileName;
            }
        }

        public void DiscardCommad(Drug drug)
        {
            using (_context = new Context())
            {
                int t = Drugs.IndexOf(drug);
                Drug temp = _context.Drugs.Include(d => d.Category).ToList().FirstOrDefault(x => x.Id.Equals(drug.Id));
                Drugs[t] = temp;
                SelectedDrug = Drugs[t];
            }
        }

        public void SearchCommad(TextBox textBox)
        {
            string temp = textBox.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                Categories.Clear();
                Drugs.Clear(); 
                using (_context = new Context())
                {
                    Categories = _context.Categories.ToList();
                    foreach (Drug drug in _context.Drugs.Include(d => d.Category))
                    {
                        if (drug.Name.ToLower().Contains(temp) || drug.Category.CategoryName.ToLower().Contains(temp))
                        {
                            Drugs.Add(drug);
                        }
                    }
                }
            }
            else
            {
                GetAssetList();
            }
            if (Drugs.Count > 0) SelectedDrug = Drugs[0];
        }

        public void Add(Drug drug)
        {
            using (_context = new Context())
            {
                _context.Drugs.Add(drug);
                _context.SaveChanges();
            }
        }

        public void Update(Drug drug)
        {
            using (_context = new Context())
            {
                _context.Drugs.Update(drug);
                _context.SaveChanges();
            }
        }

        public void Remove(Drug drug)
        {
            using (_context = new Context())
            {
                _context.Drugs.Remove(drug);
                _context.SaveChanges();
            }
        }
    }
}
