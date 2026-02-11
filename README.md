<div align="center">

# 📚 Biblioteca POO (Console) — C# / .NET

Sistema de biblioteca em **terminal/console** para praticar **POO na vida real**: encapsulamento, herança, polimorfismo, composição e regras de negócio.

<br/>

![.NET](https://img.shields.io/badge/.NET-Console-blueviolet)
![C#](https://img.shields.io/badge/C%23-POO-success)
![Status](https://img.shields.io/badge/status-em%20evolu%C3%A7%C3%A3o-informational)

</div>

---

## 🎯 Objetivo

Este projeto foi criado para **solidificar a base de Programação Orientada a Objetos** sem frameworks, sem banco e sem arquitetura avançada — apenas **domínio e regras**.

**O foco é aprender fazendo:**
- Encapsulamento (estado sempre válido)
- Herança & Polimorfismo (regras diferentes para tipos de usuário)
- Composição (Empréstimo liga Usuário + Livro)
- Regras de negócio (limite, prazo, disponibilidade e devolução segura)
- Tratamento de erros (operações inválidas geram feedback claro)

---

## ✅ Funcionalidades atuais

- Cadastro de **Usuários** (`Aluno`, `Professor`)
- Cadastro de **Livros**
- **Empréstimo** com validações:
  - usuário e livro existentes
  - limite de empréstimos por tipo de usuário
  - livro precisa estar disponível
- **Devolução**:
  - impede devolução duplicada
  - libera o livro corretamente
- Listagem:
  - livros disponíveis
  - empréstimos ativos

---

## 🧩 Modelagem (POO aplicada)

- `Usuario` *(abstrata)*  
  Define as regras variáveis por tipo:
  - `LimiteEmprestimos()`
  - `ObterPrazo()`

- `Aluno` / `Professor`  
  Implementam regras específicas via polimorfismo.

- `Livro`  
  Controla o próprio estado:
  - `Emprestar()` / `Devolver()`
  - `Disponivel` com `private set`

- `Emprestimo`  
  Registra datas e estado:
  - `DataEmprestimo`, `PrazoDevolucao`, `DataDevolucao`
  - `EstaAtrasado()`
  - `Devolver()` (sem “mexer” diretamente no usuário)

- `Biblioteca` *(orquestradora)*  
  Coordena o processo de empréstimo/devolução.

---

## 🚀 Como executar

### Pré-requisitos
- **.NET SDK** instalado

### Rodar o projeto
```bash
dotnet restore
dotnet run
