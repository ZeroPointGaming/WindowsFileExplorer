Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRootDrives()
    End Sub

    Public Sub LoadRootDrives()
        For Each drive As DriveInfo In DriveInfo.GetDrives
            Dim node As New TreeNode(drive.Name)
            With node
                .Tag = drive.Name
                .ImageKey = drive.Name
                .Nodes.Add("Empty")
            End With

            TreeView1.Nodes.Add(node)
        Next
    End Sub

    Public Sub LoadChildren(nd As TreeNode, dir As String)
        Dim DirectoryInformation As New DirectoryInfo(dir)

        Try
            For Each d As DirectoryInfo In DirectoryInformation.GetDirectories

                If Not (d.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
                    Dim folder As New TreeNode(d.Name)

                    With folder
                        .Tag = d.FullName
                        .ImageKey = d.FullName
                        .Nodes.Add("*Empty*")
                    End With

                    nd.Nodes.Add(folder)
                End If

            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub TreeView1_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        Dim IsDriveReady As Boolean = (From d As DriveInfo In DriveInfo.GetDrives Where d.Name = e.Node.ImageKey Select d.IsReady).FirstOrDefault()

        If (e.Node.ImageKey <> "Desktop" AndAlso Not e.Node.ImageKey.Contains(":\")) OrElse IsDriveReady OrElse Directory.Exists(e.Node.ImageKey) Then
            e.Node.Nodes.Clear()
            LoadChildren(e.Node, e.Node.ImageKey.ToString)

        ElseIf e.Node.ImageKey = "Dekstop" Then
            e.Node.Nodes.Clear()

            Dim DesktopFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)
            Dim UserDesktopFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

            LoadChildren(e.Node, UserDesktopFolder)
            LoadChildren(e.Node, DesktopFolder)
        Else
            e.Cancel = True
            MessageBox.Show("Error drive is empty, " + e.Node.ImageKey.ToString())
        End If

    End Sub
End Class
