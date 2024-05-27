﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.ViewModels.Commands;

namespace Supermarket.ViewModels;

public class ReceiptVM:BasePropertyChanged
{
    public Dictionary<string, int> ProductList { get; set; } = [];
    private ProductBLL ProductBll { get; set; }
    public ObservableCollection<string> FoundItems => ProductBll.FoundProducts;
    private string CashierName { get; set; }
    public ReceiptVM()
    {
        ProductBll = new();
    }

    public ReceiptVM(string cashierName)
    {
        CashierName = cashierName;
        ProductBll = new(cashierName);
    }

    public void AddProductToList(string? productName, int quantity)
    {
        ProductList.Add(productName,quantity);
    }

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

    private ICommand _createReceipt;

    public ICommand CreateReceipt
    {
        get
        {
            if (_createReceipt == null)
            {
                _createReceipt = new RelayCommand<Dictionary<string,int>>(ProductBll.CreateReceipt);
            }
            return _createReceipt;
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