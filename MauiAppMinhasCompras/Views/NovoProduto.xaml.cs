using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	// Construtor da classe NovoProduto
	public NovoProduto()
	{
		InitializeComponent(); // Inicializa os componentes da interface
	}

	// Método assíncrono que é chamado quando o item da toolbar é clicado
	private async void ToolbarItem_Clicked(object sender, EventArgs e)
	{
		try
		{
			// Cria uma nova instância de Produto e define suas propriedades
			Produto p = new Produto
			{
				Descricao = txt_descricao.Text, // Define a descrição do produto com o texto do campo txt_descricao
				Quantidade = Convert.ToDouble(txt_quantidade.Text), // Converte o texto do campo txt_quantidade para double e define a quantidade do produto
				Preco = Convert.ToDouble(txt_preco.Text) // Converte o texto do campo txt_preco para double e define o preço do produto
			};

			// Insere o novo produto no banco de dados
			await App.Db.Insert(p);
			// Exibe um alerta de sucesso
			await DisplayAlert("Sucesso!", "Registro Inserido", "OK");

		} catch(Exception ex)
		{
			// Em caso de exceção, exibe um alerta com a mensagem de erro
			await DisplayAlert("Ops", ex.Message, "OK");
		}
	}
}