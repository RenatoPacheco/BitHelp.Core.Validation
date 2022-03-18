# BitHelp.Core.Validation

[![Licensed under the MIT License](https://img.shields.io/badge/License-MIT-blue.svg)](./LICENSE)
[![Integration Tests](https://github.com/RenatoPacheco/BitHelp.Core.Validation/workflows/Integration%20Tests/badge.svg?branch=master)](https://github.com/RenatoPacheco/BitHelp.Core.Validation/actions/workflows/integration-tests.yml)
[![BitHelp.Core.Validation on fuget.org](https://www.fuget.org/packages/BitHelp.Core.Validation/badge.svg)](https://www.fuget.org/packages/BitHelp.Core.Validation)
[![NuGet](https://img.shields.io/nuget/v/BitHelp.Core.Validation.svg)](https://nuget.org/packages/BitHelp.Core.Validation)
[![Nuget](https://img.shields.io/nuget/dt/BitHelp.Core.Validation.svg)](https://nuget.org/packages/BitHelp.Core.Validation)
[![codecov](https://codecov.io/gh/RenatoPacheco/BitHelp.Core.Validation/branch/master/graph/badge.svg?token=6YLN9GKD8X)](https://codecov.io/gh/RenatoPacheco/BitHelp.Core.Validation)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=RenatoPacheco_BitHelp.Core.Validation&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=RenatoPacheco_BitHelp.Core.Validation)

This project facilitates the validation of an entity's properties.

# Getting Started

## Software dependencies

[.NET Standard 2.0](https://docs.microsoft.com/pt-br/dotnet/standard/net-standard)

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

## Release 0.11.0

**Features:**

- Adding type error to not found with message
- Adding package in github
- Otmization of the any tests validation

To read about others releases access [RELEASES.md](https://github.com/RenatoPacheco/BitHelp.Core.Validation/blob/master/RELEASES.md)

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