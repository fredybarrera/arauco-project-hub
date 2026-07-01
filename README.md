# Arauco Project Hub

Monorepo de Arauco Project Hub.

## Componentes

* `frontend`: Nuxt 4, Vue 3 y TypeScript.
* `backend`: .NET 10 y ASP.NET Core 10.
* `docs`: Engineering Playbook.

## Validación

Backend:

```powershell
dotnet build backend/Arauco.ProjectHub.slnx
dotnet test backend/Arauco.ProjectHub.slnx --no-build
```

Frontend:

```powershell
npm --prefix frontend install
npm --prefix frontend run typecheck
npm --prefix frontend run test
npm --prefix frontend run build
```

Antes de colaborar, revisar `AGENTS.md`, `docs/handbook/BOOTSTRAP.md` y `docs/handbook/CURRENT_STATE.md`.
