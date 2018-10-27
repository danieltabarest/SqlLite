namespace NsuGo.Definition.Models
{
    public class UserProfileImage
    {
        public string Base64Image
        {
            get;
            set;
        }

        public UserProfileImage(string base64Image)
        {
            Base64Image = base64Image;
        }
    }
}
