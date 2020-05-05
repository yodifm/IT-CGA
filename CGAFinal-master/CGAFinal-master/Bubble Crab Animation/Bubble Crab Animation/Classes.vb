Imports System.IO


Public Enum StateSplitBC
    ComeIn
    Intro
    Stand 'Down
    WalkLeft 'Left
    WalkRight 'Right
    LeapStart 'Space
    Leap
    LeapDown
    LeapEnd
    CrabClawsStart 'Q
    CrabClawsUP
    CrabClawsDown
    CrabClawsEnd
    Jump 'Up
    JumpDown
    JumpEnd
    'Bubble Splash
    BubbleSplashStart 'Y
    BubbleSplashShoot
    BubbleSplashEnd
    'Bubble Shield
    BubbleShieldStart 'W
    BubbleShieldStand
    BubbleShieldWalkLeft
    BubbleShieldWalkRight
    BubbleShieldJump
    BubbleShieldJumpDown
    BubbleShieldShoot1Start 'E
    BubbleShieldShoot2Start 'R
    BubbleShieldShoot3Start 'T
    BubbleShieldShoot1
    BubbleShieldShoot2
    BubbleShieldShoot3
    BubbleShieldShoot12End
    BubbleShieldShoot3End
    BubbleShieldEnd

End Enum


Public Enum Key
    Num1
    Num2
    Num3
    Num4
    Num5
    Num6
    W
    A
    S
    D
    Space
    Left
    Right
    Up
    Down
End Enum

Public Enum StateDummyZombie
    ComeIn
    Float
    Destroy
End Enum

Public Enum StateFlyRobotic
    Create
    Destroy
    MoveDiagonal
End Enum

Public Enum StateRoboticShield
    Create
    Ascend
    Float
    Chase
    Destroy
End Enum

Public Enum StateBubbleProjectile
    Create
    Move
    Destroy
End Enum

Public Enum FaceDir
    Left
    Right
End Enum


Public Class CImage
    Public Width As Integer
    Public Height As Integer
    Public Elmt(,) As System.Drawing.Color
    Public ColorMode As Integer 'not used

    Sub OpenImage(ByVal FName As String)
        Dim s As String
        Dim L As Long
        Dim BR As BinaryReader
        Dim h, w, pos As Integer
        Dim r, g, b As Integer
        Dim pad As Integer

        BR = New BinaryReader(File.Open(FName, FileMode.Open))

        Try
            BlockRead(BR, 2, s)

            If s <> "BM" Then
                MsgBox("Not a BMP file")
            Else 'BMP file
                BlockReadInt(BR, 4, L) 'size
                'MsgBox("Size = " + CStr(L))
                BlankRead(BR, 4) 'reserved
                BlockReadInt(BR, 4, pos) 'start of data
                BlankRead(BR, 4) 'size of header
                BlockReadInt(BR, 4, Width) 'width
                'MsgBox("Width = " + CStr(I.Width))
                BlockReadInt(BR, 4, Height) 'height
                'MsgBox("Height = " + CStr(I.Height))
                BlankRead(BR, 2) 'color panels
                BlockReadInt(BR, 2, ColorMode) 'colormode
                If ColorMode <> 24 Then
                    MsgBox("Not a 24-bit color BMP")
                Else

                    BlankRead(BR, pos - 30)

                    ReDim Elmt(Width - 1, Height - 1)
                    pad = (4 - (Width * 3 Mod 4)) Mod 4

                    For h = Height - 1 To 0 Step -1
                        For w = 0 To Width - 1
                            BlockReadInt(BR, 1, b)
                            BlockReadInt(BR, 1, g)
                            BlockReadInt(BR, 1, r)
                            Elmt(w, h) = Color.FromArgb(r, g, b)

                        Next
                        BlankRead(BR, pad)

                    Next

                End If

            End If

        Catch ex As Exception
            MsgBox("Error")

        End Try

        BR.Close()


    End Sub


    Sub CreateMask(ByRef Mask As CImage)
        Dim i, j As Integer

        Mask = New CImage
        Mask.Width = Width
        Mask.Height = Height

        ReDim Mask.Elmt(Mask.Width - 1, Mask.Height - 1)

        For i = 0 To Width - 1
            For j = 0 To Height - 1
                If Elmt(i, j).R = 0 And Elmt(i, j).G = 0 And Elmt(i, j).B = 0 Then
                    Mask.Elmt(i, j) = Color.FromArgb(255, 255, 255)
                Else
                    Mask.Elmt(i, j) = Color.FromArgb(0, 0, 0)
                End If
            Next
        Next

    End Sub


    Sub CopyImg(ByRef Img As CImage)
        'copies image to Img
        Img = New CImage
        Img.Width = Width
        Img.Height = Height
        ReDim Img.Elmt(Width - 1, Height - 1)

        For i = 0 To Width - 1
            For j = 0 To Height - 1
                Img.Elmt(i, j) = Elmt(i, j)
            Next
        Next

    End Sub

End Class

Public Class CCharacter
    Public PosX, PosY As Double
    Public Vx, Vy As Double
    Public FrameIdx As Integer
    Public CurrFrame As Integer
    Public ArrSprites() As CArrFrame
    Public IdxArrSprites As Integer
    Public Destroy As Boolean = False
    Public FDir As FaceDir
    Public Const gravity = 1

    Public Sub GetNextFrame()
        CurrFrame = CurrFrame + 1
        If CurrFrame = ArrSprites(IdxArrSprites).Elmt(FrameIdx).MaxFrameTime Then
            FrameIdx = FrameIdx + 1
            If FrameIdx = ArrSprites(IdxArrSprites).N Then
                FrameIdx = 0
            End If
            CurrFrame = 0

        End If

    End Sub

    Public Overridable Sub Update()

    End Sub

End Class

Public Class CCharBubbleCrab
    Inherits CCharacter
    Public CurrState As StateSplitBC
    
    Public Sub State(state As StateSplitBC, idxspr As Integer)
    CurrState = state
    IdxArrSprites = idxspr
    CurrFrame = 0
    FrameIdx = 0
    End Sub

    Public Overrides Sub Update()
        Select Case CurrState
            Case StateSplitBC.ComeIn
                PosY = PosY + Vy
                GetNextFrame()
                If PosY >= 225 Then
                    State(StateSplitBC.Intro, 1)
                    Vx = 0
                    Vy = 0
                End If

            Case StateSplitBC.Intro
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.Stand, 3)
                    Vx = 0
                    Vy = 0
                End If

            Case StateSplitBC.Stand
                GetNextFrame()


            Case StateSplitBC.WalkLeft
                FDir = FaceDir.Left
                Vx = -5
                PosX = PosX + Vx
                GetNextFrame()
                If PosX <= 50 Then
                    PosX = 50
                    Vx = 0
                    Vy = 0
                    State(StateSplitBC.Stand, 3)
                End If


            Case StateSplitBC.WalkRight
                FDir = FaceDir.Right
                Vx = 5
                PosX = PosX + Vx
                GetNextFrame()
                If PosX >= 400 Then
                    PosX = 400
                    Vx = 0
                    Vy = 0
                    State(StateSplitBC.Stand, 3)
                End If


            Case StateSplitBC.LeapStart
                GetNextFrame()
                If FDir = FaceDir.Right Then
                    State(StateSplitBC.Leap, 5)
                    Vx = 5
                    Vy = -5
                ElseIf FDir = FaceDir.Left Then
                    State(StateSplitBC.Leap, 5)
                    Vx = -5
                    Vy = -5
                End If

            Case StateSplitBC.Leap
                PosX = PosX + Vx
                PosY = PosY + Vy
                Vy = Vy + 0.2
                GetNextFrame()
                If FDir = FaceDir.Right Then
                    If PosX >= 400 Then
                        PosX = 400
                        Vx = 0
                    End If
                    If Vy >= 0 And CurrFrame = 0 And FDir = FaceDir.Right Then
                        State(StateSplitBC.LeapDown, 6)
                        Vx = 5
                        Vy = 5
                    End If
                End If
                If FDir = FaceDir.Left Then
                    If PosX <= 50 Then
                        PosX = 50
                        Vx = 0
                    End If
                    If Vy >= 0 And CurrFrame = 0 And FDir = FaceDir.Left Then
                        State(StateSplitBC.LeapDown, 6)
                        Vx = -5
                        Vy = 5
                    End If
                End If

            Case StateSplitBC.LeapDown
                PosX = PosX + Vx
                PosY = PosY + Vy
                GetNextFrame()
                If FDir = FaceDir.Right Then
                    If PosX >= 400 Then
                        PosX = 400
                        Vx = 0
                    End If
                    If PosY >= 225 And CurrFrame = 0 Then
                        State(StateSplitBC.LeapEnd, 7)
                        Vx = 0
                        Vy = 0
                    End If
                End If

                If FDir = FaceDir.Left Then
                    If PosX <= 50 Then
                        PosX = 50
                        Vx = 0
                    End If
                    If PosY >= 225 And CurrFrame = 0 Then
                        State(StateSplitBC.LeapEnd, 7)
                        Vx = 0
                        Vy = 0
                    End If
                End If

            Case StateSplitBC.LeapEnd
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.Stand, 3)
                    Vx = 0
                    Vy = 0
                End If

            Case StateSplitBC.CrabClawsStart
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.CrabClawsUP, 8)
                    Vx = 0
                    Vy = -8
                End If

            Case StateSplitBC.CrabClawsUP
                PosX = PosX + Vx
                PosY = PosY + Vy
                GetNextFrame()
                If PosY <= 108 And CurrFrame = 0 Then
                    State(StateSplitBC.CrabClawsDown, 9)
                    Vx = 0
                    Vy = 8
                End If

            Case StateSplitBC.CrabClawsDown
                PosX = PosX + Vx
                PosY = PosY + Vy
                GetNextFrame()
                If PosY >= 225 And CurrFrame = 0 Then
                    State(StateSplitBC.CrabClawsEnd, 10)
                    Vx = 0
                    Vy = 0
                End If

            Case StateSplitBC.CrabClawsEnd
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.Stand, 3)
                End If


            Case StateSplitBC.Jump
                Vx = 0
                Vy = -8
                PosX = PosX + Vx
                PosY = PosY + Vy
                GetNextFrame()
                If PosY <= 108 And CurrFrame = 0 Then
                    State(StateSplitBC.JumpDown, 13)
                    Vx = 0
                    Vy = 8
                End If

            Case StateSplitBC.JumpDown
                PosX = PosX + Vx
                PosY = PosY + Vy
                GetNextFrame()
                If PosY >= 225 And CurrFrame = 0 Then
                    State(StateSplitBC.JumpEnd, 14)
                    Vx = 0
                    Vy = 0
                End If

            Case StateSplitBC.JumpEnd
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.Stand, 3)
                    Vx = 0
                    Vy = 0
                End If

            Case StateSplitBC.BubbleSplashStart
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.BubbleSplashShoot, 16)
                End If

            Case StateSplitBC.BubbleSplashShoot
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.BubbleSplashEnd, 17)
                End If

            Case StateSplitBC.BubbleSplashEnd
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.Stand, 3)
                    Vx = 0
                    Vy = 0
                End If

            Case StateSplitBC.BubbleShieldStart
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.BubbleShieldStand, 24)
                End If

            Case StateSplitBC.BubbleShieldWalkLeft
                FDir = FaceDir.Left
                Vx = -5
                PosX = PosX + Vx
                GetNextFrame()
                If PosX <= 50 Then
                    PosX = 50
                    Vx = 0
                    Vy = 0
                    State(StateSplitBC.BubbleShieldStand, 24)
                End If


            Case StateSplitBC.BubbleShieldWalkRight
                FDir = FaceDir.Right
                Vx = 5
                PosX = PosX + Vx
                GetNextFrame()
                If PosX >= 400 Then
                    PosX = 400
                    Vx = 0
                    Vy = 0
                    State(StateSplitBC.BubbleShieldStand, 24)
                End If

            Case StateSplitBC.BubbleShieldShoot1Start
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.BubbleShieldShoot1, 25)
                End If

            Case StateSplitBC.BubbleShieldShoot1
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.BubbleShieldShoot12End, 28)
                End If

             Case StateSplitBC.BubbleShieldShoot2Start
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.BubbleShieldShoot2, 26)
                End If

             Case StateSplitBC.BubbleShieldShoot2
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.BubbleShieldShoot12End, 28)
                End If

            Case StateSplitBC.BubbleShieldShoot12End
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.Stand, 3)
                    Vx = 0
                    Vy = 0
                End If

            Case StateSplitBC.BubbleShieldShoot3Start
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.BubbleShieldShoot3, 27)
                End If

            Case StateSplitBC.BubbleShieldShoot3
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.BubbleShieldShoot3End, 29)
                    
                End If

            Case StateSplitBC.BubbleShieldShoot3End
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.Stand, 3)
                    Vx = 0
                    Vy = 0
                End If
            Case StateSplitBC.BubbleShieldEnd
                GetNextFrame()
                 If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.Stand, 3)
                    Vx = 0
                    Vy = 0
                End If

            Case StateSplitBC.BubbleShieldStand
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateSplitBC.BubbleShieldEnd, 30)
                End If
            Case StateSplitBC.BubbleShieldJump
                Vx = 0
                Vy = -8
                PosX = PosX + Vx
                PosY = PosY + Vy
                GetNextFrame()
                If PosY <= 108 And CurrFrame = 0 Then
                    State(StateSplitBC.BubbleShieldJumpDown, 31)
                    Vx = 0
                    Vy = 8
                End If
            
                
            Case StateSplitBC.BubbleShieldJumpDown
                PosX = PosX + Vx
                PosY = PosY + Vy
                GetNextFrame()
                If PosY >= 225 And CurrFrame = 0 Then
                    State(StateSplitBC.BubbleShieldStand, 24)
                    Vx = 0
                    Vy = 0
                End If


        End Select
    End Sub
End Class

Public Class CCharDummyZombie
    Inherits CCharacter
    Public CurrState As StateDummyZombie
    
    Public Sub State(state As StateDummyZombie, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0
    End Sub

    Public Overrides Sub Update()
        Select Case CurrState
            Case StateDummyZombie.ComeIn
                PosY = PosY + Vy
                GetNextFrame()
                If PosY >= 108 Then
                    PosY = 108
                    State(StateDummyZombie.Float, 1)
                End If

            Case StateDummyZombie.Float 
                GetNextFrame()
                If TargetX = 108 And TargetY = 108 And AvailTarget = True Then
                   Destroy = True
                   AvailTarget = False
                End If
        End Select
        
    End Sub
End Class

Public Class CCharRoboticShield
    Inherits CCharacter
    Public CurrState As StateRoboticShield
    
    Public Sub State(state As StateRoboticShield, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0
    End Sub

    Public Overrides Sub Update()
        Select Case CurrState
              Case StateRoboticShield.Create
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateRoboticShield.Ascend, 1)
                    Vy = -6
                End If

              Case StateRoboticShield.Ascend
                GetNextFrame()
                PosY = PosY + Vy
                If PosY <= 108 Then
                    PosY = 108
                    State(StateRoboticShield.Float, 1)
                    If FDir = FaceDir.Left Then
                       Vx = -6
                    Else
                       Vx = 6
                    End If
                End If

              Case StateRoboticShield.Float
                GetNextFrame()
                PosX = PosX + Vx
                If FDir = FaceDir.Left And PosX = 108 And PosY = 108 And AvailTarget = True Then
                    Destroy = True
                    TargetX = 108
                    TargetY = 108
                End If
                If FDir = FaceDir.Right And PosX = 108 And PosY = 108 And AvailTarget = True Then
                    Destroy = True
                    TargetX = 108
                    TargetY = 108
                End If
                If PosX <= 50 Then
                    Vx = 6
                ElseIf PosX >= 400 Then
                    Vx = -6
                End If

        End Select
    End Sub
End Class

Public Class CCharFlyRobotic
    Inherits CCharacter
    Public CurrState As StateFlyRobotic
   
     Public Sub State(state As StateFlyRobotic, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0
    End Sub

    
    Public Overrides Sub Update()
        Select Case CurrState
            Case StateFlyRobotic.Create
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateFlyRobotic.MoveDiagonal, 1)
                    If FDir = FaceDir.Left Then
                        Vx = -10
                    Else
                        Vx = 10
                    End If
                    Vy = -5
                End If

            Case StateFlyRobotic.MoveDiagonal
                GetNextFrame()
                PosX = PosX + Vx
                PosY = PosY + Vy
                If PosX <= 50 Then
                    Vx = 10
                ElseIf PosX >= 400 Then
                    Vx = -10
                    Vy = 5
                ElseIf PosY <= 20 Then
                    Vx = 10
                    Vy = 5
                ElseIf PosY >= 250 Then
                    Vx = -10
                    Vy = -5
                ElseIf PosX = 108 And PosY = 108 And AvailTarget = True Then
                    Destroy = True
                    TargetX = 108
                    TargetY = 108
                End If
        End Select
    End Sub
End Class

Public Class CCharBubbleProjectile
    Inherits CCharacter
    
    Public CurrState As StateBubbleProjectile

    Public Sub State(state As StateBubbleProjectile, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0
    End Sub

    Public Overrides Sub Update()
        Select Case CurrState
             Case StateBubbleProjectile.Create
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateBubbleProjectile.Move, 1)
                    If FDir = FaceDir.Left Then
                        Vx = -8
                        Vy = 4
                    Else
                        Vx = 8
                        Vy = 4
                    End If
                End If

             Case StateBubbleProjectile.Move
                GetNextFrame()
                PosX = PosX + Vx
                PosY = PosY + Vy
                If PosY >= 250 Then
                    Vy = -4
                End If    
                If FDir = FaceDir.Left And PosX <= 50 Then
                    Destroy = True   
                Else If FDir = FaceDir.Right And PosX >= 400 Then
                    Destroy = True
                ElseIf PosX = 108 And PosY = 108 And AvailTarget = True Then
                    Destroy = True
                    TargetX = 108
                    TargetY = 108
                End If
        End Select
    End Sub
End Class

Public Class CElmtFrame
    Public CtrPoint As TPoint
    Public Top, Bottom, Left, Right As Integer
    Public Idx As Integer
    Public MaxFrameTime As Integer

    Public Sub New(ctrx As Integer, ctry As Integer, l As Integer, t As Integer, r As Integer, b As Integer, mft As Integer)
        CtrPoint.x = ctrx
        CtrPoint.y = ctry
        Top = t
        Bottom = b
        Left = l
        Right = r
        MaxFrameTime = mft

    End Sub
End Class

Public Class CArrFrame
    Public N As Integer
    Public Elmt As CElmtFrame()
    Public Sub New()
        N = 0
        ReDim Elmt(-1)
    End Sub

    Public Overloads Sub Insert(E As CElmtFrame)
        ReDim Preserve Elmt(N)
        Elmt(N) = E
        N = N + 1
    End Sub

    Public Overloads Sub Insert(ctrx As Integer, ctry As Integer, l As Integer, t As Integer, r As Integer, b As Integer, mft As Integer)
        Dim E As CElmtFrame
        E = New CElmtFrame(ctrx, ctry, l, t, r, b, mft)
        ReDim Preserve Elmt(N)
        Elmt(N) = E
        N = N + 1

    End Sub

End Class

Public Structure TPoint
    Dim x As Integer
    Dim y As Integer

End Structure

