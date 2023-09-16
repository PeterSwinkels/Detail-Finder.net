'This module's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Drawing
Imports System.Linq
Imports System.Math
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

'This module contains this program's core procedures.
Public Module DetailFinderModule
   'The Microsoft Windows API constants and functions used by this program:
   Public Const NOTSRCCOPY As UInteger = &H330008%

   <DllImport("Gdi32.dll", SetLastError:=True)> Public Function BitBlt(ByVal hdc As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As UInteger) As Boolean
   End Function
   <DllImport("Gdi32.dll", SetLastError:=True)> Public Function CreateCompatibleDC(ByVal hRefDC As IntPtr) As IntPtr
   End Function
   <DllImport("Gdi32.dll", SetLastError:=True)> Public Function DeleteDC(ByVal hdc As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
   End Function
   <DllImport("Gdi32.dll", SetLastError:=True)> Public Function SelectObject(ByVal hdc As IntPtr, ByVal hObject As IntPtr) As IntPtr
   End Function

   'This enumeration defines the supported highlighting modes:
   Public Enum HighlightModesE As Integer
      BoxedHighlightMode      'Highlight an image's sections using boxes.
      InvertedHightlightMode  'Highlight an image's sections by inverting their colors.
      ObscuredHighlightMode   'Highlight an image's sections by obscuring those that fall outside the selection.
   End Enum

   'This structure defines the results of an image analysis:
   Public Structure ResultsStr
      Public Levels(,) As Integer   'Contains the detail levels for each image section.
      Public Steps As Size          'Contains the dimensions of an image section.
   End Structure

   'This procedure analyzes the specified image and returns the results.
   Public Function AnalyzeImage(Optional ImageO As Bitmap = Nothing, Optional Precision As Integer = Nothing, Optional GridSize As Size = Nothing) As ResultsStr
      Try
         Dim Color1 As New Color
         Dim Color2 As New Color
         Dim DetailLevel As New Integer
         Dim HighestLevel As New Integer
         Dim XDetailLevel As New Integer
         Dim YDetailLevel As New Integer
         Static Results As New ResultsStr

         If Not Precision = Nothing Then
            With ImageO
               ReDim Results.Levels(0 To GridSize.Width + 1, 0 To GridSize.Height + 1)
               Results.Steps = New Size(CInt((.Width - 1) / GridSize.Width), CInt((.Height - 1) / GridSize.Height))

               For x As Integer = 0 To .Width - 1 Step Results.Steps.Width
                  For y As Integer = 0 To .Height - 1 Step Results.Steps.Height
                     DetailLevel = 0
                     For XSection As Integer = x To x + (Results.Steps.Width - 1)
                        If XSection >= .Width - 1 Then Exit For
                        For YSection As Integer = y To y + (Results.Steps.Height - 1)
                           If YSection >= .Height - 1 Then Exit For
                           Color1 = .GetPixel(XSection, YSection)

                           Color2 = .GetPixel(XSection + 1, YSection)
                           XDetailLevel = Abs(CInt(Color1.R) - CInt(Color2.R)) + Abs(CInt(Color1.G) - CInt(Color2.G)) + Abs(CInt(Color1.B) - CInt(Color2.B))
                           Color2 = .GetPixel(XSection, YSection + 1)
                           YDetailLevel = Abs(CInt(Color1.R) - CInt(Color2.R)) + Abs(CInt(Color1.G) - CInt(Color2.G)) + Abs(CInt(Color1.B) - CInt(Color2.B))
                           DetailLevel += CInt({XDetailLevel + YDetailLevel}.Average)
                        Next YSection
                     Next XSection
                     If DetailLevel > HighestLevel Then HighestLevel = DetailLevel
                     Results.Levels(x \ Results.Steps.Width, y \ Results.Steps.Height) = DetailLevel
                  Next y
                  My.Application.DoEvents()
               Next x
            End With

            If Not HighestLevel = Nothing Then
               With Results
                  HighestLevel = CInt(HighestLevel / Precision)
                  For x As Integer = .Levels.GetLowerBound(0) To .Levels.GetUpperBound(0)
                     For y As Integer = .Levels.GetLowerBound(1) To .Levels.GetUpperBound(1)
                        .Levels(x, y) = CInt(.Levels(x, y) / HighestLevel)
                     Next y
                  Next x
               End With
            End If
         End If

         Return Results
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure draws highlights for details within the specified thresholds on the specified image.
   Public Function DrawResults(ImageO As Bitmap, Details As ResultsStr, LowerThreshold As Integer, UpperThreshold As Integer, Color As Color, Mode As HighlightModesE) As Bitmap
      Try
         Dim Highlights As Bitmap = New Bitmap(ImageO)
         Dim HighlightsCDCH As New IntPtr
         Dim HighlightsDCH As New IntPtr

         If Not Details.Levels Is Nothing Then
            With Graphics.FromImage(Highlights)
               If Mode = HighlightModesE.InvertedHightlightMode Then
                  HighlightsDCH = .GetHdc()
                  HighlightsCDCH = CreateCompatibleDC(HighlightsDCH)
                  SelectObject(HighlightsCDCH, ImageO.GetHbitmap())
               End If

               For x As Integer = 0 To Highlights.Width - 1 Step Details.Steps.Width
                  For y As Integer = 0 To Highlights.Height - 1 Step Details.Steps.Height
                     If Details.Levels(x \ Details.Steps.Width, y \ Details.Steps.Height) >= LowerThreshold AndAlso Details.Levels(x \ Details.Steps.Width, y \ Details.Steps.Height) <= UpperThreshold Then
                        If Mode = HighlightModesE.BoxedHighlightMode Then
                           .DrawRectangle(New Pen(Color), x, y, Details.Steps.Width, Details.Steps.Height)
                        ElseIf Mode = HighlightModesE.InvertedHightlightMode Then
                           BitBlt(HighlightsDCH, x, y, Details.Steps.Width, Details.Steps.Height, HighlightsCDCH, x, y, NOTSRCCOPY)
                        End If
                     Else
                        If Mode = HighlightModesE.ObscuredHighlightMode Then
                           .FillRectangle(New SolidBrush(Color), x, y, Details.Steps.Width, Details.Steps.Height)
                        End If
                     End If
                  Next y
               Next x

               If Mode = HighlightModesE.InvertedHightlightMode Then
                  DeleteDC(HighlightsCDCH)
                  .ReleaseHdc(HighlightsDCH)
               End If
            End With
         End If

         Return Highlights
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure handles any errors that occur and notifies the user.
   Public Sub HandleError(ExceptionO As Exception)
      Try
         MessageBox.Show(ExceptionO.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Catch
         Application.Exit()
      End Try
   End Sub

   'This procedure returns this program's information.
   Public Function ProgramInformation() As String
      Try
         With My.Application.Info
            Return $"{ .Title} v{ .Version}, by: { .CompanyName}"
         End With
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return Nothing
   End Function
End Module
