using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Database.Query;


namespace XFFirebase.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XFFirebase.Models;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Output { get; set; }
        public DelegateCommand StartCommand { get; set; }
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            StartCommand = new DelegateCommand(async () =>
            {
                Output = "建立與 Firebase 連線";
                var client = new Firebase.Database.FirebaseClient("https://xamarindb-3408d.firebaseio.com");
                var child = client.Child("MyMoneys");

                Output = Environment.NewLine + Environment.NewLine + "刪除掉所有的資料";
                await child.DeleteAsync();

                Console.WriteLine("產生 10 筆購物紀錄");
                for (int i = 1; i < 10; i++)
                {
                    await child.PostAsync<MyMoney>(new MyMoney()
                    {
                        Id = Guid.NewGuid(),
                        Title = $"冷泡茶 {i} 瓶",
                        InvoiceNo = $"0000 {i}",
                        Cost = 20 * i,
                    });
                }

                Output += Environment.NewLine + Environment.NewLine + "列出 Firebase 中所有的紀錄";
                var fooPosts = await child.OnceAsync<MyMoney>();
                foreach (var item in fooPosts)
                {
                    Output += Environment.NewLine + $"購買商品:{item.Object.Title} 價格:{item.Object.Cost}";
                }

                Output += Environment.NewLine + Environment.NewLine + "查詢購物價格小於 90 的紀錄";
                var fooRec = fooPosts.Where(x => x.Object.Cost <= 90);
                foreach (var item in fooRec)
                {
                    Output += Environment.NewLine + $"購買商品:{item.Object.Title} 價格:{item.Object.Cost}";
                }

                Output += Environment.NewLine + Environment.NewLine + "刪除購物價格小於 90 的紀錄";
                var fooRecDeleted = fooPosts.Where(x => x.Object.Cost <= 90);
                foreach (var item in fooRecDeleted)
                {
                    await child.Child(item.Key).DeleteAsync();
                    Output += Environment.NewLine + $"購買商品:{item.Object.Title} 價格:{item.Object.Cost} 已經被刪除";
                }


                Output += Environment.NewLine + Environment.NewLine + "列出 Firebase 中所有的紀錄";
                fooPosts = await child.OnceAsync<MyMoney>();
                foreach (var item in fooPosts)
                {
                    Output += Environment.NewLine + $"購買商品:{item.Object.Title} 價格:{item.Object.Cost}";
                }

                Output += Environment.NewLine + Environment.NewLine + "查詢購物價格等於 140 的紀錄";
                var foo140Rec = fooPosts.FirstOrDefault(x => x.Object.Cost == 140);
                foo140Rec.Object.Cost = 666;
                await child.Child(foo140Rec.Key).PutAsync(foo140Rec.Object);
                Output += Environment.NewLine + $"購買商品:{foo140Rec.Object.Title} 的價格已經修正為 價格:{foo140Rec.Object.Cost}";

                Output += Environment.NewLine + Environment.NewLine + "列出 Firebase 中所有的紀錄";
                fooPosts = await child.OnceAsync<MyMoney>();
                foreach (var item in fooPosts)
                {
                    Output += Environment.NewLine + $"購買商品:{item.Object.Title} 價格:{item.Object.Cost}";
                }
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

    }
}
