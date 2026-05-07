# ArkkanLMS

A basic Learning Management System (LMS) built with ASP.NET Core, Razor Pages, and SQLite.

## Assessment Requirements

This repository addresses the following LMS assessment requirements:

- TECH STACK: Fullstack application with frontend, backend, and database.
- USER ROLES & FEATURES:
  - Admin:
    - Manage users and assign roles (`Admin` / `Trainer` / `Trainee`).
    - Manage courses and control access via admin pages.
    - Monitor overall platform data via the admin dashboard (demo UI).
  - Trainer:
    - Create/manage course content (trainer pages / course builder in demo UI).
    - Schedule live class sessions and toggle session availability (open/close).
    - Track enrollments and course performance in the trainer dashboard (demo UI).
  - Trainee ( `Student`):
    - Browse/search the course catalog and view course details.
    - Book course sessions (with a mock payment flow).
    - Learn from the course player experience (curriculum, resources, notes) and manage personal learning pages (demo UI).
  - Support (demo UI):
    - Access support workspace with shortcuts to user management and trainer approvals.
  - Moderator (demo UI):
    - Access moderation workspace (placeholder) for reports/comments moderation.
  - Finance (demo UI):
    - Access finance workspace with analytics; payments management is a placeholder.
- DELIVERABLES:
  - Source code included in this repository.
  - README with setup and architecture notes.
  - Brief architecture summary below.

## What Was Implemented

### Core LMS

- Role model with `Admin`, `Trainer`, and `Trainee` user roles.
- Admin UI for managing user roles, courses, and access by role.
- Course browsing and trainee booking workflows.
- Class session scheduling with open/close session status.
- Booking and mock payment flow for trainees.
- SQLite persistence with automatic DB creation and seed data.
- Simple current-user simulation flow for role-based UI behavior.

### Demo UI / UX upgrade

- Premium SaaS landing page (hero, features, popular courses, top instructors, statistics, testimonials, pricing, FAQ, CTA, footer).
- Rich student dashboard (KPIs with trends, weekly progress chart, weekly goal, achievement badges, continue-learning rail, upcoming live classes, course recommendations, activity timeline, notifications).
- Netflix-style course learning page with video player, sectioned curriculum sidebar, and tabbed content (Overview · Notes · Resources · Discussion · Quiz).
- Student workspace pages: My Courses, Continue Learning, Certificates, Wishlist, Messages (chat-style), Calendar, Assignments.
- Trainer (creator-studio) dashboard with revenue, growth, course performance charts plus pending reviews and recent enrollments.
- Trainer pages: Course Builder (drag-and-drop curriculum), Courses, Analytics, Students, Revenue, Reviews, Live Sessions, Assignments.
- Admin enterprise dashboard with traffic analytics, signups breakdown, support tickets, reports queue, platform health.
- Course catalog with search, category pills, multi-filter sidebar (level, price, rating, language), sort, and pagination.
- Profile page with tabs (Personal · Security · Notifications · Language · Billing · Learning history).
- Polished login (demo-account picker + form), pricing, about, FAQ, contact pages.

### Multilingual & RTL architecture

- English (LTR) and Arabic (RTL) — switchable via `EN / العربية` toggle in navbar/sidebar/footer.
- Locale persisted in the `ark_lang` cookie via `/lang/{en|ar}` endpoint.
- `<html lang dir>` rendered server-side from cookie — full RTL mirroring for navigation, sidebar, tables, charts, and Bootstrap utilities (`ml-*`, `mr-*`, `text-left/right`, `dropdown-menu-right`, `border-left/right`, etc.).
- Arabic typography uses **Cairo** (with **IBM Plex Sans Arabic** fallback); English uses **Inter** + **Poppins**. Fonts switch automatically per locale.
- Dictionary-based translation in `ArkkanLMS.Web/Localization/Strings.cs` — easy to extend (just add keys).

### Theming

- Light & Dark modes — toggle in navbar/sidebar/profile. Persisted in `ark_theme` cookie via `/theme/{light|dark}` endpoint.
- Glassmorphism, soft shadows, rounded `2xl` corners, premium cards, gradient highlights, smooth Framer-style transitions.
- Role-based color accents: students → blue/purple, trainers → emerald/orange, admin → slate/indigo.

### Responsive

- Desktop: full sidebar layout.
- Tablet/mobile: drawer toggle for admin/trainer, bottom navigation for students.

## Architecture Decisions

The application uses a layered architecture with clean separation between domain/core models, application services, persistence, and the Razor Pages UI. It favors server-rendered pages for simplicity, EF Core + SQLite for lightweight persistence, and explicit role-based authorization logic in page handlers and UI flows.

- Backend: ASP.NET Core 10 with Razor Pages for server-rendered UI and simple navigation.
- Data access: Entity Framework Core 10 with SQLite, using `AppDbContext` for persistence.
- Layered structure:
  - `ArkkanLMS.Core`: entities, types, and shared interfaces.
  - `ArkkanLMS.Application`: business services and validations.
  - `ArkkanLMS.Persistence`: EF Core context, migrations, and seed data.
  - `ArkkanLMS.Web`: Razor Pages UI and request handling.
- Role enforcement: admin/trainer/trainee checks are applied in page handlers and UI flows.
- Database choice: SQLite keeps the demo lightweight while matching current local development.

## Setup Instructions

1. Install the .NET 10 SDK if not already installed.
2. Open the solution in Visual Studio or use the .NET CLI from the repository root.
3. Restore packages:
  ```bash
   dotnet restore ArkkanLMS.sln
  ```
4. Build the solution:
  ```bash
   dotnet build ArkkanLMS.sln
  ```
5. Run the web project:
  ```bash
   dotnet run --project ArkkanLMS.Web\ArkkanLMS.Web.csproj
  ```
6. Open the browser at the URL shown in the console (typically `https://localhost:5001`).

The application automatically creates the SQLite database file (`ArkkanLMS.db`) and seeds example data on first run.

## Development

- Open `ArkkanLMS.sln` in Visual Studio or your editor of choice.
- Use `dotnet run --project ArkkanLMS.Web\ArkkanLMS.Web.csproj` to start the site.
- The DB file is created in the application root when the site starts.
- To inspect data, open `ArkkanLMS.db` with any SQLite viewer.

## Seed Users

- Admin: `admin@ArkkanLMS.dev`
- Trainer: `trainer@ArkkanLMS.dev`
- Trainee: `trainee@ArkkanLMS.dev`

## Notes

- User selection is currently simulated with a simple role chooser instead of full login/authentication.
- The system supports course registration, booking, session scheduling, and basic role-based access control.
- The backend is upgraded to .NET 10 and uses EF Core 10 with SQLite.

## Adding new translations

All UI strings live in `[ArkkanLMS.Web/Localization/Strings.cs](ArkkanLMS.Web/Localization/Strings.cs)` as a single dictionary keyed by `(string key, string culture)`. To add a new key:

```csharp
["my.new.key"] = new Dictionary<string, string> {
    ["en"] = "My new label",
    ["ar"] = "النص الجديد",
},
```

Then in any `.cshtml`:

```cshtml
@Locale["my.new.key"]
```

`Locale` is injected globally via `_ViewImports.cshtml`. It also exposes `Locale.Culture`, `Locale.IsRtl`, `Locale.Direction` (`"ltr"` / `"rtl"`), and `Locale.Theme` (`"light"` / `"dark"`).

## Switching locale or theme via URL

- `GET /lang/en` or `GET /lang/ar` — sets the language cookie and redirects back.
- `GET /theme/light` or `GET /theme/dark` — sets the theme cookie and redirects back.

Both accept an optional `?returnUrl=` parameter that must be a local URL.