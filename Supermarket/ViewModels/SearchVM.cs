using System.Collections.ObjectModel;
using System.Windows.Input;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.ViewModels.Commands;

namespace Supermarket.ViewModels;

public class SearchVM: BasePropertyChanged
{
    public ProductBLL ProductBll = new();
    public SearchVM()
    {
    }

    #region DataMembers

    public string? SelectedSearchBy { get; set; } = "name";
    public ObservableCollection<string> ReturnedItems => ProductBll.FoundProducts;
    public ObservableCollection<string> ReturnedProductInfo => ProductBll.FoundProductInfo;
    #endregion

    #region Commnads

    private ICommand _searchCommand;

    public ICommand SearchCommand
    {
        get
        {
            if (_searchCommand == null)
            {
                _searchCommand = new RelayCommand<Tuple<string,string>>(ProductBll.SearchProducts);
            }
            return _searchCommand;
        }
    }

    private ICommand _getProductInfo;

    public ICommand GetProductInfo
    {
        get
        {
            if (_getProductInfo == null)
            {
                _getProductInfo = new RelayCommand<string>(ProductBll.GetProductInfo);
            }
            return _getProductInfo;
        }
    }

    #endregion


    #region Fields


    #endregion
}