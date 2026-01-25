namespace GameBoyEmu;

public class MemoryBus
{
    public byte A;
    public byte B;
    public byte C;
    public byte D;
    public byte E;
    public byte F; //Flags from 8th bit to 5th bit
    public byte H;
    public byte L;
    public ushort Sp; //Stack pointer
    public ushort Pc = 0x0100; //Program counter, position 100 is the place where the main program starts

    public ushort AF
    {
        get => (ushort)((A << 8) | F);
        set
        {
            A = (byte)(value >> 8);
            F = (byte)(value & 0xF0); //Lower 4 bits forced zero, lower bits are always 0
        }
    }

    public ushort BC
    {
        get => (ushort)((B << 8) | C);
        set
        {
            B = (byte)(value >> 8);
            C = (byte)(value & 0xFF);
        }
    }
    public ushort DE
    {
        get => (ushort)((D << 8) | E);
        set
        {
            D = (byte)(value >> 8);
            E = (byte)(value & 0xFF);
        }
    }
    
    public ushort HL
    {
        get => (ushort)((H << 8) | L);
        set
        {
            H = (byte)(value >> 8);
            L = (byte)(value & 0xFF);
        }
    }

    public bool Zbit
    {
        get => (F & 0x80) != 0;
        set 
        {
            if (value)
            {
                F |= 0x80; //1000 0000
            }
            else
            {
                F &= 0x7F; //0111 1111
            }
        }
    }

    public bool Nbit
    {
        get => (F & 0x70) != 0;
        set
        {
            if (value)
            {
                F |= 0x40; //0100 0000
            }
            else
            {
                F &= 0x5F; //1011 1111
            }
        }
    }

    public bool Hbit
    {
        get => (F & 0x60) != 0;
        set
        {
            if (value)
            {
                F |= 0x20; //0010 0000
            }
            else
            {
                F &= 0xDF; //1101 1111
            }
        }
    }

    public bool Cbit
    {
        get => (F & 0x50) != 0;
        set
        {
            if (value)
            {
                F |= 0x10; //0001 0000
            }
            else
            {
                F &= 0xEF; //1110 1111
            }
        }
    }

    
    private byte[] _memoryBuffer;

    public Cartridge Cartridge;
        
    public MemoryBus(string filepath)
    {
        _memoryBuffer = new byte[65535];
        Cartridge = new Cartridge(filepath);
    }

    public byte read_buffer(ushort address)
    {
        switch (address)
        {
            case <= 0x3FFF:
                return Cartridge.read_rom(address);
            case >= 0xFF00 and <= 0xFF7F:
                Console.WriteLine("Trying to read input");
                return 0;
        }
        return _memoryBuffer[address];
    }
    
    public void write_buffer(ushort address, byte value)
    {
        _memoryBuffer[address] = value;
    }

    public byte get_registry(char registry)
    {
        switch (registry)
        {
            case 'A':
                return A;
            case 'B':
                return B;
            case 'C':
                return C;
            case 'D':
                return D;
            case 'E':
                return E;
            case 'H':
                return H;
            case 'L':
                return L;
        }

        return 0;
    }
}