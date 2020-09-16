[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Testing.NUnit?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Testing-NUnit/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Testing.NUnit.svg)](https://www.nuget.org/packages/ByteDev.Testing.NUnit)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.Testing.NUnit/blob/master/LICENSE)

# ByteDev.Testing.NUnit

.NET Standard library that provides some extra NUnit functionality.

## Installation

ByteDev.Testing.NUnit has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Testing.NUnit is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Testing.NUnit`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Testing.NUnit/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.Testing.NUnit/blob/master/docs/RELEASE-NOTES.md).

## Usage

Library provides extra static classes for performing assertions. These can all be accessed in the namespace: `ByteDev.Testing.NUnit`.

### AssertDir

Directory related assertions. Methods include:

- ContainsDirectories
- ContainsFiles
- Exists
- HasNoDirectories
- HasNoFiles
- IsEmpty
- NotExists

### AssertFile

File related assertions. Methods include:

- AreSame
- Exists
- HasMoved
- IsEmpty
- NotExists
- SizeEquals

### AssertImage

Image related assertions. Methods include:

- HeightEquals
- WidthEquals
