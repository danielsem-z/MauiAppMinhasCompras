using SQLite; // Importa o namespace SQLite para usar atributos e funcionalidades do SQLite

namespace MauiAppMinhasCompras.Models
{
    // Define a classe Produto que representa um produto no banco de dados
    public class Produto
    {
        // Campo privado para armazenar a descrição do produto
        string _descricao;

        // Define a propriedade Id como chave primária e autoincremento no banco de dados
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Propriedade Descricao com lógica de validação no setter
        public string Descricao { 
            get => _descricao; // Retorna o valor da descrição
            set
            {
                // Verifica se o valor é nulo
                if(value == null) 
                {
                    // Lança uma exceção se a descrição for nula
                    throw new Exception("Por favor, preencha a descrição");
                }

                // Atribui o valor à variável privada _descricao
                _descricao = value;
            }
        }

        // Propriedade Quantidade para armazenar a quantidade do produto
        public double Quantidade { get; set; }

        // Propriedade Preco para armazenar o preço do produto
        public double Preco { get; set; }

        // Propriedade Total que calcula o total com base na quantidade e no preço
        public double Total { get => Quantidade * Preco; }
    }
}
