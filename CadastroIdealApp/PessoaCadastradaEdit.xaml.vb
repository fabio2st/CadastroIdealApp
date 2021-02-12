Imports Model
Imports Controllers
Class PessoaCadastradaEdit
    Private pessoa As Pessoa
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub New(pessoa As Pessoa)
        Me.New()
        Me.pessoa = pessoa
        SetFormValues(pessoa)
    End Sub
    Private Sub SetFormValues(pessoa As Pessoa)
        NomeTextBox.Text = pessoa.Nome
        SobrenomeTextBox.Text = pessoa.Sobrenome
        TelefoneTextBox.Text = pessoa.Telefone
    End Sub
    Private Sub GetFormValues()
        pessoa.Nome = NomeTextBox.Text
        pessoa.Sobrenome = SobrenomeTextBox.Text
        pessoa.Telefone = TelefoneTextBox.Text
    End Sub
    Private Async Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Try
            GetFormValues()
            If pessoa.ID = 0 Then
                Await PessoasController.Insert(pessoa)
            Else
                Await PessoasController.Update(pessoa)
            End If
            MessageBox.Show("Dados salvos", Me.Title, MessageBoxButton.OK, MessageBoxImage.Information)
            NavigationService.GoBack()
        Catch ex As Exception
            MessageBox.Show($"A operação falhou: {ex.Message}", Me.Title, MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub
End Class
