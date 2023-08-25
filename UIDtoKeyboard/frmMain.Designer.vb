<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.cbxReaderList = New System.Windows.Forms.ComboBox()
        Me.btnRefreshReader = New System.Windows.Forms.Button()
        Me.btnStartMonitor = New System.Windows.Forms.Button()
        Me.txtInputSpace = New System.Windows.Forms.TextBox()
        Me.lblReadingMode = New System.Windows.Forms.Label()
        Me.rbOriginal = New System.Windows.Forms.RadioButton()
        Me.rbReversed = New System.Windows.Forms.RadioButton()
        Me.chkSendEnter = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbxReaderList
        '
        Me.cbxReaderList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxReaderList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbxReaderList.FormattingEnabled = True
        Me.cbxReaderList.Location = New System.Drawing.Point(3, 3)
        Me.cbxReaderList.Name = "cbxReaderList"
        Me.cbxReaderList.Size = New System.Drawing.Size(327, 26)
        Me.cbxReaderList.TabIndex = 0
        '
        'btnRefreshReader
        '
        Me.btnRefreshReader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshReader.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnRefreshReader.Location = New System.Drawing.Point(336, 3)
        Me.btnRefreshReader.Name = "btnRefreshReader"
        Me.btnRefreshReader.Size = New System.Drawing.Size(106, 27)
        Me.btnRefreshReader.TabIndex = 1
        Me.btnRefreshReader.Text = "Refresh"
        Me.btnRefreshReader.UseVisualStyleBackColor = True
        '
        'btnStartMonitor
        '
        Me.btnStartMonitor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStartMonitor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnStartMonitor.Location = New System.Drawing.Point(12, 112)
        Me.btnStartMonitor.Name = "btnStartMonitor"
        Me.btnStartMonitor.Size = New System.Drawing.Size(445, 32)
        Me.btnStartMonitor.TabIndex = 6
        Me.btnStartMonitor.Text = "Start Monitor"
        Me.btnStartMonitor.UseVisualStyleBackColor = True
        '
        'txtInputSpace
        '
        Me.txtInputSpace.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInputSpace.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtInputSpace.Location = New System.Drawing.Point(12, 161)
        Me.txtInputSpace.Multiline = True
        Me.txtInputSpace.Name = "txtInputSpace"
        Me.txtInputSpace.Size = New System.Drawing.Size(445, 161)
        Me.txtInputSpace.TabIndex = 7
        '
        'lblReadingMode
        '
        Me.lblReadingMode.AutoSize = True
        Me.lblReadingMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblReadingMode.Location = New System.Drawing.Point(9, 59)
        Me.lblReadingMode.Name = "lblReadingMode"
        Me.lblReadingMode.Size = New System.Drawing.Size(83, 18)
        Me.lblReadingMode.TabIndex = 2
        Me.lblReadingMode.Text = "Byte Order:"
        '
        'rbOriginal
        '
        Me.rbOriginal.AutoSize = True
        Me.rbOriginal.Checked = True
        Me.rbOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rbOriginal.Location = New System.Drawing.Point(98, 59)
        Me.rbOriginal.Name = "rbOriginal"
        Me.rbOriginal.Size = New System.Drawing.Size(68, 19)
        Me.rbOriginal.TabIndex = 3
        Me.rbOriginal.TabStop = True
        Me.rbOriginal.Text = "Original"
        Me.rbOriginal.UseVisualStyleBackColor = True
        '
        'rbReversed
        '
        Me.rbReversed.AutoSize = True
        Me.rbReversed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rbReversed.Location = New System.Drawing.Point(172, 59)
        Me.rbReversed.Name = "rbReversed"
        Me.rbReversed.Size = New System.Drawing.Size(77, 19)
        Me.rbReversed.TabIndex = 4
        Me.rbReversed.Text = "Reversed"
        Me.rbReversed.UseVisualStyleBackColor = True
        '
        'chkSendEnter
        '
        Me.chkSendEnter.AutoSize = True
        Me.chkSendEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkSendEnter.Location = New System.Drawing.Point(12, 84)
        Me.chkSendEnter.Name = "chkSendEnter"
        Me.chkSendEnter.Size = New System.Drawing.Size(100, 22)
        Me.chkSendEnter.TabIndex = 5
        Me.chkSendEnter.Text = "Send Enter"
        Me.chkSendEnter.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cbxReaderList, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnRefreshReader, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(445, 33)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 338)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.chkSendEnter)
        Me.Controls.Add(Me.rbReversed)
        Me.Controls.Add(Me.rbOriginal)
        Me.Controls.Add(Me.lblReadingMode)
        Me.Controls.Add(Me.txtInputSpace)
        Me.Controls.Add(Me.btnStartMonitor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(333, 304)
        Me.Name = "frmMain"
        Me.Text = "RFID/NFC UID Keyboard Emulator"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbxReaderList As ComboBox
    Friend WithEvents btnRefreshReader As Button
    Friend WithEvents btnStartMonitor As Button
    Friend WithEvents txtInputSpace As TextBox
    Friend WithEvents lblReadingMode As Label
    Friend WithEvents rbOriginal As RadioButton
    Friend WithEvents rbReversed As RadioButton
    Friend WithEvents chkSendEnter As CheckBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
