Integrantes do Grupo:

- Bruno de Paula (RM552226)
- Kayque Lima (RM550782)
- Gabriel França (RM551905)
- Gabriel Francisco Lobo (RM99708)
- Edward de Lima (RM98676)

# **Guardian API**

Bem-vindo à **Guardian API**! Este é um projeto desenvolvido em C# com o objetivo de promover o gerenciamento de aerogeradores e parques eólicos, integrando sensores e inteligência artificial para monitoramento climático.

### **Gerenciamento de Parques Eólicos**
Além de monitorar as condições climáticas, a **Guardian** facilita o gerenciamento de parques eólicos por meio de um conjunto de funcionalidades robustas, incluindo:
- Cadastro e atualização de parques eólicos.
- Gerenciamento de torres e aerogeradores associados a cada parque.
- Registro e análise de falhas em componentes do parque.
- Histórico detalhado de condições operacionais, promovendo uma manutenção preditiva eficiente.

Com torres estrategicamente posicionadas, o sistema coleta dados como:
- Horário, intensidade e coordenadas de quedas de raios.
- Velocidade dos ventos.
- Índices de pluviosidade.
- Previsões climáticas detalhadas.

Essas informações são processadas para gerar um histórico abrangente de análise de falhas e desenvolver estratégias preventivas e corretivas para manutenção.


## **Abordagem Monolítica**

Optamos por uma arquitetura monolítica devido às seguintes vantagens:

### **Simplicidade e Desenvolvimento Rápido**
A integração de todos os componentes dentro de um único projeto facilita a configuração, desenvolvimento e implantação inicial.

### **Manutenção Centralizada**
Uma única base de código simplifica atualizações e correções, garantindo a integridade e consistência do sistema.


## **Design Patterns Utilizados**

Este projeto utiliza diversos padrões de design para garantir modularidade, manutenção e escalabilidade:

### **1. Repository Pattern**
Encapsula a lógica de acesso a dados em classes específicas, promovendo uma separação clara entre a camada de aplicação e a persistência de dados. 
- Exemplo: Repositórios como `TorreRepository`, `FalhaRepository`.

### **2. Service Layer**
Centraliza a lógica de negócios em serviços dedicados, deixando os controladores mais limpos e focados na interação com a API.
- Exemplo: Serviços como `TorreApplicationService`, `ClimaPredictionService`.

### **3. Dependency Injection**
Utilizado para reduzir o acoplamento entre as classes. Todas as dependências são injetadas via construtor, facilitando testes e manutenção.
- Exemplo: Configurado em `Program.cs` com o uso do `builder.Services.AddScoped()`.


## **Configuração do Projeto**

Para executar o projeto localmente, siga estas etapas:

### **1. Clonar o Repositório**

```bash
git clone https://github.com/seu-repositorio/guardian-api.git
```

### **2. Configurar a string de conexão**

Certifique-se de configurar a string de conexão no arquivo Program.cs

```bash
options.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=username;Password=password;");
```

### **3. Executar a API**

```bash
dotnet run
```
