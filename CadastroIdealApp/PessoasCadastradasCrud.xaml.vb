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
        Try
            Dim response = Await client.GetAsync("/api/Pessoas")
            response.EnsureSuccessStatusCode()
            Dim pessoas = Await response.Content.ReadAsAsync(Of IEnumerable(Of Pessoa))()
            Console.WriteLine(pessoas)
            For Each pessoa As Pessoa In pessoas
                pessoasCadastradasListBox.Items.Add(pessoa)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonClick(sender As Object, e As RoutedEventArgs)
        Dim pessoaCadastradaEdit As New PessoaCadastradaEdit()
        NavigationService.Navigate(pessoaCadastradaEdit)
    End Sub
End Class
