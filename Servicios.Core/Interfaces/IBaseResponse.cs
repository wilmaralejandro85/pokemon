namespace Servicios.Core.Interfaces
{
    public interface IBaseStatusResponse
    {
        public bool getInfo { get; set; }
        int status { get; set; }
        string errors { get; set; }
    }
}