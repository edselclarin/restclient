# restclient
C# REST client that pulls information from the GitHub API.

Based on the tutorial at https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient.

### Key Concepts

1. HTTP web requests
2. JSON serialization
3. DataContract, DataMember, IgnoreDataMember attributes
4. get/get accessors
5. Collections
6. async and await operators

### Build and Run

Prerequisites: 
* Windows, Linux, Mac
* Git.  Visit https://git-scm.com/ for the latest version.
* Install .NET Core (2.0.0 or later).  Visit https://www.microsoft.com/net/core#windowscmd for the latest version.

1. Open your favorite shell, "cd" into your work directory and run:
~~~~
git clone https://github.com/edselclarin/restclient
~~~~
2. Once completed, "cd" into the restclient directory.
3. Download application dependencies by running:
~~~~
dotnet restore
~~~~
4. Run the application:
~~~~
dotnet run
~~~~
