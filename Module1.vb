Module Module1

    Structure BTNode
        Dim LP As Integer
        Dim Data As String
        Dim RP As Integer
    End Structure
    Dim Root As Integer = 0
    Dim CP As Integer = Root
    Dim BT(7) As BTNode

    Sub Main()
        Dim choice As Integer
        choice = 0
        Dim searchData As Char
        Dim number As Integer
        While choice <> 6
            Console.Clear()
            Console.WriteLine("Enter 1 to Initialize... ")
            Console.WriteLine("Enter 2 To Insert Data... ")
            Console.WriteLine("Enter 3 to Simple Search... ")
            Console.WriteLine("Enter 4 to Recursive Search... ")
            Console.WriteLine("Enter 5 to Traversal... ")
            Console.WriteLine("Enter 6 to Exit... ")
            Console.Write("Your choice... ")
            choice = Console.ReadLine
            Select Case choice
                Case 1 : initialize()
                Case 2 : insert()
                Case 3
                    Console.Write("Enter Data to Search ... ")
                    searchData = Console.ReadLine()
                    number = simple(searchData)
                    If number = -1 Then
                        Console.WriteLine("Record Not Found ... ")
                        Console.ReadKey()
                    Else
                        Console.WriteLine("Record Found... " & searchData)
                        Console.ReadKey()
                    End If
                Case 4
                    Console.Write("Enter Data to search ... ")
                    searchData = Console.ReadLine()
                    number = recursive(searchData, Root)
                    If number = -1 Then
                        Console.WriteLine("Record Not Found ... ")
                        Console.ReadKey()
                    Else
                        Console.WriteLine("Record Found... " & searchData)
                        Console.ReadKey()
                    End If
                Case 5 : traverse()
                Case 6 : Exit Sub
                Case Else
                    Console.WriteLine("Wrong choice made... Press any key to continue.")
                    Console.ReadKey()
            End Select
        End While
    End Sub

    Sub initialize()
        For i = 0 To 6
            BT(i).LP = -1
            BT(i).RP = -1
            BT(i).Data = ""
        Next
    End Sub

    Sub insert()
        Dim DataVal As String

        Console.WriteLine("Enter Data ... ")
        DataVal = Console.ReadLine

        Do
            If BT(CP).Data = "" Then
                BT(CP).Data = DataVal
            ElseIf DataVal < BT(CP).Data Then
                If BT(CP).LP <> -1 Then
                    CP = BT(CP).LP
                Else
                    BT(CP).LP = AvailablePos(7)
                    CP = BT(CP).LP
                End If
            Else
                If BT(CP).RP <> -1 Then
                    CP = BT(CP).RP
                Else
                    BT(CP).RP = AvailablePos(7)
                    CP = BT(CP).RP
                End If
            End If

        Loop Until BT(CP).Data = DataVal

    End Sub

    Function AvailablePos(ByVal X As Integer) As Integer
        Dim i As Integer
        i = 0
        For i = 0 To X
            If BT(i).Data = "" Then
                Return i
            End If
        Next
    End Function


    Function simple(ByVal DataV) As Integer
        Dim i As Integer
        i = Root
        Dim isFound As Boolean = False
        While BT(i).Data <> DataV And i <> -1
            If BT(i).Data = DataV Then
                isFound = True
            ElseIf BT(i).Data < DataV Then
                i = BT(i).LP
            Else
                i = BT(i).RP
            End If
        End While
        If isFound = True Then
            Return i
        Else
            Return -1
        End If
    End Function

    Function recursive(ByVal DataV As Char, ByVal Root As Integer) As Integer
        If Root = -1 Then
            Return -1
        ElseIf BT(Root).Data = DataV Then
            Return Root
        ElseIf BT(Root).Data < DataV Then
            Return recursive(DataV, BT(Root).RP)
        Else
            Return recursive(DataV, BT(Root).LP)
        End If
    End Function

    Sub traverse()
        Dim Left As Integer = BT(Root).LP
        Dim Right As Integer = BT(Root).RP
        If Root <> -1 Then
            Call traverse(Left)
            Console.WriteLine(BT(Root).Data)
            Call traverse(Right)
        End If
    End Sub

End Module
