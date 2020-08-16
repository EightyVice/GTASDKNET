Imports System.Windows.Forms
Imports GTASDK
Imports GTASDK.ViceCity

<PluginInfo(Author:="EightyVice", Version:="1.0")>
Public Class VBExample
    Inherits VCPlugin

    Public Sub New(ByVal cmdLine As String())
        AllocConsole()
    End Sub

    Public Sub GameTick() Handles MyBase.GameTicking
        If IsKeyPressed(Keys.F5) Then
            CStreaming.RequestModel(7, StreamingFlags.GameRequest)
            CStreaming.LoadAllRequestedModels(False)
            If CStreaming.GetInfoForModel(7).LoadState = StreamingLoadState.Loaded Then
                Dim p = New CCivilianPed(PedType.CIVFEMALE, 7)
                Dim playerpos = CPed.FindPlayerPed().Placement.pos
                CWorld.Add(p)
                Console.WriteLine($"Spawned with address 0x{p.BaseAddress:X} model id {p.ModelIndex} at {p.Placement.pos.X} {p.Placement.pos.Y} {p.Placement.pos.Z}")
            End If
        End If

        If IsKeyPressed(Keys.F6) Then
            CStreaming.RequestModel(232, StreamingFlags.PriorityRequest)
            CStreaming.LoadAllRequestedModels(False)
            Dim car = New CAutomobile(232, 1)
            car.State = 4
            Dim pos = CPed.FindPlayerPed().Placement.pos
            Console.WriteLine($"232 is loaded at address {car.BaseAddress:X}")
            CWorld.Add(car)
        End If
    End Sub
End Class
