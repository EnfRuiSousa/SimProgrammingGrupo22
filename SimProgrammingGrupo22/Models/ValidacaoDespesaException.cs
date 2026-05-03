using System;

namespace SimProgrammingGrupo22.Models
{
    public class ValidacaoDespesaException : Exception
    {
        // Excepcao usada quando uma despesa nao respeita as regras de negocio.
        public ValidacaoDespesaException(string mensagem)
            : base(mensagem)
        {
        }
    }
}