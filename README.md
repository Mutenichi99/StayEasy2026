# StayEasy 2026 — Reservas de Hospedagem

Aplicativo acadêmico para a **Agenda 14 de Programação Mobile I**, desenvolvido com **C#**, **XAML** e **.NET MAUI 10**, para uso no **Visual Studio 2026 (18.x)**.

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

## Orientação a objetos (Agenda 14)

A classe `Quarto` possui propriedades de leitura e validação no construtor. `CatalogoQuartos.Criar()` retorna uma `List<Quarto>` que alimenta o Picker. A classe `Reserva` guarda o estado de uma reserva e concentra métodos de validação e propriedades calculadas (`Diarias`, `PrecoTotal`). O repositório armazena uma lista de reservas em JSON usando `FileSystem.AppDataDirectory`.

## Testes sugeridos

1. Criar uma reserva válida (ex.: 2 noites, 2 adultos, Suíte Essencial).
2. Conferir se o total muda conforme o quarto ou as datas.
3. Usar uma suíte com capacidade 2 e tentar 3 pessoas: deve exibir aviso.
4. Tentar reservar sem nome: deve exibir aviso.
5. Conferir se a saída ocorre depois da entrada.
6. Ver o comprovante, acessar Minhas reservas e cancelar uma delas.
7. Fechar e abrir de novo para confirmar a persistência.

## Envio no GitHub

Crie um **repositório novo** no seu GitHub e publique os arquivos da pasta extraída, mantendo `StayEasy2026.sln` na raiz. Não inclua as pastas `bin`, `obj` ou `.vs` (cobertas pelo `.gitignore`). Compartilhe um link no formato `https://github.com/SEU-USUARIO/NOME-DO-REPOSITORIO`.

Veja `GUIA_DE_ENTREGA.md` para saber exatamente quais prints capturar e como publicar pelo Visual Studio 2026.

## Observação técnica

Os arquivos e vínculos XAML/C# passaram por verificações estáticas neste ambiente. **Não foi realizada uma compilação real em Visual Studio/Windows**, pois o ambiente de geração é Linux e não possui a carga de trabalho MAUI. Se o Visual Studio apresentar algum erro, capture a *Lista de Erros* com o código e a mensagem.
