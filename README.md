# <a id="begin"> Desafio SE - Bemol 

## [1. Introdução](#intro)
## [2. IDE](#IDE)
## [3. Banco de dados](#db)
## [4. Clonar Repositório](#Clonar)
## [5. Conexão do Projeto com o Banco de Dados](#connection)
## [6. Executando o Projeto](#executar)
## [7. Respostas](#resp)

## <a id="intro">1. Introdução

* Projeto criado para o processo seletivo da vaga de Software Engineer na Bemol Digital.

## <a id="IDE"> 2. IDE

* A IDE de desenvolvimento usada é Visual Studio 2019. Segue o link abaixo.
  * [Visual Studio 2019 - Community](https://visualstudio.microsoft.com/pt-br/downloads/?rr=https%3A%2F%2Fwww.google.com.br%2F)

## <a id="db"> 3. Banco de Dados.

* Instale em sua máquina o Banco de dados SqlServer seguindo os links abaixo(se ja possui instalação ignore essa etapa).
  * [Microsoft® SQL Server® 2017 Express](https://www.microsoft.com/en-us/download/details.aspx?id=55994)

## <a id="Clonar"> 4. Clonar Repositório.

* Copie o link abaixo para clonar o repositório em sua máquina. 
  * Link: [GitHub](https://github.com/LerronF/Bemol.Channel.git)

## <a id="connection"> 5. Conexão do projeto com o Banco de Dados.

* Configurar a ConnectionStrings do projeto:
  * Abra este diretorio [ConnectionString](https://github.com/LerronF/Bemol.Channel/blob/main/Bemol.Channel/App.config), e faça as alterações necessárias.
  * Se tiver dificuldades para configurar siga os passos abaixo: 
    *  Altere a ConnectionStrings que fica dentro do [App.config](https://github.com/LerronF/WebApp-FPF/blob/main/src/DesafioFPF/DesafioFPF.WebApp/appsettings.json) conforme exemplo ao lado: "add name="bemolConnectionString" connectionString="data source=**SERVIDOR SQLSERVER**; Initial Catalog=**BANCO DE DADOS(OU MANTEM A MASTER)**;Integrated Security=True;" providerName="System.Data.SqlClient" "
    
## <a id="executar"> 6. Executando o Projeto
* A execução é simples, pressionando a tecla F5 a IDE faz o build do projeto, copila e quando começar a executar ele cria automatico a tabela necessária para a criação de usuarios na aplicação.

## <a id="resp"> 7. Respostas
 

[Voltar ao inicio](#begin)







