FROM ensemblorg/ensembl-vep:release_113.4 as base
ARG RID
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
ENV ASPNETCORE_hostBuilder:reloadConfigOnChange=false
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 as publish
ARG RID=linux-x64
WORKDIR /src
COPY . .
RUN dotnet publish Ensembl.Vep.Web -c Release -r ${RID} -o /app/publish --self-contained

FROM base AS final
USER root
WORKDIR /app
COPY --from=publish /app/publish/* .
ENTRYPOINT ["/app/Ensembl.Vep.Web", "--urls", "http://0.0.0.0:80"]
