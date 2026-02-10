using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_poo.Entities
{
    public class Emprestimo
    {
        public Usuario Usuario { get; }
        public Livro Livro { get; }
        public DateTime DataEmprestimo { get; }
        public DateTime PrazoDevolucao { get; }
        public DateTime? DataDevolucao { get; private set; }

        public Emprestimo(Usuario usuario, Livro livro)
        {
            Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
            Livro = livro ?? throw new ArgumentNullException(nameof(livro));

            if (!usuario.PodeEmprestar())
                throw new InvalidOperationException("Usuário atingiu o limite de empréstimos.");

            Livro.Emprestar();

            DataEmprestimo = DateTime.Now;
            PrazoDevolucao = DataEmprestimo.AddDays(usuario.ObterPrazo());
        }

        public bool EstaAtrasado() =>
            DataDevolucao == null && DateTime.Now > PrazoDevolucao;

        public void Devolver()
        {
            if (DataDevolucao != null)
                throw new InvalidOperationException("Livro já foi devolvido.");

            DataDevolucao = DateTime.Now;
            Livro.Devolver();
        }
    }
}
