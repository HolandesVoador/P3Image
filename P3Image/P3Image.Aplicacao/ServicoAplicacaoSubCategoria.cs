using System;
using System.Collections.Generic;
using System.Linq;
using P3Image.Dominio;
using P3Image.Dominio.Interfaces.Repositorio;

namespace P3Image.Aplicacao
{
    public class ServicoAplicacaoSubCategoria : ServicoDeAplicacaoBase, IServicoAplicacaoSubCategoria
    {
        private readonly IRepositorioCampos _repositorioCampos;
        private readonly IRepositorioSubCategoria _repositorioSubCategoria;


        public ServicoAplicacaoSubCategoria(IRepositorioSubCategoria repositorioSubCategoria,
            IRepositorioCampos repositorioCampos)
        {
            _repositorioSubCategoria = repositorioSubCategoria;
            _repositorioCampos = repositorioCampos;
        }

        public IList<SubCategoria> RecuperarTodasSubCategorias()
        {
            try
            {
                return _repositorioSubCategoria.RecuperarTodasSubCategorias();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro ao listar Subcategorias: {0}", ex.Message));
            }
        }

        public IList<SubCategoria> RecuperarTodasCategoriasSubCategorias()
        {
            try
            {
                return _repositorioSubCategoria.RecuperarTodasCategoriasSubCategorias();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro ao RecuperarTodasCategorias: {0}", ex.Message));
            }
        }

        public void AdicionarSubCategoria(SubCategoria subCategoria)
        {
            try
            {
                IniciarTransacao();

                _repositorioSubCategoria.Inserir(subCategoria);

                PersistirTransacao();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro ao AdicionarSubCategoria: {0}", ex.Message));
            }
        }

        public void AtualizarSubCategoria(SubCategoria subCategoria)
        {
            try
            {
                IniciarTransacao();

                _repositorioSubCategoria.Alterar(subCategoria);

                if (subCategoria.Campos != null && subCategoria.Campos.Any())
                {
                    subCategoria.Campos.ToList().ForEach(c =>
                    {
                        if (c.Id > 0)
                            _repositorioCampos.Alterar(c);
                        else
                            _repositorioCampos.Inserir(c);
                    });
                }

                if (subCategoria.CamposRemovidos.Any())
                    subCategoria.CamposRemovidos.ToList().ForEach(i => _repositorioCampos.Remover(i.Id));


                PersistirTransacao();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro ao AtualizarSubCategoria: {0}", ex.Message));
            }
        }

        public void RemoverSubCategoria(SubCategoria subCategoria)
        {
            try
            {
                IniciarTransacao();

                if (subCategoria.Campos != null && subCategoria.Campos.Any())
                    subCategoria.Campos.ToList().ForEach(_repositorioCampos.Remover);
                
                _repositorioSubCategoria.Remover(subCategoria.Id);

                PersistirTransacao();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro ao RemoverSubCategoria: {0}", ex.Message));
            }
        }

        public SubCategoria RecuperarPorId(int id)
        {
            try
            {
                return _repositorioSubCategoria.RecuperarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro ao RecuperarPorId: {0}", ex.Message));
            }
        }
    }
}