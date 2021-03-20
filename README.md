# PaletteSwapper

## A basic command-line program for swapping image palettes

PaletteSwapper is a basic utility program for processing images from one palette to another.

Currently, only supports the `.png` format.

### Usage

```text
palswp <source> <palette table> [source palette] <target palette> <destination>
```

- `<source>`: the file path to the source image.
- `<palette table>`: the file path to the palette table file.
- `[source palette]`: the palette index of the source image. Defaults to `0`.
- `<target palette>`: the palette index of the destination image.
- `<destination>`: the file path of the output image. If the file already exists, it will be overwritten.

### Motivation

This project was made purely for practicing colour processing, C#, code cleaness, file reading/writing and project management skills. It maybe transformed into a simple library and bundled as a ContentProcessor for MonoGame/FNA later on.
ImageSharp is purely used for loading/saving image data from files. Might be replaced with custom loaders.
