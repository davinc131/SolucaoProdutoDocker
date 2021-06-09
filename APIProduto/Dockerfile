#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
LABEL version="1.0.0" description="API Produto"
COPY dist /app
WORKDIR /app
RUN apt-get clean && apt-get update && apt-get install -y locales
RUN locale-gen pt_BR.UTF-8
EXPOSE 80/tcp
EXPOSE 445
ENTRYPOINT ["dotnet", "APIProduto.dll"]