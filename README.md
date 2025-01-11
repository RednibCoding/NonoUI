# NonoUI

Tiny single header, renderer agnostic ui library written in c

# Elements

```c
bool nuButton(const char *label, int x, int y, int w, int h);
void nuLabel(const char *text, int x, int y);
float nuVSlider(int x, int y, int h, float min, float max, float step, float initial);
float nuHSlider(int x, int y, int w, float min, float max, float step, float initial);
int nuDropdown(const char *text, int x, int y, int w, int h, const char **options, int numOptions, int numMaxVisibleOptions);
```
