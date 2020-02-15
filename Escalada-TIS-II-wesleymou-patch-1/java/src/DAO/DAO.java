package DAO;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.Set;
import java.util.TreeSet;

public abstract class DAO<T,K> {

	protected Set<T> lista;
	String nomeArquivo;
	
	public DAO(String nomeArquivo){
		this.nomeArquivo = nomeArquivo;
		lista = new TreeSet<T>(this.getAll());
	}

	public boolean add(T t) {
		boolean foiAdicionado = lista.add(t);
		this.gravar();
		return foiAdicionado;
	}

	@SuppressWarnings("unlikely-arg-type")
	public T get(K chave) {
		return lista.stream()
		.filter(t -> t.equals(chave))
		.findAny()
		.orElse(null);
	}

	public boolean update(T t) {
		boolean foiAtualizado = false;
		if(this.lista.removeIf(x -> x.equals(t)))
			foiAtualizado = this.add(t);
		return foiAtualizado;
	}

	@SuppressWarnings("unlikely-arg-type")
	public boolean delete(K chave) {
		boolean foiRemovido = false;
		if(foiRemovido = lista.removeIf(x -> x.equals(chave)))
			this.gravar();
		return foiRemovido;
	}
	
	public Set<T> getLista() {
		return lista;
	}

	@SuppressWarnings("unchecked")
	protected Set<T> getAll() {
		Set<T> lista = new TreeSet<T>();
		try (ObjectInputStream entrada = new ObjectInputStream(new FileInputStream(this.nomeArquivo))) {
			lista.addAll((TreeSet<T>)entrada.readObject());
			return lista;
		} catch (ClassNotFoundException e) {
			System.out.println("Classe lida no arquivo " + this.nomeArquivo +" n�o encontrada.");
			e.printStackTrace();
		} catch (FileNotFoundException e1) {
			e1.printStackTrace();
		} catch (IOException e1) {
			System.out.println("Arquivo " + this.nomeArquivo + " vazio!");
		}
		return lista;
	}

	protected void gravar() {
		try (ObjectOutputStream saida = new ObjectOutputStream(new FileOutputStream(this.nomeArquivo, false))) {
			saida.writeObject(this.lista);
			saida.flush();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
