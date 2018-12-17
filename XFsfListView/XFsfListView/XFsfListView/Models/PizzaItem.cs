using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFsfListView.Models
{
    public class PizzaItem : BindableBase
    {

        #region Name Property
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        #endregion

        #region Description Property
        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }
        #endregion

        #region Price Property
        private int _Price;
        public int Price
        {
            get { return _Price; }
            set { SetProperty(ref _Price, value); }
        }
        #endregion

        #region PizzaImage Property
        private string _PizzaImage;
        public string PizzaImage
        {
            get { return _PizzaImage; }
            set { SetProperty(ref _PizzaImage, value); }
        }
        #endregion

        #region DragIndicator Property
        private string _DragIndicator;
        public string DragIndicator
        {
            get { return _DragIndicator; }
            set { SetProperty(ref _DragIndicator, value); }
        }
        #endregion

    }
}
