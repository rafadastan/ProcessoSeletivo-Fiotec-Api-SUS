# Processo seletivo Fiotec

Processo seletivo da Fiotec, construir uma API que faça integração com o ministério da saúde e faz um relatório em cima
dessas informações. Aberto para publico onde você pode consultar e até mesmo utilizar esse código fonte. Fui aprovado no teste, 
então o código funciona, e fui aprovado usando ele. Basta você baixar o DevExpress 22.1 se eu não me engano e você consegue
utilizar o recurso dele e executa a migration da aplicação para gerar o schema do db. Abraço e seja aprovado ;)

# Api-Campanha-vacinacao-SUS
Construção de uma API para buscar os dados de vacinação.

# Arquitetura

Arquitetura ultizada foi DDD (Domain Driven Design) arquitetura em camada, desenvolvido para separar
o domínio do restante da aplicação.

# Linguens e tecnologias

Foi usado .Net 6 uma das versões mais atuais da framework, também utizando banco de dados sql server,
conceitos como UnitOfWork para tratamento de concorrencia no banco de dados, metodos assincronos 
para evitar concorrencia de thread. 

Integração com a API do SUS e utilização do DevExpress para emitir relatórios dos dados solicitados.
