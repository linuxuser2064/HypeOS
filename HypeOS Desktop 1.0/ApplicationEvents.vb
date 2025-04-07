Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Sub My_UnhandledException(sender As Object, e As ApplicationServices.UnhandledExceptionEventArgs) Handles MyBase.UnhandledException
            e.ExitApplication = False
            Form1.InException = True
            HypeSwitchFramebufMode()
            TouchOSContainer.TouchOsSwitchFramebufMode()
            Form1.println("
UNHANDLED EXCEPTION 0x" & Hex(e.Exception.HResult) + vbCrLf + e.Exception.Message)
            Form1.println("HypeOS has ran into an unhandled exception. To restart, close this window and
restart the program. To continue, Press any key.
It is recommended to restart HypeOS or the system might become unstable.")
            Form1.println("
Debug info: 
Stack trace: " + e.Exception.StackTrace + "
Exception source: " + e.Exception.Source)

            TouchOSContainer.println("
UNHANDLED EXCEPTION 0x" & Hex(e.Exception.HResult) + vbCrLf + e.Exception.Message)
            TouchOSContainer.println("HypeOS has ran into an unhandled exception. To restart, quit and
restart the program. To continue, Press any key.
It is recommended to restart HypeOS or the system might become unstable.")
            TouchOSContainer.println("
Debug info: 
Stack trace: " + e.Exception.StackTrace + "
Exception source: " + e.Exception.Source)
        End Sub
    End Class
End Namespace
