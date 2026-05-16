# DepthFirstSearch — Project Guide

## Branching workflow

Always work on a feature branch, never commit directly to `master`.

```powershell
# 1. Start from an up-to-date master
git checkout master
git pull origin master

# 2. Create a feature branch
git checkout -b fix/short-description   # bug fixes
git checkout -b feat/short-description  # new features

# 3. Make changes, then commit
git add <files>
git commit -m "Short description of what and why"

# 4. Push the branch and open a PR → master
git push origin <branch-name>
# Then create PR via GitHub UI or gh CLI
```

## Stack

- .NET 9, C#
- FluentResults for error handling
- Serilog for logging
- MSTest for unit tests

## Project structure

- `DepthFirstSearch.PoC/` — main application
  - `SearchLogic/` — DFS algorithm
  - `Helpers/` — maze utilities
  - `Repository/` — maze file loading
  - `MazeStructure/` — maze text files (`#` = wall, `S` = start, `F` = finish, ` ` = open path)
- `DeepFirstSearch.PoC.Tests/` — unit tests
