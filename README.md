# Caesar Cipher

```
  ____    _    _____ ____    _    ____
 / ___|  / \  | ____/ ___|  / \  |  _ \
| |     / _ \ |  _| \___ \ / _ \ | |_) |
| |___ / ___ \| |___ ___) / ___ \|  _ <
 \____/_/   \_\_____|____/_/   \_\_| \_\
```

A Caesar cipher implementation in C# (.NET 10) with a CLI application and reusable library.

## Projects

- **CaesarCipher.Lib** — Core cipher library
- **CaesarCipher.App** — CLI application
- **CaesarCipher.Tests** — NUnit test suite

## How it works

The `Caesar` class shifts each character in the input by a fixed rotation amount within a configurable alphabet. Characters not in the alphabet are passed through unchanged.

The default alphabet includes uppercase, lowercase, Norwegian characters (Æ, Ø, Å, æ, ø, å), and digits:

```
ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅabcdefghijklmnopqrstuvwxyzæøå0123456789
```

## Usage

```
CaesarCipher.App --file <path> [--decode] [--count <n>] [--silly]
```

| Option | Description | Default |
|--------|-------------|---------|
| `--file` | File to encode/decode | *(required)* |
| `--decode` | Decode instead of encode | false |
| `--count` | Rotation amount | 13 (ROT13) |
| `--silly` | Animated terminal output | false |

### Examples

```bash
# Encode a file with default rotation (13)
CaesarCipher.App --file caesar.txt

# Decode with rotation 3
CaesarCipher.App --file caesar_encoded.txt --decode --count 3

# Encode with animated output
CaesarCipher.App --file caesar.txt --silly
```

## Library

```csharp
var cipher = new Caesar(rotation: 13);

string encoded = cipher.Encode("Hello World");
string decoded = cipher.Decode(encoded);

// Custom alphabet
var custom = new Caesar(rotation: 3, alphabet: "abcdef");
```

## Building and testing

```bash
dotnet build
dotnet test
```

## Requirements

- .NET 10

---

All code was written by a human. The README was helpfully provided by Claude.
