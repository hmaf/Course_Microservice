namespace Category.Application.Contracts.FileTypes
{
    public class FileType
    {
        public string[] Title { get; }

        public bool IsValid(string type)
        {
            if (!Title.Contains(type))
                return false;

            return true;
        }

        public static FileType File_Type { get; } = new FileType();

        public FileType()
            => Title = new string[] { ".png" };
    }
}
