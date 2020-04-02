using Images.Data;
using Images.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Images
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageDetailsPage : ContentPage
    {
        public ImageDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetComments();
        }

        private async void GetComments()
        {
            var userAndPostId = (PostAndUserIdModel)BindingContext;
            List<CommentData> Comments = await App.Database.GetCommentsAsync();
            List<CommentData> PostComments = new List<CommentData>();
            foreach(var comment in Comments)
            {
                if(userAndPostId.PostId == comment.PostId)
                {
                    PostComments.Add(comment);
                }
            }
            commentList.ItemsSource = PostComments;
        }
    }
}