#ifndef NONO_UI_H
#define NONO_UI_H

#include <stdbool.h>
#include <stdio.h>
#include <math.h>

#ifdef __cplusplus
extern "C"
{
#endif

    // Color structure
    typedef struct
    {
        float r, g, b; // Red, Green, Blue (0.0 to 1.0)
    } nuColor;

    // Theme used by GUI elements
    typedef struct
    {
        nuColor primary;         // Main color for elements
        nuColor primaryAccent;   // Accent color for primary elements
        nuColor primaryMuted;    // Muted color for primary elements
        nuColor secondary;       // Secondary elements (e.g., backgrounds)
        nuColor secondaryAccent; // Accent color for secondary elements
        nuColor secondaryMuted;  // Muted color for secondary elements
        nuColor border;          // Border color
        nuColor borderAccent;    // Accent border color
        nuColor textPrimary;     // Primary text color
        nuColor textSecondary;   // Secondary text color
    } nuColorTheme;

    extern nuColorTheme nuTheme;

    // User must provide these functions for rendering
    void nuSetColor(nuColor color);                  // Set the current drawing color
    void nuDrawPixel(int x, int y);                  // Draw a single pixel
    void nuDrawText(const char *text, int x, int y); // Draw text at a location
    int nuTextWidth(const char *text);               // Get the width of the text
    int nuTextHeight();                              // Get the height of the text

    // Input handling functions (must be called by the user with the correct arguments)
    void nuMousePosition(int x, int y);
    void nuMousePressed(int button);
    void nuMouseReleased(int button);
    void nuMouseWheelDelta(int delta);
    void nuUpdate();

    // UI element functions
    bool nuButton(const char *label, int x, int y, int w, int h);
    void nuLabel(const char *text, int x, int y);
    float nuVSlider(int x, int y, int width, float min, float max, float step, float initial);
    float nuHSlider(int x, int y, int width, float min, float max, float step, float initial);
    int nuDropdown(const char *text, int x, int y, int w, int h, const char **options, int numOptions, int numMaxVisibleOptions);

#ifdef __cplusplus
}
#endif

#endif // NONO_UI_H

#ifdef NONOUI_IMPLEMENTATION

#include <string.h> // For strlen

nuColorTheme nuTheme = {
    .primary = {0.1f, 0.4f, 0.7f},       // Blue
    .primaryAccent = {0.2f, 0.5f, 0.8f}, // Light Blue
    .primaryMuted = {0.5f, 0.6f, 0.7f},  // Muted Blue

    .secondary = {0.12f, 0.12f, 0.12f},    // Dark Gray
    .secondaryAccent = {0.3f, 0.3f, 0.3f}, // Gray
    .secondaryMuted = {0.5f, 0.5f, 0.5f},  // Muted Gray

    .border = {0.1f, 0.1f, 0.1f},       // Medium Gray
    .borderAccent = {0.2f, 0.2f, 0.2f}, // Light Gray

    .textPrimary = {0.9f, 0.9f, 0.9f},   // Light Gray
    .textSecondary = {0.4f, 0.4f, 0.4f}, // Dark Gray
};

/********************************************************************
*********************************************************************
* STATES
*********************************************************************
*********************************************************************/

// CHECKBOX
#define _NU_MAX_CHECKBOX_STATES 64
typedef struct
{
    unsigned int id;
    bool isChecked;
} _nuCheckboxState;
static _nuCheckboxState _nuCheckboxStates[_NU_MAX_CHECKBOX_STATES];
static int _nuCheckboxStateCount = 0;

static _nuCheckboxState *_nuFindOrInitCheckbox(unsigned int id, bool checked)
{
    for (int i = 0; i < _nuCheckboxStateCount; i++)
    {
        if (_nuCheckboxStates[i].id == id)
        {
            return &_nuCheckboxStates[i];
        }
    }
    if (_nuCheckboxStateCount >= _NU_MAX_CHECKBOX_STATES)
    {
        printf("Error: Too many checkboxes! Increase _NU_MAX_CHECKBOX_STATES.\n");
        return NULL;
    }
    _nuCheckboxStates[_nuCheckboxStateCount] = (_nuCheckboxState){.id = id, .isChecked = checked};
    return &_nuCheckboxStates[_nuCheckboxStateCount++];
}

// SLIDER
#define _NU_MAX_SLIDER_STATES 64
typedef struct
{
    unsigned int id;
    float value;
} _nuSliderState;
static _nuSliderState _nuSliderStates[_NU_MAX_SLIDER_STATES];
static int _nuSliderStateCount = 0;

static _nuSliderState *_nuFindOrInitSlider(unsigned int id, float initial)
{
    for (int i = 0; i < _nuSliderStateCount; i++)
    {
        if (_nuSliderStates[i].id == id)
        {
            return &_nuSliderStates[i];
        }
    }
    if (_nuSliderStateCount >= _NU_MAX_SLIDER_STATES)
    {
        printf("Error: Too many sliders! Increase _NU_MAX_SLIDER_STATES.\n");
        return NULL;
    }
    _nuSliderStates[_nuSliderStateCount] = (_nuSliderState){.id = id, .value = initial};
    return &_nuSliderStates[_nuSliderStateCount++];
}

// DROPDOWN
#define _NU_MAX_DROPDOWN_STATES 64
typedef struct
{
    unsigned int id;
    int isOpen;
    int selectedIndex;
    int scrollOffset;
} _nuDropdownState;
static _nuDropdownState _nuDropdownStates[_NU_MAX_DROPDOWN_STATES];
static int _nuDropdownStateCount = 0;

static _nuDropdownState *_findOrInitDropdown(unsigned int id)
{
    for (int i = 0; i < _nuDropdownStateCount; i++)
    {
        if (_nuDropdownStates[i].id == id)
        {
            return &_nuDropdownStates[i];
        }
    }
    if (_nuDropdownStateCount >= _NU_MAX_DROPDOWN_STATES)
    {
        printf("Error: Too many Dropdowns! Increase _NU_MAX_Dropdown_STATES.\n");
        return NULL;
    }
    _nuDropdownStates[_nuDropdownStateCount] = (_nuDropdownState){.id = id, .isOpen = false, .selectedIndex = -1};
    return &_nuDropdownStates[_nuDropdownStateCount++];
}

#define TMP_BUFFER_SIZE 256
static char _tmpBuffer[TMP_BUFFER_SIZE];

// Generate a unique id based on two given integer values
unsigned int _genUID(int x, int y)
{
    unsigned int hash = 2166136261u; // FNV offset basis
    hash ^= (unsigned int)x;
    hash *= 16777619u;
    hash ^= (unsigned int)y;
    hash *= 16777619u;
    return hash;
}

// Checks if given string fits into the given width, if not it truncates the text and appends three dots (...)
static void _truncateText(const char *text, int width, char *result, int resultSize)
{
    if (!text || !result || resultSize == 0)
    {
        printf("ERROR <truncateText>: Invalid arguments.\n");
        return;
    }

    // Calculate the width of "..."
    int dotsWidth = nuTextWidth("...");
    if (dotsWidth > width)
    {
        // If "..." itself doesn't fit, set result to an empty string
        result[0] = '\0';
        return;
    }

    // Copy the input text to the result buffer
    strncpy(result, text, resultSize - 1);
    result[resultSize - 1] = '\0';

    // Check if the full text fits within the width
    int textWidth = nuTextWidth(result);
    if (textWidth <= width)
    {
        return; // No truncation needed
    }

    // Start truncating from the end until the text with "..." fits
    size_t length = strlen(result);
    while (length > 0)
    {
        result[length - 1] = '\0'; // Remove one character
        textWidth = nuTextWidth(result) + dotsWidth;
        if (textWidth <= width)
        {
            // Append "..." and ensure it fits
            strncat(result, "...", resultSize - strlen(result) - 1);
            return;
        }
        --length;
    }

    // If nothing fits, set result to "..."
    strncpy(result, "...", resultSize - 1);
    result[resultSize - 1] = '\0';
}

// Constants for input handling
#define MAX_KEYS 256
#define MAX_MOUSE_BUTTONS 3

// Internal input state
static int mouseX = 0, mouseY = 0;
static int mouseWheelDelta = 0;
static bool mouseButtonsPressed[MAX_MOUSE_BUTTONS] = {false};
static bool mouseButtonsHeld[MAX_MOUSE_BUTTONS] = {false};
static bool mouseButtonsReleased[MAX_MOUSE_BUTTONS] = {false};

// Clear pressed and released states (called once per frame)
static void _clearMouseStates()
{
    for (int i = 0; i < MAX_MOUSE_BUTTONS; ++i)
    {
        mouseButtonsPressed[i] = false;
        mouseButtonsReleased[i] = false;
    }
    mouseWheelDelta = 0;
}

void nuUpdate()
{
    _clearMouseStates();
}

// Input function implementations
void nuMousePosition(int x, int y)
{
    mouseX = x;
    mouseY = y;
}

void nuMouseWheelDelta(int direction)
{
    mouseWheelDelta = direction;
}

void nuMousePressed(int button)
{
    if (button < MAX_MOUSE_BUTTONS)
    {
        mouseButtonsPressed[button] = !mouseButtonsHeld[button];
        mouseButtonsHeld[button] = true;
    }
}

void nuMouseReleased(int button)
{
    if (button < MAX_MOUSE_BUTTONS)
    {
        mouseButtonsReleased[button] = true;
        mouseButtonsHeld[button] = false;
    }
}

// UI Element: Label
void nuLabel(const char *text, int x, int y)
{
    nuSetColor(nuTheme.textPrimary); // White text
    nuDrawText(text, x, y);
}

// UI Element: Button
bool nuButton(const char *label, int x, int y, int w, int h)
{
    // Check if the mouse is hovering over the button
    bool hover = (mouseX >= x && mouseX <= x + w &&
                  mouseY >= y && mouseY <= y + h);

    // Set button colors based on state
    if (hover && mouseButtonsHeld[0])
    {
        nuSetColor(nuTheme.secondary);
    }
    else if (hover)
    {
        nuSetColor(nuTheme.primaryAccent);
    }
    else
    {
        nuSetColor(nuTheme.primary);
    }

    // Draw button rectangle
    for (int i = 0; i < w; ++i)
    {
        for (int j = 0; j < h; ++j)
        {
            nuDrawPixel(x + i, y + j); // Background
        }
    }

    // Draw the border
    nuSetColor(nuTheme.border);
    for (int i = 0; i < w; ++i)
    {
        nuDrawPixel(x + i, y);         // Top border
        nuDrawPixel(x + i, y + h - 1); // Bottom border
    }
    for (int j = 0; j < h; ++j)
    {
        nuDrawPixel(x, y + j);         // Left border
        nuDrawPixel(x + w - 1, y + j); // Right border
    }

    // Get text dimensions
    int textWidth = nuTextWidth(label);
    int textHeight = nuTextHeight();

    // Calculate centered text position
    int textX = x + (w - textWidth) / 2;  // Center horizontally
    int textY = y + (h + textHeight) / 2; // Center vertically

    // Draw button label
    nuLabel(label, textX, textY);

    // Check for button click
    if (hover && mouseButtonsPressed[0])
    {
        return true; // Button clicked on this frame
    }

    return false; // Button not clicked
}

// Checkbox implementation
bool nuCheckbox(const char *text, int x, int y, bool checked)
{
    // Generate a unique ID based on position
    unsigned int id = _genUID(x, y);

    // Find or initialize slider state
    _nuCheckboxState *state = _nuFindOrInitCheckbox(id, checked);
    if (!state)
        return false;

    // Dimensions for the checkbox square
    int textHeight = nuTextHeight();
    int textWidth = nuTextWidth(text);
    int boxSize = textHeight + 8;
    int boxPadding = 2;
    int boxMargin = 6;
    int elementWidth = textWidth + boxSize + boxMargin;

    // Check if the mouse is hovering over the checkbox
    bool hover = (mouseX >= x && mouseX <= x + elementWidth &&
                  mouseY >= y && mouseY <= y + boxSize);

    // Check if the checkbox was clicked
    if (hover && mouseButtonsPressed[0])
    {
        state->isChecked = !state->isChecked; // Toggle state
    }

    // Set colors based on hover state
    if (hover)
    {
        nuSetColor(nuTheme.secondaryAccent);
    }
    else
    {
        nuSetColor(nuTheme.secondary);
    }

    // Draw the checkbox square
    for (int i = 0; i < boxSize; ++i)
    {
        for (int j = 0; j < boxSize; ++j)
        {
            nuDrawPixel(x + i, y + j);
        }
    }

    // Draw the filled box if checked
    if (state->isChecked)
    {
        if (hover)
        {
            nuSetColor(nuTheme.primaryAccent);
        }
        else
        {
            nuSetColor(nuTheme.primary);
        }
        for (int i = boxPadding; i < boxSize - boxPadding; ++i)
        {
            for (int j = boxPadding; j < boxSize - boxPadding; ++j)
            {
                nuDrawPixel(x + i, y + j);
            }
        }
    }

    // Draw the border
    nuSetColor(nuTheme.border);
    for (int i = 0; i < boxSize; ++i)
    {
        nuDrawPixel(x + i, y);               // Top border
        nuDrawPixel(x + i, y + boxSize - 1); // Bottom border
    }
    for (int j = 0; j < boxSize; ++j)
    {
        nuDrawPixel(x, y + j);               // Left border
        nuDrawPixel(x + boxSize - 1, y + j); // Right border
    }

    // Draw the label next to the checkbox
    nuLabel(text, x + boxSize + boxMargin, y + (boxSize + textHeight) / 2);

    return state->isChecked;
}

float nuHSlider(int x, int y, int width, float min, float max, float step, float initial)
{
    // Validate parameters
    if (min >= max)
    {
        printf("ERROR <nuHSlider>: min must be less than max.\n");
        return 0.0f;
    }

    if (step <= 0)
    {
        printf("ERROR <nuHSlider>: step must be greater than 0.\n");
        return 0.0f;
    }

    initial = fmaxf(min, fminf(max, initial));

    // Generate a unique ID based on position
    unsigned int id = _genUID(x, y);

    // Find or initialize slider state
    _nuSliderState *state = _nuFindOrInitSlider(id, initial);
    if (!state)
        return -1.0f;

    // Ensure the value is clamped between min and max
    state->value = fmaxf(min, fminf(max, state->value));

    // Slider dimensions
    int height = 16;

    // Check if the mouse is hovering over the slider
    bool hover = (mouseX >= x && mouseX <= x + width &&
                  mouseY >= y && mouseY <= y + height);

    bool dragging = hover && mouseButtonsHeld[0];

    // Handle dragging
    if (dragging)
    {
        float relativeX = mouseX - x;
        float proportion = fmaxf(0.0f, fminf(1.0f, relativeX / width));
        state->value = min + proportion * (max - min);
        state->value = roundf(state->value / step) * step; // Apply step resolution
    }

    // Calculate the knob position
    float proportion = (state->value - min) / (max - min);
    int knobX = x + (int)(proportion * width);

    // Draw the filled portion of the slider
    nuSetColor(hover ? nuTheme.primaryAccent : nuTheme.primary);
    for (int i = x; i < knobX; ++i)
    {
        for (int j = 0; j < height; ++j)
        {
            nuDrawPixel(i, y + j);
        }
    }

    // Draw the unfilled portion of the slider
    nuSetColor(hover ? nuTheme.secondaryAccent : nuTheme.secondary);
    for (int i = knobX; i < x + width; ++i)
    {
        for (int j = 0; j < height; ++j)
        {
            nuDrawPixel(i, y + j);
        }
    }

    // Draw the border
    nuSetColor(nuTheme.border);
    for (int i = 0; i < width; ++i)
    {
        nuDrawPixel(x + i, y);              // Top border
        nuDrawPixel(x + i, y + height - 1); // Bottom border
    }
    for (int j = 0; j < height; ++j)
    {
        nuDrawPixel(x, y + j);             // Left border
        nuDrawPixel(x + width - 1, y + j); // Right border
    }

    // Draw the knob
    nuSetColor(nuTheme.border);
    for (int i = -4; i <= 4; ++i)
    {
        for (int j = -2; j < height + 2; ++j)
        {
            nuDrawPixel(knobX + i, y + j);
        }
    }

    return state->value;
}

float nuVSlider(int x, int y, int height, float min, float max, float step, float initial)
{
    // Validate parameters
    if (min >= max)
    {
        printf("ERROR <nuVSlider>: min must be less than max.\n");
        return 0.0f;
    }

    if (step <= 0)
    {
        printf("ERROR <nuVSlider>: step must be greater than 0.\n");
        return 0.0f;
    }

    initial = fmaxf(min, fminf(max, initial));

    // Generate a unique ID based on position
    unsigned int id = _genUID(x, y);

    // Find or initialize slider state
    _nuSliderState *state = _nuFindOrInitSlider(id, initial);
    if (!state)
        return -1.0f;

    // Ensure the value is clamped between min and max
    state->value = fmaxf(min, fminf(max, state->value));

    // Slider dimensions
    int width = 16;

    // Check if the mouse is hovering over the slider
    bool hover = (mouseX >= x && mouseX <= x + width &&
                  mouseY >= y && mouseY <= y + height);

    bool dragging = hover && mouseButtonsHeld[0];

    // Handle dragging
    if (dragging)
    {
        float relativeY = mouseY - y;
        float proportion = fmaxf(0.0f, fminf(1.0f, 1.0f - (relativeY / height))); // Invert proportion
        state->value = min + proportion * (max - min);
        state->value = roundf(state->value / step) * step; // Apply step resolution
    }

    // Calculate the knob position
    float proportion = (state->value - min) / (max - min);
    int knobY = y + height - (int)(proportion * height);

    // Draw the filled portion of the slider
    nuSetColor(hover ? nuTheme.primaryAccent : nuTheme.primary);
    for (int i = 0; i < width; ++i)
    {
        for (int j = knobY; j < y + height; ++j)
        {
            nuDrawPixel(x + i, j);
        }
    }

    // Draw the unfilled portion of the slider
    nuSetColor(hover ? nuTheme.secondaryAccent : nuTheme.secondary);
    for (int i = 0; i < width; ++i)
    {
        for (int j = y; j < knobY; ++j)
        {
            nuDrawPixel(x + i, j);
        }
    }

    // Draw the border
    nuSetColor(nuTheme.border);
    for (int i = 0; i < width; ++i)
    {
        nuDrawPixel(x + i, y);              // Top border
        nuDrawPixel(x + i, y + height - 1); // Bottom border
    }
    for (int j = 0; j < height; ++j)
    {
        nuDrawPixel(x, y + j);             // Left border
        nuDrawPixel(x + width - 1, y + j); // Right border
    }

    // Draw the knob
    nuSetColor(nuTheme.border);
    for (int i = -2; i < width + 2; ++i)
    {
        for (int j = -4; j <= 4; ++j)
        {
            nuDrawPixel(x + i, knobY + j);
        }
    }

    return state->value;
}

int nuDropdown(const char *text, int x, int y, int w, int h, const char **options, int numOptions, int numMaxVisibleOptions)
{
    // Validate parameters
    if (numOptions <= 0 || !options)
    {
        printf("ERROR <nuDropdown>: Invalid options array or numOptions is zero.\n");
        return -1;
    }

    // Unique ID based on position
    unsigned int id = _genUID(x, y);

    _nuDropdownState *state = _findOrInitDropdown(id);

    // int textWidth = nuTextWidth(text);
    int textHeight = nuTextHeight();
    int triangleSize = textHeight / 2;
    int optionHeight = textHeight + 14;
    int padding = 12;
    int maxOptionsWidth = w - triangleSize - padding * 2;

    // Check if the mouse is hovering over the button
    bool hoverButton = (mouseX >= x && mouseX <= x + w &&
                        mouseY >= y && mouseY <= y + h);

    // Toggle dropdown open/close on button click
    if (hoverButton && mouseButtonsReleased[0])
    {
        state->isOpen = !state->isOpen;
    }

    // Draw dropdown button
    nuSetColor(state->isOpen ? nuTheme.primaryAccent : (hoverButton ? nuTheme.primaryAccent : nuTheme.primary));
    for (int i = 0; i < w; ++i)
    {
        for (int j = 0; j < h; ++j)
        {
            nuDrawPixel(x + i, y + j);
        }
    }

    // Draw the border
    nuSetColor(nuTheme.border);
    for (int i = 0; i < w; ++i)
    {
        nuDrawPixel(x + i, y);         // Top border
        nuDrawPixel(x + i, y + h - 1); // Bottom border
    }
    for (int j = 0; j < h; ++j)
    {
        nuDrawPixel(x, y + j);         // Left border
        nuDrawPixel(x + w - 1, y + j); // Right border
    }

    // Draw the button label
    int textX = x + padding;
    int textY = y + (h + textHeight) / 2;
    if (state->selectedIndex >= 0 && state->selectedIndex < numOptions)
    {
        const char *label = options[state->selectedIndex];
        if (nuTextWidth(label) > maxOptionsWidth - padding)
        {
            _truncateText(label, maxOptionsWidth - padding, _tmpBuffer, TMP_BUFFER_SIZE);
            nuLabel(_tmpBuffer, textX, textY);
        }
        else
        {
            nuLabel(label, textX, textY);
        }
    }
    else
    {
        if (nuTextWidth(text) > maxOptionsWidth - padding)
        {
            _truncateText(text, maxOptionsWidth - padding, _tmpBuffer, TMP_BUFFER_SIZE);
            nuLabel(_tmpBuffer, textX, textY);
        }
        else
        {
            nuLabel(text, textX, textY);
        }
    }

    // Draw the triangle indicator
    for (int i = 0; i < triangleSize; ++i)
    {
        for (int j = 0; j < triangleSize - i; ++j)
        {
            nuDrawPixel(x + w - triangleSize - padding + j, y + h / 2 - i);
            nuDrawPixel(x + w - triangleSize - padding + j, y + h / 2 + i);
        }
    }

    // If the dropdown is open, show the list of options
    if (state->isOpen)
    {
        int visibleListHeight = optionHeight * numMaxVisibleOptions;

        bool hoverList = mouseY >= y + h && mouseY <= y + h + h * numMaxVisibleOptions;

        // Ensure scrollOffset is valid
        if (state->scrollOffset > numOptions - numMaxVisibleOptions)
        {
            state->scrollOffset = numOptions - numMaxVisibleOptions;
        }
        if (state->scrollOffset < 0)
        {
            state->scrollOffset = 0;
        }

        // Handle scrolling
        if (hoverList)
        {
            if (mouseWheelDelta > 0)
            {
                state->scrollOffset = (state->scrollOffset > 0) ? state->scrollOffset - 1 : 0;
            }
            else if (mouseWheelDelta < 0)
            {
                state->scrollOffset = (state->scrollOffset < numOptions - numMaxVisibleOptions) ? state->scrollOffset + 1 : state->scrollOffset;
            }
        }

        // Draw the list background
        nuSetColor(nuTheme.secondary);
        for (int i = 0; i < w; ++i)
        {
            for (int j = 0; j < visibleListHeight; ++j)
            {
                nuDrawPixel(x + i, y + h + j);
            }
        }

        // Draw each visible option
        for (int i = state->scrollOffset; i < state->scrollOffset + numMaxVisibleOptions && i < numOptions; i++)
        {
            int optionY = y + h + (i - state->scrollOffset) * optionHeight;

            // Check if the mouse is hovering over the option
            bool hoverOption = (mouseX >= x && mouseX <= x + w &&
                                mouseY >= optionY && mouseY <= optionY + optionHeight);

            // Set background color for hovered option
            nuSetColor(hoverOption ? nuTheme.secondaryAccent : nuTheme.secondary);
            for (int j = 0; j < w; ++j)
            {
                for (int k = 0; k < optionHeight; ++k)
                {
                    nuDrawPixel(x + j, optionY + k);
                }
            }

            // Draw the option text
            int textX = x + padding;
            int textY = optionY + (optionHeight + textHeight) / 2;
            if (nuTextWidth(options[i]) > maxOptionsWidth)
            {
                _truncateText(options[i], w - padding * 2, _tmpBuffer, TMP_BUFFER_SIZE);
                nuLabel(_tmpBuffer, textX, textY);
            }
            else
            {
                nuLabel(options[i], textX, textY);
            }

            // Handle option click
            if (hoverOption && mouseButtonsReleased[0])
            {
                state->selectedIndex = i;
                state->isOpen = false;
            }
        }

        // Handle outside click
        if (!hoverButton && mouseButtonsReleased[0])
        {
            state->isOpen = false;
        }

        // Draw scrollbar if needed
        if (numOptions > numMaxVisibleOptions)
        {
            float scrollbarHeight = (float)numMaxVisibleOptions / numOptions * visibleListHeight;
            float scrollbarY = (float)state->scrollOffset / numOptions * visibleListHeight;
            nuSetColor(nuTheme.primaryAccent);
            for (int i = w - 4; i < w; ++i) // 4-pixel wide scrollbar
            {
                for (int j = scrollbarY; j < scrollbarY + scrollbarHeight; ++j)
                {
                    nuDrawPixel(x + i, y + h + j);
                }
            }
        }
    }

    return state->selectedIndex;
}

#endif // NONOUI_IMPLEMENTATION
