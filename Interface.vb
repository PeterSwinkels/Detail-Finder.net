'This module's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Convert
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms

'This module contains this program's interface.
Public Class InterfaceWindow
   Private ReadOnly IMAGE_EXTENSIONS As New List(Of String)({".bmp", ".emf", ".exif", ".gif", ".ico", ".jpg", ".jpeg", ".png", ".tif", ".tiff", ".wmf"})                                                                                                                                                                                       'The extensions of the supported image file types.

   Private CurrentImage As Bitmap = Nothing 'Contains the currently loaded image.

   'This procedure initializes this window.
   Public Sub New()
      Try
         Me.InitializeComponent()

         Directory.SetCurrentDirectory(My.Application.Info.DirectoryPath)

         With My.Computer.Screen.WorkingArea
            Me.ClientSize = New Size(CInt(.Width / 1.5), CInt(.Height / 1.5))
         End With

         Me.Text = ProgramInformation()

         ImageBox.AllowDrop = True
         ImageBox.Width = ImagePanel.Width
         ImageBox.Height = ImagePanel.Height

         AddHandler HighlightColorBar.Scroll, AddressOf UpdateHighlights
         AddHandler HighlightModeBox1.CheckedChanged, AddressOf UpdateHighlights
         AddHandler HighlightModeBox2.CheckedChanged, AddressOf UpdateHighlights
         AddHandler HighlightModeBox3.CheckedChanged, AddressOf UpdateHighlights
         AddHandler LowerThresholdBox.LostFocus, AddressOf UpdateHighlights
         AddHandler UpperThresholdBox.LostFocus, AddressOf UpdateHighlights
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to analyze the current image.
   Private Sub AnalyzeButton_Click(sender As Object, e As EventArgs) Handles AnalyzeButton.Click
      Try
         If Not CurrentImage Is Nothing Then
            MousePointer(Busy:=True)
            ImageBox.Image = DrawResults(CurrentImage, AnalyzeImage(New Bitmap(ImageBox.Image), ToInt32(PrecisionBox.Text), New Size(ToInt32(XGridSizeBox.Text), ToInt32(YGridSizeBox.Text))), ToInt32(LowerThresholdBox.Text), ToInt32(UpperThresholdBox.Text), HighlightColorBox.BackColor, GetHighlightMode())
            MousePointer(Busy:=False)
         End If
      Catch ExceptionO As Exception
         MousePointer(Busy:=False)
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure changes the current directory.
   Private Sub DirectoryListBox_DoubleClick(sender As Object, e As EventArgs) Handles DirectoryListBox.DoubleClick
      Try
         If Not DirectoryListBox.Text = Nothing Then
            Directory.SetCurrentDirectory(DirectoryListBox.Text)
            UpdateDirectoryList()
            UpdateFilesList()
         End If
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to update the list of drives.
   Private Sub DriveListBox_GotFocus(sender As Object, e As EventArgs) Handles DriveListBox.GotFocus
      Try
         UpdateDriveList()
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to update the directory list box.
   Private Sub DriveListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DriveListBox.SelectedIndexChanged
      Try
         Directory.SetCurrentDirectory(GetDrive(DriveListBox.Text))
         UpdateDirectoryList()
         UpdateFilesList()
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      Finally
         SelectCurrentDrive()
      End Try
   End Sub

   'This procedure loads the selected image.
   Private Sub FileListBox_DoubleClick(sender As Object, e As EventArgs) Handles FileListBox.DoubleClick
      Try
         If Not FileListBox.Text = Nothing Then
            CurrentImage = New Bitmap(Path.Combine(Directory.GetCurrentDirectory(), FileListBox.Text))
            ImageBox.Image = CurrentImage
         End If
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure enables/disables the image grabber.
   Private Sub GrabFromClipboardBox_CheckedChanged(sender As Object, e As EventArgs) Handles GrabFromClipboardBox.CheckedChanged
      Try
         ImageGrabber.Enabled = GrabFromClipboardBox.Checked
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to load the file dropped into the image box.
   Private Sub ImageBox_DragDrop(sender As Object, e As DragEventArgs) Handles ImageBox.DragDrop
      Try
         If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            CurrentImage = New Bitmap(DirectCast(e.Data.GetData(DataFormats.FileDrop), String())(0))
            ImageBox.Image = CurrentImage
         End If
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure handles objects being dragged into the image box.
   Private Sub ImageBox_DragEnter(sender As Object, e As DragEventArgs) Handles ImageBox.DragEnter
      Try
         If e.Data.GetDataPresent(DataFormats.FileDrop) Then e.Effect = DragDropEffects.All
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure displays the information for the seleected image section.
   Private Sub ImageBox_MouseMove(sender As Object, e As MouseEventArgs) Handles ImageBox.MouseMove
      Try
         Me.Text = ProgramInformation()

         With AnalyzeImage()
            If Not .Levels Is Nothing AndAlso .Steps.Width > 0 AndAlso .Steps.Height > 0 Then Me.Text &= $" - Detail Level: { .Levels(e.X \ .Steps.Width, e.Y \ .Steps.Height)}"
         End With
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure waits for an image to be copied to the clipboard and sets it as the current image.
   Private Sub ImageGrabber_Tick(sender As Object, e As EventArgs) Handles ImageGrabber.Tick
      Try
         If Clipboard.ContainsImage() Then
            MousePointer(Busy:=True)
            CurrentImage = New Bitmap(Clipboard.GetImage())
            ImageBox.Image = CurrentImage
            Clipboard.Clear()
            ImageBox.Image = DrawResults(New Bitmap(ImageBox.Image), AnalyzeImage(New Bitmap(ImageBox.Image), ToInt32(PrecisionBox.Text), New Size(ToInt32(XGridSizeBox.Text), ToInt32(YGridSizeBox.Text))), ToInt32(LowerThresholdBox.Text), ToInt32(UpperThresholdBox.Text), HighlightColorBox.BackColor, GetHighlightMode())
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            MousePointer(Busy:=False)
         End If
      Catch ExceptionO As Exception
         MousePointer(Busy:=False)
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure updates the tooltip specifying the current image's size.
   Private Sub ImageBox_Resize(sender As Object, e As System.EventArgs) Handles ImageBox.Resize
      Try
         ToolTipBox.SetToolTip(ImageBox, $"Size: {ImageBox.Width} x {ImageBox.Height}")
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure initializes this window's controls.
   Private Sub InterfaceWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
      Try
         ToolTipBox.SetToolTip(FileListBox, String.Format("{0} Supported types: {1}", ToolTipBox.GetToolTip(FileListBox), String.Join(Path.PathSeparator & " ", IMAGE_EXTENSIONS)))

         HighlightColorBar.Value = 10
         HighlightModeBox1.Checked = True
         LowerThresholdBox.Text = "5"
         PrecisionBox.Text = "10"
         UpperThresholdBox.Text = "10"
         XGridSizeBox.Text = "10"
         YGridSizeBox.Text = "10"

         UpdateDriveList()
         SelectCurrentDrive()
         UpdateFilesList()

         UpdateHighlights(Nothing, Nothing)
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure returns the drive being referred to in the specified path.
   Private Function GetDrive(PathO As String) As String
      Try
         Return PathO.Substring(0, PathO.IndexOf(Path.VolumeSeparatorChar) + 1)
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure returns the selected highlight mode based upon which highlight mode box is on.
   Private Function GetHighlightMode() As HighlightModesE
      Try
         Select Case True
            Case HighlightModeBox1.Checked
               Return HighlightModesE.BoxedHighlightMode
            Case HighlightModeBox2.Checked
               Return HighlightModesE.InvertedHightlightMode
            Case HighlightModeBox3.Checked
               Return HighlightModesE.ObscuredHighlightMode
         End Select
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return HighlightModesE.BoxedHighlightMode
   End Function

   'This procedure manages the mouse pointer.
   Private Sub MousePointer(Busy As Boolean)
      Try
         Me.Cursor = If(Busy, Cursors.WaitCursor, Cursors.Default)

         For Each Item As Control In Me.Controls
            Item.Cursor = If(Busy, Cursors.WaitCursor, Cursors.Default)
         Next Item
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure selects the current drive in the drive list.
   Private Sub SelectCurrentDrive()
      Try
         With DriveListBox
            For Index As Integer = 0 To .Items.Count - 1
               If Path.GetPathRoot(.Items(Index).ToString().ToLower()).StartsWith(Path.GetPathRoot(Directory.GetCurrentDirectory()).ToLower()) Then
                  .SelectedIndex = Index
                  Exit For
               End If
            Next Index
         End With
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure updates the list of directories.
   Private Sub UpdateDirectoryList()
      Try
         Dim Current As String = Directory.GetCurrentDirectory()

         With DirectoryListBox
            .Items.Clear()
            If Not Path.GetPathRoot(Current).ToLower() = Current.ToLower Then .Items.Add("..")
            .Items.AddRange((From Item In New DirectoryInfo(Current).GetDirectories() Where Not Item.Attributes.HasFlag(FileAttributes.Hidden)).ToArray())
         End With
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure updates the list of drives.
   Private Sub UpdateDriveList()
      Try
         Dim Item As String = Nothing

         With DriveListBox
            .Items.Clear()
            For Each DriveO As DriveInfo In DriveInfo.GetDrives()
               Item = DriveO.Name
               If DriveO.IsReady() AndAlso Not DriveO.VolumeLabel = Nothing Then Item &= $" [{ DriveO.VolumeLabel}]"
               .Items.Add(Item.ToUpper())
            Next DriveO
         End With
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure updates the list of files.
   Private Sub UpdateFilesList()
      Try
         FileListBox.Items.Clear()
         FileListBox.Items.AddRange((From FileO As FileInfo In New DirectoryInfo(Directory.GetCurrentDirectory()).GetFiles() Where IMAGE_EXTENSIONS.Contains(FileO.Extension.ToLower()) Select FileO.Name).ToArray())
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to update the image's highlights using the new settings.
   Private Sub UpdateHighlights(sender As Object, e As EventArgs)
      Try
         Dim HighlightColor As Integer = QBColor(HighlightColorBar.Value)

         HighlightColorBox.BackColor = Color.FromArgb(HighlightColor And &HFF%, (HighlightColor And &HFF00%) >> &H8%, (HighlightColor And &HFF0000%) >> &H10%)

         If Not CurrentImage Is Nothing Then
            MousePointer(Busy:=True)
            ImageBox.Image = DrawResults(CurrentImage, AnalyzeImage(), ToInt32(LowerThresholdBox.Text), ToInt32(UpperThresholdBox.Text), HighlightColorBox.BackColor, GetHighlightMode())
            MousePointer(Busy:=False)
         End If
      Catch ExceptionO As Exception
         MousePointer(Busy:=False)
         HandleError(ExceptionO)
      End Try
   End Sub
End Class
