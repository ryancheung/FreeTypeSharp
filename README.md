# FreeTypeSharp
[![Nuget](https://img.shields.io/nuget/v/FreeTypeSharp)](https://www.nuget.org/packages/FreeTypeSharp/)
[![Nuget](https://img.shields.io/nuget/vpre/FreeTypeSharp)](https://www.nuget.org/packages/FreeTypeSharp/)

A moden managed FreeType2 library based on the freetype2 code in the [ultraviolet](https://github.com/tlgkccampbell/ultraviolet/tree/develop/Source/Ultraviolet.FreeType2) project.

FreeTypeSharp v2+ provides cross-platform bindings for:

- net6.0 (Windows, Linux, macOS)
- net6.0-android
- net6.0-ios
- net6.0-windows10

## FreeType Wrapped

FreeType 2.10.1

# Installation

`dotnet add package FreeTypeSharp`

# Usage

There's no magic(abstraction) based on the original C freetype API. All managed API are almost identical with the original freetype C API. Import the namespaces like `using FreeTypeSharp.Native;` and `using static FreeTypeSharp.Native.FT;`, then you can play the font rendering as what you do in C.

Optionally, a facade `FreeTypeFaceFacade` was provided to handle some basic job. Feel free to use it.

# Credits

- https://github.com/tlgkccampbell/ultraviolet
- https://github.com/Robmaister/SharpFont/
