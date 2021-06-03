#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["BasicASP.NETCoreMvcKnowledge/BasicASP.NETCoreMvcKnowledge.csproj", "BasicASP.NETCoreMvcKnowledge/"]
RUN dotnet restore "BasicASP.NETCoreMvcKnowledge/BasicASP.NETCoreMvcKnowledge.csproj"
COPY . .
WORKDIR "/src/BasicASP.NETCoreMvcKnowledge"
RUN dotnet build "BasicASP.NETCoreMvcKnowledge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasicASP.NETCoreMvcKnowledge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasicASP.NETCoreMvcKnowledge.dll"]
