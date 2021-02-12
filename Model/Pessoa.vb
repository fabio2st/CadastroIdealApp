Public Class Pessoa
    Private _Nome As String
    Private _Sobrenome As String
    Private _Telefone As String
    Public Property ID As UInt32
    Public Property Nome As String
        Get
            Return _Nome
        End Get
        Set
            If String.IsNullOrWhiteSpace(Value) Then
                Throw New ArgumentException("O nome é inválido")
            End If
            _Nome = Value
        End Set
    End Property

    Public Property Sobrenome As String
        Get
            Return _Sobrenome
        End Get
        Set
            If String.IsNullOrWhiteSpace(Value) Then
                Throw New ArgumentException("O sobrenome é inválido")
            End If
            _Sobrenome = Value
        End Set
    End Property

    Public Property Telefone As String
        Get
            Return _Telefone
        End Get
        Set
            If String.IsNullOrWhiteSpace(Value) Then
                Throw New ArgumentException("O telefone é inválido")
            End If
            _Telefone = Value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return String.Format("{0}, {1}", Sobrenome, Nome)
    End Function
End Class
