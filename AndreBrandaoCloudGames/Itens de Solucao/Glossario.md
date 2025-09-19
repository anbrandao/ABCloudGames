
# Corrected code to create README.md and Relatorio_Entrega.txt files

# Content for README.md
readme_content = """# 🎮 Sistema de Pedidos e Promoções de Jogos (.NET)

## 📌 Objetivo

Este projeto tem como objetivo gerenciar pedidos de jogos em uma plataforma digital, permitindo:

- Cadastro de usuários com diferentes perfis (USER e ADMIN).
- Registro de pedidos contendo múltiplos jogos.
- Aplicação de promoções com desconto configurável.
- Cálculo automático do valor total do pedido.
- Integração com repositórios e aplicação de padrões como Observer.

## 🧱 Estrutura do Projeto

- `BaseEntity`: classe base com `Id` e `CreatedDate`.
- `Usuario`: representa o usuário da plataforma.
- `Pedido`: representa um pedido feito por um usuário.
- `ItemPedido`: representa um item dentro de um pedido.
- `Jogo`: representa um jogo disponível para compra.
- `PromocaoService`: aplica promoções aos jogos.
- `ConfiguracaoPromocao`: record que define o fator de desconto.
- `IPromocaoObserver`: interface para observadores de promoção.
- `Notificador`: classe abstrata para notificação de observadores.

## 🚀 Instruções de Uso

### 1. Clonar o repositório

