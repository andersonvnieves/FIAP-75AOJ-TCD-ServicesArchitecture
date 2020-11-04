# FIAP-75AOJ-TCD-ServicesArchitecture
Todos os serviços foram feitos no seguinte padrão:
Arquitetura de micro serviços baseados no padrão Rest. .NET Core 3.1 para realização dos serviços. Está configurado para Deploy em Docker
Utilizamos Swagger para documentação do Front End da API, documentando os métodos das chamadas da API e o Status Code da mesma.
Padrão de Arquitetura usamos o DTO para objetos transferidos pela API, não são os mesmos models dos bancos de dados. 
Cada serviço tem o seu banco de dados. Para o banco de dados usamos o MySql como instância na cloud da Microsoft Azure.
ORM Entity Framework Core, com a abordagem code first sendo adota. Fizemos a modelagem do banco no projeto, criando as classes e relacionamento da forma que o Entity Framework aguarda. Com os comandos do Entity Framework criamos o banco de dados a partir do código da aplicação.
Utilizamos o Migration indo na linha do versionamento de banco de dados. Caso tenha que ser feito uma alteração, o Migration registra a alteração e faz o update no banco de dados.
Na arquitetura geral temos as controllers que contendo as chamadas e a lógica em si. As classes de repositório que são responsáveis pelo acesso ao banco. Os DTOs estão separados, que são os objetos que trafegam pela API. Para representação do Banco de Dados temos as models. 
Por questões de segurança adotamos o recurso de cadastrar os Ids pelo GUID. Para documentação dos métodos aderimos ao Swagger como citado acima. Para o serviço de mensageria usamos o Service Bus do Azure, pela praticidade de já estarmos adotando instâncias de banco de dados no Azure, decidimos por padronizar alguns serviços nesta plataforma. 
