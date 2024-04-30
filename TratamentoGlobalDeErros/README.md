## Desafio - Implementação do recurso técnico de Tratamento global de erros na API Arquivos

A API de Arquivos é um serviço simples de upload (POST) e download (GET) de arquivos, que faz com que estes possam ser armazenados e recuperados em uma pasta no servidor (localizada na raíz do próprio projeto).

Como operações de I/O são classicamente críticas quanto a ocorrências de erros e exceções no sistema, foram implementados nos métodos dos endpoints tratamentos de fluxos de exceções para mitigação de possíveis problemas. Porém, além de existirem tratamentos desnecessários, também é perceptível que há uma certa verbosidade desnecessária desses tratamentos quando feitos diretamente nos métodos da controller.

Seu desafio aqui será utilizar os code snippets disponibilizados abaixo para construir a API, e implementar otimizações nos próprios fluxos de upload/download para reduzir potenciais origens de exceções, assim como, para as exceções que não puderem ser evitadas com a refatoração do design do código, implementar seu tratamento através de um controle global de exceções.