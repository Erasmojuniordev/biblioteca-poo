using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_poo.Entities
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Emprestimo> EmprestimosAtivos = new List<Emprestimo>();

        protected Usuario(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        // Método abstrato para definir o limite de empréstimos, a ser implementado pelas subclasses
        public abstract int LimiteEmprestimos();
        public abstract int ObterPrazo();

        public int QuantidadeEmprestimosAtivos()
        {
            return EmprestimosAtivos.Count;
        }

        public bool PodeEmprestar()
        {
            return QuantidadeEmprestimosAtivos() < LimiteEmprestimos();
        }

        public void AdicionarEmprestimo(Emprestimo emprestimo)
        {
            EmprestimosAtivos.Add(emprestimo);
        }

        public void RemoverEmprestimo(Emprestimo emprestimo)
        {
            EmprestimosAtivos.Remove(emprestimo);
        }
    }
}
