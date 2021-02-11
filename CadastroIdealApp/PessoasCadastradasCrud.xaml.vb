Imports System
Imports System.Collections.Generic
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Documents
Imports Model
Imports Controllers
Class PessoasCadastradasCrud
    Inherits Page
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Sub PessoasCadastradasCrud_Loaded(sender As Object, e As RoutedEventArgs)
        LoadListbox()
    End Sub
    Private Sub EditarButton_Click(sender As Object, e As RoutedEventArgs)
        Dim pessoa As Pessoa = pessoasCadastradasListBox.SelectedItem
        Dim pessoaCadastradaEdit As New PessoaCadastradaEdit(pessoa)
        NavigationService.Navigate(pessoaCadastradaEdit)
    End Sub
    Private Sub RemoverButton_Click(sender As Object, e As RoutedEventArgs)
        Dim pessoa As Pessoa = pessoasCadastradasListBox.SelectedItem
        If pessoa IsNot Nothing Then
            If MessageBox.Show("Tem certeza que está removendo " & pessoa.ToString(), Me.Title, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) Then
                PessoaDelete(pessoa)
            End If
        End If
    End Sub
    Private Async Sub LoadListbox()
        Try
            Dim pessoas = Await PessoasController.SelectAll()
            pessoasCadastradasListBox.Items.Clear()
            For Each pessoa As Pessoa In pessoas
                pessoasCadastradasListBox.Items.Add(pessoa)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Async Sub PessoaDelete(pessoa As Pessoa)
        Try
            Await PessoasController.Delete(pessoa)
            LoadListbox()
        Catch ex As Exception
            MessageBox.Show($"A operação falhou: {ex.Message}")
        End Try
    End Sub
End Class
