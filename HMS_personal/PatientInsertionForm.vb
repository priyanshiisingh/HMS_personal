Public Class PatientInsertionForm

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        'DOB to string
        Dim date1 As String
        Dim date3() As String
        Dim size, i, j, size2 As Integer
        TextBox9.Text = DateTimePicker1.Value.Date
        date1 = TextBox9.Text.ToArray
        size = date1.Length
        ReDim date3(size)
        size2 = date3.Length
        For i = 0 To size - 1
            TextBox10.Text &= date1(i) & vbNewLine
            For j = 0 To size2 - 1
                If date1(i) <> "/" Then
                    date3(j) = date1(i)
                Else
                    date3(j) = vbNullChar
                End If
            Next
            TextBox11.Text &= date3(i)
        Next

        'IDcode generation
        Dim fname, lname, idcode As String
        Dim fshort(3), lshort(3) As String
        Dim k, l As Integer
        fname = TextBox3.Text.ToArray
        lname = TextBox1.Text.ToArray
        For k = 0 To 2
            For l = 0 To lshort.Length - 1
                lshort(l) = lname(k)
            Next
            TextBox12.Text &= lshort(k)
        Next
        For k = 0 To 2
            For l = 0 To fshort.Length - 1
                fshort(l) = fname(k)
            Next
            TextBox13.Text &= fshort(k)
        Next
        idcode = TextBox12.Text + TextBox13.Text
        TextBox14.Text = idcode

        'Unique id compile
        Dim datetb As String
        datetb = TextBox11.Text.ToString
        TextBox15.Text &= TextBox14.Text + datetb

        'INSERTION CODE
        Dim con As New OleDb.OleDbConnection
        Try
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\lenovo\Desktop\P projects\HMS_personal.accdb"
            con.Open()
            Dim cmd As New OleDb.OleDbCommand("insert into Patients (Unique_ID,LastName,FirstName,DOB,Address1,Address2,City,State,PINcode) values (@id,@lname,@fname,@dob,@address1,@address2,@city,@state,@pin)", con)
            cmd.Parameters.AddWithValue("@id", TextBox15.Text)
            cmd.Parameters.AddWithValue("@lname", TextBox1.Text)
            cmd.Parameters.AddWithValue("@fname", TextBox3.Text)
            cmd.Parameters.AddWithValue("@dob", DateTimePicker1.Text)
            cmd.Parameters.AddWithValue("@address1", TextBox4.Text)
            cmd.Parameters.AddWithValue("@address2", TextBox5.Text)
            cmd.Parameters.AddWithValue("@city", TextBox6.Text)
            cmd.Parameters.AddWithValue("@state", TextBox7.Text)
            cmd.Parameters.AddWithValue("@pin", TextBox8.Text)
            If cmd.ExecuteNonQuery() > 0 Then
                MessageBox.Show("RECORD INSERTED")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

End Class
