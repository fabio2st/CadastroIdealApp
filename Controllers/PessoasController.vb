Imports System
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Threading.Tasks
Imports Model
Public Class PessoasController
    Shared client As New HttpClient()
    Shared Sub New()
        'client.BaseAddress = New Uri("https://localhost:5001")
        client.BaseAddress = New Uri("https://cadastroidealapi20210212012143.azurewebsites.net")
        client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
    End Sub
    Shared Async Function SelectAll() As Task(Of IEnumerable(Of Pessoa))
        Try
            Dim response As HttpResponseMessage = Await client.GetAsync("/api/Pessoas")
            response.EnsureSuccessStatusCode()
            Return Await response.Content.ReadAsAsync(Of IEnumerable(Of Pessoa))()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Shared Async Function SelectOne(id As UInteger) As Task(Of Pessoa)
        Try
            Dim response As HttpResponseMessage = Await client.GetAsync($"/api/Pessoas/{id}")
            response.EnsureSuccessStatusCode()
            Return Await response.Content.ReadAsAsync(Of Pessoa)()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Shared Async Function Update(pessoa As Pessoa) As Task
        Try
            Dim response As HttpResponseMessage = Await client.PutAsJsonAsync($"api/Pessoas/{pessoa.ID}", pessoa)
            response.EnsureSuccessStatusCode()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Shared Async Function Insert(pessoa As Pessoa) As Task
        Try
            Dim response As HttpResponseMessage = Await client.PostAsJsonAsync($"api/Pessoas", pessoa)
            response.EnsureSuccessStatusCode()
        Catch ex As ArgumentException
            Throw ex
        Catch ex As Exception
            Throw New ArgumentException("Valide os dados inseridos")
        End Try
    End Function
    Shared Async Function Delete(pessoa As Pessoa) As Task
        Try
            Dim response = Await client.DeleteAsync($"/api/Pessoas/{pessoa.ID}")
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
