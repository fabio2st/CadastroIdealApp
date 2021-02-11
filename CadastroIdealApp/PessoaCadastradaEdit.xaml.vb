Imports Model
Class PessoaCadastradaEdit
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub New(pessoa As Pessoa)
        Me.New()
        NomeTextBox.Text = pessoa.Nome
        SobrenomeTextBox.Text = pessoa.Sobrenome
        TelefoneTextBox.Text = pessoa.Telefone
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        'Dim response = Await client.GetAsync("/api/Pessoas")
        '    response.EnsureSuccessStatusCode()
        'Dim pessoas = Await response.Content.ReadAsAsync(Of IEnumerable(Of Pessoa))()

    End Sub
End Class
