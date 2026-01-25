namespace GameBoyEmu;

public class Instruction
{
    public delegate int InstructionHandler(MemoryBus bus);

    private InstructionHandler[] mainOptcodes = new InstructionHandler[256];
    private InstructionHandler[] cbOpcodes = new InstructionHandler[256];

    public Instruction()
    {
        InitOptcodes();
    }
    
    public void InitOptcodes()
    {
        mainOptcodes[0x00] = NOP; 
        mainOptcodes[0x01] = NotInplemented;
        mainOptcodes[0x02] = NotInplemented;
        mainOptcodes[0x03] = NotInplemented;
        mainOptcodes[0x04] = NotInplemented;
        mainOptcodes[0x05] = NotInplemented;
        mainOptcodes[0x06] = NotInplemented;
        mainOptcodes[0x07] = NotInplemented;
        mainOptcodes[0x08] = NotInplemented;
        mainOptcodes[0x09] = NotInplemented;
        mainOptcodes[0x10] = STOP; 
        mainOptcodes[0x11] = NotInplemented;
        mainOptcodes[0x12] = NotInplemented;
        mainOptcodes[0x13] = NotInplemented;
        mainOptcodes[0x14] = NotInplemented;
        mainOptcodes[0x15] = NotInplemented;
        mainOptcodes[0x16] = NotInplemented;
        mainOptcodes[0x17] = NotInplemented;
        mainOptcodes[0x18] = NotInplemented;
        mainOptcodes[0x19] = NotInplemented;
        mainOptcodes[0x20] = JR_NZ_s8;
        mainOptcodes[0x21] = NotInplemented;
        mainOptcodes[0x22] = NotInplemented;
        mainOptcodes[0x23] = NotInplemented;
        mainOptcodes[0x24] = NotInplemented;
        mainOptcodes[0x25] = NotInplemented;
        mainOptcodes[0x26] = NotInplemented;
        mainOptcodes[0x27] = NotInplemented;
        mainOptcodes[0x28] = NotInplemented;
        mainOptcodes[0x29] = NotInplemented;
        mainOptcodes[0x30] = JR_NC_s8;
        mainOptcodes[0x31] = NotInplemented;
        mainOptcodes[0x32] = NotInplemented;
        mainOptcodes[0x33] = NotInplemented;
        mainOptcodes[0x34] = NotInplemented;
        mainOptcodes[0x35] = NotInplemented;
        mainOptcodes[0x36] = NotInplemented;
        mainOptcodes[0x37] = NotInplemented;
        mainOptcodes[0x38] = NotInplemented;
        mainOptcodes[0x39] = NotInplemented;
        mainOptcodes[0x40] = NOP; //LD B, B
        mainOptcodes[0x41] = NotInplemented;
        mainOptcodes[0x42] = NotInplemented;
        mainOptcodes[0x43] = NotInplemented;
        mainOptcodes[0x44] = NotInplemented;
        mainOptcodes[0x45] = NotInplemented;
        mainOptcodes[0x46] = NotInplemented;
        mainOptcodes[0x47] = NotInplemented;
        mainOptcodes[0x48] = NotInplemented;
        mainOptcodes[0x49] = NotInplemented;
        mainOptcodes[0x50] = LD_D_B;
        mainOptcodes[0x51] = NotInplemented;
        mainOptcodes[0x52] = NotInplemented;
        mainOptcodes[0x53] = NotInplemented;
        mainOptcodes[0x54] = NotInplemented;
        mainOptcodes[0x55] = NotInplemented;
        mainOptcodes[0x56] = NotInplemented;
        mainOptcodes[0x57] = NotInplemented;
        mainOptcodes[0x58] = NotInplemented;
        mainOptcodes[0x59] = NotInplemented;
        mainOptcodes[0x60] = LD_H_B;
        mainOptcodes[0x70] = LD_HL_B;
        mainOptcodes[0x80] = ADD_A_B;
        mainOptcodes[0x90] = SUB_B;
        mainOptcodes[0xA0] = AND_B;
        mainOptcodes[0xB0] = OR_B;
        mainOptcodes[0xC0] = NotInplemented;
        mainOptcodes[0xC1] = NotInplemented;
        mainOptcodes[0xC2] = NotInplemented;
        mainOptcodes[0xC3] = NotInplemented;
        mainOptcodes[0xC4] = NotInplemented;
        mainOptcodes[0xC5] = NotInplemented;
        mainOptcodes[0xC6] = NotInplemented;
        mainOptcodes[0xC7] = NotInplemented;
        mainOptcodes[0xC8] = NotInplemented;
        mainOptcodes[0xC9] = NotInplemented;
        mainOptcodes[0xD0] = NotInplemented;
        mainOptcodes[0xE0] = NotInplemented;
        mainOptcodes[0xF0] = NotInplemented;
        
    }
    public int execute_from_byte(byte optcode,ref MemoryBus memoryBus)
    {
        Console.WriteLine("----- Values -----");
        Console.WriteLine($"PC: {memoryBus.Pc}");
        Console.WriteLine($"\nExecuting instruction {optcode:X2}");
        int amountOfCycles = mainOptcodes[optcode](memoryBus);
        
        Console.WriteLine($"Cycles: {amountOfCycles}");
        
        return amountOfCycles;
        
        /*
        switch (optcode)
        {
            case 0x00:
                (instructionCycles, programCounter, replacePC) = NOP();
                break;
            case 0x10:
                (instructionCycles, programCounter, replacePC) = STOP();
                break;
            case 0x20:
                (instructionCycles, programCounter, replacePC) = JR_NZ_s8(memoryBus.Zbit, memoryBus.read_buffer((ushort)(memoryBus.Pc + 1)));
                break;
            case 0x30:
                (instructionCycles, programCounter, replacePC) = JR_NC_s8(memoryBus.Cbit, memoryBus.read_buffer((ushort)(memoryBus.Pc + 1)));
                break;
            case 0x40: //LD B, B
                (instructionCycles, programCounter, replacePC) = NOP();
                break;
            case 0x50: //LD B, D
                (instructionCycles, programCounter, replacePC) = LD('B', 'D', ref memoryBus);
                break;
            case 0x60:
                (instructionCycles, programCounter, replacePC) = LD('B', 'H', ref memoryBus);
                break;
            case 0x70:
                (instructionCycles, programCounter, replacePC) = LD_HL('B', ref memoryBus);
                break;
            case 0x80:
                (instructionCycles, programCounter, replacePC) = ADD_A('B', ref memoryBus);
                break;
            case 0x90:
                (instructionCycles, programCounter, replacePC) = SUB_A('B', ref memoryBus);
                break;
            case 0xA0:
                (instructionCycles, programCounter, replacePC) = AND_A('B', ref memoryBus);
                break;
            case 0xB0:
                (instructionCycles, programCounter, replacePC) = OR_A('B', ref memoryBus);
                break;
            case 0xC0:
                Console.WriteLine("Not implemented");
                break;
            default :
                Console.WriteLine($"Not implemented: {value:X2}");
                break;
        }*/
        
    }

    private int NotInplemented(MemoryBus memoryBus)
    {
        Console.WriteLine($"{memoryBus.Pc:X2}: Not Implemented");
        return 0;
    }
    
    private int NOP(MemoryBus memoryBus)
    {
        return 1;
    }

    private int STOP(MemoryBus memoryBus)
    {
        return 1;
    }

    private int JR_NZ_s8(MemoryBus memoryBus)
    {
        if (!memoryBus.Zbit)
        {
            memoryBus.Pc += memoryBus.read_buffer((ushort)(memoryBus.Pc + 1));
            return 3;
        }

        memoryBus.Pc += 1;
        return 2;
    }
    
    private int JR_NC_s8(MemoryBus memoryBus)
    {
        if (!memoryBus.Cbit)
        {
            memoryBus.Pc += memoryBus.read_buffer((ushort)(memoryBus.Pc + 1));
            return 3;
        }

        memoryBus.Pc += 1;
        return 2;
    }

    private int LD_D_B(MemoryBus memoryBus)
    {
        memoryBus.D = memoryBus.B;
        
        return 1;
    }

    private int LD_H_B(MemoryBus memoryBus)
    {
        memoryBus.H = memoryBus.B;
        
        return 1;
    }

    private int LD_HL_B(MemoryBus memoryBus)
    {
        memoryBus.write_buffer(memoryBus.HL, memoryBus.B);
        return 2;
    }

    private int ADD_A_B(MemoryBus memoryBus)
    {
        byte value = memoryBus.B;
        
        int result = value + memoryBus.A;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF)) > 0xF; //Check if A + value_in is bigger than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 1;
    }

    private int SUB_B(MemoryBus memoryBus)
    {
        byte value = memoryBus.B;
        
        int result = memoryBus.A - value;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = true; 
        memoryBus.Hbit = ((memoryBus.A & 0xF) < (value & 0xF)); //Check if A + value_in is bigger than 16
        memoryBus.Cbit = memoryBus.A < value; //Bigger than 255
        
        memoryBus.A = (byte)result;

        return 1;
    }

    private int AND_B(MemoryBus memoryBus)
    {
        byte value = memoryBus.B;

        byte result = (byte)(value & memoryBus.A);

        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = true;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }
    
    private int OR_B(MemoryBus memoryBus)
    {
        byte value = memoryBus.B;

        byte result = (byte)(value | memoryBus.A);

        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = false;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }
}