using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace WCFMemberServiceLibrary
{

    // The following settings must be added to your configuration file in order for 
    // the new WCF service item added to your project to work correctly.

    // <system.serviceModel>
    //    <services>
    //      <!-- Before deployment, you should remove the returnFaults behavior configuration to avoid disclosing information in exception messages -->
    //      <service type="WCFMemberServiceLibrary.SampleService" behaviorConfiguration="returnFaults">
    //        <endpoint contract="WCFMemberServiceLibrary.ISampleService" binding="wsHttpBinding"/>
    //      </service>
    //    </services>
    //    <behaviors>
    //      <serviceBehaviors>
    //        <behavior name="returnFaults" >
    //          <serviceDebug includeExceptionDetailInFaults="true" />
    //        </behavior>
    //       </serviceBehaviors>
    //    </behaviors>
    // </system.serviceModel>


    // A WCF service consists of a contract (defined below), 
    // a class which implements that interface, and configuration 
    // entries that specify behaviors and endpoints associated with 
    // that implementation (see <system.serviceModel> in your application
    // configuration file).

    [ServiceContract()]
    public interface ISampleService
    {
        [OperationContract]
        void addMember(Member member);

        [OperationContract]
        Member getMember(int memberId);
    }

    public class SampleService : ISampleService
    {
        static Dictionary<int, Member> members = new Dictionary<int, Member>();
        public void addMember(Member member)
        {
            members[member.Id] = member;
        }

        public Member getMember(int memberId)
        {
            return members[memberId];
        }
        
    }

    [DataContract]
    public class Member
    {
        int _id;
        string _name;

        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}

