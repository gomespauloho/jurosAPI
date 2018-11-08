# Juros API
## API para cálculo de juros compostos em .NET Core 2.1
### Instruções para o projeto __jurosAPI__:
Para iniciar a api com docker:
```
docker build -t jurosapi
docker-compose up -d
```
Para parar a execução da api com docker:
```
docker-compose down
```
Para iniciar a api pelo cmd:
```
dotnet run
```
Por padrão utilizará a porta 8080:
```
http://localhost:8080
```
### Instruções para os projetos de teste:
Para iniciar os testes:
```
dotnet test
```