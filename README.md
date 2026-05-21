# Gestão de Pedidos

## Especificações técnicas do projeto
   - Gerais
     - Utilizando .NET 10 e C# 14
     - Organizando com arquitetura limpa com as seguintes camadas - Domain, Application, Infrastrucure e API
     - Desenvolvido com Domain Driven Design (DDD) foco em domínios ricos para regras de negócio
     - Utilização de EF Core versão 10.0.8 para persistência de dados
     - Projeto do [Jason Taylor](https://github.com/jasontaylordev/CleanArchitecture/tree/main) utilizado como base para organização e implementações
     - Utilização de GlobalUsings para concentração de namespaces de forma que não fiquem espalhados pelas classes
     - Com exceção da camada de domínio todas as outras possuem uma classe DependencyInjection que funciona como o contêinter de injeção de dependência da respectiva camada.
     - Utilização da bibliteca xUnit para geração de testes.
     
  - Domínio
    - Criação da classe Entity como base para outras entidades
    - Criação da interface IAuditableEntity como uma marcação e contrato para que classes com propriedades auditáveis sejam implementadas
    - Utilização de [Guard Clauses](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/diagnostics/guard) para validação de dados de entrada
    - Utilização da classe ErrorMessages para agrupamento e reutilização de mensagens de erro para o resto do código
    - Utilização do design pattern [specification](https://elemarjr.com/clube-de-estudos/artigos/specification-pattern-o-que-e-para-que-serve-e-quando-adotar/) com a implementação do [Ardalis](https://specification.ardalis.com/getting-started/quick-start-guide.html)
    - O tipo escolhido para valores monetários foi o decimal devido a alta precisão que evita erros na hora do arredondamento

- Aplicação
  - Divisão das ações do sistema em [Use Cases](https://alistaircockburn.com/Use%20Case%20Foundation.pdf) onde o objeto é que o sistema atinja um objetivo para um determinado usuário. Apesar de gerar uma grande organização de código e divisão de responsabilidades conforme o código cresce pode tornar-se muito complexo para manter a estrutura de pastas.
  - Todos os UseCase de entrada de dados possuem um AbstractValidator da biblioteca FluentValidation para realizar a validação da entrada de dados.
  - Em Behaviours uso do classe UseCaseValidation para implementação do Fail Fast Validation que consiste em retornar o erro o mais cedo possível isso para verificações com os validadores da FluentValidation
  - Paginação divida entre três classes 
    - PagedExtensions
      - Um método de extensão para o tipo IQueryable nele é feito a contagem de registros
      - No método .Skip() é feito a página pelo método de descolamento quando a partir do índice e tamanho da página verificamos quantos registros iremos "pular" para ir para a próxima página
      - No método .Take() verificamos a quantidade de registros que desejam mostrar em uma página
      - Por fim, retornamos o PagedResult com todos os dados do PagedResult
    - PagedRequest
      -  O objeto de requisição para listagens paginada nele podemos decidir qual página vai ser mostrada e quantos registros por página
      -  IndicePagina - Qual página o cliente quer que seja exibida
      -  TamanhoPagina - Qual a quantidade de registros que pode ser exibido na página
      - Exemplo de requisição
        ```json
        {
          "dados": [],
          "indicePagina": 1,
          "tamanhoPagina": 10,
          "totalRegistros": 1,
          "totalPaginas": 1,
          "temProximaPagina": false,
          "temPaginaAnterior": false
        }
       ```
    - PagedResult
     - Objeto que é retornado como resposta da API
     - Dados - Os dados que serão apresentados retornados no endpoints sendo dtos
     - IndicePagina - Qual página é atual
     - TamanhoPagina - Quantos registros por página
     - TotalRegistros - O total de registros de todas as páginas
     - TotalPaginas - O total de páginas
     - TemProximaPagina => IndicePagina < TotalPaginas - Verificação se existe uma próxima página isso é utilizado principalmente pelo frontend
     - TemPaginaAnterior => IndicePagina > 1 - Verificação se existe uma página anterior também utilizado pelo frontend
    
  - Infraestrutura
    - Utilização do EF Core para persistência dos dados 
    - Criação de configurações para mapeamento de entidades utilizando a interface IEntityTypeConfiguration.
    - Utilização de um DbContext para representação de uma sessão com o banco de dados
    - Utilização de interface do IGestaoPedidosDbContext para acesso aos dados impedindo que o DbContext seja utilizado diretamente na camada de aplicação ou em outras camadas. A desvantagem é a dependência com o EF Core.
    - Utilização de [interceptor](https://learn.microsoft.com/en-us/ef/core/logging-events-diagnostics/interceptors) para atualização de dados de auditoria como data de criação e data de atualização. A grande vantagem é separar a responsabilidade em uma classe diferente, mas é necessário cuidado para com a manutenção dessa classe. 

  - API
    - Utilização de Controllers para construção dos endpoints
    - Utilização de [handlers de exceção globais](https://learn.microsoft.com/pt-br/aspnet/core/fundamentals/error-handling?view=aspnetcore-10.0#iexceptionhandler) para captura e tratamento de exceções sem a necessidade de try/catch.
    - Utilização do ProblemDetails [RFC 7807](https://datatracker.ietf.org/doc/html/rfc7807) para padronização de retorno de erros em conjunto com os handlers de exceção globais.
    - Criação do SaoPauloDateTimeConverter para conversão dos valores de data de acordo com o fuso de São Paulo.
    - Criação do DecimalJsonConverter para converter todos arredondamento de todos os dados decimais para duas casas após a vírgula
    - Utilização de Payloads para facilitar as requisções em endpoints.
    - Utilização de Swagger para documentação de endpoints, respostas e erros.
    - Configuração de retorno do Json com conversão de tipos de dados para o formato esperado pelo frontend, nomeação em camelcase e ingorando ciclos para prevenção de erros.

  - Estratégia de arredondamento e valores monetários
    - Conforme dito anteriormente decimal foi escolhido para tipos monetários devido sua alta precisão em relação ao floar e double. O problema é do decimal é a divisão por frações que pode gerar valores inconsistentes quando não é utilizado o sufixo m.
    - A precisão para armazenamento escolhida foi 18, 2, ou seja, até 18 dígitos antes da vírgula e apenas 2 dígitos após essa abordagem foi escolhida com base no que é mais utilizado pelo mercado sendo uma solução adequada para maiorias dos casos.
    - O arredondamento é feito pelo DecimalJsonConverter sendo o retorno dos valores monetários sendo duas casas após a vírgula para todas as consultas.

  - Estratégia de Estoque
    - No UseCase CriarPedido sempre que um pedido é criado o estoque do produto é verificado, também se o produto está ativo e se existe.
    - Após isso o pedido é criado, o estoque do produto é descontado e o histórico de preço é armazenado.
    - Sempre que um pedido é cancelado e está com o status de pagamento Criado o estoque é reposto e esse pedido não pode ser alterado, tendo o usuário que fazer um novo pedido mesmo que seja igual.
    - Para cada mudança de Status do Pedido um histórico de status é armazenado na base de dados.
    - Tanto o histórico de preço quanto o histórico de mudança de status podem ser consultados por meio de endpoints na PedidosController.
      - api/pedidos/{id}/historico-preco
      - api/pedidos/{id}/historico-status

  - Datas
    - Datas são armazenadas em UTC 
    - Datas são retornadas conforme o fuso horário de São Paulo fazendo o uso do SaoPauloDateTimeConverter

  - Testes
    - A tecnologia utilizada para os testes foi a biblioteca xUnit devido sua grande popularidade e consolidação de mercado.
    - O foco dos testes foi na camada de domínio para agrupar as regras de domínio devido o desenvolvimento utilizando Domain Driven Design.
    - Os testes podem ser executados via IDE da sua preferência ou via linha de comando executando dotnet test na pasta raiz do projeto.
 
 - Pontos que ficaram fora do escopo
   - Testes de integração utilizando [WebApplicationFactory](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-10.0&pivots=xunit) que é uma recomendação da Microsoft
     - Isso permite emular a API de forma que podemos fazer chamadas diretamente e usar a própria infraestrutura do projeto sem a necessidade de dados mockados aumentando muita a confiabilidade dos testes
   - Melhorar as validações tanto no domínio quanto na camada de aplicação
   - Criar uma documentação mais personalidade para os endpoints em conjunto com o Swagger para algo mais detalhado de forma que o entendimento para todos fique mais fácil

## Instruções para execução da aplicação

- Instale o [SDK do .NET 10](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) utilize a versão 10.0.104
- Clonar o repositório para uma pasta local
- Acessar o diretório raiz do projeto onde está localizado o arquivo de solução -> ..\Gestão Produtos
- Métodos
  - As migrations já estão criadas então não é necessário criar
  - Via IDE
    - Abrir a solução da IDE de sua preferência
    - Dentro do projeto GestaoDePedidos.API criar o arquivo appsettings.json com o conteúdo abaixo substituindo o Server e o Password pelos valores locais referentes ao seu banco de dados
    ````json
     {
       "Logging": {
         "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "ConnectionStrings": {
        "DefaultConnection": "Server=SeuServidor;Database=GestaoPedidos; Trusted_Connection=True; Password=SuaSenha; TrustServerCertificate=true; MultipleActiveResultSets=false"
     },
     "AllowedHosts": "*"
     }
    ````
    - Realizar a atualização do banco de dados conforme a migrations - Visual Studio e Rider IDE tem essas opções
  - Via linha de comando
    - Abrir a solução da IDE de sua preferência
    - Dentro do projeto GestaoDePedidos.API criar o arquivo appsettings.json com o conteúdo abaixo substituindo o Server e o Password pelos valores locais referentes ao seu banco de dados
    ````json
     {
       "Logging": {
         "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "ConnectionStrings": {
        "DefaultConnection": "Server=SeuServidor;Database=GestaoPedidos; Trusted_Connection=True; Password=SuaSenha; TrustServerCertificate=true; MultipleActiveResultSets=false"
     },
     "AllowedHosts": "*"
     }
    ````
    - Instale a [cli do ef core](https://learn.microsoft.com/en-us/ef/core/cli/dotnet). A ferramenta é múltiplataforma.
    - Acesse o terminal do seu sistema operacional dentro da pasta que contém a migration do projeto
    - Execute o comando dotnet ef database update --project src/GestaoDePedidos.Infrastructure --startup-project src/GestaoDePedidos.API
    - Execute o comando dotnet run --launch-profile https --project src/GestaoDePedidos.API na pasta raiz do projeto
    - Agora os endpoints podem ser acessados via Swagger [https](https://localhost:7223/swagger/index.html) ou [http](http://localhost:5055/swagger/index.html)

