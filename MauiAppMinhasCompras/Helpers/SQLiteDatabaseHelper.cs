using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        // Conexão assíncrona com o banco de dados SQLite
        readonly SQLiteAsyncConnection _conn;

        // Construtor que inicializa a conexão e cria a tabela Produto se não existir
        public SQLiteDatabaseHelper(string path) 
        { 
            _conn = new SQLiteAsyncConnection(path); // Inicializa a conexão com o caminho fornecido
            _conn.CreateTableAsync<Produto>().Wait(); // Cria a tabela Produto de forma assíncrona e espera a conclusão
        }

        // Insere um novo produto na tabela Produto
        public Task<int> Insert(Produto p) 
        {
            return _conn.InsertAsync(p); // Insere o produto de forma assíncrona e retorna o número de linhas afetadas
        }

        // Atualiza um produto existente na tabela Produto
        public Task<List<Produto>> Update(Produto p) 
        {
            // SQL para atualizar o produto com base no Id
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";

            // Executa a consulta de atualização de forma assíncrona e retorna a lista de produtos atualizados
            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
            );
        }

        // Deleta um produto da tabela Produto pelo Id
        public Task<int> Delete(int id) 
        {
            // Deleta o produto com o Id fornecido de forma assíncrona e retorna o número de linhas afetadas
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        // Retorna todos os produtos da tabela Produto
        public Task<List<Produto>> GetAll() 
        {
            // Retorna todos os produtos da tabela de forma assíncrona
            return _conn.Table<Produto>().ToListAsync();
        }

        // Pesquisa produtos na tabela Produto pela descrição
        public Task<List<Produto>> Search(string q) 
        {
            // SQL para selecionar produtos cuja descrição contém a string de pesquisa
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + q + "%'";

            // Executa a consulta de pesquisa de forma assíncrona e retorna a lista de produtos correspondentes
            return _conn.QueryAsync<Produto>(sql);
        }
    }
}
