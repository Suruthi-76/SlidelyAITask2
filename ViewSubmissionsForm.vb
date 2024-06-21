Public Class ViewSubmissionsForm
    Private currentIndex As Integer = 0
    Private submissions As List(Of Submission)

    Private Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSubmissions()
        DisplaySubmission(currentIndex)
    End Sub

    Private Sub LoadSubmissions()
        ' Make API call to /read to load submissions
        ' For now, mock data will be used
        submissions = New List(Of Submission) From {
            New Submission With {.Name = "John Doe", .Email = "john@example.com", .Phone = "1234567890", .GitHubLink = "https://github.com/johndoe", .StopwatchTime = "00:10:00"},
            New Submission With {.Name = "Jane Smith", .Email = "jane@example.com", .Phone = "0987654321", .GitHubLink = "https://github.com/janesmith", .StopwatchTime = "00:05:30"}
        }
    End Sub

    Private Sub DisplaySubmission(index As Integer)
        If index >= 0 AndAlso index < submissions.Count Then
            Dim submission = submissions(index)
            ' Display the submission details
            lblDetails.Text = $"Name: {submission.Name}" & vbCrLf &
                              $"Email: {submission.Email}" & vbCrLf &
                              $"Phone: {submission.Phone}" & vbCrLf &
                              $"GitHub: {submission.GitHubLink}" & vbCrLf &
                              $"Stopwatch: {submission.StopwatchTime}"
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            DisplaySubmission(currentIndex)
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            DisplaySubmission(currentIndex)
        End If
    End Sub
End Class

Public Class Submission
    Public Property Name As String
    Public Property Email As String
    Public Property Phone As String
    Public Property GitHubLink As String
    Public Property StopwatchTime As String
End Class
