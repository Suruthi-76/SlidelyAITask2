Public Class CreateSubmissionForm
    Private stopwatchRunning As Boolean = False
    Private stopwatchStartTime As DateTime
    Private stopwatchElapsedTime As TimeSpan

    Private Sub btnStopwatch_Click(sender As Object, e As EventArgs) Handles btnStopwatch.Click
        If stopwatchRunning Then
            stopwatchRunning = False
            stopwatchElapsedTime += DateTime.Now - stopwatchStartTime
            Timer1.Stop()
        Else
            stopwatchRunning = True
            stopwatchStartTime = DateTime.Now
            Timer1.Start()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim currentTime = stopwatchElapsedTime + (DateTime.Now - stopwatchStartTime)
        lblStopwatch.Text = currentTime.ToString("hh\:mm\:ss")
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Make API call to /submit to save the submission
        ' For now, just show a message box
        MessageBox.Show("Submission saved!")
    End Sub
End Class
