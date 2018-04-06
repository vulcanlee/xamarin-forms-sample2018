using Prism.Navigation;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace XFEFCore.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";
        }

        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            using (var db = new DatabaseContext())
            {
                db.Database.Migrate();

                if((await db.Blogs.CountAsync()) == 0)
                {
                    db.Add(new Blog() { Rating = 5, Url = "https://mylabtw.blogspot.com/" });
                    db.SaveChanges();
                }

                Title = db.Blogs.ToList().FirstOrDefault().Url;
            }
        }
    }
}
