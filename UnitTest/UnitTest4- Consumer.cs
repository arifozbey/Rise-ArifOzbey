using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class UnitTest4
    {
        [Fact]
    public void RabbitMQConsumer()
    {
            ProcessStartInfo startinfo = new ProcessStartInfo();
            startinfo.FileName = @"bin\Debug\net5.0\ConsumerRabbitMQ.exe";
            startinfo.CreateNoWindow = true;
            startinfo.UseShellExecute = true;
            Process myProcess = Process.Start(startinfo);
            myProcess.Start();
        }
    }
}
    

