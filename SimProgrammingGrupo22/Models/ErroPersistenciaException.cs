using System;

namespace SimProgrammingGrupo22.Models
{
    public class ErroPersistenciaException : Exception
    {
        // Excepcao usada para encapsular erros relacionados com leitura/escrita em JSON.
        public ErroPersistenciaException(string mensagem, Exception innerException)
            : base(mensagem, innerException)
        {
        }
    }
}