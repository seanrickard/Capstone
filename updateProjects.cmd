cd .\PurchaseReq.DAL\PurchaseReq.Models\
dotnet pack -o ../Nuget
cd ..\PurchaseReq.DAL\
dotnet pack -o ../Nuget
cd ..\..\PurchaseReq.Service\PurchaseReq.Service\
dotnet add package PurchaseReq.DAL
dotnet add package PurchaseReq.Models
cd ..\..\PurchaseReq.MVC\PurchaseReq.MVC\
dotnet add package PurchaseReq.DAL
dotnet add package PurchaseReq.Models
