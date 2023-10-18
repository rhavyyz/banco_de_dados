# Projeto de Banco de Dados

## Equipe:
  Alicia Paiva (1612479) e Rhavy Frota Sá Nogueira Neves Souza  (1612468)

## Classificação dos atributos do modelo: 
<br />
**User** 
<br />
  	Refere-se aos usuários cadastrados no blog, cada usuário tem uma permissão de usuário, id, nome, email e um pass_hash. 
<br />
	Um usuário pode dar like em um post, comentar em um post e, dependendo do tipo de permissão que o usuário possuir, ele pode fazer um post no site ou fazer uma colab em um post com outros usuários de permissão semelhante.
<br />
**Post**
<br />
	Refere-se aos posts que serão feitos no site, cada post tem um título, subtítulo, conteúdo, data de publicação e se está aprovado ou não, a intenção é que usuários de permissões mais baixas possam solicitar a publicação de um post e usuários de permissão mais alta possa permitir de fato a publicação da postagem.
 <br />
	Um post pode ter vários likes, vários comentários e deve ser publicado por um usuário ou mais e todo post deve ter uma categoria, o qual se refere.
<br />
**Comment**
<br />
	Refere-se aos comentários feitos nos posts feitos pelos usuários, cada comentário tem um id, conteúdo e data de publicação.
<br />
**Category**
<br />
	Refere-se às categorias de posts que serão feitos no site, cada categoria tem um nome e pode ter uma categoria pai, sendo uma subcategoria.

## Descrição da Aplicação (objetivo, linguagem, principais requisitos) e indicação do que falta ser implementado na aplicação para a entrega final
O objetivo dessa aplicação é ser o Banco de Dados do blog (que está em desenvolvimento) do Grupo de Estudo para Maratona de Programação da UECE (GEMP), a linguagem de banco de dados usada será SQL e os principais requisitos são:
<br />
    - armazenar as informações dos usuários
    <br />
    - armazenar as informações dos posts
    <br />
    - armazenar as informações dos comentários
    <br />
    - armazenar as informações das categorias
<br />
O que falta ser implementado são as definições de permissões, a estruturação das consultas e inserções de dados pelo usuário final, além da API para conexão com cliente final.
