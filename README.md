# e-Evento: Sistema de Gerenciamento de Eventos e Inscrições

## Entidades

- **Evento**: Relaciona-se com o Patrocinador (N:N), Organizador (1:N) e Local (1:N)
- **Inscrição**: Relaciona-se com o Evento (1:N) e Participante (1:N)
- **Local**
- **Participante**
- **Organizador**
- **Patrocinador**

## Validações
- **Campos obrigatórios**
- **Limite de caracteres**
- **Validação de Email,CPF e Contato**
- **Validação de Range**
- **Validação de Autenticação**
- **Autorizações**

## Tecnologias Utilizadas

- **ASP.NET MVC**: Framework utilizado para o desenvolvimento do sistema.
- **C#**: Linguagem de programação utilizada.
- **Entity Framework**: ORM para manipulação de dados (Code First.
- **Bootstrap**: Framework CSS para o design responsivo.
- **JavaScript**: Para funcionalidades interativas no front-end.

## Pré-requisitos

Antes de executar o projeto, certifique-se de que você possui o seguinte:

- **Visual Studio** (versão 2019 ou superior) ou **Visual Studio Code** instalado.
- **.NET Framework 4.7.2** ou superior.
- **SQL Server** para a base de dados.

## Passos para Execução

1. **Clone o Repositório**

   Abra seu terminal e execute o seguinte comando:

   ```bash
   git clone <URL_DO_REPOSITORIO>
2. **Abra o Projeto**

   Abra o projeto no Visual Studio ou Visual Studio Code. Certifique-se de abrir a solução (`.sln`) para carregar todas as dependências corretamente.

3. **Restaurar Pacotes NuGet**

   No Visual Studio, clique com o botão direito do mouse no projeto na **Solution Explorer** e selecione **Restore NuGet Packages**. Isso garantirá que todas as dependências necessárias sejam baixadas e instaladas.

4. **Configurar a Conexão com o Banco de Dados**

   - Localize o arquivo de configuração `web.config` e edite a string de conexão para o seu banco de dados SQL Server.

    ```xml
   <connectionStrings>
       <add name="eEventoDb" 
            connectionString="Server=SEU_SERVIDOR;Database=SEU_BANCO_DE_DADOS;Trusted_Connection=True;MultipleActiveResultSets=true"
            providerName="System.Data.SqlClient" />
   </connectionStrings>
    
5. **Criar o Banco de Dados**

   Execute as migrações para criar o banco de dados e suas tabelas. Abra o Package Manager Console e execute:
   
   ```bash
     Update-Database
6. **Executar o Projeto**

    No Visual Studio, pressione F5 ou clique em Run para iniciar o projeto. O aplicativo será aberto em seu navegador padrão.
