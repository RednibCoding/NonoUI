def generate_c_code(replacement):
    # Prepare the replacement variations
    upper_replacement = replacement.upper()
    title_replacement = replacement.capitalize()

    # Define the template C code
    c_template = """
    // {upper}
    #define _NU_MAX_{upper}_STATES 64
    typedef struct
    {{
        unsigned int id;
        /* Add more fields here */
    }} _nu{title}State;
    static _nu{title}State _nu{title}States[_NU_MAX_{upper}_STATES];
    static int _nu{title}StateCount = 0;

    static _nu{title}State *_nuFindOrInit{title}(unsigned int id /*Add more params here*/)
    {{
        for (int i = 0; i < _nu{title}StateCount; i++)
        {{
            if (_nu{title}States[i].id == id)
            {{
                return &_nu{title}States[i];
            }}
        }}
        if (_nu{title}StateCount >= _NU_MAX_{upper}_STATES)
        {{
            printf("Error: Too many {title}s! Increase _NU_MAX_{upper}_STATES.\\n");
            return NULL;
        }}
        _nu{title}States[_nu{title}StateCount] = (_nu{title}State){{.id = id /*Add more arguments here*/}};
        return &_nu{title}States[_nu{title}StateCount++];
    }}

    ---------------------------------------------------------------------------------------------------------

    // Generate a unique ID based on position
    unsigned int id = _nuGenUID(x, y);

    // Find or initialize slider state
    _nu{title}State *state = _nuFindOrInit{title}(id /*Add more arguments here*/);
    if (!state)
        return NULL;
    """

    # Replace placeholders in the template
    generated_code = c_template.format(upper=upper_replacement, title=title_replacement)

    return generated_code

# Example usage
replacement_name = "Dropdown"
output_code = generate_c_code(replacement_name)

# Print the output
print("C code generated successfully:")
print(output_code)
