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
        Me.cbxReaderList = New System.Windows.Forms.ComboBox()
        Me.btnRefreshReader = New System.Windows.Forms.Button()
        Me.btnStartMonitor = New System.Windows.Forms.Button()
        Me.txtInputSpace = New System.Windows.Forms.TextBox()
        Me.lblReadingMode = New System.Windows.Forms.Label()
        Me.rbOriginal = New System.Windows.Forms.RadioButton()
        Me.rbReversed = New System.Windows.Forms.RadioButton()
        Me.chkSendEnter = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cbxReaderList
        '
        Me.cbxReaderList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbxReaderList.FormattingEnabled = True
        Me.cbxReaderList.Location = New System.Drawing.Point(25, 22)
        Me.cbxReaderList.Name = "cbxReaderList"
        Me.cbxReaderList.Size = New System.Drawing.Size(400, 26)
        Me.cbxReaderList.TabIndex = 0
        '
        'btnRefreshReader
        '
        Me.btnRefreshReader.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnRefreshReader.Location = New System.Drawing.Point(431, 22)
        Me.btnRefreshReader.Name = "btnRefreshReader"
        Me.btnRefreshReader.Size = New System.Drawing.Size(87, 27)
        Me.btnRefreshReader.TabIndex = 2
        Me.btnRefreshReader.Text = "Refresh"
        Me.btnRefreshReader.UseVisualStyleBackColor = True
        '
        'btnStartMonitor
        '
        Me.btnStartMonitor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnStartMonitor.Location = New System.Drawing.Point(25, 112)
        Me.btnStartMonitor.Name = "btnStartMonitor"
        Me.btnStartMonitor.Size = New System.Drawing.Size(496, 32)
        Me.btnStartMonitor.TabIndex = 3
        Me.btnStartMonitor.Text = "Start Monitor"
        Me.btnStartMonitor.UseVisualStyleBackColor = True
        '
        'txtInputSpace
        '
        Me.txtInputSpace.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtInputSpace.Location = New System.Drawing.Point(25, 159)
        Me.txtInputSpace.Multiline = True
        Me.txtInputSpace.Name = "txtInputSpace"
        Me.txtInputSpace.Size = New System.Drawing.Size(496, 206)
        Me.txtInputSpace.TabIndex = 4
        '
        'lblReadingMode
        '
        Me.lblReadingMode.AutoSize = True
        Me.lblReadingMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblReadingMode.Location = New System.Drawing.Point(22, 59)
        Me.lblReadingMode.Name = "lblReadingMode"
        Me.lblReadingMode.Size = New System.Drawing.Size(83, 18)
        Me.lblReadingMode.TabIndex = 9
        Me.lblReadingMode.Text = "Byte Order:"
        '
        'rbOriginal
        '
        Me.rbOriginal.AutoSize = True
        Me.rbOriginal.Checked = True
        Me.rbOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rbOriginal.Location = New System.Drawing.Point(111, 59)
        Me.rbOriginal.Name = "rbOriginal"
        Me.rbOriginal.Size = New System.Drawing.Size(68, 19)
        Me.rbOriginal.TabIndex = 10
        Me.rbOriginal.TabStop = True
        Me.rbOriginal.Text = "Original"
        Me.rbOriginal.UseVisualStyleBackColor = True
        '
        'rbReversed
        '
        Me.rbReversed.AutoSize = True
        Me.rbReversed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.rbReversed.Location = New System.Drawing.Point(185, 59)
        Me.rbReversed.Name = "rbReversed"
        Me.rbReversed.Size = New System.Drawing.Size(77, 19)
        Me.rbReversed.TabIndex = 11
        Me.rbReversed.Text = "Reversed"
        Me.rbReversed.UseVisualStyleBackColor = True
        '
        'chkSendEnter
        '
        Me.chkSendEnter.AutoSize = True
        Me.chkSendEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.chkSendEnter.Location = New System.Drawing.Point(25, 84)
        Me.chkSendEnter.Name = "chkSendEnter"
        Me.chkSendEnter.Size = New System.Drawing.Size(100, 22)
        Me.chkSendEnter.TabIndex = 12
        Me.chkSendEnter.Text = "Send Enter"
        Me.chkSendEnter.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 395)
        Me.Controls.Add(Me.chkSendEnter)
        Me.Controls.Add(Me.rbReversed)
        Me.Controls.Add(Me.rbOriginal)
        Me.Controls.Add(Me.lblReadingMode)
        Me.Controls.Add(Me.txtInputSpace)
        Me.Controls.Add(Me.btnStartMonitor)
        Me.Controls.Add(Me.btnRefreshReader)
        Me.Controls.Add(Me.cbxReaderList)
        Me.Name = "frmMain"
        Me.Text = "UIDtoKeyboard"
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
End Class
