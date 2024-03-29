# FreeTypeSharp
[![Nuget](https://img.shields.io/nuget/v/FreeTypeSharp)](https://www.nuget.org/packages/FreeTypeSharp/)

A modern managed FreeType2 library based on the freetype2 code in the [ultraviolet](https://github.com/tlgkccampbell/ultraviolet/tree/develop/Source/Ultraviolet.FreeType2) project.

FreeTypeSharp v2+ provides cross-platform bindings for:

- netcoreapp3.1;net8.0 (Windows, Linux, macOS)
- net8.0-android
- net8.0-ios
- net8.0-tvos
- netstandard2.0
- uap10.0 (UWP)

[README](https://github.com/ryancheung/FreeTypeSharp/tree/v1) for release v1.X

## FreeType Wrapped

FreeType 2.13.2

Native binaries are built by the CI in https://github.com/ryancheung/freetype/tree/csharp-patch

# Installation

`dotnet add package FreeTypeSharp`

UWP target is in a seperate package

`dotnet add package FreeTypeSharp.UWP`

# Usage

There's no magic(abstraction) based on the original C freetype API. All managed API are almost identical with the original freetype C API. Import the namespaces like `using FreeTypeSharp.Native;` and `using static FreeTypeSharp.Native.FT;`, then you can play the font rendering as what you do in C.

# Credits

- https://github.com/tlgkccampbell/ultraviolet
- https://github.com/Robmaister/SharpFont/
