# Bemol Channel
## Feature - Criação de contas de usuário.

### Para executar a aplicação em sua maquina, siga os passos abaixo.

* Copie o link abaixo para clonar o repositório em sua máquina. 
  * Link: [GitHub](https://github.com/LerronF/Bemol.Channel)
* Instale em sua máquina o Banco de dados SqlServer seguindo os links abaixo(se ja possui instalação ignore essa etapa).
  * [Microsoft® SQL Server® 2017 Express](https://www.microsoft.com/en-us/download/details.aspx?id=55994)
* A IDE de desenvolvimento usada é Visual Studio 2019. Segue o link abaixo.
  * [Visual Studio 2019 - Community](https://visualstudio.microsoft.com/pt-br/downloads/?rr=https%3A%2F%2Fwww.google.com.br%2F)
* Configurar a ConnectionStrings do projeto:
  * Abra este diretorio [ConnectionString](https://github.com/LerronF/Bemol.Channel/blob/main/Bemol.Channel/App.config), e faça as alterações necessárias.
  * Se tiver dificuldades para configurar siga os passos abaixo: 
    *  Altere a ConnectionStrings que fica dentro do [App.config](https://github.com/LerronF/WebApp-FPF/blob/main/src/DesafioFPF/DesafioFPF.WebApp/appsettings.json) conforme exemplo ao lado: "add name="bemolConnectionString" connectionString="data source=**SERVIDOR SQLSERVER**; Initial Catalog=**BANCO DE DADOS(OU MANTEM A MASTER)**;Integrated Security=True;" providerName="System.Data.SqlClient" "


#### Pronto ! Sua maquina está configurada para rodar a aplicação !

#### As operações do cadastro são bem intuitivas e simples.


Até logo.
