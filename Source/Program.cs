using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Phoenix.Core;
namespace Phoenix
{
    internal class Program
    {
        private delegate bool EventHandler(CtrlType sig);
        private enum CtrlType
        {
            CTRL_BREAK_EVENT = 1,
            CTRL_C_EVENT = 0,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }
        private static bool Booted = false;
        private static EventHandler OnShutdown;
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(Program.EventHandler handler, bool add);
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        public static void Main(string[] args)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(Program.CriticalExceptionLogger);
            Program.OnShutdown = (Program.EventHandler)Delegate.Combine(Program.OnShutdown, new Program.EventHandler(Program.Shutdown));
            Program.SetConsoleCtrlHandler(Program.OnShutdown, true);

            try
            {
                Phoenix @class = new Phoenix();

                //if (Licence.CheckHostsFile(false))
                //{
                //    return;
                //}

                @class.Initialize();

                Program.Booted = true;

                while (true)
                {
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                Console.ReadKey();
            }
        }

        private static void CriticalExceptionLogger(object sender, UnhandledExceptionEventArgs e)
        {
            Logging.StartLog();
            Exception ex = (Exception)e.ExceptionObject;
            Logging.LogCriticalException(ex.ToString());
        }

        private static bool Shutdown(CtrlType enum0_0)
        {
            try
            {
                if (Program.Booted)
                {
                    Logging.StartLog();
                    Console.Clear();
                    Console.WriteLine("The server is saving users furniture, rooms, etc. WAIT FOR THE SERVER TO CLOSE, DO NOT EXIT THE PROCESS IN TASK MANAGER!!");
                    Phoenix.Destroy("", true);
                }
            }
            catch { }
            return true;
        }
    }
}