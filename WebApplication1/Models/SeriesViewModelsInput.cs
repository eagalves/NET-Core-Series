using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesApp.Models
{
    public class SeriesViewModelsInput
    {
		// Atributos
		public string Genero { get; set; }
		public string Titulo { get; set; }
		public string Descricao { get; set; }
		public int Ano { get; set; }
		public bool Excluido { get; set; }

		//// Métodos
		//public SeriesViewModelsInput(string genero, string titulo, string descricao, int ano)
		//{
		//	this.Genero = genero;
		//	this.Titulo = titulo;
		//	this.Descricao = descricao;
		//	this.Ano = ano;
		//	this.Excluido = false;
		//}

		//public override string ToString()
		//{
		//	// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
		//	string retorno = "";
		//	retorno += "Gênero: " + this.Genero + Environment.NewLine;
		//	retorno += "Titulo: " + this.Titulo + Environment.NewLine;
		//	retorno += "Descrição: " + this.Descricao + Environment.NewLine;
		//	retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
		//	retorno += "Excluido: " + this.Excluido;
		//	return retorno;
		//}

		//public string retornaTitulo()
		//{
		//	return this.Titulo;
		//}

		////public int retornaId()
		////{
		////	return this.Id;
		////}
		//public bool retornaExcluido()
		//{
		//	return this.Excluido;
		//}
		//public void Excluir()
		//{
		//	this.Excluido = true;
		//}
	}
}
