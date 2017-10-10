using System;
using System.Runtime.Serialization; // DataContract

namespace WebAPIClient
{
    [DataContract(Name="repo")]
    public class Repository    
    {
        [DataMember(Name="name")]
        public string Name { get; set; }
        /*  // The line of code above is equivalent to block of code below.
            public string Name 
            { 
                get { return this._name; }
                set { this._name = value; }
            }
            private string _name;         
        */

        [DataMember(Name="description")]
        public string Description { get; set; }

        [DataMember(Name="html_url")]
        public Uri GitHubHomeUrl { get; set; }

        [DataMember(Name="homepage")]
        public Uri Homepage { get; set; }

        [DataMember(Name="watchers")]
        public int Watchers { get; set; }
    }
}