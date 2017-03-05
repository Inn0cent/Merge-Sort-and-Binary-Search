Module Module1

    Sub Main()
        Dim ar() As Integer = {245, 7, 8, 46, 6, 426, 8, 3546, 2456, 8, 35462, 763, 45, 6, 27, 674}
        Dim target As Integer = 426

        ar = mergesort(ar)

        For i = 0 To ar.Length - 1
            Console.WriteLine(ar(i))
        Next
        ' Console.WriteLine(Binsearch(ar, 0, ar.Length - 1, target))
        Console.ReadLine()
    End Sub

    Function Binsearch(M, low, high, target)
        Dim mid As Integer
        Dim result As Integer
        If low <= high Then
            mid = (low + high) / 2
            If M(mid) = target Then Return mid
            If M(mid) < target Then result = Binsearch(M, mid + 1, high, target)
            If M(mid) > target Then result = Binsearch(M, low, mid - 1, target)
        Else
            Return -1
        End If
        Return result
    End Function

    Function mergesort(ByVal ar() As Integer)
        If ar.Length <= 1 Then Return ar
        Dim left() As Integer = mergesort(ar.Take(ar.Length / 2).ToArray)
        Dim right() As Integer = mergesort(ar.Skip(ar.Length / 2).Take(ar.Length - (ar.Length / 2)).ToArray)
        Return merge(left, right)
    End Function

    Function merge(ByVal left() As Integer, ByVal right() As Integer)
        Dim temp(left.Length + right.Length - 1) As Integer
        Dim countL As Integer = 0
        Dim countR As Integer = 0
        Dim countT As Integer = 0

        While countT < temp.Length
            If countL < left.Length And countR < right.Length Then
                If left(countL) < right(countR) Then
                    temp(countT) = left(countL)
                    countL += 1
                    countT += 1
                ElseIf left(countL) > right(countR) Then
                    temp(countT) = right(countR)
                    countR += 1
                    countT += 1
                Else
                    temp(countT) = right(countR)
                    countR += 1
                    countT += 1
                    temp(countT) = left(countL)
                    countL += 1
                    countT += 1
                End If
            ElseIf countL = left.Length Then
                For i = countR To right.Length - 1
                    temp(countT) = right(i)
                    countT += 1
                Next
            ElseIf countR = right.Length Then
                For i = countL To left.Length - 1
                    temp(countT) = left(i)
                    countT += 1
                Next
            End If
        End While

        Return temp
    End Function


End Module
