# PaletteSwapper

## A basic command-line program for swapping image palettes.

PaletteSwapper is a basic utility program for processing images from one palette to another.

Currently, only supports the `.png` format.

### Usage

```
palswp <source> <palette table> [source palette] <target palette> <destination>
```

- `<source>`: the file path to the source image.
- `<palette table>`: the file path to the palette table file.
- `[source palette]`: the palette index of the source image. Defaults to `0`.
- `<target palette>`: the palette index of the destination image.
- `<destination>`: the file path of the output image. If the file already exists, it will be overwritten.