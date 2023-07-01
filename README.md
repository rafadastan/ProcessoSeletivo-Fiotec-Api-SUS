# Api-Campanha-vacinacao-SUS
Construção de uma API para buscar os dados de vacinação.

# Arquitetura

Arquitetura ultizada foi DDD (Domain Driven Design) arquitetura em camada, desenvolvido para separar
o domínio do restante da aplicação.

#Linguens e tecnologias

Foi usado .Net 6 uma das versões mais atuais da framework, também utizando banco de dados sql server,
conceitos como UnitOfWork para tratamento de concorrencia no banco de dados, metodos assincronos 
para evitar concorrencia de thread. 

Integração com a API do SUS e utilização do DevExpress para emitir relatórios dos dados solicitados.
