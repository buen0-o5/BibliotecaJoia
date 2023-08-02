## ⚡ Biblioteca Joia  
### Projeto desenvolvido em ASP.NET Core Web App (Model-View-Controller) .Net Core 3.1.

## Estrutura de diretórios da solução 
<div style="display: inline_block"><br>
  <details>
  <summary>Controlles</summary>
Contêm as actions, que são responsáveis por processar as solicitações HTTP (GET e POST)
</details>
 <details>
  <summary>Models</summary>

<details>
  <summary>Contexts</summary>
  A pasta "Contexts" é um diretório que é usado para armazenar
classes que representam os contextos e gerenciamento de dados em um aplicativo
</details>
<details>
  <summary>Contracts</summary>
  A pasta "Contracts" é um diretório usado para armazenar interfaces que definem
os contratos da aplicação. Essas interfaces são chamadas de contratos porque elas
estabelecem as especificações que outras partes do código devem seguir ao implementá-las.
Em outras palavras, elas definem os métodos e propriedades que devem ser implementados pelas
classes que desejam cumprir esse contrato.
</details>

<details>
  <summary>DTO</summary>
  A pasta "DTO" é um diretório usado para armazenar objetos de transferência de dados,
que atuam como uma ponte de comunicação simples e eficiente entre a interface do usuário
(página) e outras camadas da aplicação, como a camada de serviço. Eles ajudam a evitar
acoplamento excessivo e a otimizar a transferência de dados entre as diferentes partes 
do sistema.
</details>
<details>
  <summary>Entidade</summary>
  A pasta "Entidades" é usada para armazenar as classes que representam as entidades de negócio,
que contêm os atributos e comportamentos relevantes para o domínio da aplicação.
</details>
<details>
  <summary>Enum</summary>
  Enumerações que são utilizadas para definir um conjunto de constantes.
Cada constante da enumeração é um identificador único que representa uma consulta específica.
</details>
<details>
  <summary>Respositories</summary>
</details>
<details>
  <summary>Services</summary>
</details>
</details>
<details>
  <summary>View</summary>
  Estrutura que representa a interface do usuário
</details>

## Banco de Dados

Este projeto utiliza o ADO.NET para fazer a conexão com o banco de dados SQL Server. O provedor usado é o System.Data.SqlClient.

OBS: Projeto atualizado para a versão 0.0.2 em 19 de julho de 2023. Nesta versão, foram adicionadas novas funcionalidades de login, emprestimo livro, cadastro  e melhorias na interface do usuário.

