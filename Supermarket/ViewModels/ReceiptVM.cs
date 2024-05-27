using System.Collections.ObjectModel;
using System.Windows.Input;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.ViewModels.Commands;

namespace Supermarket.ViewModels;

public class ReceiptVM:BasePropertyChanged
{
    private ObservableCollection<Tuple<string,int>> ProductQuantity { get; set; }
    private ProductBLL ProductBll { get; set; } = new();
    public ObservableCollection<string> FoundItems => ProductBll.FoundProducts;

    #region Commands

    private ICommand _searchItems;

    public ICommand SearchItems
    {
        get
        {
            if (_searchItems == null)
            {
                _searchItems = new RelayCommand<string>(ProductBll.SearchProducts);
            }
            return _searchItems;
        }
    }

    private ICommand _checkStock;

    public ICommand CheckStock
    {
        get
        {
            if (_checkStock == null)
            {
                _checkStock = new RelayCommand<Tuple<string,int>>(ProductBll.CheckStock);
            }
            return _checkStock;
        }
    }


    #endregion


    #region Fields

    public string? SearchedText
    {
        get=>ProductBll.SearchedText;
        set
        {
            ProductBll.SearchedText = value;
            NotifyPropertyChanged("SearchedText");
        }
    }

    public bool EnoughStock => ProductBll.EnoughStock;

    #endregion
}