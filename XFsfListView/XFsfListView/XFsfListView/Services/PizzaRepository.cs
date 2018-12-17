using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XFsfListView.Models;

namespace XFsfListView.Services
{
    public class PizzaRepository
    {
        public ObservableCollection<PizzaItem> myItemList { get; set; } = new ObservableCollection<PizzaItem>();

        public ObservableCollection<PizzaItem> Get(int cycle)
        {
            Random random = new Random();
            myItemList.Clear();
            for (int i = 0; i < 18; i++)
            {
                myItemList.Add(new PizzaItem()
                {
                    Name = $"{cycle} Pizza{i}",
                    Description = $"{cycle} Pizza{i}",
                    PizzaImage = $@"XFsfListView.Images.Pizza{i}.jpg",
                    DragIndicator = $@"XFsfListView.Images.DragIndicator.png",
                    Price = random.Next(50,300)
                });
            }
            return myItemList;
        }
    }
}
