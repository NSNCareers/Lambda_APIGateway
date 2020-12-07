(1) Initialize repository
sam init --runtime dotnetcore3.1 --name Lambda_App
(2) Build repository
dotnet restore src/HelloWorld/HelloWorld.csproj
dotnet build src/HelloWorld/HelloWorld.csproj
dotnet publish -c Release -r win-x64 --output ./src/HelloWorld/buildOutput src/HelloWorld/HelloWorld.csproj

(3) Start server locally
sam local start-api -t template.yaml
(4) Start server locally with json file creating the event 
 sam local invoke AddItemFunction --event addItem.json

./src/HelloWorld/  {proxy+}


Adding EF Core 
* dotnet add src/HelloWorld/HelloWorld.csproj  package Microsoft.EntityFrameworkCore.InMemory
dotnet add src/HelloWorld/HelloWorld.csproj  package AWSSDK.Extensions.NetCore.Setup
dotnet add src/HelloWorld/HelloWorld.csproj  package AWSSDK.DynamoDBv2



Sam Commands
To package => sam package
To build => sam build
To Invoke Function: sam local invoke
To Deploy: sam deploy --guided
aws cloudformation delete-stack --stack-name MY-NEW-STACK
sam local generate-event apigateway aws-proxy | pbcopy