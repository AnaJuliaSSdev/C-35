# Jornada Milhas - Testando integração com banco de dados

# Sobre

Este projeto foi desenvolvido como parte de um curso focado em testes de integração com banco de dados utilizando .NET. O objetivo principal é criar testes de baixo acoplamento e aplicar boas práticas para manter o código limpo e reutilizável.

- Testes de Integração com Banco de Dados: Integração com SQL Server em containers Docker utilizando Testcontainers.
- Geração de Massa de Dados: Uso da biblioteca Bogus para criar dados fictícios para os testes.
- Reversão de Dados: Implementação de métodos para limpar dados do banco após a execução dos testes, garantindo que os testes sejam determinísticos e isolados.

Tecnologias Utilizadas

- .NET 7
- XUnit: Framework de testes utilizado para escrever e executar os testes de integração.
- Entity Framework Core: ORM utilizado para gerenciar o contexto de dados e realizar migrações no banco de dados.
- Testcontainers: Biblioteca utilizada para criar e gerenciar containers Docker durante os testes.
- SQL Server: Banco de dados utilizado nos testes, rodando em um container Docker.
- Bogus: Biblioteca usada para gerar dados fictícios de forma rápida e eficiente.