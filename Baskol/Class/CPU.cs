using System.Management;
class CPU
{
    public static string GetProcessorID()
    {
        string sProcessorID = "";
        string sQuery = "SELECT ProcessorId FROM Win32_Processor";
        ManagementObjectSearcher oManagementObjectSearcher = new ManagementObjectSearcher(sQuery);
        ManagementObjectCollection oCollection = oManagementObjectSearcher.Get();
        foreach (ManagementObject oManagementObject in oCollection)
        {
            sProcessorID = (string)oManagementObject["ProcessorId"];
        }

        return (sProcessorID);
    }
}
