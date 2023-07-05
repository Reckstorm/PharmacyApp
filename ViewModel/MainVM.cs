using Prism.Commands;
using Prism.Mvvm;
using PharmacyApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PharmacyApp.ViewModel
{
    class MainVM : BindableBase
    {
        readonly DrugsModel _model = new DrugsModel();
        private Drug selectedDrug;
        public MainVM()
        {
            _model.PropertyChanged += (s, e) => RaisePropertyChanged(e.PropertyName);
            AddCommand = new DelegateCommand(() =>
            {
                _model.AddCommand(new Drug());
            });
            FocusCommand = new DelegateCommand<TextBox>(tb =>
            {
                tb.Focus();
            });
            RemoveCommand = new DelegateCommand<Drug>(drug =>
            {
                _model.RemoveCommand(drug);
            });
            SaveCommand = new DelegateCommand<Drug>(drug =>
            {
                if (drug == null) return;
                if (drug.Name.Equals(string.Empty) ||
                    //drug.DrugImgURL.Equals(string.Empty) ||
                    drug.Composition.Equals(string.Empty) ||
                    drug.BriefDescription.Equals(string.Empty) ||
                    drug.Description.Equals(string.Empty)
                ) return;
                else _model.SaveCommad(drug);
            });
            DiscardCommand = new DelegateCommand<Drug>(drug =>
            {
                _model.DiscardCommad(drug);
            });
            SearchCommand = new DelegateCommand<TextBox>(tb =>
            {
                _model.SearchCommad(tb);
                RaisePropertyChanged(nameof(Drugs));
                RaisePropertyChanged(nameof(Categories));
            });
            PickImageCommand = new DelegateCommand(() =>
            {
                _model.PickImageCommand();
            });
        }
        public DelegateCommand AddCommand { get; }
        public DelegateCommand PickImageCommand { get; }
        public DelegateCommand<TextBox> FocusCommand { get; }
        public DelegateCommand<Drug> RemoveCommand { get; }
        public DelegateCommand<Drug> SaveCommand { get; }
        public DelegateCommand<Drug> DiscardCommand { get; }
        public DelegateCommand<TextBox> SearchCommand { get; }
        public ObservableCollection<Drug> Drugs => _model.Drugs;
        public List<Category> Categories => _model.Categories;
        public Drug SelectedDrug
        {
            get { return _model.SelectedDrug; }
            set { _model.SelectedDrug = value; }
        }
    }
}
