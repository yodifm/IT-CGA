Imports System.IO

Public Class Form1

    Dim bmp As Bitmap
    Dim Bg, Bg1, Img As CImage
    Dim SpriteMap As CImage
    Dim SpriteMask As CImage
    Dim BCComeIn, BCIntro, BCStand, BCWalk, BCLeapStart, BCLeap, BCLeapDown, BCLeapEnd, BCJump, BCJumpDown, BCJumpEnd As CArrFrame
    Dim BCCrabClawsStart, BCCrabClawsUp, BCCrabClawsDown, BCCrabClawsEnd As CArrFrame
    Dim DZComeIn, DZFloat As CArrFrame
    Dim BCBubbleShieldStart, BCBubbleShieldEnd, BCBubbleShieldJump, BCBubbleShieldJumpDown, BCBubbleShieldWalk, BCBubbleShieldStand As CArrFrame
    Dim BCBubbleShieldShoot1Start, BCBubbleShieldShoot1, BCBubbleShieldShoot2Start, BCBubbleShieldShoot2, BCBubbleShieldShoot3Start, BCBubbleShieldShoot3, BCBubbleShieldShoot12End, BCBubbleShieldShoot3End As CArrFrame
    'Shoot1 = RoboticShield
    'Shoot2 = FlyRobotic
    'Shoot3 = BubbleSplash
    Dim BCBubbleSplashStart, BCBubbleSplashShoot, BCBubbleSplashEnd As CArrFrame
    Dim BubbleProjCreate, BubbleProjMove As CArrFrame
    Dim RoboticShieldCreate1, RoboticShieldCreate2, RoboticShieldCreate3, RoboticShieldFloat, RoboticShieldChase As CArrFrame
    Dim FlyRoboticCreate1, FlyRoboticCreate2, FlyRoboticCreate3, FlyRoboticCreate4, FlyRoboticMove As CArrFrame
    Dim ListChar As New List(Of CCharacter)
    Dim BC As CCharBubbleCrab

    Public Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'Note : ' = KeyValue
        If e.KeyValue = Keys.Right Then '39
            BC.State(StateSplitBC.WalkRight, 2)
        ElseIf e.KeyValue = Keys.Left Then '37
            BC.State(StateSplitBC.WalkLeft, 2)
        ElseIf e.KeyValue = Keys.Up Then '38
            BC.State(StateSplitBC.Jump, 12)
        ElseIf e.KeyValue = Keys.Down Then '40
            BC.State(StateSplitBC.Stand, 3)
        ElseIf e.KeyValue = Keys.Space Then '32
            BC.State(StateSplitBC.LeapStart, 4)
        ElseIf e.KeyValue = Keys.D1 Then '49
            BC.State(StateSplitBC.CrabClawsStart, 8)
        ElseIf e.KeyValue = Keys.D2 Then '50
            BC.State(StateSplitBC.BubbleShieldStart, 18)
        ElseIf e.KeyValue = Keys.D3 Then '51
            BC.State(StateSplitBC.BubbleShieldShoot1Start, 19)
        ElseIf e.KeyValue = Keys.D4 Then '52
            BC.State(StateSplitBC.BubbleShieldShoot2Start, 20)
        ElseIf e.KeyValue = Keys.D5 Then '53
            BC.State(StateSplitBC.BubbleShieldShoot3Start, 21)
        ElseIf e.KeyValue = Keys.D6 Then '54
            BC.State(StateSplitBC.BubbleSplashStart, 15)
        ElseIf e.KeyValue = Keys.W Then '87
            BC.State(StateSplitBC.BubbleShieldJump, 22)
        ElseIf e.KeyValue = Keys.A Then '65
            BC.State(StateSplitBC.BubbleShieldWalkLeft, 23)
        ElseIf e.KeyValue = Keys.S Then '83
            BC.State(StateSplitBC.BubbleShieldStand, 24)
        ElseIf e.KeyValue = Keys.D Then '68
            BC.State(StateSplitBC.BubbleShieldWalkRight, 23)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Public Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'open image for background, assign to bg

        Randomize()
        Bg = New CImage
        Bg.OpenImage("C:\Users\luqman\Downloads\backgroundfix.bmp")

        Bg.CopyImg(Img)

        Bg.CopyImg(Bg1)

        SpriteMap = New CImage
        SpriteMap.OpenImage("C:\Users\luqman\Downloads\BC(3).bmp")

        SpriteMap.CreateMask(SpriteMask)

        'initialize sprites
        BCComeIn = New CArrFrame
        BCComeIn.Insert(80, 80, 59, 60, 108, 98, 1)

        BCStand = New CArrFrame
        BCStand.Insert(30, 24, 9, 8, 57, 40, 1)

        BCIntro = New CArrFrame
        BCIntro.Insert(30, 24, 9, 8, 57, 40, 3)
        BCIntro.Insert(125, 24, 106, 10, 149, 39, 6)
        BCIntro.Insert(89, 201, 62, 165, 123, 220, 3)
        BCIntro.Insert(30, 201, 5, 154, 58, 220, 3)
        BCIntro.Insert(89, 201, 62, 165, 123, 220, 3)
        BCIntro.Insert(30, 201, 5, 154, 58, 220, 3)
        BCIntro.Insert(360, 24, 340, 4, 384, 38, 3)
        BCIntro.Insert(411, 24, 387, 4, 428, 40, 3)
        BCIntro.Insert(451, 24, 430, 2, 474, 38, 3)
        BCIntro.Insert(230, 250, 214, 232, 256, 268, 3)
        BCIntro.Insert(125, 24, 106, 10, 149, 39, 3)
        BCIntro.Insert(172, 24, 153, 10, 196, 39, 3)
        BCIntro.Insert(218, 24, 200, 9, 242, 38, 3)
        BCIntro.Insert(265, 24, 247, 9, 289, 39, 3)
        BCIntro.Insert(312, 24, 294, 10, 337, 38, 3)
        BCIntro.Insert(30, 24, 9, 8, 57, 40, 3)

        BCWalk = New CArrFrame
        BCWalk.Insert(30, 250, 8, 231, 56, 268, 1)
        BCWalk.Insert(80, 250, 61, 232, 107, 268, 1)
        BCWalk.Insert(130, 250, 111, 232, 157, 268, 1)
        BCWalk.Insert(182, 250, 161, 230, 209, 268, 1)

        BCLeapStart = New CArrFrame
        BCLeapStart.Insert(30, 250, 8, 231, 56, 268, 1)
        BCLeapStart.Insert(30, 73, 8, 53, 53, 96, 2)

        BCLeap = New CArrFrame
        BCLeap.Insert(30, 73, 8, 53, 53, 96, 1)

        BCLeapDown = New CArrFrame
        BCLeapDown.Insert(80, 80, 59, 60, 108, 98, 1)

        BCLeapEnd = New CArrFrame
        BCLeapEnd.Insert(125, 24, 106, 10, 149, 39, 5)
        BCLeapEnd.Insert(30, 24, 9, 8, 57, 40, 3)

        BCCrabClawsStart = New CArrFrame
        BCCrabClawsStart.Insert(30, 201, 5, 154, 58, 220, 2)
        BCCrabClawsStart.Insert(89, 201, 62, 165, 123, 220, 2)
        BCCrabClawsStart.Insert(30, 201, 5, 154, 58, 220, 2)
        BCCrabClawsStart.Insert(89, 201, 62, 165, 123, 220, 2)

        BCCrabClawsUp = New CArrFrame
        BCCrabClawsUp.Insert(152, 194, 125, 145, 180, 222, 1)
        BCCrabClawsUp.Insert(210, 194, 183, 154, 242, 222, 1)
        BCCrabClawsUp.Insert(152, 194, 125, 145, 180, 222, 1)
        BCCrabClawsUp.Insert(210, 194, 183, 154, 242, 222, 1)

        BCCrabClawsDown = New CArrFrame
        BCCrabClawsDown.Insert(268, 192, 245, 146, 296, 221, 1)
        BCCrabClawsDown.Insert(327, 193, 300, 152, 359, 220, 1)
        BCCrabClawsDown.Insert(268, 192, 245, 146, 296, 221, 1)
        BCCrabClawsDown.Insert(327, 193, 300, 152, 359, 220, 1)

        BCCrabClawsEnd = New CArrFrame
        BCCrabClawsEnd.Insert(125, 24, 106, 10, 149, 39, 5)
        BCCrabClawsEnd.Insert(30, 24, 9, 8, 57, 40, 3)

        BCJump = New CArrFrame
        BCJump.Insert(30, 73, 8, 53, 53, 96, 1)

        BCJumpDown = New CArrFrame
        BCJumpDown.Insert(80, 80, 59, 60, 108, 98, 1)

        BCJumpEnd = New CArrFrame
        BCJumpEnd.Insert(125, 24, 106, 10, 149, 39, 5)
        BCJumpEnd.Insert(30, 24, 9, 8, 57, 40, 3)

        BCBubbleSplashStart = New CArrFrame
        BCBubbleSplashStart.Insert(360, 24, 340, 4, 384, 38, 1)
        BCBubbleSplashStart.Insert(411, 24, 387, 4, 428, 40, 1)
        BCBubbleSplashStart.Insert(230, 250, 214, 232, 256, 268, 3)
        BCBubbleSplashStart.Insert(273, 250, 258, 231, 299, 268, 3)

        BCBubbleSplashShoot = New CArrFrame
        BCBubbleSplashShoot.Insert(317, 250, 302, 233, 342, 268, 2)
        BCBubbleSplashShoot.Insert(360, 250, 345, 232, 388, 268, 3)
        BCBubbleSplashShoot.Insert(317, 250, 302, 233, 342, 268, 2)
        BCBubbleSplashShoot.Insert(360, 250, 345, 232, 388, 268, 2)

        BCBubbleSplashEnd = New CArrFrame
        BCBubbleSplashEnd.Insert(273, 250, 258, 231, 299, 268, 3)
        BCBubbleSplashEnd.Insert(230, 250, 214, 232, 256, 268, 3)
        BCBubbleSplashEnd.Insert(360, 24, 340, 4, 384, 38, 1)

        BCBubbleShieldStart = New CArrFrame
        BCBubbleShieldStart.Insert(30, 129, 8, 109, 57, 149, 1)
        BCBubbleShieldStart.Insert(81, 128, 61, 108, 111, 149, 1)
        BCBubbleShieldStart.Insert(432, 363, 398, 329, 467, 392, 1)
        BCBubbleShieldStart.Insert(352, 363, 323, 330, 386, 393, 1)

        BCBubbleShieldWalk = New CArrFrame
        BCBubbleShieldWalk.Insert(37, 585, 7, 555, 77, 617, 1)
        BCBubbleShieldWalk.Insert(116, 585, 86, 554, 153, 617, 1)
        BCBubbleShieldWalk.Insert(197, 585, 166, 554, 234, 616, 1)
        BCBubbleShieldWalk.Insert(274, 585, 245, 554, 309, 616, 1)

        BCBubbleShieldJump = New CArrFrame
        BCBubbleShieldJump.Insert(116, 363, 87, 332, 150, 393, 1)

        BCBubbleShieldJumpDown = New CArrFrame
        BCBubbleShieldJumpDown.Insert(275, 363, 243, 331, 308, 393, 1)

        BCBubbleShieldStand = New CArrFrame
        BCBubbleShieldStand.Insert(36, 363, 6, 330, 72, 395, 20)

        BCBubbleShieldShoot1Start = New CArrFrame
        BCBubbleShieldShoot1Start.Insert(30, 129, 8, 109, 57, 149, 1)
        BCBubbleShieldShoot1Start.Insert(81, 128, 61, 108, 111, 149, 1)
        BCBubbleShieldShoot1Start.Insert(432, 363, 398, 329, 467, 392, 1)
        BCBubbleShieldShoot1Start.Insert(352, 363, 323, 330, 386, 393, 1)

        BCBubbleShieldShoot2Start = New CArrFrame
        BCBubbleShieldShoot2Start.Insert(30, 129, 8, 109, 57, 149, 1)
        BCBubbleShieldShoot2Start.Insert(81, 128, 61, 108, 111, 149, 1)
        BCBubbleShieldShoot2Start.Insert(432, 363, 398, 329, 467, 392, 1)
        BCBubbleShieldShoot2Start.Insert(352, 363, 323, 330, 386, 393, 1)

        BCBubbleShieldShoot3Start = New CArrFrame
        BCBubbleShieldShoot3Start.Insert(30, 129, 8, 109, 57, 149, 1)
        BCBubbleShieldShoot3Start.Insert(81, 128, 61, 108, 111, 149, 1)
        BCBubbleShieldShoot3Start.Insert(432, 363, 398, 329, 467, 392, 1)
        BCBubbleShieldShoot3Start.Insert(352, 363, 323, 330, 386, 393, 1)
        BCBubbleShieldShoot3Start.Insert(414, 489, 385, 457, 454, 519, 3)
        BCBubbleShieldShoot3Start.Insert(340, 489, 311, 457, 381, 519, 3)

        BCBubbleShieldShoot1 = New CArrFrame
        BCBubbleShieldShoot1.Insert(352, 363, 323, 330, 386, 393, 1)
        BCBubbleShieldShoot1.Insert(36, 363, 6, 330, 72, 395, 1)
        BCBubbleShieldShoot1.Insert(193, 363, 165, 331, 228, 393, 15)

        BCBubbleShieldShoot2 = New CArrFrame
        BCBubbleShieldShoot2.Insert(352, 363, 323, 330, 386, 393, 1)
        BCBubbleShieldShoot2.Insert(36, 363, 6, 330, 72, 395, 1)
        BCBubbleShieldShoot2.Insert(193, 363, 165, 331, 228, 393, 15)

        BCBubbleShieldShoot3 = New CArrFrame
        BCBubbleShieldShoot3.Insert(263, 489, 233, 457, 300, 519, 2)
        BCBubbleShieldShoot3.Insert(190, 489, 157, 457, 229, 519, 3)
        BCBubbleShieldShoot3.Insert(263, 489, 233, 457, 300, 519, 2)
        BCBubbleShieldShoot3.Insert(190, 489, 157, 457, 229, 519, 2)

        BCBubbleShieldShoot12End = New CArrFrame
        BCBubbleShieldShoot12End.Insert(193, 363, 165, 331, 228, 393, 1)
        BCBubbleShieldShoot12End.Insert(36, 363, 6, 330, 72, 395, 1)
        BCBubbleShieldShoot12End.Insert(352, 363, 323, 330, 386, 393, 1)

        BCBubbleShieldShoot3End = New CArrFrame
        BCBubbleShieldShoot3End.Insert(340, 489, 311, 457, 381, 519, 3)
	    BCBubbleShieldShoot3End.Insert(414, 489, 385, 457, 454, 519, 3)
        BCBubbleShieldShoot3End.Insert(36, 363, 6, 330, 72, 395, 1)

        BCBubbleShieldEnd = New CArrFrame
        BCBubbleShieldEnd.Insert(352, 363, 323, 330, 386, 393, 5)
        BCBubbleShieldEnd.Insert(30, 129, 8, 109, 57, 149, 1)


        BC = New CCharBubbleCrab
        ReDim BC.ArrSprites(31)
        BC.ArrSprites(0) = BCComeIn
        BC.ArrSprites(1) = BCIntro
        BC.ArrSprites(2) = BCWalk
        BC.ArrSprites(3) = BCStand

        BC.ArrSprites(4) = BCLeapStart
        BC.ArrSprites(5) = BCLeap
        BC.ArrSprites(6) = BCLeapDown
        BC.ArrSprites(7) = BCLeapEnd

        BC.ArrSprites(8) = BCCrabClawsStart
        BC.ArrSprites(9) = BCCrabClawsUp
        BC.ArrSprites(10) = BCCrabClawsDown
        BC.ArrSprites(11) = BCCrabClawsEnd

        BC.ArrSprites(12) = BCJump
        BC.ArrSprites(13) = BCJumpDown
        BC.ArrSprites(14) = BCJumpEnd

        BC.ArrSprites(15) = BCBubbleSplashStart
        BC.ArrSprites(16) = BCBubbleSplashShoot
        BC.ArrSprites(17) = BCBubbleSplashEnd

        BC.ArrSprites(18) = BCBubbleShieldStart
        BC.ArrSprites(19) = BCBubbleShieldShoot1Start
        BC.ArrSprites(20) = BCBubbleShieldShoot2Start
        BC.ArrSprites(21) = BCBubbleShieldShoot3Start
        BC.ArrSprites(22) = BCBubbleShieldJump
        BC.ArrSprites(23) = BCBubbleShieldWalk
        BC.ArrSprites(24) = BCBubbleShieldStand
        BC.ArrSprites(25) = BCBubbleShieldShoot1
        BC.ArrSprites(26) = BCBubbleShieldShoot2
        BC.ArrSprites(27) = BCBubbleShieldShoot3
        BC.ArrSprites(28) = BCBubbleShieldShoot12End
        BC.ArrSprites(29) = BCBubbleShieldShoot3End
        BC.ArrSprites(30) = BCBubbleShieldEnd
        BC.ArrSprites(31) = BCBubbleShieldJumpDown


        BC.PosX = 342
        BC.PosY = 83
        BC.Vx = 0
        BC.Vy = 5
        BC.State(StateSplitBC.ComeIn, 0)
        BC.FDir = FaceDir.Left

        ListChar.Add(BC)

        DZComeIn = New CArrFrame
        DZComeIn.Insert(691, 514, 675, 496, 709, 539, 1)

        DZFloat = New CArrFrame
        DZFloat.Insert(580, 515, 571, 496, 589, 539, 1)
        DZFloat.Insert(600, 515, 591, 496, 610, 539, 1)

        BubbleProjCreate = New CArrFrame
        BubbleProjCreate.Insert(706, 263, 699, 257, 710, 271, 1)
        BubbleProjCreate.Insert(723, 263, 713, 257, 730, 269, 1)
        BubbleProjCreate.Insert(754, 260, 735, 248, 770, 269, 1)
        BubbleProjCreate.Insert(794, 259, 776, 247, 807, 269, 1)
        BubbleProjCreate.Insert(827, 261, 813, 246, 840, 270, 1)
        BubbleProjCreate.Insert(873, 259, 850, 244, 884, 271, 1)
        BubbleProjCreate.Insert(753, 298, 729, 282, 767, 307, 1)
        BubbleProjCreate.Insert(795, 298, 773, 282, 810, 307, 1)
        BubbleProjCreate.Insert(843, 297, 819, 281, 857, 308, 1)

        BubbleProjMove = New CArrFrame
        BubbleProjMove.Insert(843, 297, 819, 281, 857, 308, 1)

        RoboticShieldCreate1 = New CArrFrame
        RoboticShieldCreate1.Insert(75, 423, 55, 404, 96, 441, 1)

        RoboticShieldCreate2 = New CArrFrame
        RoboticShieldCreate2.Insert(75, 423, 55, 404, 96, 441, 1)

        RoboticShieldCreate3 = New CArrFrame
        RoboticShieldCreate3.Insert(75, 423, 55, 404, 96, 441, 1)

        RoboticShieldFloat = New CArrFrame
        RoboticShieldFloat.Insert(75, 423, 55, 404, 96, 441, 2)
        RoboticShieldFloat.Insert(26, 423, 5, 404, 45, 441, 2)
        RoboticShieldFloat.Insert(124, 423, 103, 405, 145, 441, 2)

        FlyRoboticCreate1 = New CArrFrame
        FlyRoboticCreate1.Insert(644, 359, 630, 347, 656, 370, 1)

        FlyRoboticCreate2 = New CArrFrame
        FlyRoboticCreate2.Insert(644, 359, 630, 347, 656, 370, 1)

        FlyRoboticCreate3 = New CArrFrame
        FlyRoboticCreate3.Insert(644, 359, 630, 347, 656, 370, 1)

        FlyRoboticCreate4 = New CArrFrame
        FlyRoboticCreate4.Insert(644, 359, 630, 347, 656, 370, 1)

        FlyRoboticMove = New CArrFrame
        FlyRoboticMove.Insert(644, 359, 630, 347, 656, 370, 1)
        FlyRoboticMove.Insert(669, 359, 658, 347, 681, 370, 1)
        FlyRoboticMove.Insert(694, 359, 683, 347, 707, 370, 1)
        FlyRoboticMove.Insert(669, 359, 658, 347, 681, 370, 1)

        bmp = New Bitmap(Img.Width, Img.Height)

        DisplayImg()
        ResizeImg()

        Timer1.Enabled = True
    End Sub

    Sub PutSprite()
        Dim CC As CCharacter
        Dim i, j As Integer
        'set background
        For i = 0 To Img.Width - 1
            For j = 0 To Img.Height - 1
                Img.Elmt(i, j) = Bg1.Elmt(i, j)
            Next
        Next

        For Each CC In ListChar
            Dim EF As CElmtFrame = CC.ArrSprites(CC.IdxArrSprites).Elmt(CC.FrameIdx)
            Dim spritewidth = EF.Right - EF.Left
            Dim spriteheight = EF.Bottom - EF.Top


            If CC.FDir = FaceDir.Left Then
                Dim spriteleft As Integer = CC.PosX - EF.CtrPoint.x + EF.Left
                Dim spritetop As Integer = CC.PosY - EF.CtrPoint.y + EF.Top
                'set mask
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMask.Elmt(EF.Left + i, EF.Top + j))
                    Next
                Next

                'set sprite
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMap.Elmt(EF.Left + i, EF.Top + j))
                    Next
                Next
            Else 'facing right
                Dim spriteleft = CC.PosX + EF.CtrPoint.x - EF.Right
                Dim spritetop = CC.PosY - EF.CtrPoint.y + EF.Top
                'set mask
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMask.Elmt(EF.Right - i, EF.Top + j))
                    Next
                Next

                'set sprite
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMap.Elmt(EF.Right - i, EF.Top + j))
                    Next
                Next

            End If
        Next
    End Sub

    Sub DisplayImg()
        'display bg and sprite on picturebox
        Dim i, j As Integer
        PutSprite()

        For i = 0 To Img.Width - 1
            For j = 0 To Img.Height - 1
                bmp.SetPixel(i, j, Img.Elmt(i, j))
            Next
        Next

        PictureBox1.Refresh()

        PictureBox1.Image = bmp
        PictureBox1.Width = bmp.Width
        PictureBox1.Height = bmp.Height
        PictureBox1.Top = 0
        PictureBox1.Left = 0
        'Me.Width = PictureBox1.Width + 30
        'Me.Height = PictureBox1.Height + 100





    End Sub

    Sub ResizeImg()
        Dim w, h As Integer

        w = PictureBox1.Width
        h = PictureBox1.Height

        Me.ClientSize = New Size(w, h)

    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim CC As CCharacter
        
        If AvailTarget = False Then
             If RespawnTime > 0 Then
                RespawnTime = RespawnTime - 1
             Else
                RespawnTime = 20
                CreateDummyZombie(1)
                AvailTarget = True
                If AvailTarget = True Then
                    TargetX = 50
                    TargetY = 50
                End If
             End If
        End If

        PictureBox1.Refresh()
        
        For Each CC In ListChar
            CC.Update()
        Next

        If BC.CurrState = StateSplitBC.Intro And BC.FrameIdx = 0 AndAlso BC.CurrFrame = 1 Then
            CreateDummyZombie(1)
        'Bubble Splash
        ElseIf BC.CurrState = StateSplitBC.BubbleSplashShoot And BC.FrameIdx = 0 AndAlso BC.CurrFrame = 0 Then
            CreateBubbleProjectile(1)

        ElseIf BC.CurrState = StateSplitBC.BubbleShieldShoot3 And BC.FrameIdx = 0 AndAlso BC.CurrFrame = 0 Then
            CreateBubbleProjectile(1)

            'Bubble Robotic Shield
        ElseIf BC.CurrState = StateSplitBC.BubbleShieldShoot1 And BC.FrameIdx = 2 AndAlso BC.CurrFrame = 2 Then
            CreateRoboticShield(1)

        ElseIf BC.CurrState = StateSplitBC.BubbleShieldShoot1 And BC.FrameIdx = 2 AndAlso BC.CurrFrame = 8 Then
            CreateRoboticShield(2)

        ElseIf BC.CurrState = StateSplitBC.BubbleShieldShoot1 And BC.FrameIdx = 2 AndAlso BC.CurrFrame = 14 Then
            CreateRoboticShield(3)
            'Fly Robotic Crab
        ElseIf BC.CurrState = StateSplitBC.BubbleShieldShoot2 And BC.FrameIdx = 2 AndAlso BC.CurrFrame = 3 Then
            CreateFlyRobotic(1)
            CreateFlyRobotic(2)
            CreateFlyRobotic(3)
            CreateFlyRobotic(4)


        End If

        Dim ListChar1 As New List(Of CCharacter)
        For Each CC In ListChar
            If Not CC.Destroy Then
                ListChar1.Add(CC)
            End If
        Next

        ListChar = ListChar1

        
        DisplayImg()
       
    End Sub

    Sub CreateDummyZombie(n As Integer)
        Dim DZ As CCharDummyZombie
        DZ = New CCharDummyZombie

        If BC.FDir = FaceDir.Left Then
            DZ.FDir = FaceDir.Right
        Else
            DZ.FDir = FaceDir.Left
        End If
        DZ.PosX = 108
        DZ.PosY = 50
        If n = 1 Then
            DZ.Vy = 4
        End If

        DZ.CurrState = StateDummyZombie.ComeIn
        ReDim DZ.ArrSprites(1)
        DZ.ArrSprites(0) = DZComeIn
        DZ.ArrSprites(1) = DZFloat

        ListChar.Add(DZ)
    End Sub

    Sub CreateFlyRobotic(n As Integer)
        Dim FR As CCharFlyRobotic
        FR = New CCharFlyRobotic

        If BC.FDir = FaceDir.Left Or BC.PosX <= 60 Then
            FR.FDir = FaceDir.Left
            If n = 1 Then '90 degree
                FR.PosX = BC.PosX
                FR.PosY = BC.PosY - 20
            ElseIf n = 2 Then 'Around 70 degree
                FR.PosX = BC.PosX - 9
                FR.PosY = BC.PosY - 16
            ElseIf n = 3 Then 'Around 30 degree
                FR.PosX = BC.PosX - 16
                FR.PosY = BC.PosY - 9
            ElseIf n = 4 Then '0 degree
                FR.PosX = BC.PosX - 20
                FR.PosY = BC.PosY
            End If

        ElseIf BC.FDir = FaceDir.Right Or BC.PosX >= 390 Then
            FR.FDir = FaceDir.Left
            If n = 1 Then '90 degree
                FR.PosX = BC.PosX
                FR.PosY = BC.PosY - 20
            ElseIf n = 2 Then 'Around 70 degree
                FR.PosX = BC.PosX - 9
                FR.PosY = BC.PosY - 16
            ElseIf n = 3 Then 'Around 30 degree
                FR.PosX = BC.PosX - 16
                FR.PosY = BC.PosY - 9
            ElseIf n = 4 Then '0 degree
                FR.PosX = BC.PosX + 20
                FR.PosY = BC.PosY
            End If
        End If

        FR.CurrState = StateFlyRobotic.Create
        ReDim FR.ArrSprites(1)
        If n = 1 Then
            FR.ArrSprites(0) = FlyRoboticCreate1
        ElseIf n = 2 Then
            FR.ArrSprites(0) = FlyRoboticCreate2
        ElseIf n = 3 Then
            FR.ArrSprites(0) = FlyRoboticCreate3
        ElseIf n = 4 Then
            FR.ArrSprites(0) = FlyRoboticCreate4
        End If
        FR.ArrSprites(1) = FlyRoboticMove

        ListChar.Add(FR)
    End Sub


    Sub CreateRoboticShield(n As Integer)
        Dim RS As CCharRoboticShield
        RS = New CCharRoboticShield

        If BC.FDir = FaceDir.Left Then
            RS.PosX = BC.PosX
            RS.FDir = FaceDir.Left
        Else
            RS.PosX = BC.PosX
            RS.FDir = FaceDir.Right
        End If

        RS.PosY = BC.PosY - 20

        RS.Vx = 0
        RS.Vy = 0
        RS.CurrState = StateRoboticShield.Create
        ReDim RS.ArrSprites(1)
        If n = 1 Then
            RS.ArrSprites(0) = RoboticShieldCreate1
        ElseIf n = 2 Then
            RS.ArrSprites(0) = RoboticShieldCreate2
        ElseIf n = 3 Then
            RS.ArrSprites(0) = RoboticShieldCreate3

        End If
        RS.ArrSprites(1) = RoboticShieldFloat

        ListChar.Add(RS)

    End Sub


    Sub CreateBubbleProjectile(n As Integer)
        Dim BSp As CCharBubbleProjectile
        BSp = New CCharBubbleProjectile

         
        If BC.FDir = FaceDir.Left Then
            BSp.PosX = BC.PosX - 10
            BSp.FDir = FaceDir.Left
            BSp.Vx = -2
        Else
            BSp.PosX = BC.PosX + 10
            BSp.FDir = FaceDir.Right
            BSp.Vx = 2
        End If
        BSp.PosY = BC.PosY + 7
        BSp.Vx = 0
        BSp.Vy = 0
        BSp.CurrState = StateBubbleProjectile.Create
        ReDim BSp.ArrSprites(1)
        If n = 1 Then
            BSp.ArrSprites(0) = BubbleProjCreate
        End If
        BSp.ArrSprites(1) = BubbleProjMove

        
        ListChar.Add(BSp)
    End Sub

End Class
