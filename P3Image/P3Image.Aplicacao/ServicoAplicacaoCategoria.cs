using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using P3Image.Dominio;
using P3Image.Dominio.Interfaces.Repositorio;

namespace P3Image.Aplicacao
{
    public class ServicoAplicacaoCategoria : ServicoDeAplicacaoBase, IServicoAplicacaoCategoria
    {
        private readonly IRepositorioCategoria _repositorioCategoria;


        public ServicoAplicacaoCategoria(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public IList<Categoria> RecuperarTodasCategorias()
        {
            try
            {
                return _repositorioCategoria.RecuperarTodasCategorias();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro ao RecuperarTodasCategorias: {0}", ex.Message));
            }
        }

        public void AdicionarCategoria(Categoria categoria)
        {
            try
            {
                IniciarTransacao();
                _repositorioCategoria.Inserir(categoria);
                PersistirTransacao();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro ao AdicionarCategoria: {0}", ex.Message));
            }
        }

        public void AtualizarCategoria(Categoria categoria)
        {
            try
            {
                IniciarTransacao();
                _repositorioCategoria.Alterar(categoria);
                PersistirTransacao();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro ao AtualizarCategoria: {0}", ex.Message));
            }
        }

        public void RemoverCategoria(int id)
        {
            try
            {
                IniciarTransacao();
                _repositorioCategoria.Remover(id);
                PersistirTransacao();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro ao RemoverCategoria: {0}", ex.Message));
            }
        }

        public Categoria RecuperarPorId(int id)
        {
            try
            {
                return _repositorioCategoria.RecuperarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro ao RecuperarPorId: {0}", ex.Message));
            }
        }

        public IList<Categoria> RetornarCategoriasDisponiveis()
        {
            try
            {
                return _repositorioCategoria.RetornarCategoriasDisponiveis();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro ao RetornarCategoriasDisponiveis: {0}", ex.Message));
            }
        }
    }
}