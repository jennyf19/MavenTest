using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation.Runspaces;
using Microsoft.Win32;

namespace MavenTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PowerShellExecutor t = new PowerShellExecutor();

            t.ExecuteAsynchronously();
        }


    }

    internal class PowerShellExecutor
    {
        public void ExecuteAsynchronously()
        {
            using (PowerShell powerShellInstance = PowerShell.Create())
            {


                string filePath = @"c:\users\jeferrie\sample\mavenDeploy.ps1";

                powerShellInstance.Commands.AddScript(filePath);
                powerShellInstance.Invoke(filePath);

                Collection<PSObject> pSOutput = powerShellInstance.Invoke();

                if (powerShellInstance.Streams.Error.Count > 0)
                {

                }
                foreach (PSObject outputItem in pSOutput)
                {
                    if (outputItem != null)
                    {
                        Console.WriteLine(outputItem.BaseObject.GetType().FullName);
                        Console.WriteLine(outputItem.BaseObject.ToString() + "\n");
                    }
                }
                Console.WriteLine("Maven deploy finished");

                Console.ReadLine();
            }
        }
    }

}
