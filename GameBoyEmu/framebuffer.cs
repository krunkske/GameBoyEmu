using Raylib_cs;

namespace GameBoyEmu;

public class Framebuffer
{
    private int _width = 0;
    private int _height = 0;
    
    Color[] _buffer;
    Texture2D _texture;
    
    public Framebuffer(int width, int height)
    {
        this._width = width;
        this._height = height;
        this._buffer = new Color[width * height];

        Image image = Raylib.GenImageColor(this._width, this._height, Color.Black);
        this._texture = Raylib.LoadTextureFromImage(image);
    }

    public Texture2D MakeFrame()
    {
        Raylib.UpdateTexture(this._texture, this._buffer);
        return this._texture;
    }
}