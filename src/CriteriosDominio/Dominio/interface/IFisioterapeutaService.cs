using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosDominio.Dominio.interfaces
{
    public interface IFisioterapeutaService
    {
        Task<IEnumerable<Fisioterapeuta>> GetFisioterapeuta();
        Task<Fisioterapeuta?> GetFisioterapeutaById(Guid id);
        Task<IGenericResponse> AddFisioterapeuta(Fisioterapeuta fisioterapeuta);
        Task<IGenericResponse> DeleteFisioterapeuta(Guid id);
        Task<IGenericResponse> UpdateFisioterapeuta(Fisioterapeuta fisioterapeuta);
    }
}