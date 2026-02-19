namespace GameZone.Setting
{
    public abstract class Filesetting
    {
        public const string ImagePath = "/assests/image/games";
        public const string Allowedextentions = ".jpg,.png,.jpeg";
        public const int maxfilesizeMB = 1;
        public const int maxfilesizebyte = maxfilesizeMB * 1024 * 1024;

    }
}
