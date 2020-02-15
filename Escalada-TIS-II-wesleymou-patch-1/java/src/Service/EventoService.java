/* Pontifícia Universidade Católica de Minas Gerais || Trabalho Interdisciplinar de Software - 2º período
    Membros:
    Filipe Iannarelli Caldeira
    Gabriel Vinicius Ramos da Silva
    Paulo Angelo Dias Barbosa
    Wesley Mouraria Pereira
*/
package Service;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.Map;
import java.util.Set;

import org.json.JSONArray;
import org.json.JSONObject;
import org.simpleframework.http.Query;
import org.simpleframework.http.Request;

import DAO.EventoDAO;
import Main.Evento;;

//Criação da classe EventoService, seu construtor, variáveis e métodos,
//utilizado como uma "interface" entre os campos da página e os dados de um evento no servidor
public final class EventoService {
	private static final String NOME = "nome";
	private static final String DATAINICIO = "dataInicio";
	private static final String DATATERMINO = "dataTermino";
	private static final String LOCAL = "local";
	private static final String CAPACIDADE = "capacidade";
	private static final String QUORUM = "quorum";
	private static final String ORCAMENTOPREVIO = "orcamentoPrevio";
	private static final String VALORINGRESSO = "valorIngresso";
	private static final String STATUS = "status";
	private static final String NOVONOME = "novoNome";

	private EventoDAO eventoDAO;

	public EventoService() {
		eventoDAO = new EventoDAO("eventos.ser");
	}

	public JSONObject add(Request request) {
		Query query = request.getQuery();

		String nome = query.get(NOME);
		String dataInicio = query.get(DATAINICIO);
		String dataTermino = query.get(DATATERMINO);
		String local = query.get(LOCAL);
		int capacidade = query.getInteger(CAPACIDADE);
		int quorum = query.getInteger(QUORUM);
		double orcamentoPrevio = query.getFloat(ORCAMENTOPREVIO);
		double valorIngresso = query.getFloat(VALORINGRESSO);
		String status = query.get(STATUS);

		Evento evento = new Evento(
				nome,
				dataInicio,
				dataTermino,
				local,
				capacidade,
				quorum,
				orcamentoPrevio,
				valorIngresso,
				status);

		this.eventoDAO.add(evento);
		return evento.toJson();
	}

	public JSONArray get(Request request) {
		JSONArray listaJson = new JSONArray();
		eventoDAO.getLista().stream()
		.forEach(e -> listaJson.put(e.toJson()));
		return listaJson;
	}


	public Evento getEvento(Request request) {
		return eventoDAO.get(request.getQuery().get(NOME));
	}

	public JSONObject update(Request request) {
		Query query = request.getQuery();
		Evento evento = eventoDAO.get(request.getQuery().get(NOME));

		String novoNome = query.get(NOVONOME);
		if(novoNome != "" && novoNome != null)
			evento.setNome(novoNome);
		evento.setDataInicio(query.get(DATAINICIO));
		evento.setDataTermino(query.get(DATATERMINO));
		evento.setLocal(query.get(LOCAL));
		evento.setCapacidade(query.getInteger(CAPACIDADE));
		evento.setQuorum(query.getInteger(QUORUM));
		evento.setOrcamentoPrevio(query.getFloat(ORCAMENTOPREVIO));
		evento.setValorIngresso(query.getFloat(VALORINGRESSO));
		evento.setStatus(query.get(STATUS));

		eventoDAO.update(evento);
		return evento.toJson();
	}

	public JSONObject remove (Request request) { 
		return new JSONObject(eventoDAO.delete(request.getQuery().get(NOME)));
	}
	
	public Set<Evento> getAllEventos() {
		return eventoDAO.getAllEventos();
	}
	
	public JSONObject getAllCronograma(Request request) {
		JSONObject jsonObject = new JSONObject();
		Evento evento;
		if ((evento = getEvento(request)) != null) {
			Map<LocalDateTime, String> cronograma = evento.getCronograma();
				cronograma.forEach((k,v) -> jsonObject.put(k.format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss")), v));
		}
		return jsonObject;
	}
	
	public JSONObject receberCronograma(Request request) {
		Evento evento;
		if ((evento = getEvento(request)) != null) {
			Map<LocalDateTime, String> cronograma = evento.getCronograma();
			cronograma.clear();
			request.getQuery().remove("nome");
			request.getQuery().forEach((x,y) -> cronograma.put(LocalDateTime.parse(x), y));
			eventoDAO.update(evento);
		}
		return new JSONObject(true);
	}
}
