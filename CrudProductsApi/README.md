# Desafio Dapper: CRUD de produtos

Aproveitando os dados cadastrados no desafio anterior de ADO.NET, neste desafio você vai executar uma SP (Stored Procedure) que recebe parâmetros de filtro, para isso você deve:

    1. Criar uma SP no banco de dados que receba parâmetros para filtragem dos resultados
    2. Chamar via Dapper essa SP na camada de acesso a dados da aplicação, passando os parâmetros recebidos na requisição


Observações:

    * Neste desafio foram reutilizados o banco de dados do projeto anterior e o Model de Produto. 
    * Além disso, é possível encontrar os comandos SQL para criação da tabela e da procedure na pasta 'SQL' na raiz do diretório. 
    * A string de conexão com o banco está armazenada no arquivo appsettings.json.