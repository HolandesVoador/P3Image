using System;
using System.Collections.Generic;

namespace P3Image.Dominio
{
    public class SubCategoria : Identificador
    {
        public string Descricao { get; set; }
        public String Slug { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Campos> Campos { get; set; }
        public virtual ICollection<Campos> CamposRemovidos { get; set; }
    }
}
