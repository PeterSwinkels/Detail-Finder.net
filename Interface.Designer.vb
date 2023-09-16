<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InterfaceWindow
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InterfaceWindow))
      Me.FileListBox = New System.Windows.Forms.ListBox()
      Me.DirectoryListBox = New System.Windows.Forms.ListBox()
      Me.DriveListBox = New System.Windows.Forms.ComboBox()
      Me.ImageFrame = New System.Windows.Forms.GroupBox()
      Me.GrabFromClipboardBox = New System.Windows.Forms.CheckBox()
      Me.ImagePanel = New System.Windows.Forms.Panel()
      Me.ImageBox = New System.Windows.Forms.PictureBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.YGridSizeBox = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.XGridSizeBox = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.PrecisionBox = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.AnalyzeButton = New System.Windows.Forms.Button()
      Me.ImageGrabber = New System.Windows.Forms.Timer(Me.components)
      Me.HighlightFrame = New System.Windows.Forms.GroupBox()
      Me.HighlightColorBox = New System.Windows.Forms.PictureBox()
      Me.HighlightColorBar = New System.Windows.Forms.HScrollBar()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.UpperThresholdBox = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.LowerThresholdBox = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.HighlightModeBox3 = New System.Windows.Forms.RadioButton()
      Me.HighlightModeBox2 = New System.Windows.Forms.RadioButton()
      Me.HighlightModeBox1 = New System.Windows.Forms.RadioButton()
      Me.ToolTipBox = New System.Windows.Forms.ToolTip(Me.components)
      Me.ImageFrame.SuspendLayout()
      Me.ImagePanel.SuspendLayout()
      CType(Me.ImageBox, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
      Me.HighlightFrame.SuspendLayout()
      CType(Me.HighlightColorBox, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'FileListBox
      '
      Me.FileListBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FileListBox.FormattingEnabled = True
      Me.FileListBox.Location = New System.Drawing.Point(16, 19)
      Me.FileListBox.Name = "FileListBox"
      Me.FileListBox.Size = New System.Drawing.Size(157, 121)
      Me.FileListBox.TabIndex = 0
      Me.ToolTipBox.SetToolTip(Me.FileListBox, "Double click to load the selected image.")
      '
      'DirectoryListBox
      '
      Me.DirectoryListBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DirectoryListBox.FormattingEnabled = True
      Me.DirectoryListBox.Location = New System.Drawing.Point(16, 146)
      Me.DirectoryListBox.Name = "DirectoryListBox"
      Me.DirectoryListBox.Size = New System.Drawing.Size(157, 82)
      Me.DirectoryListBox.TabIndex = 1
      Me.ToolTipBox.SetToolTip(Me.DirectoryListBox, "Select the directory containing the image to analyze here.")
      '
      'DriveListBox
      '
      Me.DriveListBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DriveListBox.FormattingEnabled = True
      Me.DriveListBox.Location = New System.Drawing.Point(16, 234)
      Me.DriveListBox.Name = "DriveListBox"
      Me.DriveListBox.Size = New System.Drawing.Size(157, 21)
      Me.DriveListBox.TabIndex = 2
      Me.ToolTipBox.SetToolTip(Me.DriveListBox, "Select the drive containing the image to analyze here.")
      '
      'ImageFrame
      '
      Me.ImageFrame.Controls.Add(Me.GrabFromClipboardBox)
      Me.ImageFrame.Controls.Add(Me.DriveListBox)
      Me.ImageFrame.Controls.Add(Me.DirectoryListBox)
      Me.ImageFrame.Controls.Add(Me.FileListBox)
      Me.ImageFrame.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ImageFrame.Location = New System.Drawing.Point(12, 12)
      Me.ImageFrame.Name = "ImageFrame"
      Me.ImageFrame.Size = New System.Drawing.Size(190, 289)
      Me.ImageFrame.TabIndex = 0
      Me.ImageFrame.TabStop = False
      Me.ImageFrame.Text = "Image"
      '
      'GrabFromClipboardBox
      '
      Me.GrabFromClipboardBox.AutoSize = True
      Me.GrabFromClipboardBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.GrabFromClipboardBox.Location = New System.Drawing.Point(32, 261)
      Me.GrabFromClipboardBox.Name = "GrabFromClipboardBox"
      Me.GrabFromClipboardBox.Size = New System.Drawing.Size(141, 17)
      Me.GrabFromClipboardBox.TabIndex = 3
      Me.GrabFromClipboardBox.Text = "Grab from &clipboard:"
      Me.ToolTipBox.SetToolTip(Me.GrabFromClipboardBox, "Select to enable the automatic analysis of any image copied to the clipboard.")
      Me.GrabFromClipboardBox.UseVisualStyleBackColor = True
      '
      'ImagePanel
      '
      Me.ImagePanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ImagePanel.AutoScroll = True
      Me.ImagePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.ImagePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.ImagePanel.Controls.Add(Me.ImageBox)
      Me.ImagePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ImagePanel.Location = New System.Drawing.Point(208, 12)
      Me.ImagePanel.Name = "ImagePanel"
      Me.ImagePanel.Size = New System.Drawing.Size(485, 569)
      Me.ImagePanel.TabIndex = 1
      '
      'ImageBox
      '
      Me.ImageBox.Location = New System.Drawing.Point(3, 4)
      Me.ImageBox.Name = "ImageBox"
      Me.ImageBox.Size = New System.Drawing.Size(250, 250)
      Me.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.ImageBox.TabIndex = 1
      Me.ImageBox.TabStop = False
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.YGridSizeBox)
      Me.GroupBox1.Controls.Add(Me.Label3)
      Me.GroupBox1.Controls.Add(Me.XGridSizeBox)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.PrecisionBox)
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Controls.Add(Me.AnalyzeButton)
      Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox1.Location = New System.Drawing.Point(12, 307)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(190, 101)
      Me.GroupBox1.TabIndex = 2
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Analysis"
      '
      'YGridSizeBox
      '
      Me.YGridSizeBox.Location = New System.Drawing.Point(141, 41)
      Me.YGridSizeBox.Name = "YGridSizeBox"
      Me.YGridSizeBox.Size = New System.Drawing.Size(43, 20)
      Me.YGridSizeBox.TabIndex = 6
      Me.YGridSizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ToolTipBox.SetToolTip(Me.YGridSizeBox, "Specify the number of vertical image sections here.")
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(124, 46)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(11, 13)
      Me.Label3.TabIndex = 8
      Me.Label3.Text = ","
      '
      'XGridSizeBox
      '
      Me.XGridSizeBox.Location = New System.Drawing.Point(84, 43)
      Me.XGridSizeBox.Name = "XGridSizeBox"
      Me.XGridSizeBox.Size = New System.Drawing.Size(41, 20)
      Me.XGridSizeBox.TabIndex = 5
      Me.XGridSizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ToolTipBox.SetToolTip(Me.XGridSizeBox, "Specify the number of horizontal image sections here.")
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(16, 46)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(60, 13)
      Me.Label2.TabIndex = 6
      Me.Label2.Text = "Grid size:"
      '
      'PrecisionBox
      '
      Me.PrecisionBox.Location = New System.Drawing.Point(84, 18)
      Me.PrecisionBox.Name = "PrecisionBox"
      Me.PrecisionBox.Size = New System.Drawing.Size(100, 20)
      Me.PrecisionBox.TabIndex = 4
      Me.PrecisionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ToolTipBox.SetToolTip(Me.PrecisionBox, "Specify the precision used to measure detail levels here.")
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(13, 18)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(63, 13)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Precision:"
      '
      'AnalyzeButton
      '
      Me.AnalyzeButton.Location = New System.Drawing.Point(16, 67)
      Me.AnalyzeButton.Name = "AnalyzeButton"
      Me.AnalyzeButton.Size = New System.Drawing.Size(157, 25)
      Me.AnalyzeButton.TabIndex = 7
      Me.AnalyzeButton.Text = "&Analyze"
      Me.ToolTipBox.SetToolTip(Me.AnalyzeButton, "Click here to start the analysis of the detail levels in the current image.")
      Me.AnalyzeButton.UseVisualStyleBackColor = True
      '
      'ImageGrabber
      '
      Me.ImageGrabber.Interval = 250
      '
      'HighlightFrame
      '
      Me.HighlightFrame.Controls.Add(Me.HighlightColorBox)
      Me.HighlightFrame.Controls.Add(Me.HighlightColorBar)
      Me.HighlightFrame.Controls.Add(Me.Label6)
      Me.HighlightFrame.Controls.Add(Me.UpperThresholdBox)
      Me.HighlightFrame.Controls.Add(Me.Label4)
      Me.HighlightFrame.Controls.Add(Me.LowerThresholdBox)
      Me.HighlightFrame.Controls.Add(Me.Label5)
      Me.HighlightFrame.Controls.Add(Me.HighlightModeBox3)
      Me.HighlightFrame.Controls.Add(Me.HighlightModeBox2)
      Me.HighlightFrame.Controls.Add(Me.HighlightModeBox1)
      Me.HighlightFrame.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.HighlightFrame.Location = New System.Drawing.Point(14, 414)
      Me.HighlightFrame.Name = "HighlightFrame"
      Me.HighlightFrame.Size = New System.Drawing.Size(188, 167)
      Me.HighlightFrame.TabIndex = 3
      Me.HighlightFrame.TabStop = False
      Me.HighlightFrame.Text = "Highlight"
      '
      'HighlightColorBox
      '
      Me.HighlightColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.HighlightColorBox.Location = New System.Drawing.Point(60, 77)
      Me.HighlightColorBox.Name = "HighlightColorBox"
      Me.HighlightColorBox.Size = New System.Drawing.Size(123, 16)
      Me.HighlightColorBox.TabIndex = 17
      Me.HighlightColorBox.TabStop = False
      Me.ToolTipBox.SetToolTip(Me.HighlightColorBox, "The color used to highlight the image sections with the specified detail levels.")
      '
      'HighlightColorBar
      '
      Me.HighlightColorBar.LargeChange = 1
      Me.HighlightColorBar.Location = New System.Drawing.Point(60, 48)
      Me.HighlightColorBar.Maximum = 15
      Me.HighlightColorBar.Name = "HighlightColorBar"
      Me.HighlightColorBar.Size = New System.Drawing.Size(120, 17)
      Me.HighlightColorBar.TabIndex = 10
      Me.ToolTipBox.SetToolTip(Me.HighlightColorBar, "Move the slider to select a color.")
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(11, 48)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(40, 13)
      Me.Label6.TabIndex = 15
      Me.Label6.Text = "Color:"
      '
      'UpperThresholdBox
      '
      Me.UpperThresholdBox.Location = New System.Drawing.Point(115, 19)
      Me.UpperThresholdBox.Name = "UpperThresholdBox"
      Me.UpperThresholdBox.Size = New System.Drawing.Size(43, 20)
      Me.UpperThresholdBox.TabIndex = 9
      Me.UpperThresholdBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ToolTipBox.SetToolTip(Me.UpperThresholdBox, "Specify the highest detail level to be highlighted here.")
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(102, 21)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(11, 13)
      Me.Label4.TabIndex = 14
      Me.Label4.Text = "-"
      '
      'LowerThresholdBox
      '
      Me.LowerThresholdBox.Location = New System.Drawing.Point(58, 21)
      Me.LowerThresholdBox.Name = "LowerThresholdBox"
      Me.LowerThresholdBox.Size = New System.Drawing.Size(41, 20)
      Me.LowerThresholdBox.TabIndex = 8
      Me.LowerThresholdBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ToolTipBox.SetToolTip(Me.LowerThresholdBox, "Specify the lowest detail level to be highlighted here.")
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(4, 22)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(48, 13)
      Me.Label5.TabIndex = 12
      Me.Label5.Text = "Levels:"
      '
      'HighlightModeBox3
      '
      Me.HighlightModeBox3.AutoSize = True
      Me.HighlightModeBox3.Location = New System.Drawing.Point(6, 145)
      Me.HighlightModeBox3.Name = "HighlightModeBox3"
      Me.HighlightModeBox3.Size = New System.Drawing.Size(139, 17)
      Me.HighlightModeBox3.TabIndex = 13
      Me.HighlightModeBox3.TabStop = True
      Me.HighlightModeBox3.Text = "Highlight: &obscured."
      Me.ToolTipBox.SetToolTip(Me.HighlightModeBox3, "Highlight image sections by obscuring those that fall outside the specified range" & _
        ".")
      Me.HighlightModeBox3.UseVisualStyleBackColor = True
      '
      'HighlightModeBox2
      '
      Me.HighlightModeBox2.AutoSize = True
      Me.HighlightModeBox2.Location = New System.Drawing.Point(6, 122)
      Me.HighlightModeBox2.Name = "HighlightModeBox2"
      Me.HighlightModeBox2.Size = New System.Drawing.Size(133, 17)
      Me.HighlightModeBox2.TabIndex = 12
      Me.HighlightModeBox2.TabStop = True
      Me.HighlightModeBox2.Text = "Highlight: &inverted."
      Me.ToolTipBox.SetToolTip(Me.HighlightModeBox2, "Highlight image sections by inverting their colors.")
      Me.HighlightModeBox2.UseVisualStyleBackColor = True
      '
      'HighlightModeBox1
      '
      Me.HighlightModeBox1.AutoSize = True
      Me.HighlightModeBox1.Location = New System.Drawing.Point(6, 99)
      Me.HighlightModeBox1.Name = "HighlightModeBox1"
      Me.HighlightModeBox1.Size = New System.Drawing.Size(120, 17)
      Me.HighlightModeBox1.TabIndex = 11
      Me.HighlightModeBox1.TabStop = True
      Me.HighlightModeBox1.Text = "Highlight: &boxes."
      Me.ToolTipBox.SetToolTip(Me.HighlightModeBox1, "Highlight image sections using boxes.")
      Me.HighlightModeBox1.UseVisualStyleBackColor = True
      '
      'ToolTipBox
      '
      Me.ToolTipBox.AutoPopDelay = 5000
      Me.ToolTipBox.InitialDelay = 500
      Me.ToolTipBox.ReshowDelay = 100
      '
      'InterfaceWindow
      '
      Me.AcceptButton = Me.AnalyzeButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(705, 598)
      Me.Controls.Add(Me.HighlightFrame)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.ImagePanel)
      Me.Controls.Add(Me.ImageFrame)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "InterfaceWindow"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.ImageFrame.ResumeLayout(False)
      Me.ImageFrame.PerformLayout()
      Me.ImagePanel.ResumeLayout(False)
      Me.ImagePanel.PerformLayout()
      CType(Me.ImageBox, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.HighlightFrame.ResumeLayout(False)
      Me.HighlightFrame.PerformLayout()
      CType(Me.HighlightColorBox, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents DirectoryListBox As System.Windows.Forms.ListBox
   Friend WithEvents DriveListBox As System.Windows.Forms.ComboBox
   Friend WithEvents ImageFrame As System.Windows.Forms.GroupBox
   Friend WithEvents ImagePanel As System.Windows.Forms.Panel
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents GrabFromClipboardBox As System.Windows.Forms.CheckBox
   Friend WithEvents AnalyzeButton As System.Windows.Forms.Button
   Friend WithEvents ImageGrabber As System.Windows.Forms.Timer
   Friend WithEvents YGridSizeBox As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents XGridSizeBox As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents PrecisionBox As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents FileListBox As System.Windows.Forms.ListBox
   Friend WithEvents ImageBox As System.Windows.Forms.PictureBox
   Friend WithEvents HighlightFrame As System.Windows.Forms.GroupBox
   Friend WithEvents HighlightModeBox2 As System.Windows.Forms.RadioButton
   Friend WithEvents HighlightModeBox1 As System.Windows.Forms.RadioButton
   Friend WithEvents HighlightModeBox3 As System.Windows.Forms.RadioButton
   Friend WithEvents HighlightColorBar As System.Windows.Forms.HScrollBar
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents UpperThresholdBox As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents LowerThresholdBox As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents HighlightColorBox As System.Windows.Forms.PictureBox
   Friend WithEvents ToolTipBox As System.Windows.Forms.ToolTip
End Class
