# F1 Ticket — F1 Race Ticket Marketplace

## Overview

F1 Ticket is a web application developed in ASP.NET Web Forms (C#).

The system is a platform for browsing Formula 1 information and simulating ticket purchases for upcoming races. Authenticated users can view past race results (including fastest lap), check drivers’ and constructors’ championship standings for the 2023 season as stored in the database, browse driver and team pages, choose a grandstand and a quantity of tickets for future races, add them to a cart, and complete a simulated checkout. The project focuses on multi-page ASP.NET Web Forms development, SQL Server data access, user authentication, and an end-to-end purchase flow.

The application consists of public feature pages (home, championships, drivers/teams, race results or ticket purchase, cart, history, profile), a shared master page, a set of admin pages for managing content, and a SQL Server database (`F1Ticket`). User accounts use the built-in ASP.NET SQL Membership provider and Forms Authentication.

## Features

- Home page listing grands prix from the `Pistas` table, ordered with upcoming races first, then past races
- For races whose start date is treated as past, a link to results; for future races, a link to ticket purchase
- Race results (finishing order, times, and fastest lap) when data exists in `ResultadosCorridas` / `VoltaRapida`
- Drivers’ and constructors’ championship standings (points stored in the database, ordered by points, best result, and number of times that result was achieved)
- Driver and team listing pages, with detail pages (stats, nationality, team, images)
- Ticket purchase for upcoming races: grandstand letter, session type (practice, qualifying, race, or full weekend), quantity, remaining seats, and price per ticket
- Shopping cart stored per user in the database, supporting items across different races and session types
- Simulated checkout with card-holder fields that are validated as required but not sent to a payment provider
- Purchase history per user, including the ability to clear that history
- User registration, login, profile (username, email, account creation date), and password change
- Admin UI (visible when the custom `Admin` table has `Admin = 'Sim'` for the current user) to manage tracks, tickets/grandstands, race results, championships, drivers, and teams

## System Architecture

The application is composed of the following components:

### Pages (ASP.NET Web Forms)

Each feature is implemented as an `.aspx` page with a matching C# code-behind. Most pages declare `MasterPageFile="~/Navbar.Master"` and render into `ContentPlaceHolder1` (and optionally `head`).

Pages that **use** `Navbar.Master`:

- `PaginaInicial` — home: race list, top three drivers by championship points, a grid of the user’s past purchases, and admin shortcuts when applicable
- `CampeonatoPilotos` / `CampeonatoConstrutores` — championship standings
- `SobrePilotos` / `SobreEquipas` — driver / team listings (ordered by championship points)
- `AllPilotos` / `AllEquipas` — driver / team detail pages (`?nome=...`)
- `PaginasPistas/Resultados` — results for a past race (`?nomePista=...`, also kept in `Session["nomePista"]`)
- `PaginasPistas/ComprarBilhete` — ticket selection for a future race
- `Carrinho` — shopping cart
- `Historico` — purchase history
- `Perfil` — account summary and link to change password
- Admin pages under `Admin/`

Pages that **do not** use the master page (standalone layout, login-style CSS/background):

- `Login.aspx` — `asp:Login` control
- `Register.aspx` — `CreateUserWizard`; on success inserts a row into `Admin` with `Admin = 'Nao'`
- `AlterarPP.aspx` — `asp:ChangePassword` control
- `FinalizarCompra.aspx` — checkout form

### Navbar (Master Page)

`Navbar.Master` provides the shared layout and navigation used by the pages listed above: home, F1 information (drivers/teams), 2023 championships, cart, history, profile, and logout.

On each load, the master page’s code-behind (`Navbar.Master.cs`) reads the logged-in user’s Membership `ProviderUserKey` and sets the cart badge from `SELECT COALESCE(SUM(quantidade), 0) FROM Carrinho WHERE idUser = ...`. Logout clears and abandons the session and redirects to `login.aspx`.

Client assets on the master page include `Themes/Navbar.css`, jQuery, and Font Awesome (CDN).

### Authentication

- Forms Authentication (`loginUrl="Login.aspx"`, timeout 2880 minutes).
- Site-wide authorization denies anonymous users (`<deny users="?" />`), with an explicit exception for `Register.aspx`.
- Membership uses `SqlMembershipProvider` against the same SQL Server connection (`minRequiredPasswordLength` 6, password reset enabled, no security question, unique email not required).
- After a successful `Membership.ValidateUser`, the app sets `Session["user"]` and redirects to `PaginaInicial.aspx`. Most pages also redirect to login if `Session["user"]` is null.
- A custom `Admin` table (`UserId`, `Admin`) flags administrators (`Sim` / `Nao`). Listing/championship/home pages show admin buttons only when `Admin = 'Sim'`. Admin page access is not fully restricted to users with the Admin flag, this is listed under Future Improvements.

### Shopping cart and purchase flow

The cart is **not** kept only in session. It is persisted in the `Carrinho` table (`idUser`, `quantidade`, `idPista`, `idBancada`, `preco`, `tipo`).

Session is used for:

- `Session["user"]` — login flag used by page guards
- `Session["nomePista"]` — current race name, taken from the query string on results/ticket pages (cleared on the home page)

Flow:

1. Home compares each race’s `dataCorridaInicio` with a date built as year **2023** plus the current month/day/time. Past races go to `Resultados.aspx`; future races go to `ComprarBilhete.aspx`.
2. `ComprarBilhete` loads track name, flag, and grandstand map from `Pistas`, and remaining seats/prices from `BancadaT` (practice), `BancadaQ` (qualifying), `BancadaC` (race), and `BancadaFDS` (full weekend). The user picks a **grandstand letter** (`letraBancada`) and a **quantity**, not an individual seat number.
3. Adding to the cart inserts or updates `Carrinho` for that user, track, grandstand, and `tipo` (`Treinos`, `Qualificação`, `Corrida`, `Fim de semana Completo`). Remaining seats are displayed; the add-to-cart handlers do not compare the chosen quantity against remaining stock.
4. `Carrinho` lists items (join of `Carrinho`, `BancadaT`, `Pistas`, `aspnet_Users`), shows a total (`SUM(preco)`), can empty the cart, and navigates to checkout if the cart is not empty.
5. `FinalizarCompra` requires titular, card number, expiry, and CVV via `RequiredFieldValidator`. Those values are not written to the database and are not passed to any payment API. On confirm, each cart row is copied to `Transfers` (with `dataCompra = GETDATE()`), removed from `Carrinho`, and remaining `lugares` are decremented on the matching bancada table(s). Full-weekend purchases update `BancadaT`, `BancadaQ`, `BancadaC`, and `BancadaFDS`.
6. `Historico` (and a similar grid on the home page) reads `Transfers` joined to `BancadaT` and `Pistas`. The user can delete all of their `Transfers` rows.

### Admin area

Admin pages (all using `Navbar.Master`):

- `Admin/EditarPista` — add / edit / delete tracks (`Pistas`: name, race name, dates, country flag image, grandstand map image)
- `Admin/AdicionarBilhetes` — create/replace grandstand rows (letter, seats, price) for **future** races (`dataCorridaInicio > GETDATE()`) in `BancadaT` / `BancadaQ` / `BancadaC` / `BancadaFDS`
- `Admin/AdicionarResultados` — replace results and fastest lap for **past** races (`ResultadosCorridas`, `VoltaRapida`)
- `Admin/EditarClassificacao` — update drivers’ championship (`Pontos`, `MelhorResultado`, `NumVezes`)
- `Admin/EditarClassificacaoConstrutores` — same for constructors
- `Admin/EditarPilotos` — add / edit / remove drivers (`SobrePilotos`)
- `Admin/EditarEquipas` — add / edit / remove teams (`SobreEquipas`); adding a team also inserts a `CampeonatoConstrutores` row

There is no separate admin master layout or ASP.NET Roles provider in this project.

### Data access

Entity Framework 6.4.4 is referenced in the project (`packages.config`, `Web.config` `<entityFramework>` section, and assembly references), but **no `DbContext`, entity classes, EDMX, or migrations appear in the source**. All application queries use ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`) against the `ConnectionString` named connection.

Tables used by the application code:

| Table | Role (from queries) |
| --- | --- |
| `Pistas` | Races/circuits: names, dates, flag and grandstand images |
| `BancadaT` / `BancadaQ` / `BancadaC` / `BancadaFDS` | Grandstands per session type: letter, remaining seats, price |
| `Carrinho` | Per-user cart lines |
| `Transfers` | Completed purchases |
| `SobrePilotos` / `SobreEquipas` | Driver and team content and images |
| `CampeonatoPilotos` / `CampeonatoConstrutores` | Championship points and tie-break fields |
| `ResultadosCorridas` / `VoltaRapida` | Race classification and fastest lap |
| `Admin` | Custom admin flag per Membership user |
| `aspnet_Users` / `aspnet_Membership` | ASP.NET Membership schema |

The repository does not include a SQL script or backup that creates `F1Ticket`. The database (including the ASP.NET Membership objects) must already exist or be created separately.

Images for flags, cars, driver photos, and maps are stored as binary columns and rendered as `data:image/png;base64,...` in the pages.

## Technologies Used

- ASP.NET Web Forms on .NET Framework 4.7.2
- C#
- SQL Server (ADO.NET)
- Entity Framework 6.4.4 (NuGet/reference only; not used in application code)
- ASP.NET Membership (`SqlMembershipProvider`) and Forms Authentication
- CSS (`Themes/Login.css`, `Navbar.css`, `PaginaInicial.css`, `Register.css`, plus page-level styles)
- JavaScript used on some pages (`Script/Bilhetes.js`, `CampeonatoPilotos.js`, `ResultadosCorridas.js`)
- jQuery 3.6.0 and Font Awesome (CDN)

## Running the Project

1. Open `PAP - F1 Ticket.sln` in Visual Studio.
2. Restore NuGet packages if prompted (Entity Framework 6.4.4 and Microsoft.CodeDom.Providers.DotNetCompilerPlatform 2.0.1).
3. Update the `ConnectionString` entry in `Web.config` to point to your SQL Server instance and the `F1Ticket` database.
4. Ensure the `F1Ticket` database already contains the application tables listed above and the ASP.NET Membership schema (this repo has no migrations or schema script).
5. Run the project with IIS Express (the project is configured for `https://localhost:44346/`).

Unauthenticated visitors are sent to `Login.aspx`. New accounts are created on `Register.aspx`.

## Technical Challenges

This project required dealing with several concepts, including:

- Structuring a multi-page Web Forms application with a master page for shared chrome, and a few standalone pages for login, register, password change, and checkout
- Designing a relational schema covering races, grandstands per session type, cart lines, purchases, drivers, teams, championships, and results, and querying it with ADO.NET
- Keeping purchase state across pages via a database-backed cart keyed by Membership user id, plus session for the current race name
- Combining the default ASP.NET Membership tables with custom tables (`Admin`, `Carrinho`, `Transfers`, and F1 content)
- Encoding binary images from SQL Server for display in HTML

## Lessons Learned

Through this project I gained practical experience in:

- ASP.NET Web Forms development (pages, master pages, GridView, Membership controls)
- Relational database design and SQL from C#
- User authentication and a simple custom admin flag
- Building an end-to-end purchase flow (selection → cart → simulated payment → history)
- Working with a still widely used .NET Framework web stack

## Future Improvements

Potential future improvements include:

- Using Entity Framework (already referenced) or another data layer instead of string-built SQL throughout the code-behind files
- Externalizing the connection string and other secrets out of `Web.config` / source control
- Adding a SQL schema script or backup so the database can be recreated from the repository
- Restricting admin pages by the `Admin` flag (or ASP.NET Roles), not only by login
- Checking remaining seats when adding items to the cart, not only when decrementing stock at checkout
- Real payment integration (the current checkout only requires card fields locally)
- Selecting individual seats rather than a grandstand letter plus quantity
- Automated tests
- Migrating to ASP.NET Core MVC or Razor Pages
- A more responsive layout (many pages use fixed percentages and desktop-oriented CSS)
