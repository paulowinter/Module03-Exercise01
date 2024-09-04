using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module02Exercise01.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace Module02Exercise01.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private Employee _employee;

        private string _fullName;

        public EmployeeViewModel()
        {
            //Initialize a sample employee model. Coordination with model
            _employee = new Employee { FirstName = "Aeri", LastName = "Uchinaga", Position = "Manager", Department = "IT Department", IsActive = true};
            
            LoadManagerDataCommand = new Command(async () => await LoadManagerDataAsync());

            // Collections
            Employees = new ObservableCollection<Employee>
            {
                new Employee {FirstName="Jimin", LastName="Yu", Position ="Data analyst", Department = "Data Science Department", IsActive = true},
                new Employee {FirstName="Min-jeong", LastName="Kim", Position ="Developer", Department = "IT Department", IsActive = true},
                new Employee {FirstName="Ning", LastName="Yizhuo", Position ="Quality Assurance", Department = "Quality Control Department", IsActive = true}
            };
        }

        public ObservableCollection<Employee> Employees { get; set; }

        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;

                    OnPropertyChanged(nameof(FullName));

                }
            }
        }

        public ICommand LoadManagerDataCommand { get; }

        private async Task LoadManagerDataAsync()
        {
            await Task.Delay(1000); // I/O operation
            FullName = $"{_employee.FirstName} {_employee.LastName}" + $" | " + $"Position: " + $"{_employee.Position}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
