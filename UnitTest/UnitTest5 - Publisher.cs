using Publisher;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class UnitTest5
    {
        [Fact]
        public void PublisherRabbitMQ()
        {
            ProcessStartInfo startinfo = new ProcessStartInfo();
            startinfo.FileName = @"bin\Debug\net5.0\PublisherDemo-Rabbitmq.exe";
            startinfo.CreateNoWindow = true;
            startinfo.UseShellExecute = true;
            Process myProcess = Process.Start(startinfo);
            myProcess.Start();
        }
    }
}


