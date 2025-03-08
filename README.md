# testeriscobr

Olá!
Este é o programa-fonte Trade, conforme explicação no documento recebido.
Incluso um arquivo em configuração em formato Json, files/config.json, que facilitará a criação de novas categorias. A explicação está em readme.md.

Prós: Foquei bastante em cálculos e validações, e escolhi o formato Json pela simplicidade em manipular categorias, sem a necessidade de criação de um banco de dados físico.
Contras: Talvez pode não estar em orientação a objetos perfeito, pela simplicidade da lógica.

# Arquivo files/config.json

Modo de uso:
Para facilitar a criação de novas categorias, criamos um arquivo files/config.json, que deverá estar respeitando dessa forma:

- dayPaymentDelayed   : Informe o número de dias de vencimento em atraso para filtro. Se for 30 dias, contabilizará se for SUPERIOR A 30 dias.
- higherValue         : Informe o valor mínimo a ser filtrado. Se for 1000000 (um milhão em valor), contabilizará o valor SUPERIOR A um milhão.
- sectorCustomer      : Informe o setor que deverá ser filtrado. Pode colocar qualquer identificador além de Public e Private. ATENÇÃO: CASE SENSITIVE. Caso deixar em branco, este campo não será filtrado.
- result              : Informe qual resultado deverá aparecer na saída.

Obs: Os parâmetros em Json deverão obedecer a ordem de precedência. Caso uma das sentenças for encontrada, obrigatoriamente não deverá analisar as demais sentenças.