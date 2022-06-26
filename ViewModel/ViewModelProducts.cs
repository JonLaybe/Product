using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProducts.Model;
using WpfProducts.View;

namespace WpfProducts.ViewModel
{
    public class ViewModelProducts : INotifyPropertyChanged
    {
        private RequestsDatabase requests;
        private List<Product> list_products;
        private Product product;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelProducts()
        {
            requests = new RequestsDatabase();
            ListProducts = requests.Select();
        }

        private void RisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public List<Product> ListProducts
        {
            get { return list_products; }
            set
            {
                list_products = value;
                RisePropertyChanged("ListProducts");
            }
        }
        public Product SelectProduct
        {
            get { return product; }
            set
            {
                product = value;
                RisePropertyChanged("SelectProduct");
            }
        }
        public ICommand AddProductClick
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    AddProduct addProduct = new AddProduct();
                    addProduct.ShowDialog();
                    ListProducts = requests.Select();
                }));
            }
        }
        public ICommand ChangeClike
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    StaticProduct.product = product;
                    AddProduct addProduct = new AddProduct();
                    addProduct.ShowDialog();
                    StaticProduct.product = null;
                }));
            }
        }
        public ICommand DeleteProductClick
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    requests.Delete(product);
                    ListProducts = requests.Select();
                }));
            }
        }
    }
}
