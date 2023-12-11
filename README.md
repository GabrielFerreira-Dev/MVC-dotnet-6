# Projeto MVC em .NET

Este projeto tem como objetivo praticar o padrão MVC (Model-View-Controller) usando o framework .NET 6.0. O trabalho inclui a criação de um esquema para lidar com Departamentos, Vendedores e Vendas, estabelecendo relações entre as classes e usando o método Code-First para interagir com um banco de dados MySQL.

## Primeiro Commit e Resumo das Etapas Anteriores

### Construção Inicial dos Modelos e Relacionamentos

Neste estágio inicial, foram criados modelos para Departamentos, Vendedores e Vendas, juntamente com a definição de seus relacionamentos.

### Criação da View "Departments"

Foi desenvolvida a view para a entidade "Departments", que representa a interface do usuário relacionada a departamentos no aplicativo.

### Alteração do CSS do Bootstrap para o Flaty

Houve uma personalização no estilo visual do Bootstrap, utilizando o tema "Flaty" para melhor atender aos requisitos estéticos do projeto.

### Criação do Contexto para Gerenciar o CRUD no Banco

Um contexto foi estabelecido para gerenciar as operações CRUD (Create, Read, Update, Delete) no banco de dados. Esse contexto é crucial para a interação eficiente com o banco de dados MySQL.

### Adição do Contexto do Banco de Dados ao Escopo da Aplicação

O contexto do banco de dados foi adicionado ao escopo da aplicação, garantindo que ele esteja acessível onde necessário.

### Conexão com o Banco do MySQL Apontando para o Localhost

Foi configurada a conexão com o banco de dados MySQL, apontando para o servidor local (localhost).

## Implementação do SeedingService

Para lidar com a população inicial do banco de dados durante o desenvolvimento, foi criado um serviço de "Seeding" (preenchimento) chamado "SeedingService". Este serviço é responsável por verificar se existem dados no banco de dados e, caso contrário, preenchê-lo com informações iniciais.

## Utilização do CreateScope para Chamar o Método de Preenchimento de Dados

Para garantir a execução do serviço de "Seeding" no ambiente de desenvolvimento, um novo escopo foi criado usando o método `CreateScope` do serviço. Isso permite chamar o método responsável pelo preenchimento dos dados na base de dados.

Essas etapas fornecem uma base sólida para o desenvolvimento do projeto MVC em .NET 6.0, incorporando boas práticas de arquitetura e interação eficiente com o banco de dados MySQL.
