Public Class Class1
    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
        (ByVal lpApplicationName As String,
         ByVal lpKeyName As String,
         ByVal lpDefault As String,
         ByVal lpReturnedString As System.Text.StringBuilder,
         ByVal nSize As Integer,
         ByVal lpFileName As String) _
     As Integer

    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
        (ByVal lpApplicationName As String,
         ByVal lpKeyName As String,
         ByVal lpString As String,
         ByVal lpFileName As String) _
    As Integer

    Public Function ReadValue(ByVal path As String, ByVal section As String, ByVal key As String) As String
        Dim sb As New System.Text.StringBuilder(255)
        Dim i = GetPrivateProfileString(section, key, "", sb, 255, path)
        Return sb.ToString()
    End Function

    Public Sub WriteValue(ByVal path As String, ByVal section As String, ByVal key As String, ByVal value As String)
        WritePrivateProfileString(section, key, value, path)
    End Sub

End Class
