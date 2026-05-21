using System.Collections.ObjectModel;
using System.Windows;

namespace Lista;

public partial class MainWindow : Window
{
    public ObservableCollection<string> nomes { get; set; } = new();

    public MainWindow()
    {
        InitializeComponent();

        this.DataContext = this;
    }

    private void BtnAdicionaNome_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(tbNome.Text) || tbNome.Text.Length < 3)
        {
            MessageBox.Show("Escreva um nome válido!");
            return;
        }

        nomes.Add(tbNome.Text);
    }

    private void BtnRemoveNome_OnClick(object sender, RoutedEventArgs e)
    {
        if (!nomes.Contains(tbNome.Text, StringComparer.CurrentCultureIgnoreCase))
        {
            MessageBox.Show("Nome não encontrado!");
            return;
        }

        var nomeEncontrado = nomes.FirstOrDefault(nomePessoa =>
            nomePessoa.Equals(tbNome.Text, StringComparison.CurrentCultureIgnoreCase));

        nomes.Remove(nomeEncontrado);
        MessageBox.Show("Nome removido com sucesso!");
    }

    private void BtnEncontrarNomes_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(tbNome.Text))
        {
            MessageBox.Show("Escreva um nome válido!");
            return;
        }

        lbNomes.SelectedItems.Clear();

        string termoBuscaMinusculo = tbNome.Text.ToLower();

        foreach (var nome in nomes)
        {
            if (nome.Contains(termoBuscaMinusculo, StringComparison.CurrentCultureIgnoreCase))
            {
                lbNomes.SelectedItems.Add(nome);
            }
        }
    }
}