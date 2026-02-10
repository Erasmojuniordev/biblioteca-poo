using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_poo.Entities.User_Types
{
    public class Aluno : Usuario
    {
        public Aluno(int id, string nome) : base(id, nome) { }
        public override int LimiteEmprestimos() => 3;
        public override int ObterPrazo() => 7;
    }
}
