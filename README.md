# Descrição

API REST em ASP.NET CORE para gerenciar lista de tarefas

Pré requisitos:

- Git
- Docker
- Dot.net Core

# Banco de dados

Configurado via Docker.

Na pasta raiz do projeto encontra-se o arquivo docker-compose.yml, para subir o banco de dados, executar o comando abaixo, via terminal: 

```
$ docker-compose up
```

Utilizando um gerenciador de banco de dados, crie um banco de dados com o nome Todo

```
CREATE DATABASE Todo
```

# Firebase Authentication

Neste projeto foi utilizado o padrão de authenticação com o Google atráves do Firebase.

Acesse o site do firebase (caso não possua uma conta google crie uma nova)

```
https://firebase.google.com/
```
Após logado, clique em 'Ir para o console'

- Crie um novo projeto (Não precisa ativar o Google Analytics)

Com o projeto criado, vá para o painel do projeto e acesse a opção <b>Authentication</b>-> <b>Método de login</b>

- Ative a opção Google 

O firebase foi configurado, agora basta registrar um aplicativo e adicionar as configurações no arquivo Startup.cs

Ainda no firebase, acesse o menu Visão geral do projeto e clique na opção Web: 
```
</>
```
- Registre um apelido para o app

Após registrado serão exibidas as informações para configuração do firebase na sua aplicação

Copie o nome do projeto: 
```
projectId: "{{project-name}}"
```

No arquivo Startup.cs da sua aplicação, altere as configurações de acordo com o nome do projeto:

```
services
      .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
          options.Authority = "https://securetoken.google.com/{{project-name}}";
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidIssuer = "https://securetoken.google.com/{{project-name}}",
              ValidateAudience = true,
              ValidAudience = "{{project-name}}",
              ValidateLifetime = true                   
          };
      });
```

Tudo pronto, a authenticação com firebase foi configurada.
