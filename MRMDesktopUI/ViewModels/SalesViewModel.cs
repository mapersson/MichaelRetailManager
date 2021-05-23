﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;

        public BindingList<string>  Products
        {
            get { return _products; }
            set { 
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<string> _itemQuantity;

        public  BindingList<string> ItemQuantity
        {
            get { return _itemQuantity; }
            set { 
                _itemQuantity = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public bool CanAddToCart
        {
            get
            {
                bool output = false;

                return output;
            }
        }

        public bool CanRemoveFromCart
        {
            get
            {
                return true;
            }
        }


        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set { 
                _cart = value;
                NotifyOfPropertyChange(() => Cart);            
            }
        }


        public string SubTotal
        {
            get { 
                //TODO: Replace with calculation.
                return "$0.00"; 
            }
            
        }


        public string Tax
        {
            get
            {
                //TODO: Replace with calculation.
                return "$0.00";
            }

        }


        public string Total
        {
            get
            {
                //TODO: Replace with calculation.
                return "$0.00";
            }

        }


        public void CheckOut()
        {

        }



    }
}