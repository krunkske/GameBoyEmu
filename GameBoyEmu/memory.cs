namespace GameBoyEmu;

public class memory
{
    public byte A;
    public byte B;
    public byte C;
    public byte D;
    public byte E;
    public byte F;
    public byte H;
    public byte L;
    public ushort SP;
    public ushort PC;
    
    public byte[] memory_buffer;
    public memory()
    {
        memory_buffer = new byte[65535];
    }
}