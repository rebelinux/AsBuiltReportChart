- [x] Add chart border option
    - [x] Border color
    - [x]  Border width
    - [x]  Border line style (solid, dashed etc)

- [x]  Add legend
    - [x]  Legend position (Top, Down, Edge)
    - [x] legend orientation (Vertical, Horizontal)
    - [x] legend font properties
    - [x] legend box line properties (No Line)

- [x] Add Color palette
    - [x] ScottPlot.Palette
    - [x] Custom Color palette

- [ ] Add per image format save support

```c#
string[] customColors = { "#ddf6ed", "#c3e2d7", "#aacec2", "#90bbad", "#77a898" , "#5e9584", "#458370", "#2a715d", "#005f4b"};
plt.Palette = new ScottPlot.Drawing.Palette(customColors);

for (int i = 0; i < 5; i++)
{
    double[] xs = DataGen.Consecutive(100);
    double[] ys = DataGen.Sin(100, phase: -i * .5 / 5);
    plt.AddScatterLines(xs, ys, lineWidth: 3);
}
```
