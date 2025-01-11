#define FREEGLUT_STATIC
#include "deps/include/GL/freeglut.h"
#define NONOUI_IMPLEMENTATION
#include "../nui.h"

#include <stdio.h>

// Screen dimensions
int screenWidth = 800;
int screenHeight = 600;

// Set the current drawing color
void nuSetColor(nuColor color)
{
    glColor3f(color.r, color.g, color.b);
}

// Draw a pixel
void nuDrawPixel(int x, int y)
{
    glBegin(GL_POINTS);
    glVertex2i(x, screenHeight - y); // Invert y-axis for FreeGLUT
    glEnd();
}

// Draw text
void nuDrawText(const char *text, int x, int y)
{
    glRasterPos2i(x, screenHeight - y); // Invert y-axis for FreeGLUT
    while (*text)
    {
        glutBitmapCharacter(GLUT_BITMAP_HELVETICA_12, *text++);
    }
}

int nuTextWidth(const char *text)
{
    int width = 0;
    for (const char *c = text; *c != '\0'; ++c)
    {
        width += glutBitmapWidth(GLUT_BITMAP_HELVETICA_12, *c);
    }
    return width;
}

int nuTextHeight()
{
    return 8;
}

// FreeGLUT mouse delta callback
void mouseWheelDeltaCallback(int wheel, int direction, int x, int y)
{
    nuMouseWheelDelta(direction); // positive number for up, negative number for down
}

// FreeGLUT mouse callback
void mouseCallback(int button, int state, int x, int y)
{
    nuMousePosition(x, y);
    if (state == GLUT_DOWN)
    {
        nuMousePressed(button);
    }
    else if (state == GLUT_UP)
    {
        nuMouseReleased(button);
    }
}

// FreeGLUT passive motion callback
void passiveMotionCallback(int x, int y)
{
    nuMousePosition(x, y);
}

// FreeGLUT display callback
void display()
{
    glClear(GL_COLOR_BUFFER_BIT);

    nuButton("Click Me", 100, 50, 100, 25);

    nuCheckbox("Option 1", 50, 90, true);
    nuCheckbox("Option 2", 50, 115, false);

    nuHSlider(50, 150, 200, 0.0f, 1.0f, 0.1f, 0.5f);
    nuVSlider(20, 50, 200, 0.0f, 1.0f, 0.1f, 0.5f);

    const char *options[] = {
        "View Account Details",
        "Edit Account Settings",
        "Generate Report",
        "Export Data",
        "Import Data",
        "Manage Users",
        "System Preferences",
        "Network Settings",
        "Security Settings",
        "Backup and Restore",
        "Performance Metrics",
        "Data Analytics",
        "Error Logs",
        "User Activity Log",
        "Notifications and Alerts",
        "Language Preferences",
        "Help and Support",
        "About This Software",
        "Exit Application",
        "Restart System"};

    nuDropdown("Select Option", 260, 50, 150, 25, options, 20, 8);

    glutSwapBuffers();

    // Update NonoUI state once per frame
    nuUpdate();
}

// FreeGLUT reshape callback
void reshape(int w, int h)
{
    screenWidth = w;
    screenHeight = h;
    glViewport(0, 0, w, h);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluOrtho2D(0, w, 0, h);
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
}

// Main function
int main(int argc, char **argv)
{
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
    glutInitWindowSize(screenWidth, screenHeight);
    glutCreateWindow("NonoUI Example");

    glutDisplayFunc(display);
    glutReshapeFunc(reshape);
    glutMouseFunc(mouseCallback);
    glutMotionFunc(passiveMotionCallback);
    glutPassiveMotionFunc(passiveMotionCallback);
    glutMouseWheelFunc(mouseWheelDeltaCallback);
    glutIdleFunc(glutPostRedisplay);

    glClearColor(0.2f, 0.2f, 0.2f, 1.0f);
    glutMainLoop();

    return 0;
}
