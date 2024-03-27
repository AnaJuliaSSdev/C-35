# Desafio - API de Simulação de Empréstimos

A API de Simulação de Empréstimos permite que sejam enviados pedidos de simulação para empréstimos pessoais e de aposentado através de um endpoint POST. A API então efetua todas as verificações e cálculos necessários, devolvendo uma resposta de reprovação ou aprovação - se aprovado - indicando número de parcelas e valores.
Também possui um mecanismo de armazenamento das solicitações e simulações executadas, que funciona enquanto a API estiver rodando, e proporciona consulta deste histórico através de um endpoint GET.

Seu desafio aqui será utilizar os code snippets disponibilizados para construir a API, e efetuar a correção de problemas que fazem com que alguns recursos não funcionem corretamente.

## Problemas identificados

1. O fluxo das etapas parece não estar funcionando como um todo, pois a requisição sempre retorna reprovações e tudo zerado.
2. Em algum momento atrás, quando as etapas ainda funcionavam, percebeu-se também que parecia haver um problema gravíssimo de a API aprovar simulações de empréstimo pessoal e sempre apresentar parcelamento e valores resultantes de uma aplicação de taxa para empréstimo de aposentados. 
    * Nota: Esse problema só aparecerá após a resolução do problema 1.
3. O mecanismo de armazenamento das solicitações também parece estar com falha, pois sempre que é requisitada a lista das solicitações efetuadas através do endpoint GET, a resposta vem com uma lista vazia.

# ❗ Lembre-se: Este desafio tem a ver com injeção de dependências. Compreenda o fluxo de todas as classes e analise qual a relação das falhas com as dependências injetadas.