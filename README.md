# MedicalSystem

Este repositório contém o código-fonte de um sistema médico desenvolvido em .NET. O projeto segue uma arquitetura de camadas e inclui funcionalidades para gerenciamento de consultas, médicos e pacientes.

## Estrutura do Projeto

A estrutura do projeto é dividida em quatro camadas principais:
- **API**: Interface do usuário e controladores.
- **Aplication**: Casos de uso e lógica de negócios.
- **Domain**: Entidades e regras de negócios.
- **Infra**: Persistência de dados, serviços externos, services.

## Funcionalidades Principais

- **Gerenciamento de Consultas**:
  - Criação de consultas
  - Exclusão de consultas
  - Envio de notificações por e-mail

- **Gerenciamento de Médicos**:
  - Criação de médicos
  - Exclusão de médicos

- **Gerenciamento de Pacientes**:
  - Criação de pacientes
  - Exclusão de pacientes
  - Atualização de pacientes

## Configuração e Execução

### Pré-requisitos

- .NET SDK 7.0 ou superior
- Banco de dados SQL Server (ou outro banco de dados compatível)
- Configuração de um servidor SMTP (para envio de e-mails)

### Configuração do Projeto

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/Alansilvao/MedicalSystem.git
   cd seu-repositorio
