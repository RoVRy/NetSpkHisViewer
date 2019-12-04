Imports System.Collections.ObjectModel
Imports Microsoft.VisualBasic.FileSystem
Imports System.IO
Imports System.Text

Public Class MainWindow

    Public UINPath As String

    Public Class Header
        Public Shared Sign As UInteger
        Public Shared RemoteUIN As UInteger
        Public Shared LocalUIN As UInteger
        Public Shared MsgCount As UInteger
        Public Shared HisType As Byte
    End Class

    Public Class Message
        Public Shared RemoteUIN As UInteger
        Public Shared DateTime As Date
        Public Shared Type As Char
        Public Shared Direct As Byte
        Public Shared Flags As UInteger
        Public Shared MsgLenght As UInteger
        Public Shared MsgText As String
    End Class

    Public Class RTF
        Public Shared CrLf As String = "\par" & vbCrLf
        Public Shared BoldO As String = "\b"
        Public Shared BoldC As String = "\b0"
        Public Shared ItalicO As String = "\i"
        Public Shared ItalicC As String = "\i0"
        Public Shared UlO As String = "\ul"
        Public Shared UlC As String = "\ulnone"
        Public Shared FontSize As String = "\fs"
    End Class

    Private Sub MainWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer
        Dim CurUIN As UInteger
        Dim ProfilePlace As Byte
        Dim UINDat As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "AppData", "").ToString & "\NetSpeakerphone\uin.dat"

        If My.Computer.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall\Net Speakerphone_is1") Is Nothing Then
            My.Computer.Registry.LocalMachine.Close()
            Exit Sub
        End If
        NetSph_status.Text = "Да"
        NetSph_status.ForeColor = Color.Green
        NetSph_path.ForeColor = Color.Green
        UINList.Enabled = True
        If Not My.Computer.FileSystem.FileExists(UINDat) Then
            MsgBox("Файл с информацией о текущем профиле не найден!", MsgBoxStyle.Exclamation, "Ошибка!")
            Me.Close()
            Exit Sub
        End If

        Dim Handle As New BinaryReader(File.OpenRead(UINDat))
        CurUIN = Handle.ReadUInt32()
        ProfilePlace = Handle.ReadByte()
        Handle.Close()
        If ProfilePlace = 1 Then
            UINPath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "Personal", "").ToString & "\NetSpeakerphone\History\"
        Else
            UINPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall\Net Speakerphone_is1", "InstallLocation", "").ToString & "UINS\" & CurUIN.ToString & "\History\"
        End If
        NetSph_path.Text = UINPath
        Dim ofiles As ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(UINPath, FileIO.SearchOption.SearchTopLevelOnly, "*.nsh")
        Directory.GetFiles(UINPath, "*.nsh", SearchOption.TopDirectoryOnly)
        If ofiles.Count > 0 Then
            Dim UINs As New ArrayList
            For i = 0 To (ofiles.Count - 1)
                UINs.Add(Path.GetFileNameWithoutExtension(ofiles(i)))
            Next
            ShowHis.Enabled = True
            UINList.DataSource = UINs
        End If
    End Sub

    Private Sub ShowHis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHis.Click

        Dim i, j As UInt16
        Dim Codepage As Encoding = Encoding.GetEncoding(1251)
        Dim Filename As String = UINPath & UINList.Text & ".nsh"
        Dim Content As String = "{\rtf1\ansi\ansicpg1251{\colortbl;\red0\green0\blue0;\red255\green0\blue0;\red0\green128\blue0;\red0\green64\blue255;}" & vbCrLf
        Dim Handle As New BinaryReader(File.OpenRead(Filename), Codepage)
        Header.Sign = Handle.ReadUInt32()
        If Header.Sign <> 2857698305 Then
            MsgBox("Файл поврежден или имеет неподдерживаемый формат!", MsgBoxStyle.Exclamation, "Ошибка!")
            Handle.Close()
            Exit Sub
        End If
        Me.HistoryBox.Enabled = True
        HistoryBox.ScrollToCaret()
        Header.LocalUIN = Handle.ReadUInt32()
        Header.RemoteUIN = Handle.ReadUInt32()
        Header.MsgCount = Handle.ReadUInt32()
        Header.HisType = Handle.ReadByte()
        If Header.MsgCount = 0 Then
            MsgBox("В этой истории нет сообщений!", MsgBoxStyle.Exclamation)
            Handle.Close()
            Exit Sub
        End If
        Handle.BaseStream.Seek(15, SeekOrigin.Current)
        For i = 1 To CUShort(Header.MsgCount)
            Message.RemoteUIN = Handle.ReadUInt32()
            Handle.BaseStream.Seek(4, SeekOrigin.Current)
            Message.DateTime = Date.FromOADate(Handle.ReadDouble())
            Message.Type = Handle.ReadChar()
            Message.Direct = Handle.ReadByte()
            Handle.BaseStream.Seek(2, SeekOrigin.Current)
            Message.Flags = Handle.ReadUInt32()
            Message.MsgLenght = Handle.ReadUInt32()
            Handle.BaseStream.Seek(4, SeekOrigin.Current)
            Message.MsgText = Handle.ReadChars(CInt(Message.MsgLenght))
            Message.MsgText = Replace(Message.MsgText, "\", "\'5c")
            For j = 128 To 255
                Message.MsgText = Replace(Message.MsgText, Chr(j), "\'" & Hex(j))
            Next
            Message.MsgText = Replace(Message.MsgText, Chr(13) & Chr(10), "\par ")
            Content &= RTF.BoldO
            If Message.Direct = 1 Then
                Content &= "\cf2 " & CStr(Message.RemoteUIN)
            Else
                Content &= "\cf3 " & CStr(Header.LocalUIN)
            End If
            Content &= " (" & Format(Message.DateTime, "dd.MM.yyyy HH:mm:ss") & ")" & RTF.BoldC & RTF.CrLf
            If Message.Type = "t" Or Message.Type = "n" Or Message.Type = "u" _
               Then Content &= "\cf1 "
            If Message.Type = "s" Or Message.Type = "f" Or Message.Type = "w" Or Message.Type = "?" Or Message.Type = "!" Or Message.Type = "c" _
               Then Content &= "\cf4" & RTF.ItalicO & " "
            Content &= Message.MsgText
            If Message.Type = "s" Or Message.Type = "f" Or Message.Type = "w" Or Message.Type = "?" Or Message.Type = "!" Or Message.Type = "c" _
               Then Content &= RTF.ItalicC
            Content &= RTF.CrLf & RTF.CrLf
        Next
        Handle.Close()
        Content &= "}"
        Me.HistoryBox.Rtf = Content
    End Sub

End Class