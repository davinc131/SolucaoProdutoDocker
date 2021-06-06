#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
LABEL version="1.0.0" description="API Produto"
COPY dist /app
WORKDIR /app
EXPOSE 80/tcp
EXPOSE 445
ENTRYPOINT ["dotnet", "APIProduto.dll", "--environment=Development"]

#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["APIProduto/APIProduto.csproj", "APIProduto/"]
#RUN dotnet restore "APIProduto/APIProduto.csproj"
#COPY . .
#WORKDIR "/src/APIProduto"
#RUN dotnet build "APIProduto.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "APIProduto.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "APIProduto.dll"]