Public Class PatientDetailsAndUpdatingForm

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            updateButton.Visible = True
            RadioButton2.Enabled = False

            TextBox1.ReadOnly = True
            TextBox2.ReadOnly = True
            TextBox3.ReadOnly = True
            TextBox4.ReadOnly = True

            TextBox5.ReadOnly = False
            TextBox6.ReadOnly = False
            TextBox7.ReadOnly = False
            TextBox8.ReadOnly = False
            TextBox9.ReadOnly = False

        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles updateButton.Click
        Dim conn As New OleDb.OleDbConnection
        Try
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\lenovo\Desktop\P projects\HMS_personal.accdb"
            conn.Open()
            Dim cmmd As New OleDb.OleDbCommand("UPDATE Patients set Address1 = '" + TextBox5.Text + "', Address2 = '" + TextBox6.Text + "', City = '" + TextBox7.Text + "', State = '" + TextBox8.Text + "', PINcode = " + TextBox9.Text + " where Unique_ID='" + TextBox1.Text + "'", conn)

            If cmmd.ExecuteNonQuery Then
                MessageBox.Show("RECORD UPDATED")
            Else
                MessageBox.Show("RECORD NOT UPDATED")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class