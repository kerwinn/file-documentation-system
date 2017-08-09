Imports System.Data.OleDb

Public Class Print
    Private pConnectionString As String =
        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Client\Desktop\db\DocumentsTracking.accdb"


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dateEnd As String = DateTimePicker2.Value
        Dim datestart As String = DateTimePicker1.Value
        Dim t As New DataTable
        Dim adapter As OleDbDataAdapter = New OleDbDataAdapter()
        Dim con As OleDbConnection = New OleDbConnection(pConnectionString)


        con.Close()
        con.Open()

        Dim qry As String = ("Select [Control No], [Division], [Date Received], [School], [Complainant], [Respondent], [Charge/s], [Status], [Action Taken], [Date Released] FROM [Legal Unit] WHERE ((([Legal Unit].[Date Released])>= @datestart ) AND (([Legal Unit].[Date Released])<= @dateEnd ))")

        Dim cmd As OleDbCommand = New OleDbCommand(qry, con)
        cmd.Parameters.AddWithValue("@datestart", datestart)
        cmd.Parameters.AddWithValue("@dateEnd", dateEnd)
        t.Load(cmd.ExecuteReader)

        DataGridView1.DataSource = t

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PrintDocument1.Print()
    End Sub
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        DataGridView1.DrawToBitmap(bm, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        e.Graphics.DrawImage(bm, 0, 0)
    End Sub

End Class