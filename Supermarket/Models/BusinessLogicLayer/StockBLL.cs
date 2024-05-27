using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.EntityLayer;

namespace Supermarket.Models.BusinessLogicLayer;

public class StockBLL:BasePropertyChanged
{
    private StockDAL StockDal { get; set; } = new();
    public void CheckStock(Tuple<string, int> obj)
    {
        EnoughStock = StockDal.CheckStock(obj.Item1, obj.Item2);
    }

    #region Fields

    private bool _enoughStock;

    public bool EnoughStock
    {
        get => _enoughStock;
        set
        {
            _enoughStock = value;
            NotifyPropertyChanged("SearchedText");
        }
    }

    #endregion
}