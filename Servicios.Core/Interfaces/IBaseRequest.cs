namespace Servicios.Core.Interfaces
{
    public interface IBaseTelefonoRequest
    {
        string interactionId { get; set; }
        string telefono { get; set; }
    }
    public interface IBaseIdRequest
    {
        string interactionId { get; set; }
        string documento { get; set; }
    }
    public interface IBaseCodigoFamiliarRequest
    {
        string interactionId { get; set; }
        string codigoFamiliar { get; set; }
    }
    public interface IBaseContratoRequest
    {
        string interactionId { get; set; }
        string contrato { get; set; }
    }
    public interface IBaseCelularRequest
    {
        string interactionId { get; set; }
        string celular { get; set; }
    }
    public interface IBaseSaldoRequest
    {
        string interactionId { get; set; }
        string valor { get; set; }
    }
    public interface IBaseAniRequest
    {
        string interactionId { get; set; }
        string ani { get; set; }
    }
}