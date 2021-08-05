Option Strict On 'This line helps us stay honest in our work!

'''This is a CLASS!
'''Classes are programming code bases that contain a bunch of tasks and jobs that you want your program to do.
'''
'''Classes use what is called INHERITANCE.  
'''
'''INHERITANCE is when you pass ATTRIBUTES down to other OBJECTS!
'''
'''Let's run this code to see what's going to happen!

Public Class Form1
    Private Timeleft As Integer = 51    'this is our countdown timer value 
    Private RandomNumber As Integer     'This generates a random number
    Private RandomNumber2 As Integer = Convert.ToInt32(Now.ToString("ssmm"))    'This is another random number


    'This is called a SUBROUTINE.  Subroutines do mundane, repetitive tasks that you don't like to mess with all the time.
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Label1.Text = String.Empty
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            SubmitGuess.Visible = False
            PictureBox1.Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'This subroutine handles the main START button.  Lots of stuff going on here!
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            RandomNumber = CInt(Int((RandomNumber2 * Rnd()) + 1)) 'THIS is the math part!!!  HOORAY FOR MRS. GRAYER!
            Disabler()
            Label1.Text = Timeleft & " Seconds left:"
            Timer1.Start()
            My.Computer.Audio.Play("D:\MITheme.wav", AudioPlayMode.Background)
            PictureBox1.Visible = True
            PictureBox1.Image = Image.FromFile("D:\green.gif")
        Catch ex As Exception
            Label1.Text = "Uh oh, there was a problem!"
            Disabler()
            Label1.Text = Timeleft & " Seconds left:"
            Timer1.Start()
            PictureBox1.Visible = True
            PictureBox1.Image = Image.FromFile("D:\green.gif")
        End Try

    End Sub


    'This is a TIMER.  Timers count down to a value that you choose to set, by the number that you choose to INCREMENT the counter by.
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Timer1.Interval = 1000 ' this is in MILLISECONDS!!!  MAAAAAATH!

        'TO CALCULATE MILLISECONDS
        '1000 MILLISECONDS = 1 SECOND

        ProgressBar1.Increment(-2)  'this takes the green bar at the bottom of the form and it makes it smaller....and smaller....

        'Remember TIMELEFT above at the top of the form?  Look up again :)
        Select Case Timeleft
            Case > 40
                Timeleft -= 1
                Label1.Text = Timeleft.ToString & " Seconds Left"
            Case > 30
                Timeleft -= 1
                Label1.Text = Timeleft.ToString & " Seconds Left...You'll Never Get it!"
            Case > 20
                BackColor = Color.Yellow
                ForeColor = Color.Black
                PictureBox1.Image = Image.FromFile("D:\yellow.gif")
                Timeleft -= 1
                Label1.Text = Timeleft.ToString & " Seconds Left...why are you still trying?"
            Case > 10
                Timeleft -= 1
                Label1.Text = Timeleft.ToString & " Seconds Left...Sigh....just QUIT :) "
            Case 10
                BackColor = Color.DarkRed
                ForeColor = Color.White
                PictureBox1.Image = Image.FromFile("D:\red.gif")
                Timeleft -= 1
                Label1.Text = Timeleft.ToString & " Seconds Left...I "
            Case 9
                Timeleft -= 1
                Label1.Text = Timeleft.ToString & " Seconds Left...TOLD "
            Case 8
                Timeleft -= 1
                Label1.Text = Timeleft.ToString & " Seconds Left...YOU "
            Case 7
                Timeleft -= 1
                Label1.Text = Timeleft.ToString & " Seconds Left...THIS "
            Case 6
                Timeleft -= 1
                Label1.Text = Timeleft.ToString & " Seconds Left...WAS "
            Case 5
                Timeleft -= 1
                Label1.Text = Timeleft.ToString & " Seconds Left...MISSION "
            Case 4
                Timeleft -= 1
                Label1.Text = Timeleft.ToString & " Seconds Left...IMPOSSIBLE "
            Case 3
                Timeleft -= 1
                Label1.Text = Timeleft.ToString & " Seconds Left...YOU "
            Case 2
                Timeleft -= 1
                Label1.Text = Timeleft.ToString & " Seconds Left...LOSE!!! "
            Case 1
                Timer1.Stop()
                My.Computer.Audio.Play("D:\bomb.wav", AudioPlayMode.Background)
                Label1.Text = "Time's Up! The answer was " & RandomNumber.ToString()
                SetTimerValue.Text = String.Empty
                BackColor = Color.Black
                ForeColor = Color.White
                Button1.ForeColor = Color.Black
                Enabler()
        End Select
    End Sub

    'This SUBROUTINE handles what happens when a person clicks the "Make a Guess" Button...
    Private Sub SubmitGuess_Click(sender As Object, e As EventArgs) Handles SubmitGuess.Click

        If Not IsNumeric(SetTimerValue.Text) Then
            Label3.Text = "Uh, does " & SetTimerValue.Text & " look like a NUMBER to you?!?  Try again, SMH..."
            SetTimerValue.Text = String.Empty
            SetTimerValue.Focus()
        ElseIf Convert.ToInt32(SetTimerValue.Text) = RandomNumber Then
            Label1.Text = "That was a lucky guess!!!"
            Timer1.Stop()
        Else
            Select Case Timeleft
                Case >= 50, > 45
                    Label3.Text = "No."
                Case >= 44, > 40
                    Label3.Text = "Nope."
                Case >= 39, > 35
                    Label3.Text = "Nee."
                Case >= 34, > 30
                    Label3.Text = "Negative."
                Case >= 29, > 25
                    Label3.Text = "Negatory."
                Case >= 24, > 20
                    Label3.Text = "Nooooooooooo."
                Case >= 19, > 15
                    Label3.Text = "No Dice."
                Case >= 14, > 10
                    Label3.Text = "Not Close."
                Case >= 9, > 5
                    Label3.Text = "Not Remotely Close."
                Case >= 4, > 0
                    Label3.Text = "Not Even Close."
                Case Else
                    Label3.Text = "Just. Give. Up. Now."
            End Select
            SetTimerValue.Text = String.Empty
            SetTimerValue.Focus()
        End If
    End Sub

    'What would we use these two Subroutines for?
    Private Sub Enabler()
        'We have to reset everything to what it was before!
        Button1.Enabled = True
        SubmitGuess.Visible = False
        ProgressBar1.Refresh()
        ProgressBar1.Value = 100
        ProgressBar1.Maximum = 100
        PictureBox1.Visible = False
        Timeleft = 50
        MsgBox("Thanks for playing!")
    End Sub

    Private Sub Disabler()
        Button1.Enabled = False
        SubmitGuess.Visible = True
        BackColor = Control.DefaultBackColor
        ForeColor = Control.DefaultForeColor
    End Sub


End Class
