# MedicalSystem

Este reposit�rio cont�m o c�digo-fonte de um sistema m�dico desenvolvido em .NET. O projeto segue uma arquitetura de camadas e inclui funcionalidades para gerenciamento de consultas, m�dicos e pacientes.

## Estrutura do Projeto

A estrutura do projeto � dividida em quatro camadas principais:
- **API**: Interface do usu�rio e controladores.
- **Aplication**: Casos de uso e l�gica de neg�cios.
- **Domain**: Entidades e regras de neg�cios.
- **Infra**: Persist�ncia de dados, servi�os externos, services.

## Funcionalidades Principais

- **Gerenciamento de Consultas**:
  - Cria��o de consultas
  - Exclus�o de consultas
  - Envio de notifica��es por e-mail

- **Gerenciamento de M�dicos**:
  - Cria��o de m�dicos
  - Exclus�o de m�dicos

- **Gerenciamento de Pacientes**:
  - Cria��o de pacientes
  - Exclus�o de pacientes
  - Atualiza��o de pacientes

## Configura��o e Execu��o

### Pr�-requisitos

- .NET SDK 7.0 ou superior
- Banco de dados SQL Server (ou outro banco de dados compat�vel)
- Configura��o de um servidor SMTP (para envio de e-mails)

### Configura��o do Projeto

1. **Clone o reposit�rio**:
   ```bash
   git clone https://github.com/Alansilvao/MedicalSystem.git
   cd seu-repositorio
