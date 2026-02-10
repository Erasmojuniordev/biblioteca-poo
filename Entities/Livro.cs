using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_poo.Entities
{
    public class Livro
    {
        public int Id { get; }
        public string Titulo { get; }
        public bool Disponivel { get; private set; } = true;

        public Livro(int id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }

        public void Emprestar()
        {
            if (!Disponivel)
            {
                throw new InvalidOperationException("Livro indisponível para empréstimo.");
            }
            Disponivel = false;
        }

        public void Devolver()
        {
            if (Disponivel)
            {
                throw new InvalidOperationException("Livro já está disponível.");
            }
            Disponivel = true;
        }
    }
}
