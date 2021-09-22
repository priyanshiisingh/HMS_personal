Public Class PatientSearchingForm

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim con As New OleDb.OleDbConnection
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\lenovo\Desktop\P projects\HMS_personal.accdb"
        con.Open()
        Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("select Unique_ID,LastName, FirstName, DOB from Patients where Unique_ID like '" + TextBox1.Text + "%'", con)
        Dim ds As New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As System.EventArgs) Handles TextBox1.Click
        Button1.Visible = True
        TextBox2.Enabled = False
        Button2.Visible = False
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As System.EventArgs) Handles TextBox2.Click
        Button2.Visible = True
        TextBox1.Enabled = False
        Button1.Visible = False
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim conn As New OleDb.OleDbConnection
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\lenovo\Desktop\P projects\HMS_personal.accdb"
        conn.Open()
        Dim daa As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("select Unique_ID,LastName, FirstName, DOB from Patients where DOB like '" + TextBox2.Text + "%'", conn)
        Dim dss As New DataSet
        daa.Fill(dss)
        DataGridView1.DataSource = dss.Tables(0)
        conn.Close()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Enabled = True
        TextBox2.Enabled = True
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        PatientDetailsAndUpdatingForm.Show()
        Dim i, j As Integer
        i = e.RowIndex
        j = e.ColumnIndex
        PatientDetailsAndUpdatingForm.TextBox1.Text = DataGridView1.Item(i, j).Value

        'Inserting details in PatientDetailsAndUpdatingForm
        Dim con As New OleDb.OleDbConnection
        Try
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\lenovo\Desktop\P projects\HMS_personal.accdb"
            con.Open()
            Dim cmd As New OleDb.OleDbCommand("select * from Patients where Unique_ID=@id", con)
            cmd.Parameters.AddWithValue("id", PatientDetailsAndUpdatingForm.TextBox1.Text)
            Dim dr As OleDb.OleDbDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                PatientDetailsAndUpdatingForm.TextBox2.Text = dr(2)
                PatientDetailsAndUpdatingForm.TextBox3.Text = dr(3)
                PatientDetailsAndUpdatingForm.TextBox4.Text = dr(4)
                PatientDetailsAndUpdatingForm.TextBox5.Text = dr(5)
                PatientDetailsAndUpdatingForm.TextBox6.Text = dr(6)
                PatientDetailsAndUpdatingForm.TextBox7.Text = dr(7)
                PatientDetailsAndUpdatingForm.TextBox8.Text = dr(8)
                PatientDetailsAndUpdatingForm.TextBox9.Text = dr(9)
            Else
                MessageBox.Show("Record not found")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        con.Close()
        
    End Sub

    
    Private Sub TextBox1_TextChanged(sender As Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Button1.Visible = True
        TextBox2.Enabled = False
        Button2.Visible = False
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As System.EventArgs) Handles TextBox2.TextChanged
        Button2.Visible = True
        TextBox1.Enabled = False
        Button1.Visible = False
    End Sub

End Class



'LastName, FirstName, DOB

'Dim conn As New OleDb.OleDbConnection
'        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\lenovo\Desktop\P projects\HMS_personal.accdb"
'        conn.Open()
'Dim daa As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("select LastName, FirstName, DOB from Patients where DOB like '" + TextBox2.Text + "%'", conn)
'Dim dss As New DataSet
'        daa.Fill(dss)
'        DataGridView1.DataSource = dss.Tables(0)
'        conn.Close()