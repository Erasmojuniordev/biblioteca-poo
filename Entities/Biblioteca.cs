using biblioteca_poo.Entities.User_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_poo.Entities
{
    public class Biblioteca
    {
        public List<Livro> _livros { get; set; } = new List<Livro>();
        public List<Usuario> _usuarios { get; set; } = new List<Usuario>();
        public List<Emprestimo> _emprestimosAtivos { get;} = new List<Emprestimo>();

        public void AdicionarLivro(Livro livro)
        {
            _livros.Add(livro);
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public void RealizarEmprestimo(int usuarioId, int livroId)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == usuarioId);
            if (usuario == null)
                throw new InvalidOperationException("Usuário não encontrado.");

            var livro = _livros.FirstOrDefault(l => l.Id == livroId);
            if (livro == null)
                throw new InvalidOperationException("Livro não encontrado.");

            var emprestimo = new Emprestimo(usuario, livro);
            _emprestimosAtivos.Add(emprestimo);
            usuario.AdicionarEmprestimo(emprestimo);
        }

        public void RealizarDevolucao(int livroId)
        {
            var emprestimo = _emprestimosAtivos.FirstOrDefault(e => e.Livro.Id == livroId);

            if (emprestimo == null)
                throw new InvalidOperationException("Empréstimo não encontrado.");
            emprestimo.Devolver();
            _emprestimosAtivos.Remove(emprestimo);
            emprestimo.Usuario.RemoverEmprestimo(emprestimo);
        }

        public IReadOnlyList<Emprestimo> ListarEmprestimosAtivos() => _emprestimosAtivos;

        public IReadOnlyList<Livro> ListarLivrosDisponiveis() =>
            _livros.Where(l => l.Disponivel).ToList();
    }
}
