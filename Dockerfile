FROM microsoft/dotnet:1.1.2-runtime
LABEL name "dotnet-test"

WORKDIR /app
COPY out .

ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000 587 25

ENTRYPOINT ["dotnet","dotnetTest.dll"]