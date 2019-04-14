Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRootDrives()
        ListView1.SmallImageList = ImageList1
        ListView1.LargeImageList = ImageList1
    End Sub

    Public Sub LoadRootDrives()
        For Each drive As DriveInfo In DriveInfo.GetDrives
            Dim node As New TreeNode(drive.Name)
            With node
                .Tag = drive.Name
                .ImageKey = "folder"
                .SelectedImageKey = drive.Name
                .Nodes.Add("Empty")
            End With

            TreeView1.Nodes.Add(node)
        Next
    End Sub

    Public Sub LoadChildren(nd As TreeNode, dir As String)
        Dim DirectoryInformation As New DirectoryInfo(dir)

        ListView1.Items.Clear()
        Dim SubItems() As ListViewItem.ListViewSubItem
        Dim Item As ListViewItem = Nothing

        Try
            'Load all sub folders into the node
            For Each d As DirectoryInfo In DirectoryInformation.GetDirectories

                If Not (d.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
                    Dim folder As New TreeNode(d.Name)

                    With folder
                        .Tag = d.FullName
                        .ImageKey = "folder"
                        .SelectedImageKey = "folder"
                        .Nodes.Add("*Empty*")
                    End With

                    nd.Nodes.Add(folder)

                    Item = New ListViewItem(d.Name, 4)
                    SubItems = New ListViewItem.ListViewSubItem() {New ListViewItem.ListViewSubItem(Item, "Directory"), New ListViewItem.ListViewSubItem(Item, d.LastAccessTime.ToShortDateString())}

                    Item.SubItems.AddRange(SubItems)
                    ListView1.Items.Add(Item)
                End If

            Next

            'load all files into the child nodes
            For Each file As FileInfo In DirectoryInformation.GetFiles
                If Not (file.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
                    Dim FN As New TreeNode(file.Name)
                    With FN
                        .Tag = file.FullName
                        .ImageKey = "file"
                        .SelectedImageKey = "file"
                    End With
                    nd.Nodes.Add(FN)

                    Dim file_type As String = "File"
                    Dim file_icon As Integer = 3

                    Select Case file.FullName.Split(".").LastOrDefault().ToLower()
                        'System Files
                        Case "dll"
                            file_type = "Dynamic Link Library"
                            file_icon = 10
                        Case "sys"
                            file_type = "System File"
                            file_icon = 10
                        Case "exe"
                            file_type = "Executable"
                            file_icon = 2
                        Case "jar"
                            file_type = "Executable"
                            file_icon = 2
                        Case "dat"
                            file_type = "Data File"

                        Case "ini"
                            file_type = "INI File"
                            file_icon = 6
                        Case "bat"
                            file_type = "Batch File"
                            file_icon = 13
                        Case "cmd"
                            file_type = "Command File"
                            file_icon = 14

                        'Text Files
                        Case "txt"
                            file_type = "Document"
                            file_icon = 1
                        Case "html"
                            file_type = "Document"
                            file_icon = 1
                        Case "css"
                            file_type = "Document"
                            file_icon = 1
                        Case "rtf"
                            file_type = "Document"
                            file_icon = 1
                        Case "text"
                            file_type = "Document"
                            file_icon = 1
                        Case "log"
                            file_type = "Document"
                            file_icon = 1
                        Case "yml"
                            file_type = "Document"
                            file_icon = 1
                        Case "xml"
                            file_type = "Document"
                            file_icon = 1

                        'Compression Formats
                        Case "zip"
                            file_type = "Compressed File"
                            file_icon = 0
                        Case "rar"
                            file_type = "Compressed File"
                            file_icon = 15
                        Case "7z"
                            file_type = "Compressed File"
                            file_icon = 0
                        Case "pak"
                            file_type = "Compressed File"
                            file_icon = 0
                        Case "rpf"
                            file_type = "Compressed File"
                            file_icon = 0

                        'Image Formats
                        Case "bin"
                            file_type = "System Image"
                            file_icon = 9
                        Case "iso"
                            file_type = "System Image"
                            file_icon = 9
                        Case "img"
                            file_type = "System Image"
                            file_icon = 9
                        Case "dmg"
                            file_type = "System Image"
                            file_icon = 9

                        'Picture Formats
                        Case "bmp"
                            file_type = "Image"
                            file_icon = 8
                        Case "jpg"
                            file_type = "Image"
                            file_icon = 8
                        Case "png"
                            file_type = "Image"
                            file_icon = 8
                        Case "gif"
                            file_type = "Image"
                            file_icon = 8
                        Case "tiff"
                            file_type = "Image"
                            file_icon = 8
                        Case "jpeg"
                            file_type = "Image"
                            file_icon = 8
                        Case "ico"
                            file_type = "Image"
                            file_icon = 8
                        Case "jfif"
                            file_type = "Image"
                            file_icon = 8

                        'Video Formats
                        Case "mp4"
                            file_type = "Video"
                            file_icon = 12
                        Case "webm"
                            file_type = "Video"
                            file_icon = 12
                        Case "3gp"
                            file_type = "Video"
                            file_icon = 12
                        Case "m4v"
                            file_type = "Video"
                            file_icon = 12
                        Case "flv"
                            file_type = "Video"
                            file_icon = 12
                        Case "mpeg"
                            file_type = "Video"
                            file_icon = 12
                        Case "mpe"
                            file_type = "Video"
                            file_icon = 12
                        Case "mov"
                            file_type = "Video"
                            file_icon = 12
                        Case "swf"
                            file_type = "Video"
                            file_icon = 12
                        Case "wmv"
                            file_type = "video"
                            file_icon = 12

                        'Music Formats
                        Case "mp1"
                            file_type = "Music"
                            file_icon = 7
                        Case "mp2"
                            file_type = "Music"
                            file_icon = 7
                        Case "mp3"
                            file_type = "Music"
                            file_icon = 7
                        Case "mp4"
                            file_type = "Music"
                            file_icon = 7
                        Case "wav"
                            file_type = "Music"
                            file_icon = 7
                        Case "m4a"
                            file_type = "Music"
                            file_icon = 7
                        Case "flac"
                            file_type = "Music"
                            file_icon = 7
                        Case "wma"
                            file_type = "Music"
                            file_icon = 7
                        Case "ogg"
                            file_type = "Music"
                            file_icon = 7

                        'Font Formats
                        Case "ttf"
                            file_type = "Font File"
                            file_icon = 11
                        Case "ufo"
                            file_type = "Font File"
                            file_icon = 11
                        Case "fnt"
                            file_type = "Font File"
                            file_icon = 11
                        Case Else
                            file_type = "File"
                            file_icon = 11
                    End Select

                    Item = New ListViewItem(file.Name, file_icon)
                    SubItems = New ListViewItem.ListViewSubItem() {New ListViewItem.ListViewSubItem(Item, file_type.ToString()), New ListViewItem.ListViewSubItem(Item, file.LastAccessTime.ToShortDateString())}

                    Item.SubItems.AddRange(SubItems)
                    ListView1.Items.Add(Item)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub TreeView1_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        Dim IsDriveReady As Boolean = (From d As DriveInfo In DriveInfo.GetDrives Where d.Name = e.Node.Tag Select d.IsReady).FirstOrDefault()

        If (e.Node.Tag <> "Desktop" AndAlso Not e.Node.Tag.Contains(":\")) OrElse IsDriveReady OrElse Directory.Exists(e.Node.Tag) Then
            e.Node.Nodes.Clear()
            LoadChildren(e.Node, e.Node.Tag.ToString)

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

    Private Sub CopyFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyFileToolStripMenuItem.Click
        Try
            Dim destination As String = InputBox("Enter the destination directory", "Copy File To", "C:/")
            My.Computer.FileSystem.CopyDirectory(TreeView1.SelectedNode.ImageKey.ToString(), destination.ToString())
        Catch ex As Exception
            ex = Nothing
        End Try
    End Sub

    Private Sub DeleteFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteFileToolStripMenuItem.Click
        Try
            Dim result As Integer = MessageBox.Show("Are you sure you would like to delete this file or folder?", "Are you sure?", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Yes Then
                My.Computer.FileSystem.DeleteDirectory(TreeView1.SelectedNode.Tag.ToString(), FileIO.DeleteDirectoryOption.DeleteAllContents)
                TreeView1.Nodes.Remove(TreeView1.SelectedNode)
            End If
        Catch ex As Exception
            ex = Nothing
        End Try
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        TextBox1.Text = e.Node.Tag.ToString()
    End Sub

    Private Sub TreeView1_AfterCollapse(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCollapse
        e.Node.Nodes.Clear()
        e.Node.Nodes.Add("Empty")
    End Sub

    Private Sub TreeView1_DoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        If e.Button = MouseButtons.Left AndAlso File.Exists(e.Node.Tag.ToString) Then
            Try
                Process.Start(e.Node.Tag.ToString())
            Catch ex As Exception
                ex = Nothing
            End Try
        End If
    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Dim DirectoryInformation As New DirectoryInfo(e.Node.Tag.ToString())

        ListView1.Items.Clear()
        Dim SubItems() As ListViewItem.ListViewSubItem
        Dim Item As ListViewItem = Nothing

        Try
            'Load all sub folders into the node
            For Each d As DirectoryInfo In DirectoryInformation.GetDirectories

                If Not (d.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
                    Item = New ListViewItem(d.Name, 4)
                    SubItems = New ListViewItem.ListViewSubItem() {New ListViewItem.ListViewSubItem(Item, "Directory"), New ListViewItem.ListViewSubItem(Item, d.LastAccessTime.ToShortDateString())}

                    Item.SubItems.AddRange(SubItems)
                    ListView1.Items.Add(Item)
                End If

            Next

            'load all files into the child nodes
            For Each file As FileInfo In DirectoryInformation.GetFiles
                If Not (file.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
                    Dim file_type As String = "File"
                    Dim file_icon As Integer = 3

                    Select Case file.FullName.Split(".").LastOrDefault().ToLower()
                        'System Files
                        Case "dll"
                            file_type = "Dynamic Link Library"
                            file_icon = 10
                        Case "sys"
                            file_type = "System File"
                            file_icon = 10
                        Case "exe"
                            file_type = "Executable"
                            file_icon = 2
                        Case "jar"
                            file_type = "Executable"
                            file_icon = 2
                        Case "dat"
                            file_type = "Data File"

                        Case "ini"
                            file_type = "INI File"
                            file_icon = 6
                        Case "bat"
                            file_type = "Batch File"
                            file_icon = 13
                        Case "cmd"
                            file_type = "Command File"
                            file_icon = 14

                        'Text Files
                        Case "txt"
                            file_type = "Document"
                            file_icon = 1
                        Case "html"
                            file_type = "Document"
                            file_icon = 1
                        Case "css"
                            file_type = "Document"
                            file_icon = 1
                        Case "rtf"
                            file_type = "Document"
                            file_icon = 1
                        Case "text"
                            file_type = "Document"
                            file_icon = 1
                        Case "log"
                            file_type = "Document"
                            file_icon = 1
                        Case "yml"
                            file_type = "Document"
                            file_icon = 1
                        Case "xml"
                            file_type = "Document"
                            file_icon = 1

                        'Compression Formats
                        Case "zip"
                            file_type = "Compressed File"
                            file_icon = 0
                        Case "rar"
                            file_type = "Compressed File"
                            file_icon = 15
                        Case "7z"
                            file_type = "Compressed File"
                            file_icon = 0
                        Case "pak"
                            file_type = "Compressed File"
                            file_icon = 0
                        Case "rpf"
                            file_type = "Compressed File"
                            file_icon = 0

                        'Image Formats
                        Case "bin"
                            file_type = "System Image"
                            file_icon = 9
                        Case "iso"
                            file_type = "System Image"
                            file_icon = 9
                        Case "img"
                            file_type = "System Image"
                            file_icon = 9
                        Case "dmg"
                            file_type = "System Image"
                            file_icon = 9

                        'Picture Formats
                        Case "bmp"
                            file_type = "Image"
                            file_icon = 8
                        Case "jpg"
                            file_type = "Image"
                            file_icon = 8
                        Case "png"
                            file_type = "Image"
                            file_icon = 8
                        Case "gif"
                            file_type = "Image"
                            file_icon = 8
                        Case "tiff"
                            file_type = "Image"
                            file_icon = 8
                        Case "jpeg"
                            file_type = "Image"
                            file_icon = 8
                        Case "ico"
                            file_type = "Image"
                            file_icon = 8
                        Case "jfif"
                            file_type = "Image"
                            file_icon = 8

                        'Video Formats
                        Case "mp4"
                            file_type = "Video"
                            file_icon = 12
                        Case "webm"
                            file_type = "Video"
                            file_icon = 12
                        Case "3gp"
                            file_type = "Video"
                            file_icon = 12
                        Case "m4v"
                            file_type = "Video"
                            file_icon = 12
                        Case "flv"
                            file_type = "Video"
                            file_icon = 12
                        Case "mpeg"
                            file_type = "Video"
                            file_icon = 12
                        Case "mpe"
                            file_type = "Video"
                            file_icon = 12
                        Case "mov"
                            file_type = "Video"
                            file_icon = 12
                        Case "swf"
                            file_type = "Video"
                            file_icon = 12
                        Case "wmv"
                            file_type = "video"
                            file_icon = 12

                        'Music Formats
                        Case "mp1"
                            file_type = "Music"
                            file_icon = 7
                        Case "mp2"
                            file_type = "Music"
                            file_icon = 7
                        Case "mp3"
                            file_type = "Music"
                            file_icon = 7
                        Case "mp4"
                            file_type = "Music"
                            file_icon = 7
                        Case "wav"
                            file_type = "Music"
                            file_icon = 7
                        Case "m4a"
                            file_type = "Music"
                            file_icon = 7
                        Case "flac"
                            file_type = "Music"
                            file_icon = 7
                        Case "wma"
                            file_type = "Music"
                            file_icon = 7
                        Case "ogg"
                            file_type = "Music"
                            file_icon = 7

                        'Font Formats
                        Case "ttf"
                            file_type = "Font File"
                            file_icon = 11
                        Case "ufo"
                            file_type = "Font File"
                            file_icon = 11
                        Case "fnt"
                            file_type = "Font File"
                            file_icon = 11
                        Case Else
                            file_type = "File"
                            file_icon = 11
                    End Select

                    Item = New ListViewItem(file.Name, file_icon)
                    SubItems = New ListViewItem.ListViewSubItem() {New ListViewItem.ListViewSubItem(Item, file_type.ToString()), New ListViewItem.ListViewSubItem(Item, file.LastAccessTime.ToShortDateString())}

                    Item.SubItems.AddRange(SubItems)
                    ListView1.Items.Add(Item)
                End If
            Next
        Catch ex As Exception
            ex = Nothing
        End Try
    End Sub
End Class
