Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
    If e.Control AndAlso e.KeyCode = Keys.S Then
        btnSubmit.PerformClick()
    End If
End Sub

Private Sub ViewSubmissionsForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
    If e.KeyCode = Keys.Left Then
        btnPrevious.PerformClick()
    ElseIf e.KeyCode = Keys.Right Then
        btnNext.PerformClick()
    End If
End Sub
