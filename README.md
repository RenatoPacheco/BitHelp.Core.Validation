# BitHelp.Core.Validation

[![Licensed under the MIT License](https://img.shields.io/badge/License-MIT-blue.svg)](./LICENSE)
[![Integration Tests](https://github.com/RenatoPacheco/BitHelp.Core.Validation/workflows/Integration%20Tests/badge.svg?branch=master)](https://github.com/RenatoPacheco/BitHelp.Core.Validation/actions/workflows/integration-tests.yml)
[![NuGet](https://img.shields.io/nuget/v/BitHelp.Core.Validation.svg)](https://nuget.org/packages/BitHelp.Core.Validation)
[![Nuget](https://img.shields.io/nuget/dt/BitHelp.Core.Validation.svg)](https://nuget.org/packages/BitHelp.Core.Validation)

This project facilitates the validation of an entity's properties.

# Getting Started

## Software dependencies

[BitHelp.Core.Extend (>= 0.4.0)](https://www.nuget.org/packages/BitHelp.Core.Extend/)

## Installation process

This package is available through Nuget Packages: https://www.nuget.org/packages/BitHelp.Core.Validation

**Nuget**
```
Install-Package BitHelp.Core.Validation
```

**.NET CLI**
```
dotnet add package BitHelp.Core.Validation
```

## Latest releases

#### Release 0.10.0

**Features:**

- Fixing the RemoveAtReference extension
- There is no need to keep .nupkg files
- Add extension to check for notifications
- Add extension to add notifications for ISelfValidation

To read about others releases access [RELEASES.md](./RELEASES.md)

# Build and Test

Using Visual Studio Code, you can build and test the project from the terminal.

Build and restore the project:

```
dotnet restore
dotnet build --no-restore
```

Tests:

```
dotnet test --no-build --verbosity normal
```