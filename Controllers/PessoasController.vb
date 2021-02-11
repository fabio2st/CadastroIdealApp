Imports System
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Threading.Tasks
Imports Model
Public Class PessoasController
    Shared client As New HttpClient()
    Shared Sub New()
        client.BaseAddress = New Uri("https://localhost:5001")
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
    Shared Async Function Delete(pessoa As Pessoa) As Task
        Try
            Dim response = Await client.DeleteAsync($"/api/Pessoas/{pessoa.ID}")
            'Await SelectAll()
            'Return response.StatusCode
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
