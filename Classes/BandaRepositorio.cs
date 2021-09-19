using DIO.Musicas.Interfaces;
using System.Collections.Generic;

namespace DIO.Musicas
{
    public class BandaRepositorio : IRepositorio<Banda>
	{
        private List<Banda> _listaBanda = new List<Banda>();

		public void Atualiza(int id, Banda objeto)
		{
			_listaBanda[id] = objeto;
		}

		public void Exclui(int id)
		{
			_listaBanda[id].Excluir();
		}

		public void Insere(Banda objeto)
		{
			_listaBanda.Add(objeto);
		}

		public List<Banda> Lista()
		{
			return _listaBanda;
		}

		public int ProximoId()
		{
			return _listaBanda.Count;
		}

		public Banda RetornaPorId(int id)
		{
			return _listaBanda[id];
		}
	}
}