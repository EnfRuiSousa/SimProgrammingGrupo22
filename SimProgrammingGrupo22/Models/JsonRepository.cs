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
                // Se o ficheiro não existir, devolve uma lista vazia
                if (!File.Exists(_filePath)) return new List<Despesa>();

                // Lê todo o conteúdo e escreve para List<Despesa> e devolve a lista
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Despesa>>(json, _options) ?? new List<Despesa>();
            }
            catch
            {
                // Em caso de erro, devolve lista vazia para não bloquear a aplicação
                return new List<Despesa>();
            }
        }

        /* FUNÇÃO GuardarDespesas */
        public void GuardarDespesas(List<Despesa> despesas)
        {
            if (despesas == null) throw new ArgumentNullException(nameof(despesas));

            // Verifica que o diretório existe antes de guardar
            var dir = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);

            // 1) escreve num ficheiro temporário
            // 2) substitui o ficheiro final e limpa a memória
            var tempFile = _filePath + ".tmp";
            var json = JsonSerializer.Serialize(despesas, _options);
            File.WriteAllText(tempFile, json);
            File.Copy(tempFile, _filePath, overwrite: true);
            File.Delete(tempFile);
        }
    }
}
