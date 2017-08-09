Imports System.Windows.Forms


Public Class Search1

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Search_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub DataGridView_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim i As Integer
        i = DataGridView1.CurrentRow.Index


        Dim id As String = Convert.ToString(DataGridView1.Item(0, i).Value)
        Dim control_No As String = Convert.ToString(DataGridView1.Item(1, i).Value)
        Dim division As String = Convert.ToString(DataGridView1.Item(2, i).Value)
        Dim date_received As String = Convert.ToString(DataGridView1.Item(3, i).Value)
        Dim school As String = Convert.ToString(DataGridView1.Item(4, i).Value)
        Dim complainant As String = Convert.ToString(DataGridView1.Item(5, i).Value)
        Dim respondent As String = Convert.ToString(DataGridView1.Item(6, i).Value)
        Dim charges As String = Convert.ToString(DataGridView1.Item(7, i).Value)
        Dim status As String = Convert.ToString(DataGridView1.Item(8, i).Value)
        Dim actiontaken As String = Convert.ToString(DataGridView1.Item(9, i).Value)
        Dim datereleased As String = Convert.ToString(DataGridView1.Item(11, i).Value)
        Dim releaseto As String = Convert.ToString(DataGridView1.Item(12, i).Value)
        Dim adm As String = Convert.ToString(DataGridView1.Item(13, i).Value)
        Dim administrative As Boolean = DataGridView1.Item(14, i).Value
        Dim pi As String = Convert.ToString(DataGridView1.Item(15, i).Value)
        Dim preliminary As Boolean = DataGridView1.Item(16, i).Value
        Dim complaint As Boolean = DataGridView1.Item(17, i).Value
        Dim detxt As Boolean = DataGridView1.Item(18, i).Value
        Dim child As Boolean = DataGridView1.Item(19, i).Value
        Dim bully As Boolean = DataGridView1.Item(20, i).Value
        Dim chargesAgainst As Boolean = DataGridView1.Item(21, i).Value
        Dim pri As Boolean = DataGridView1.Item(22, i).Value
        Dim sped As Boolean = DataGridView1.Item(23, i).Value
        Dim cease As Boolean = DataGridView1.Item(24, i).Value
        Dim es As Boolean = DataGridView1.Item(25, i).Value
        Dim hs As Boolean = DataGridView1.Item(26, i).Value
        Dim miscelleneous As Boolean = DataGridView1.Item(27, i).Value
        Dim letter As Boolean = DataGridView1.Item(28, i).Value


        encode.LBLId.Text = id
        encode.cntb.Text = control_No
        encode.dtb.Text = division
        If (date_received.ToString = " ") Then
            encode.DateTimePicker1.Value = Date.Today
        Else
            encode.DateTimePicker1.Value = Convert.ToDateTime(date_received)
        End If
        encode.sotb.Text = school
        encode.complainanttb.Text = complainant
        encode.respondenttb.Text = respondent
        encode.chargestb.Text = charges
        encode.statustb.Text = status
        encode.actiontb.Text = actiontaken
        If (datereleased.ToString = Nothing) Or (datereleased.ToString = " ") Then
            encode.CheckBox7.Checked = True
        Else
            encode.DateTimePicker2.Value = datereleased.ToString
            encode.CheckBox7.Checked = False
        End If
        encode.releasedtb.Text = releaseto
        encode.pifitb.Text = pi
        encode.admtb.Text = adm

        If (pri = True) Then
            encode.slevel.SelectedIndex = 2
        ElseIf (es = True) Then
            encode.slevel.SelectedIndex = 0
        ElseIf (hs = True) Then
            encode.slevel.SelectedIndex = 1
        ElseIf (sped = True) Then
            encode.slevel.SelectedIndex = 3
        End If

        encode.CheckBox1.Checked = miscelleneous
        encode.CheckBox2.Checked = complaint
        encode.CheckBox3.Checked = chargesAgainst
        encode.CheckBox4.Checked = child
        encode.CheckBox5.Checked = bully
        encode.CheckBox6.Checked = cease
        encode.CheckBox8.Checked = detxt
        encode.CheckBox9.Checked = administrative
        encode.CheckBox10.Checked = preliminary
        encode.CheckBox11.Checked = letter

    End Sub
End Class