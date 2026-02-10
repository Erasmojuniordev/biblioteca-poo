using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_poo.Entities.User_Types
{
    public class Professor : Usuario
    {
        public Professor(int id, string nome) : base(id, nome) { }
        public override int LimiteEmprestimos() => 5;
        public override int ObterPrazo() => 14; // Prazo de 14 dias para professores
        
    }
}
