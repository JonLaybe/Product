using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProducts.Model;

namespace WpfProducts.ViewModel
{
    public class ViewModelAddProduct : INotifyPropertyChanged
    {
        private Product product;
        private string _lines;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelAddProduct()
        {
            if (StaticProduct.product == null)
            {
                product = new Product();
                product.id = -1;
            }
            else
            {
                product = StaticProduct.product;
            }
        }

        private void RisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Name
        {
            get { return product.name; }
            set
            {
                product.name = value;
                RisePropertyChanged("Name");
            }
        }
        public int Price
        {
            get { return product.price; }
            set
            {
                product.price = value;
                RisePropertyChanged("Price");
            }
        }
        public string Description
        {
            get { return product.description; }
            set
            {
                product.description = value;
                RisePropertyChanged("Description");
            }
        }
        public string PhotoPath
        {
            get { return product.photo_path; }
            set
            {
                product.photo_path = value;
                RisePropertyChanged("PhotoPath");
            }
        }
        public string Lines
        {
            get { return _lines; }
            set
            {
                if (value != "0")
                {
                    _lines = "✔";
                }
                else
                {
                    _lines = "Error";
                }
                RisePropertyChanged("Lines");
            }
        }
        public ICommand AddClick
        {
            get
            {
                return new ButtonCommand(new Action(() => {
                    RequestsDatabase request = new RequestsDatabase();

                    if (product.id == -1)
                    {
                        Lines = (request.Insert(product)).ToString();
                    }
                    else
                    {
                        Lines = (request.Update(product)).ToString();
                    }
                }));
            }
        }
    }
}
