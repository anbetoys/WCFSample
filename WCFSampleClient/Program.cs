using System;
using System.Collections.Generic;
using System.Text;
//using WCFSampleClient.localhost;
using WCFMemberServiceLibrary;
using System.ServiceModel;

namespace WCFSampleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //            SampleServiceClient client = new SampleServiceClient();

            ChannelFactory<ISampleService> fact = new ChannelFactory<ISampleService>("EndpointTcp");
            ISampleService client = fact.CreateChannel();

            Member member1 = new Member();
            member1.Id = 1;
            member1.Name = "Doi";

            client.addMember(member1);

            Member member2 = new Member();
            member2.Id = 2;
            member2.Name = "Yamada";

            client.addMember(member2);

            Member member = client.getMember(1);
            Console.WriteLine(member.Name);
            Console.In.ReadLine();
            
            ((IClientChannel)client).Close();

        }
    }
}
