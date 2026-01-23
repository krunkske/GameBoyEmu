using Raylib_cs;

namespace GameBoyEmu;

public class framebuffer
{
    private int width = 0;
    private int height = 0;
    
    Color[] buffer;
    Texture2D texture;
    
    public framebuffer(int width, int height)
    {
        this.width = width;
        this.height = height;
        this.buffer = new Color[width * height];

        Image image = Raylib.GenImageColor(this.width, this.height, Color.Black);
        this.texture = Raylib.LoadTextureFromImage(image);
    }

    public Texture2D MakeFrame()
    {
        Raylib.UpdateTexture(this.texture, this.buffer);
        return this.texture;
    }
}