Imports System.ComponentModel

Public Class ctrlDashboardCard

    Public Property Description As String
        Get
            Return lblDescription.Text
        End Get
        Set(value As String)
            lblDescription.Text = value
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Bindable(True)>
    <Category("Misc")>
    Public Overrides Property Text As String
        Get
            Return lblText.Text
        End Get
        Set(value As String)
            lblText.Text = value
        End Set
    End Property

    Public Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(value As Font)
            MyBase.Font = value
            lblText.Font = New Font(Me.Font.FontFamily, Me.Font.Size * 2)
            lblDescription.Font = Me.Font
        End Set
    End Property

    Public Overrides Property ForeColor As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(value As Color)
            MyBase.ForeColor = value
            lblText.ForeColor = value
            lblDescription.ForeColor = value
        End Set
    End Property

    Public Property Color1 As Color
        Get
            Return ctrlGrd.Color1
        End Get
        Set(value As Color)
            ctrlGrd.Color1 = value
        End Set
    End Property

    Public Property Color2 As Color
        Get
            Return ctrlGrd.Color2
        End Get
        Set(value As Color)
            ctrlGrd.Color2 = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()

        Me.DoubleBuffered = True
    End Sub

End Class
