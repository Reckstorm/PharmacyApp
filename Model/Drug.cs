using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Model
{
    class Drug : BindableBase
    {
		private int id;

		public int Id
		{
			get { return id; }
			set 
			{ 
				id = value;
                RaisePropertyChanged(nameof(Id));
            }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set 
			{ 
				name = value;
                RaisePropertyChanged(nameof(Name));
            }
		}

        private string drugImgURL;

        public string DrugImgURL
        {
            get { return drugImgURL; }
            set
            {
                drugImgURL = value;
                RaisePropertyChanged(nameof(DrugImgURL));
            }
        }

		private string composition;

		public string Composition
        {
			get { return composition; }
			set 
			{ 
				composition = value; 
				RaisePropertyChanged(nameof(Composition));
			}
		}

		private Category category;

		public Category Category
        {
			get { return category; }
			set 
			{ 
				category = value; 
				RaisePropertyChanged(nameof(Category));
			}
		}


		private string briefDescription;

		public string BriefDescription
        {
			get { return briefDescription; }
			set 
			{ 
				briefDescription = value; 
				RaisePropertyChanged(nameof(BriefDescription));
			}
		}

		private string description;

		public string Description
        {
			get { return description; }
			set 
			{ 
				description = value; 
				RaisePropertyChanged(nameof(Description));
			}
		}

		public Drug()
        {
            id=0;
			name = string.Empty;
			drugImgURL = string.Empty;
			composition = string.Empty;
			briefDescription = string.Empty;
			description = string.Empty;
        }
    }
}
