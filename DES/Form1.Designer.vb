<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtBox = New TextBox()
        bttn = New Button()
        SuspendLayout()
        ' 
        ' txtBox
        ' 
        txtBox.Location = New Point(322, 165)
        txtBox.Name = "txtBox"
        txtBox.Size = New Size(205, 23)
        txtBox.TabIndex = 0
        ' 
        ' bttn
        ' 
        bttn.Location = New Point(345, 224)
        bttn.Name = "bttn"
        bttn.Size = New Size(148, 78)
        bttn.TabIndex = 1
        bttn.Text = "click"
        bttn.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1281, 716)
        Controls.Add(bttn)
        Controls.Add(txtBox)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtBox As TextBox
    Friend WithEvents bttn As Button

End Class
