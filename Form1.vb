Imports System.Data
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbConnection
Imports System.Windows.Forms.MessageBox

Public Class encode

    Private pConnectionString As String =
        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Client\Desktop\db\DocumentsTracking.accdb"

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles actiontb.TextChanged

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged

    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        slevel.SelectedIndex = 0
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (CheckBox1.Checked = False) And (CheckBox2.Checked = False) And (CheckBox3.Checked = False) And (CheckBox4.Checked = False) And (CheckBox5.Checked = False) And (CheckBox6.Checked = False) And (CheckBox8.Checked = False) And (CheckBox9.Checked = False) And (CheckBox10.Checked = False) And (CheckBox11.Checked = False) And (CheckBox12.Checked = False) Then
            MessageBox.Show("Please Checked atleast one (1) Category!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Try
                Dim sqlconn As New OleDbConnection
                Dim sqlquery As New OleDbCommand
                sqlconn.ConnectionString = pConnectionString
                sqlquery.Connection = sqlconn
                sqlconn.Open()
                sqlquery.CommandText = "INSERT INTO [Legal Unit]([Control No], [Division], [Date Received], [School], [Charge/s] , [Complainant], [Respondent], [Status], [Action Taken], [Date Released], [Relased to], [ADM No NCR], [PI and FI No], [Miscelleneous], [Complaint], [Charges against the Principal], [Child Abuse], [Bullying], [Cease & Desist],[DETxt Complaint], [Administrative Case], [Preliminary and Fact Finding  Investigaition], [Private], [SPED], [ES], [HS], [Letter])VALUES " +
                    "(@controlno, @division, @datereceived, @school, @charge, @complainant, @respondent, @status, @actiontaken, @datereleased, @relaseto, @admnoncr, @piandfino, @misc, @complaint, @catp, @child, @bull, @Cease, @detxt, @admin, @prelim, @pri, @SPED, @hs, @es, @letter)"
                sqlquery.Parameters.AddWithValue("@controlno", cntb.Text)
                sqlquery.Parameters.AddWithValue("@division", dtb.Text)
                sqlquery.Parameters.AddWithValue("@datereceived", DateTimePicker1.Value.ToString)
                sqlquery.Parameters.AddWithValue("@school", sotb.Text)
                sqlquery.Parameters.AddWithValue("@charge", chargestb.Text)
                sqlquery.Parameters.AddWithValue("@complainant", complainanttb.Text)
                sqlquery.Parameters.AddWithValue("@respondent", respondenttb.Text)
                sqlquery.Parameters.AddWithValue("@status", statustb.Text)
                sqlquery.Parameters.AddWithValue("@actiontaken", actiontb.Text)
                If (CheckBox7.Checked) Then
                    sqlquery.Parameters.AddWithValue("@datereleased", DBNull.Value)
                Else
                    sqlquery.Parameters.AddWithValue("@datereleased", DateTimePicker2.Value.ToString)
                End If
                sqlquery.Parameters.AddWithValue("@relaseto", releasedtb.Text)
                sqlquery.Parameters.AddWithValue("@admnoncr", admtb.Text)
                sqlquery.Parameters.AddWithValue("@piandfino", pifitb.Text)
                sqlquery.Parameters.AddWithValue("@misc", CheckBox1.Checked)
                sqlquery.Parameters.AddWithValue("@complaint", CheckBox2.Checked)
                sqlquery.Parameters.AddWithValue("@catp", CheckBox3.Checked)
                sqlquery.Parameters.AddWithValue("@child", CheckBox4.Checked)
                sqlquery.Parameters.AddWithValue("@bull", CheckBox5.Checked)
                sqlquery.Parameters.AddWithValue("@cease", CheckBox6.Checked)
                sqlquery.Parameters.AddWithValue("@detxt", CheckBox8.Checked)
                sqlquery.Parameters.AddWithValue("@admin", CheckBox9.Checked)
                sqlquery.Parameters.AddWithValue("@prelim", CheckBox10.Checked)
                sqlquery.Parameters.AddWithValue("@pri", (slevel.SelectedIndex = 2))
                sqlquery.Parameters.AddWithValue("@SPED", (slevel.SelectedIndex = 3))
                sqlquery.Parameters.AddWithValue("@hs", (slevel.SelectedIndex = 1))
                sqlquery.Parameters.AddWithValue("@es", (slevel.SelectedIndex = 0))
                sqlquery.Parameters.AddWithValue("@letter", CheckBox11.Checked)
                sqlquery.ExecuteNonQuery()
                sqlconn.Close()

                MessageBox.Show("Saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.None)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Controls.Clear()
        InitializeComponent()
    End Sub

    Private Sub TextBox11_TextChanged_1(sender As Object, e As EventArgs) Handles searchbox.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim t As New DataTable
        Dim adapter As OleDbDataAdapter = New OleDbDataAdapter()
        Dim con As OleDbConnection = New OleDbConnection(pConnectionString)
        Dim search As String = searchbox.Text
      
        con.Close()
        con.Open()

        Dim validSearch As Boolean = True
        Dim query As String = ""
        If (RadioButton1.Checked) Then
            query = "SELECT * FROM [Legal Unit] Where [ID] = @search"
        ElseIf (RadioButton2.Checked) Then
            query = "SELECT * FROM [Legal Unit] Where [Control No] = @search"
        ElseIf (RadioButton3.Checked) Then
            query = "SELECT * FROM [Legal Unit] Where [Complainant] like  '%'+@search+'%'"
        ElseIf (RadioButton4.Checked) Then
            query = "SELECT * FROM [Legal Unit] Where [Status] like '%'+@search+'%'"
        ElseIf (RadioButton5.Checked) Then
            query = "SELECT * FROM [Legal Unit] Where [Respondent] like '%'+@search+'%'"
        Else
            validSearch = False
            MessageBox.Show("Please select search category!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If (validSearch) Then
            Dim cmd As OleDbCommand = New OleDbCommand(query, con)
            cmd.Parameters.AddWithValue("@search", search)
            t.Load(cmd.ExecuteReader)

            Search1.DataGridView1.DataSource = t
            Search1.Show()
        End If

        con.Close()
    End Sub

    

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub


    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub chargestb_TextChanged(sender As Object, e As EventArgs) Handles chargestb.TextChanged

    End Sub

    Private Sub dtb_TextChanged(sender As Object, e As EventArgs) Handles dtb.TextChanged

    End Sub

    Private Sub Idtb_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cntb_TextChanged(sender As Object, e As EventArgs) Handles cntb.TextChanged

    End Sub

    Private Sub respondenttb_TextChanged(sender As Object, e As EventArgs) Handles respondenttb.TextChanged

    End Sub

    Private Sub pifitb_TextChanged(sender As Object, e As EventArgs) Handles pifitb.TextChanged

    End Sub

    Private Sub releasedtb_TextChanged(sender As Object, e As EventArgs) Handles releasedtb.TextChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub sotb_TextChanged(sender As Object, e As EventArgs) Handles sotb.TextChanged

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim search As String = searchbox.Text

            Dim update As String = "Update [Legal Unit] SET [Control No] = @controlNo, [Division] = @division, " +
                "[Date Received] = @dateReceived, [School] = @school, [Complainant] = @complainant, [Respondent] = @respondent, " +
                "[Charge/s] = @charges, [Status] = @status, [Action Taken] = @actionTaken, [Date Released] = @dateReleased, " +
                "[Relased to] = @releasedTo, [Adm No NCR] = @admNoNCR, [Administrative Case] = @adminCase, " +
                "[PI and FI No] = @pfNo, [Preliminary and Fact Finding  Investigaition] = @prem, [Complaint] = @complaint, " +
                "[DETxt Complaint] = @deTxt, [Child Abuse] = @childAbuse, [Bullying] = @bullying, " +
                "[Charges against the Principal] = @chargesPrincipal, [Cease & Desist] = @cease, [Miscelleneous] = @misc, " +
                "[Letter] = @letter, [Private] = @private, [SPED] = @sped, [ES] = @es, [HS] = @hs Where [ID] = @id"
            Using con = New OleDbConnection(pConnectionString)
                Using cmd = New OleDbCommand(update, con)
                    con.Close()
                    con.Open()
                    cmd.Parameters.AddWithValue("@controlNo", cntb.Text)
                    cmd.Parameters.AddWithValue("@division", dtb.Text)
                    cmd.Parameters.AddWithValue("@dateReceived", DateTimePicker1.Value.ToString)
                    cmd.Parameters.AddWithValue("@school", sotb.Text)
                    cmd.Parameters.AddWithValue("@complainant", complainanttb.Text)
                    cmd.Parameters.AddWithValue("@respondent", respondenttb.Text)
                    cmd.Parameters.AddWithValue("@charges", chargestb.Text)
                    cmd.Parameters.AddWithValue("@status", statustb.Text)
                    cmd.Parameters.AddWithValue("@actionTaken", actiontb.Text)
                    If (CheckBox7.Checked) Then
                        cmd.Parameters.AddWithValue("@dateReleased", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@dateReleased", DateTimePicker2.Value.ToString)
                    End If
                    cmd.Parameters.AddWithValue("@releasedTo", releasedtb.Text)
                    cmd.Parameters.AddWithValue("@admNoNCR", admtb.Text)
                    cmd.Parameters.AddWithValue("@adminCase", CheckBox9.Checked)
                    cmd.Parameters.AddWithValue("@pfNo", pifitb.Text)
                    cmd.Parameters.AddWithValue("@prem", CheckBox10.Checked)
                    cmd.Parameters.AddWithValue("@complaint", CheckBox2.Checked)
                    cmd.Parameters.AddWithValue("@deTxt", CheckBox8.Checked)
                    cmd.Parameters.AddWithValue("@childAbuse", CheckBox4.Checked)
                    cmd.Parameters.AddWithValue("@bullying", CheckBox5.Checked)
                    cmd.Parameters.AddWithValue("@chargesPrincipal", CheckBox3.Checked)
                    cmd.Parameters.AddWithValue("@cease", CheckBox6.Checked)
                    cmd.Parameters.AddWithValue("@misc", CheckBox1.Checked)
                    cmd.Parameters.AddWithValue("@letter", CheckBox11.Checked)
                    cmd.Parameters.AddWithValue("@private", (slevel.SelectedIndex = 2))
                    cmd.Parameters.AddWithValue("@sped", (slevel.SelectedIndex = 3))
                    cmd.Parameters.AddWithValue("@es", (slevel.SelectedIndex = 0))
                    cmd.Parameters.AddWithValue("@hs", (slevel.SelectedIndex = 1))
                    cmd.Parameters.AddWithValue("@id", LBLId.Text)
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Updated!", "Save", MessageBoxButtons.OK, MessageBoxIcon.None)
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("./. " + ex.Message)
        End Try
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Pending_Document.Show()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Print.Show()

    End Sub
End Class
