using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    // ObservableCollection para armazenar a lista de produtos
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();

    public ListaProduto()
    {
        InitializeComponent();

        // Define o ItemsSource do ListView para a ObservableCollection
        lst_produtos.ItemsSource = lista;
    }

    // Sobrescreve o método OnAppearing para carregar dados quando a página aparece
    protected async override void OnAppearing()
    {
        try
        {
            // Limpa a lista atual
            lista.Clear();

            // Busca todos os produtos do banco de dados
            List<Produto> tmp = await App.Db.GetAll();

            // Adiciona cada produto à ObservableCollection
            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            // Exibe um alerta se ocorrer uma exceção
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    // Manipulador de eventos para o clique do ToolbarItem para navegar para a página NovoProduto
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Navega para a página NovoProduto
            Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {
            // Exibe um alerta se ocorrer uma exceção
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    // Manipulador de eventos para o evento TextChanged da caixa de pesquisa
    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            // Obtém o novo valor de texto da caixa de pesquisa
            string q = e.NewTextValue;

            // Limpa a lista atual
            lista.Clear();

            // Pesquisa produtos no banco de dados que correspondem à consulta
            List<Produto> tmp = await App.Db.Search(q);

            // Adiciona cada produto correspondente à ObservableCollection
            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            // Exibe um alerta se ocorrer uma exceção
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    // Manipulador de eventos para o clique do ToolbarItem para calcular o total
    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            // Calcula a soma da propriedade Total de todos os produtos na lista
            double soma = lista.Sum(i => i.Total);

            // Exibe um alerta com o valor total
            DisplayAlert("Total", soma.ToString("C"), "OK");
        }
        catch (Exception ex)
        {
            // Exibe um alerta se ocorrer uma exceção
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    // Manipulador de eventos para o clique do MenuItem para excluir um produto
    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Obtém o produto associado ao item do menu
            var mi = ((MenuItem)sender);
            var p = mi.CommandParameter as Produto;

            // Exibe um alerta de confirmação
            bool confirm = await DisplayAlert("Confirmação", "Deseja excluir este produto?", "Sim", "Não");

            // Se confirmado, exclui o produto do banco de dados e da lista
            if (confirm)
            {
                await App.Db.Delete(p.Id);
                lista.Remove(p);
            }
        }
        catch (Exception ex)
        {
            // Exibe um alerta se ocorrer uma exceção
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    // Manipulador de eventos para a seleção de um item na lista
    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            // Obtém o produto selecionado
            Produto p = e.SelectedItem as Produto;

            // Navega para a página EditarProduto com o produto selecionado como contexto de dados
            Navigation.PushAsync(new Views.EditarProduto
            {
                BindingContext = p,
            });
        }
        catch (Exception ex)
        {
            // Exibe um alerta se ocorrer uma exceção
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}