<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.Label1 = New System.Windows.Forms.Label
        Me.NetSph_status = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.NetSph_path = New System.Windows.Forms.Label
        Me.UINList = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ShowHis = New System.Windows.Forms.Button
        Me.HistoryBox = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Name = "Label1"
        '
        'NetSph_status
        '
        resources.ApplyResources(Me.NetSph_status, "NetSph_status")
        Me.NetSph_status.BackColor = System.Drawing.Color.Transparent
        Me.NetSph_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NetSph_status.ForeColor = System.Drawing.Color.Red
        Me.NetSph_status.Name = "NetSph_status"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Name = "Label2"
        '
        'NetSph_path
        '
        resources.ApplyResources(Me.NetSph_path, "NetSph_path")
        Me.NetSph_path.AutoEllipsis = True
        Me.NetSph_path.BackColor = System.Drawing.Color.Transparent
        Me.NetSph_path.ForeColor = System.Drawing.Color.Red
        Me.NetSph_path.MaximumSize = New System.Drawing.Size(223, 15)
        Me.NetSph_path.Name = "NetSph_path"
        '
        'UINList
        '
        resources.ApplyResources(Me.UINList, "UINList")
        Me.UINList.BackColor = System.Drawing.Color.White
        Me.UINList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UINList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UINList.FormattingEnabled = True
        Me.UINList.Name = "UINList"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Name = "Label3"
        '
        'ShowHis
        '
        resources.ApplyResources(Me.ShowHis, "ShowHis")
        Me.ShowHis.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ShowHis.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ShowHis.Name = "ShowHis"
        Me.ShowHis.UseVisualStyleBackColor = True
        '
        'HistoryBox
        '
        resources.ApplyResources(Me.HistoryBox, "HistoryBox")
        Me.HistoryBox.AutoWordSelection = True
        Me.HistoryBox.BackColor = System.Drawing.Color.White
        Me.HistoryBox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.HistoryBox.Name = "HistoryBox"
        Me.HistoryBox.ReadOnly = True
        '
        'MainWindow
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Controls.Add(Me.HistoryBox)
        Me.Controls.Add(Me.ShowHis)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.UINList)
        Me.Controls.Add(Me.NetSph_path)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NetSph_status)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "MainWindow"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NetSph_status As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NetSph_path As System.Windows.Forms.Label
    Friend WithEvents UINList As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ShowHis As System.Windows.Forms.Button
    Friend WithEvents HistoryBox As System.Windows.Forms.RichTextBox

End Class
