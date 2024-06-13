Imports System.ComponentModel
Public Class AppSettings

    Implements INotifyPropertyChanged

    Private _isReversedByteOrder As Boolean = True
    Private _isAutoStartMonitorEnabled As Boolean = True
    Private _isRunAtStartupEnabled As Boolean = True
    Private _isMinimizeToTrayEnabled As Boolean = True

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property IsReversedByteOrder As Boolean
        Get
            Return _isReversedByteOrder
        End Get
        Set(value As Boolean)
            If _isReversedByteOrder <> value Then
                _isReversedByteOrder = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(IsReversedByteOrder)))
            End If
        End Set
    End Property

    Public Property IsAutoStartMonitorEnabled As Boolean
        Get
            Return _isAutoStartMonitorEnabled
        End Get
        Set(value As Boolean)
            If _isAutoStartMonitorEnabled <> value Then
                _isAutoStartMonitorEnabled = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(IsAutoStartMonitorEnabled)))
            End If
        End Set
    End Property

    Public Property IsRunAtStartupEnabled As Boolean
        Get
            Return _isRunAtStartupEnabled
        End Get
        Set(value As Boolean)
            If _isRunAtStartupEnabled <> value Then
                _isRunAtStartupEnabled = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(IsRunAtStartupEnabled)))
            End If
        End Set
    End Property

    Public Property IsMinimizeToTrayEnabled As Boolean
        Get
            Return _isMinimizeToTrayEnabled
        End Get
        Set(value As Boolean)
            If _isMinimizeToTrayEnabled <> value Then
                _isMinimizeToTrayEnabled = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(IsMinimizeToTrayEnabled)))
            End If
        End Set
    End Property

    Protected Sub OnPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

End Class
