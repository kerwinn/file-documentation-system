Public Class Pending_Document

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        
    End Sub

    Private Sub Pending_Document_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
        Dim sqlconn As New OleDb.OleDbConnection
        Dim sqlquery As New OleDb.OleDbCommand
        Dim connString As String
        Dim dt = New DataTable
        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Client\Desktop\db\DocumentsTracking.accdb"
        sqlconn.ConnectionString = connString
        sqlquery.Connection = sqlconn
        sqlconn.Close()
        sqlconn.Open()

        Dim da As New OleDb.OleDbDataAdapter("SELECT [Legal Unit].[Date Received], [Legal Unit].*, [Legal Unit].[Date Released], [Legal Unit].[Relased to] FROM [Legal Unit] WHERE DATEADD('d', 15, [Date Received]) <= DATE() AND Trim(Status & '') = '' AND [Date Released] IS NULL AND Letter AND Trim([Action Taken] & '') = '' ORDER BY [Legal Unit].[Date Received] DESC", sqlconn)

        da.Fill(dt)

        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sqlconn As New OleDb.OleDbConnection
        Dim sqlquery As New OleDb.OleDbCommand
        Dim connString As String
        Dim dt = New DataTable
        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Client\Desktop\db\DocumentsTracking.accdb"
        sqlconn.ConnectionString = connString
        sqlquery.Connection = sqlconn
        sqlconn.Close()
        sqlconn.Open()

        Dim da As New OleDb.OleDbDataAdapter("SELECT [Legal Unit].[Date Received], [Legal Unit].*, [Legal Unit].[Date Released], [Legal Unit].[Relased to] FROM [Legal Unit] WHERE DATEADD('d', 15, [Date Received]) <= DATE() AND Trim(Status & '') = '' AND [Date Released] IS NULL AND Letter AND Trim([Action Taken] & '') = '' ORDER BY [Legal Unit].[Date Received] DESC", sqlconn)

        da.Fill(dt)

        DataGridView1.DataSource = dt
    End Sub
End Class