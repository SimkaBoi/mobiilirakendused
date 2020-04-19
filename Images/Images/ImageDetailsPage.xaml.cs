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
            var userAndPostData = (PostAndUserDataModel)BindingContext;
            List<CommentData> Comments = await App.Database.GetCommentsAsync();
            List<CommentData> PostComments = new List<CommentData>();
            foreach(var comment in Comments)
            {
                if(userAndPostData.PostId == comment.PostId)
                {
                    PostComments.Add(comment);
                }
            }
            commentList.ItemsSource = PostComments;
        }

        private async void CommentAddButton_Clicked(object sender, EventArgs e)
        {
            if(CommentEntry.Text == "" || CommentEntry.Text == null)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Comment field is empty!", "OK");
                return;
            }
            var userAndPostData = (PostAndUserDataModel)BindingContext;
            CommentData comment = new CommentData();
            comment.Id = 0;
            comment.PostId = userAndPostData.PostId;
            comment.UserId = userAndPostData.UserId;
            comment.UserName = userAndPostData.UserName;
            comment.ProfilePicPath = userAndPostData.ProfilePicPath;
            comment.CommentString = CommentEntry.Text;
            await App.Database.SaveCommentAsync(comment);
            ImageData image = await App.Database.GetImageAsync(userAndPostData.PostId);
            image.Comments++;
            await App.Database.SaveImageAsync(image);
            GetComments();
        }
    }
}