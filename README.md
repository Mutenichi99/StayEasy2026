# StayEasy 2026 — Reservas de Hospedagem

Aplicativo acadêmico.

> Projeto demonstrativo: não efetua pagamentos nem reservas reais.

## Funcionalidades

- Página inicial personalizada, com identidade visual azul-marinho e dourado.
- Formulário de nova reserva com nome, quarto, adultos e crianças.
- Três tipos de suítes, com preços e limite de hóspedes.
- Calendários de check-in e check-out; saída obrigatoriamente posterior à entrada.
- Estimativa imediata de diárias e preço total.
- Validações de nome, datas, capacidade, limite de 30 noites e presença de adulto.
- Confirmação com número de reserva e detalhes da hospedagem.
- Histórico de reservas armazenado no próprio dispositivo (arquivo JSON).
- Cancelamento com confirmação.
- Tela "Sobre o projeto" com conceitos de orientação a objetos utilizados.

## Requisitos

- **Visual Studio 2026 (versão 18.0 ou superior)**.
- **SDK do .NET 10** e carga de trabalho **Desenvolvimento da interface do usuário de aplicativos multiplataforma .NET (.NET MAUI)**.
- Para execução inicial, escolha **Windows Machine**; há também alvo Android caso o SDK/emulador estejam configurados.

## Início rápido

1. Extraia todo o arquivo ZIP.
2. Abra `StayEasy2026.sln` no Visual Studio 2026.
3. Aguarde a restauração das dependências NuGet.
4. Na barra superior, selecione a configuração de **Windows** (`net10.0-windows10.0.19041.0`) e o destino **Windows Machine**.
5. Pressione **F5**.

O projeto usa `<WindowsPackageType>None</WindowsPackageType>` para facilitar a execução sem assinatura de pacote MSIX no Windows.

## Estrutura de pastas

```text
StayEasy2026.sln
StayEasy2026/
  App.xaml(.cs)                    - recursos, cores e navegação inicial
  MauiProgram.cs                  - inicialização
  Models/
    Quarto.cs                      - classe e propriedades de uma suíte
    Reserva.cs                     - classe com validações e cálculos
  Services/
    CatalogoQuartos.cs            - List<Quarto>
    RepositorioReservas.cs        - leitura/gravação local em JSON
  Views/
    InicioPage.xaml(.cs)
    NovaReservaPage.xaml(.cs)
    ConfirmacaoPage.xaml(.cs)
    MinhasReservasPage.xaml(.cs)
    SobrePage.xaml(.cs)
  Platforms/                       - Android e Windows
  Resources/                       - splash, ícone e arte SVG
```
