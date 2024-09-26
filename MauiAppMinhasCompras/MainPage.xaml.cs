namespace MauiAppMinhasCompras
{
    public partial class MainPage : ContentPage
    {
        // Variável para contar o número de cliques
        int count = 0;

        // Construtor da classe MainPage
        public MainPage()
        {
            // Inicializa os componentes da página
            InitializeComponent();
        }

        // Método que é chamado quando o botão é clicado
        private void OnCounterClicked(object sender, EventArgs e)
        {
            // Incrementa o contador
            count++;

            // Atualiza o texto do botão dependendo do valor do contador
            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time"; // Singular
            else
                CounterBtn.Text = $"Clicked {count} times"; // Plural

            // Anuncia o novo texto do botão para leitores de tela
            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
