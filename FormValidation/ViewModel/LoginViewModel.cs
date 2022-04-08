using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace FormValidation.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _age;
        private bool _isValid;

        public string Name
        {
            get => _name;
            set 
            { 
                _name = value; 
                Validate();
            }
        }

        public string Age
        {
            get => _age;
            set 
            { 
                _age = value; 
                Validate(); 
            }
        }

        public bool IsValid 
        { 
          get => _isValid; 
          set
          {
              _isValid = value;
              OnPropertyChanged();
          }
        }

        public void Validate()
        {
            if(!string.IsNullOrEmpty(Name) && !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrEmpty(Age) && Enumerable.Range(20,40).Contains(int.Parse(Age)))
            {
                IsValid = true;
            }
            else
            {
                IsValid = false;
            }
        }


        # region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(sender: this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
