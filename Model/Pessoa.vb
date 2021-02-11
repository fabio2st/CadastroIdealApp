Public Class Pessoa
    Public Property ID As UInt32
    Public Property Nome As String
    Public Property Sobrenome As String
    Public Property Telefone As String
    Public Overrides Function ToString() As String
        Return String.Format("{0}, {1}", Sobrenome, Nome)
    End Function
End Class
