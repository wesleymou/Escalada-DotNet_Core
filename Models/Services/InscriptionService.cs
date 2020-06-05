using System.Collections.Generic;
using System.Threading.Tasks;
using Escalada.Models.DataModels;

namespace Escalada.Models.Services
{
    public class InscriptionService
    {
        private readonly IInscriptionData _inscriptionData;

        public InscriptionService(IInscriptionData inscriptionData)
        {
            _inscriptionData = inscriptionData;
        }
        
        public async Task<Inscription> BuscarPorId(int id) => await _inscriptionData.BuscarPorId(id);
        public async Task<Inscription> Cadastrar(Inscription inscription) => await _inscriptionData.Cadastrar(inscription);
        public async Task<List<Inscription>> Listar() => await _inscriptionData.Listar();
        public async Task Atualizar(Inscription inscription) => await _inscriptionData.Atualizar(inscription);
        public async Task Remover(int id) => await _inscriptionData.Remover(id);
        public async Task<List<PaymentType>> ListarMeiosDePagamento() => await _inscriptionData.ListarMeiosDePagamento();
    }
}