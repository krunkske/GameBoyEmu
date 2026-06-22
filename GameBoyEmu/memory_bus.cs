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
                Console.WriteLine($"Reading cartridge Bank-00: {address}");
                return Cartridge.read_rom(address);
            case >= 0x4000 and <= 0x7FFF:
                Console.WriteLine($"Reading cartridge Bank-01-NN. NOT IMPLEMENTED: {address}");
                return Cartridge.read_rom(address);
            case >= 0x8000 and <= 0x9FFF:
                Console.WriteLine($"Reading VRAM: {address}");
                return _memoryBuffer[address];
            case >= 0xA000 and <= 0xBFFF:
                Console.WriteLine($"Reading External RAM bank. NOT IMPLEMENTED: {address}");
                return _memoryBuffer[address];
            case >= 0xC000 and <= 0xCFFF:
                Console.WriteLine($"Reading work RAM: {address}");
                return _memoryBuffer[address];
            case >= 0xD000 and <= 0xDFFF:
                Console.WriteLine($"Reading work RAM for GBC: {address}");
                return _memoryBuffer[address];
            case >= 0xE000 and <= 0xFDFF:
                Console.WriteLine($"Reading mirror of part of work RAM. Use is prohibited: {address}");
                return _memoryBuffer[address];
            case >= 0xFE00 and <= 0xFE9F:
                Console.WriteLine($"Reading Object attribute memory: {address}");
                return _memoryBuffer[address];
            case >= 0xFEA0 and <= 0xFEFF:
                Console.WriteLine($"Reading unusable memory! Use is prohibited: {address}");
                return _memoryBuffer[address];
            case >= 0xFF00 and <= 0xFF7F:
                Console.WriteLine($"Reading input. NOT IMPLEMENTED: {address}");
                return 0;
            case >= 0xFF80 and <= 0xFFFE:
                Console.WriteLine($"Reading High RAM. NOT IMPLEMENTED I think: {address}");
                return _memoryBuffer[address];
            case 0xFFFF:
                Console.WriteLine($"Reading Interrupt Enable register: {address}");
                return _memoryBuffer[address];
            default:
                Console.WriteLine($"This part can never be reached: {address}");
                return _memoryBuffer[address];
            
        }
    }
    
    public void write_buffer(ushort address, byte value)
    {
        switch (address)
        {
            case <= 0x3FFF:
                Console.WriteLine($"Writing to cartridge Bank-00. Is impossible: {address}, {value}");
                break;
            case >= 0x4000 and <= 0x7FFF:
                Console.WriteLine($"Writing to cartridge Bank-01-NN. Is impossible: {address}, {value}");
                break;
            case >= 0x8000 and <= 0x9FFF:
                Console.WriteLine("Writing to VRAM");
                _memoryBuffer[address] = value;
                break;
            case >= 0xA000 and <= 0xBFFF:
                Console.WriteLine($"Writing to External RAM bank. NOT IMPLEMENTED: {address}, {value}");
                _memoryBuffer[address] = value;
                break;
            case >= 0xC000 and <= 0xCFFF:
                Console.WriteLine($"Writing to work RAM: {address}, {value}");
                _memoryBuffer[address] = value;
                break;
            case >= 0xD000 and <= 0xDFFF:
                Console.WriteLine($"Writing to work RAM for GBC: {address}, {value}");
                _memoryBuffer[address] = value;
                break;
            case >= 0xE000 and <= 0xFDFF:
                Console.WriteLine($"Writing to mirror part of work RAM. Use is prohibited: {address}, {value}");
                _memoryBuffer[address] = value;
                break;
            case >= 0xFE00 and <= 0xFE9F:
                Console.WriteLine($"Writing to Object attribute memory: {address}, {value}");
                _memoryBuffer[address] = value;
                break;
            case >= 0xFEA0 and <= 0xFEFF:
                Console.WriteLine($"Writing to unusable memory! Use is prohibited: {address}, {value}");
                _memoryBuffer[address] = value;
                break;
            case >= 0xFF00 and <= 0xFF7F:
                Console.WriteLine($"Writing to input. NOT IMPLEMENTED: {address}, {value}");
                break;
            case >= 0xFF80 and <= 0xFFFE:
                Console.WriteLine($"writing to High RAM. NOT IMPLEMENTED I think: {address}, {value}");
                _memoryBuffer[address] = value;
                break;
            case 0xFFFF:
                Console.WriteLine($"Writing to Interrupt Enable register. INTERRUPTS NOT IMPLEMENTED: {address}, {value}");
                _memoryBuffer[address] = value;
                break;
            default:
                Console.WriteLine($"This part can never be reached: {address}, {value}");
                break;
            
        }
    }

    public ushort read_buffer_u16(ushort address)
    {
        byte lower = read_buffer(address);
        byte upper = read_buffer((ushort)(address + 1));
        return (ushort)(upper | lower << 8);
    }

    public void write_buffer_u16(ushort address, ushort value)
    {
        byte lower = (byte)(value & 0xFF);
        byte upper = (byte)((value >> 8) & 0xFF);
        
        write_buffer(address, lower);
        write_buffer(address, upper);
    }
}