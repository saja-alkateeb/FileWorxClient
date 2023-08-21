namespace FileWorxServer
{

    public enum ClassIds
    {
        User = 3,
        Photo = 2,
        Contact=4,
        News = 1,
        All = -1
    }
    public class clsClass
    {
        public int ID { get; set; }
        public string ClassName { get; set; }

    }
}
