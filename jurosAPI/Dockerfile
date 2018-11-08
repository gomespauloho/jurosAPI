FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# copia o csproj and resolve as dependências
COPY *.csproj ./
RUN dotnet restore

# executa o build
COPY . ./
RUN dotnet publish -c Release -o out

# executa o build da imagem
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "jurosAPI.dll"]