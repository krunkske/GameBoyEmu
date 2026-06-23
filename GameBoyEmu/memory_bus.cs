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
    
    /// <summary>
    /// Zero flag (bit 7)
    /// 
    /// This bit is set if and only if the result of an operation is zero. Used by conditional jumps.
    /// </summary>
    public bool Zbit 
    {
        get => (F & 0x80) == 0x80;
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
    
    /// <summary>
    /// Subtraction flag (BCD) (bit 6)
    ///
    /// Indicates whether the previous instruction has been a subtraction
    /// </summary>
    public bool Nbit
    {
        get => (F & 0x40) == 0x40;
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
    
    /// <summary>
    /// Half Carry flag (BCD) (bit 5)
    /// 
    /// Indicates carry for the lower 4 bits of the result
    /// </summary>
    public bool Hbit
    {
        get => (F & 0x20) == 0x20;
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
    
    /// <summary>
    /// Carry flag (bit 4)
    ///
    /// Is set in these cases:
    ///     When the result of an 8-bit addition is higher than $FF.
    ///     When the result of a 16-bit addition is higher than $FFFF.
    ///     When the result of a subtraction or comparison is lower than zero.
    ///     When a rotate/shift operation shifts out a “1” bit.
    ///
    ///Used by conditional jumps and instructions such as ADC, SBC, RL, RLA, etc.
    /// </summary>
    public bool Cbit
    {
        get => (F & 0x10) == 0x10;
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
        
        // Following the original DMG GameBoy model (Not DMG0)
        A = 0x01;
        B = 0x00;
        C = 0x13;
        D = 0x00;
        E = 0xD8;
        H = 0x01;
        L = 0x4D;
        F = 0xB0;
        Sp = 0xFFFE;

    }
    
    public string get_all_registers_formatted()
    {
        string text = "";
        string flagText = "";
        flagText += (Zbit) ? "Z" : "-";
        flagText += (Nbit) ? "N" : "-";
        flagText += (Hbit) ? "H" : "-";
        flagText += (Cbit) ? "C" : "-";

        text += $"A: {A:X2}  F: {F:X2}  (AF: {AF:X4})\n";
        text += $"B: {B:X2}  C: {C:X2}  (BC: {BC:X4})\n";
        text += $"D: {D:X2}  E: {E:X2}  (DE: {DE:X4})\n";
        text += $"H: {H:X2}  L: {L:X2}  (HL: {HL:X4})\n";
        text += $"PC: {Pc:X}  SP: {Sp:X}\n";
        
        text += $"F: [{flagText}] ({F:B})";
        
        return text;
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