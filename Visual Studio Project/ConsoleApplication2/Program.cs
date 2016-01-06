//This was taken from https://github.com/Ben0xA/AwesomerShell

using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace AwesomerShell
{
    class Program
    {
        static void Main(string[] args)
        {

            //Powershell command
            String cmd = "get-process;pause";

            Runspace rs = RunspaceFactory.CreateRunspace();
            rs.Open();

            PowerShell ps = PowerShell.Create();
            ps.Runspace = rs;
            ps.AddScript(cmd);

            Collection<PSObject> output = ps.Invoke();
            if (output != null)
            {
                foreach (PSObject rtnItem in output)
                {
                    Console.WriteLine(rtnItem.ToString());
                }
            }
            rs.Close();
            Console.Write("Press any key to exit.");
            Console.ReadLine();
        }
    }
}






