#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CalCambApi/CalCambApi.csproj", "CalCambApi/"]
COPY ["CalCambApi.Aplication.Services/CalCambApi.Aplication.Services.csproj", "CalCambApi.Aplication.Services/"]
COPY ["CalCambApi.Infraestructure.UnitOfWork/CalCambApi.Infraestructure.UnitOfWork.csproj", "CalCambApi.Infraestructure.UnitOfWork/"]
COPY ["CalCambApi.Infraestructure.Repository/CalCambApi.Infraestructure.Repository.csproj", "CalCambApi.Infraestructure.Repository/"]
COPY ["CalCambApi.Domain/CalCambApi.Domain.csproj", "CalCambApi.Domain/"]
COPY ["CalCambApi.Infraestructure.UnitOfWork.Repository/CalCambApi.Infraestructure.UnitOfWork.Repository.csproj", "CalCambApi.Infraestructure.UnitOfWork.Repository/"]
COPY ["CalCambApi.Infraestructure.Connections/CalCambApi.Infraestructure.Connections.csproj", "CalCambApi.Infraestructure.Connections/"]
COPY ["CalCambApi.Aplication.Adapter/CalCambApi.Aplication.Adapter.csproj", "CalCambApi.Aplication.Adapter/"]
RUN dotnet restore "CalCambApi/CalCambApi.csproj"
COPY . .
WORKDIR "/src/CalCambApi"
RUN dotnet build "CalCambApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalCambApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalCambApi.dll"]