namespace Servicios.Core.DTOs
{
    public class ServiceHelperDTO
    {
        public bool success { get; set; } = false;
        public string? message { get; set; }
        public dynamic? data { get; set; }
    }
}
