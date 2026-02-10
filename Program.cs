using biblioteca_poo.Entities;
using biblioteca_poo.Entities.User_Types;

class Program
{
    static void Main()
    {
        var biblioteca = new Biblioteca();

        // Usuários
        var aluno = new Aluno(1, "João");
        var professor = new Professor(2, "Maria");

        biblioteca.AdicionarUsuario(aluno);
        biblioteca.AdicionarUsuario(professor);

        // Livros
        var livro1 = new Livro(101, "Clean Code");
        var livro2 = new Livro(102, "Domain-Driven Design");
        var livro3 = new Livro(103, "Padrões de Projeto");

        biblioteca.AdicionarLivro(livro1);
        biblioteca.AdicionarLivro(livro2);
        biblioteca.AdicionarLivro(livro3);

        Console.WriteLine("=== Empréstimos iniciais ===");

        biblioteca.RealizarEmprestimo(1, 101); // João pega Clean Code
        biblioteca.RealizarEmprestimo(2, 102); // Maria pega DDD

        Console.WriteLine("Livros disponíveis:");
        foreach (var livro in biblioteca.ListarLivrosDisponiveis())
        {
            Console.WriteLine($"- {livro.Titulo}");
        }

        Console.WriteLine("\n=== Tentando emprestar livro já emprestado ===");
        try
        {
            biblioteca.RealizarEmprestimo(1, 101); // erro
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\n=== Devolvendo livro ===");
        biblioteca.RealizarDevolucao(101);

        Console.WriteLine("\nLivros disponíveis após devolução:");
        foreach (var livro in biblioteca.ListarLivrosDisponiveis())
        {
            Console.WriteLine($"- {livro.Titulo}");
        }

        Console.WriteLine("\n=== Forçando limite de empréstimos do aluno ===");
        try
        {
            biblioteca.RealizarEmprestimo(1, 101);
            biblioteca.RealizarEmprestimo(1, 102);
            biblioteca.RealizarEmprestimo(1, 103);
            biblioteca.RealizarEmprestimo(1, 101); // erro de limite ou disponibilidade
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\n=== Empréstimos ativos ===");
        foreach (var e in biblioteca.ListarEmprestimosAtivos())
        {
            Console.WriteLine($"{e.Usuario.Nome} → {e.Livro.Titulo}");
        }

        Console.WriteLine("\n=== Teste concluído ===");
    }
}

