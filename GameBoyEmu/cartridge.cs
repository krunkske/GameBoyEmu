namespace GameBoyEmu;

public class Cartridge
{
    private byte[] _rom;

    public Cartridge(string filepath)
    {
        _rom = File.ReadAllBytes(filepath);
    }

    public byte read_rom(ushort address)
    {
        return  _rom[address];
    }
    
}