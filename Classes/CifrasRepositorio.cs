using System;
using System.Collections.Generic;
using DIO.CIFRASNET.Interfaces;

namespace DIO.CIFRASNET

{
	public class CifrasRepositorio : IRepositorio<Cifras>
	{
        private List<Cifras> listaCifra = new List<Cifras>();
		public void Atualiza(int id, Cifras objeto)
		{
			listaCifra[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaCifra[id].Excluir();
		}

		public void Insere(Cifras objeto)
		{
			listaCifra.Add(objeto);
		}

		public List<Cifras> Lista()
		{
			return listaCifra;
		}

		public int ProximoId()
		{
			return listaCifra.Count;
		}

		public Cifras RetornaPorId(int id)
		{
			return listaCifra[id];
		}
	}
}