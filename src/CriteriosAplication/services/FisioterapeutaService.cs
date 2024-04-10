using CriteriosDominio.Dominio.interfaces;
using CriteriosDominio.Dominio.Modelos.Entidades;

namespace CriteriosAplicaion.Services{

    class FisioterapeutaService : IFisioterapeutaService{

        private readonly IFisioterapeutaRepository _fisioterapeutaRepository;

        public FisioterapeutaService(IFisioterapeutaRepository fisioterapeutaRepository){
            _fisioterapeutaRepository = fisioterapeutaRepository;
        }

        public async Task AddFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            if(fisioterapeuta == null)
            {
                throw new ArgumentException("El fisioterapeuta no puede ser nulo");
            }

            if(fisioterapeuta.Rango == 0 || fisioterapeuta.Rango < 0 || fisioterapeuta.Rango != 10 || fisioterapeuta.Rango != 20 || fisioterapeuta.Rango != 30)
            {
                throw new ArgumentException("El rango del fisioterapeuta no es valido");
            }

            await _fisioterapeutaRepository.AddFisioterapeuta(fisioterapeuta);
        }

        public async Task DeleteFisioterapeuta(Guid id)
        {
            Fisioterapeuta? fisioterapeuta = await _fisioterapeutaRepository.GetFisioterapeutaById(id);

            if(fisioterapeuta == null)
            {
                throw new ArgumentException("El fisioterapeuta no existe");
            }

            await _fisioterapeutaRepository.DeleteFisioterapeuta(id);

        }

        public async Task<IEnumerable<Fisioterapeuta>> GetFisioterapeuta()
        {
            return await _fisioterapeutaRepository.GetFisioterapeuta();
        }

        public async Task<Fisioterapeuta?> GetFisioterapeutaById(Guid id)
        {
            Fisioterapeuta? fisioterapeuta = await _fisioterapeutaRepository.GetFisioterapeutaById(id);

            if(fisioterapeuta == null)
            {
                throw new ArgumentException("El fisioterapeuta no existe");
            }

            return fisioterapeuta;
        }

        public async Task UpdateFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            if(fisioterapeuta == null)
            {
                throw new ArgumentException("El fisioterapeuta no puede ser nulo");
            }

            if(fisioterapeuta.Rango == 0 || fisioterapeuta.Rango < 0 || fisioterapeuta.Rango != 10 || fisioterapeuta.Rango != 20 || fisioterapeuta.Rango != 30)
            {
                throw new ArgumentException("El rango del fisioterapeuta no es valido");
            }

            await _fisioterapeutaRepository.UpdateFisioterapeuta(fisioterapeuta);
        }
    }

}