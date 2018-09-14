using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics;
namespace Proc
{
        class Program
        {
            static void Main(string[] args)
            {

                if (args.Length != 0)
                {
                    if (args[0] == "1")
                    {
                        AlternatePathOfExecution();
                    }                   
                }
                else
                {
                    NormalPathOfExectution();
                }          
            }
            private static void NormalPathOfExectution()
            {
                Process[] proc = Process.GetProcesses();
               
                System.Diagnostics.Process.Start("Proc.exe", "1");
                for(;;)
                { 

                    for (int i = 0; i < proc.Length; i++)
                    {
                        Process a = Process.GetProcesses()[i];
                        PerformanceCounter ramCounter = new PerformanceCounter("Process", "Working Set", a.ProcessName);
                        PerformanceCounter cpuCounter = new PerformanceCounter("Process", "% Processor Time", a.ProcessName);

                        double ram = ramCounter.NextValue();
                        double cpu = cpuCounter.NextValue();
                        if (ram / (1024 * 1024) > 1)
                            Console.WriteLine("ProCess Name = | " + proc[i].ProcessName +" | "+ "  PID=  "+ proc[i].Id +" | UID= "+ GetProcessOwner(proc[i].Id) + " |  RAM=  "+ Math.Round((ram / (1024 * 1024))) + " MB | CPU= " + Math.Round(cpu) + " % |");
                    }
                    System.Threading.Thread.Sleep(10000);
                    Console.Clear();
                }

                



            }
        public static string GetProcessOwner(int processId)
        {
            string query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            foreach (ManagementObject obj in processList)
            {
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    
                    return argList[1] + "\\" + argList[0];
                }
            }

            return "NO OWNER";
        }
        private static void AlternatePathOfExecution()
            {
               
                PerformanceCounter ramUse = new PerformanceCounter("Memory", "% Committed Bytes In Use");
                PerformanceCounter cpuTotal = new PerformanceCounter("Процессор", "% загруженности процессора", "_Total");
                
                Process[] proc = Process.GetProcesses();
                while (true)
                {
                Console.WriteLine("Total CPU and RAM");
                void_update(ramUse.NextValue(), "RAM");
                void_update(cpuTotal.NextValue(), "CPU");
                   
                   
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
                System.Threading.Thread.Sleep(3000);

            }
           
            static void void_update(double value, string name)
            {
            double help_var = value;
            double storage = 100 - value;
                
                Console.Write(name + " [");
                for (; help_var >= 0; help_var--)
                {
                    Console.Write("|");
                }
                for (; storage > 0; storage--)
                {
                    Console.Write(" ");
                }
                Console.Write("]" + Math.Round(value) + "%\n");
            }
       
    }
}
