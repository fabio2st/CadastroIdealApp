Imports System
Imports System.Collections.Generic
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Documents
Imports Model
Partial Class PessoasCadastradasCrud
    Inherits Page
    Private client As New HttpClient()
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        client.BaseAddress = New Uri("https://localhost:5001")
        client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
        'client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("text/plain"))

    End Sub
    Async Sub PessoasCadastradasCrud_Loaded(sender As Object, e As RoutedEventArgs)
        Await PessoaSelectAll()
    End Sub
    Private Sub EditarButton_Click(sender As Object, e As RoutedEventArgs)
        Dim pessoaCadastradaEdit As New PessoaCadastradaEdit()
        NavigationService.Navigate(pessoaCadastradaEdit)
    End Sub
    Private Async Sub RemoverButton_Click(sender As Object, e As RoutedEventArgs)
        Dim pessoa As Pessoa = pessoasCadastradasListBox.SelectedItem
        If pessoa IsNot Nothing Then
            If MessageBox.Show("Tem certeza que está removendo " & pessoa.ToString(), Me.Title, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) Then
                Await PessoaDelete(pessoa)
            End If
        End If
    End Sub
    Private Async Function PessoaSelectAll() As Task
        Try
            Dim response = Await client.GetAsync("/api/Pessoas")
            response.EnsureSuccessStatusCode()
            Dim pessoas = Await response.Content.ReadAsAsync(Of IEnumerable(Of Pessoa))()
            pessoasCadastradasListBox.Items.Clear()
            For Each pessoa As Pessoa In pessoas
                pessoasCadastradasListBox.Items.Add(pessoa)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Async Function PessoaDelete(pessoa As Pessoa) As Task
        Try
            Dim response = Await client.DeleteAsync($"/api/Pessoas/{pessoa.ID}")
            Await PessoaSelectAll()
            'Return response.StatusCode
        Catch ex As Exception
            MessageBox.Show($"A operação falhou: {ex.Message}")
        End Try
    End Function
End Class
