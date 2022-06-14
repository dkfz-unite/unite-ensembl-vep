# FROM ensemblorg/ensembl-vep:release_103 as base
FROM ensemblorg/ensembl-vep as base
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
ENV ASPNETCORE_hostBuilder:reloadConfigOnChange=false
EXPOSE 80
EXPOSE 443

# FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as publish
FROM mcr.microsoft.com/dotnet/sdk:6.0 as publish
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -r linux-x64 -o /app/publish
# RUN dotnet publish -c Release -r linux-arm64 -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["/app/Unite.Vep.Web", "--urls", "http://0.0.0.0:80"]
