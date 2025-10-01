# Estágio 1: Build - Usando o SDK completo do .NET 9
FROM mcr.microsoft.com/dotnet/sdk:9.0-noble AS build
WORKDIR /src
 
# --- Otimização de Cache do Docker ---
# 1. Copia os arquivos de projeto (.sln e .csproj) primeiro, mantendo a estrutura de pastas.
# O contexto do build é a pasta raiz (OndeTaMotoProject).
COPY ["OndeTaMoto/OndeTaMoto.sln", "OndeTaMoto/"]
COPY ["OndeTaMoto/OndeTaMotoApi.csproj", "OndeTaMoto/"]
COPY ["OndeTaMotoBusiness/OndeTaMotoBusiness.csproj", "OndeTaMotoBusiness/"]
COPY ["OndeTaMotoData/OndeTaMotoData.csproj", "OndeTaMotoData/"]
COPY ["OndeTaMotoModel/OndeTaMotoModel.csproj", "OndeTaMotoModel/"]
 
# 2. Restaura todas as dependências a partir da pasta onde está o .sln
WORKDIR /src/OndeTaMoto
RUN dotnet restore "OndeTaMoto.sln"
 
# Volta para a raiz do WORKDIR e copia todo o código fonte
WORKDIR /src
COPY . .
 
# 3. Publica a aplicação, especificando o caminho completo para o projeto principal
RUN dotnet publish "OndeTaMoto/OndeTaMotoApi.csproj" -c Release -o /app/publish --no-restore
 
# ---
 
# Estágio 2: Final - Usando apenas o Runtime do ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:9.0-noble AS final
WORKDIR /app
 
# Define a porta padrão que a aplicação vai escutar dentro do container.
ENV ASPNETCORE_URLS=http://+:5294
EXPOSE 5294
 
# Copia os arquivos publicados do estágio de build para a imagem final
COPY --from=build /app/publish .
 
# Define o ponto de entrada. Este é o comando que será executado quando o container iniciar.
ENTRYPOINT ["dotnet", "OndeTaMotoApi.dll"]
