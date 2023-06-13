

```shell
NetIdentityModels % dotnet ef migrations add InitialCreate --startup-project ../NetIdentityAPI/NetIdentityAPI.csproj
```
마이그레이션 추가 _add InitialCreate_ 에 마이그레이션 명을 넣어줘야함

```shell
dotnet ef migrations add CreateIdentitySchema --startup-project ../NetIdentityAPI/NetIdentityAPI.csproj
dotnet ef database update
```

Identity 추가후 업데이트


```shell
dotnet ef database update --startup-project ../NetIdentityAPI/NetIdentityAPI.csproj
```
마이그레이션 업데이트