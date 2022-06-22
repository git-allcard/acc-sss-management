
Imports System.IO
Public Class Log

    Public Shared ErrorLog As String = ""
    Public Shared SystemLog As String = ""
    Public Shared SETUpdateLog As String = ""

    Enum logType
        systemLog = 1
        errorLog
        setUpdateLog
    End Enum

    Public Shared Sub SaveLog(ByVal logType As logType, ByVal desc As String)
        Dim logFolder As String = String.Concat(Application.StartupPath, "\Log\", Now.ToString("yyyyMMdd"))
        If Not System.IO.Directory.Exists(logFolder) Then System.IO.Directory.CreateDirectory(logFolder)

        Dim logName As String = ""
        Select Case logType
            Case logType.systemLog
                logName = Path.Combine(logFolder, "System.txt")
            Case logType.errorLog
                logName = Path.Combine(logFolder, "Error.txt")
            Case logType.setUpdateLog
                logName = Path.Combine(logFolder, "SETUpdate.txt")
        End Select

        Dim SW As New IO.StreamWriter(logName, True)
        SW.WriteLine(String.Concat(Timestamp, " ", desc.Trim))
        SW.Close()
        SW.Dispose()
        SW = Nothing
    End Sub

    Public Shared Function Timestamp() As String
        Return Now.ToString("MM/dd/yyyy hh:mm:ss tt")
    End Function



End Class
