Option Strict On
Imports System

Module Program
    Sub Main(args As String())

        Dim someDecimal As Decimal = 100.1D
        Dim stringNum As String = Nothing

        someDecimal += Convert.ToDecimal(stringNum)

        Console.WriteLine(someDecimal)
        Console.ReadLine()
    End Sub
End Module
