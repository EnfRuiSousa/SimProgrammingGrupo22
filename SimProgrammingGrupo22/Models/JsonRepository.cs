using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimProgrammingGrupo22.Models
{
    internal class JsonRepository
    {
        // Caminho do ficheiro onde estão os dados 
        private readonly string _filePath;

        // Opções do serializador JSON(como os dados ficaram guardados)
        private readonly JsonSerializerOptions _options;

        // Construtor para definir o ficheiro e a sua serialização
        public JsonRepository(string filePath = "Models/repository.json")
        {
            _filePath = filePath;

            _options = new JsonSerializerOptions
            {
                WriteIndented = true,                 // escreve o JSON com indentação
                PropertyNameCaseInsensitive = true   // ignora as maiúsculas/minúsculas
            };

            // Converte as enums para strings no JSON
            _options.Converters.Add(new JsonStringEnumConverter());
        }

        /* FUNÇÃO LerDespesas */
        public List<Despesa> LerDespesas()
        {
            try
            {
                // Se o ficheiro nao existir, a aplicacao inicia com uma lista vazia.
                if (!File.Exists(_filePath))
                    return new List<Despesa>();

                var json = File.ReadAllText(_filePath);

                // Se o ficheiro existir mas estiver vazio, evita erro de desserializacao.
                if (string.IsNullOrWhiteSpace(json))
                    return new List<Despesa>();

                return JsonSerializer.Deserialize<List<Despesa>>(json, _options) ?? new List<Despesa>();
            }
            catch (Exception ex)
            {
                // Em vez de esconder o erro, lancamos uma excepcao propria para o Controller tratar.
                throw new ErroPersistenciaException(
                    "Não foi possível ler o ficheiro JSON das despesas.",
                    ex
                );
            }
        }

        /* FUNÇÃO GuardarDespesas */
        public void GuardarDespesas(List<Despesa> despesas)
        {
            if (despesas == null)
                throw new ArgumentNullException(nameof(despesas));

            try
            {
                // Garante que a pasta de destino existe antes de escrever o ficheiro.
                var dir = Path.GetDirectoryName(_filePath);
                if (!string.IsNullOrEmpty(dir))
                    Directory.CreateDirectory(dir);

                // Escreve primeiro num ficheiro temporario para reduzir risco de corromper o JSON final.
                var tempFile = _filePath + ".tmp";
                var json = JsonSerializer.Serialize(despesas, _options);

                File.WriteAllText(tempFile, json);
                File.Copy(tempFile, _filePath, overwrite: true);
                File.Delete(tempFile);
            }
            catch (Exception ex)
            {
                // Encapsula erros de escrita para o Controller conseguir apresentar mensagem adequada.
                throw new ErroPersistenciaException(
                    "Não foi possível guardar as despesas no ficheiro JSON.",
                    ex
                );
            }
        }
    }
}
