using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        // Campo estático para armazenar a instância do helper do banco de dados SQLite
        static SQLiteDatabaseHelper _db;

        // Propriedade estática para acessar a instância do helper do banco de dados SQLite
        public static SQLiteDatabaseHelper Db
        {
            get
            {
                // Se a instância do banco de dados ainda não foi criada
                if(_db == null)
                {
                    // Obtém o caminho do diretório de dados locais da aplicação
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3"); // Nome do arquivo do banco de dados

                    // Cria uma nova instância do helper do banco de dados SQLite com o caminho especificado
                    _db = new SQLiteDatabaseHelper(path);
                }

                // Retorna a instância do helper do banco de dados SQLite
                return _db;
            }
        }

        // Construtor da classe App
        public App()
        {
            InitializeComponent(); // Inicializa os componentes da aplicação

            // Define a página principal da aplicação como uma nova NavigationPage contendo a view ListaProduto
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
