FROM testlagoon/dotnet-6-sdk:pr-550

COPY src /app
WORKDIR /app/
RUN dotnet build

EXPOSE 3000
RUN apk add figlet
# RUN dotnet dev-certs https
CMD ["dotnet", "run","--no-build"]
