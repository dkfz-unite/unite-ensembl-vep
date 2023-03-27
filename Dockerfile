FROM ensemblorg/ensembl-vep:release_109.3 as base
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
ENV ASPNETCORE_hostBuilder:reloadConfigOnChange=false
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 as publish
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -r linux-x64 -o /app/publish

FROM base AS final
RUN mkdir /data
RUN chmod 666 /data
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["/app/Ensembl.Vep.Web", "--urls", "http://0.0.0.0:80"]
