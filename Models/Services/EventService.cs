using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escalada.Models.DataModels;
using Escalada.Models.Exceptions;

namespace Escalada.Models.Services
{
    public class EventService
    {
        private readonly IEventData _eventData;
        private readonly ICustomerData _customerData;
        private readonly IInscriptionData _inscriptionData;

        public EventService(IEventData eventData, ICustomerData customerData,
            IInscriptionData inscriptionData)
        {
            _eventData = eventData;
            _customerData = customerData;
            _inscriptionData = inscriptionData;
        }

        public async Task<Event> BuscarPorId(int id) => await _eventData.BuscarPorId(id);
        public async Task<Event> Cadastrar(Event evento) => await _eventData.Cadastrar(evento);
        public async Task<List<Event>> Listar() => await _eventData.Listar();
        public async Task Atualizar(Event evento) => await _eventData.Atualizar(evento);
        public async Task<List<EventStatus>> ListarStatusEvento() => await _eventData.ListarStatusEvento();

        public async Task Remover(int id)
        {
            Event evento = await _eventData.BuscarPorId(id);
            evento.Excluido = true;
            await this.Atualizar(evento);
        }

        public async Task InscreverCliente(int eventoId, int clienteId, int qtdinteira, int qtdMeia, decimal valorPago)
        {
            Event evento = await _eventData.BuscarPorId(eventoId);
            Customer cliente = await _customerData.BuscarPorId(clienteId);

            if (evento.Capacidade < qtdinteira + qtdMeia)
            {
                throw new EscaladaException($"Número de ingressos indisponível para o evento. " +
                                            $"Quantidade disponível atualmente: {evento.QtdDisponiveis}.");
            }

            if (evento.Inscricoes.Any(i => i.Cliente.Id == cliente.Id))
            {
                throw new EscaladaException("Cliente já foi cadastrado no evento.");
            }

            await _inscriptionData.Cadastrar(new Inscription
            {
                Evento = evento,
                Cliente = cliente,
                QtdInteira = qtdinteira,
                QtdMeia = qtdMeia,
                ValorRecebido = valorPago,
                ValorTotal = CalcularValorTotal(evento, qtdinteira, qtdMeia)
            });
        }

        public async Task PagarInscricao(int eventoId, int clienteId, decimal valor)
        {
            Event evento = await _eventData.BuscarPorId(eventoId);
            Inscription inscricao = ObterInscricaoPorCliente(evento.Inscricoes, clienteId);

            decimal debito = inscricao.ValorTotal - inscricao.ValorRecebido;

            if (valor > debito)
            {
                throw new EscaladaException("O valor pago é maior que o valor devido.");
            }

            inscricao.ValorRecebido += valor;

            await _inscriptionData.Atualizar(inscricao);
        }

        public async Task<Inscription> ObterDadosInscricao(int eventoId, int clienteId)
        {
            Event evento = await _eventData.BuscarPorId(eventoId);
            return ObterInscricaoPorCliente(evento.Inscricoes, clienteId);
        }

        private Inscription ObterInscricaoPorCliente(IEnumerable<Inscription> inscricoes, int clienteId)
        {
            Inscription inscricao = inscricoes.FirstOrDefault(i => i.Cliente.Id == clienteId);
            if (inscricao == null)
            {
                throw new EscaladaException("O cliente não está cadastrado no evento.");
            }
            return inscricao;
        }

        private decimal CalcularValorTotal(Event evento, int qtdinteira, int qtdMeia)
        {
            return (evento.ValorIngresso * qtdinteira) + (evento.ValorIngresso / 2 * qtdMeia);
        }
    }
}