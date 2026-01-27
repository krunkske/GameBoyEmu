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
        //0x
        mainOptcodes[0x00] = NOP;
        mainOptcodes[0x01] = LD_BC_d16;
        mainOptcodes[0x02] = LD_BC_A;
        mainOptcodes[0x03] = INC_BC;
        mainOptcodes[0x04] = INC_B;
        mainOptcodes[0x05] = DEC_B;
        mainOptcodes[0x06] = LD_B_d8;
        mainOptcodes[0x07] = RLCA;
        mainOptcodes[0x08] = NotInplemented;
        mainOptcodes[0x09] = NotInplemented;
        mainOptcodes[0x0A] = NotInplemented;
        mainOptcodes[0x0B] = NotInplemented;
        mainOptcodes[0x0C] = NotInplemented;
        mainOptcodes[0x0D] = NotInplemented;
        mainOptcodes[0x0E] = NotInplemented;
        mainOptcodes[0x0F] = NotInplemented;
        //1x
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
        mainOptcodes[0x1A] = NotInplemented;
        mainOptcodes[0x1B] = NotInplemented;
        mainOptcodes[0x1C] = NotInplemented;
        mainOptcodes[0x1D] = NotInplemented;
        mainOptcodes[0x1E] = NotInplemented;
        mainOptcodes[0x1F] = NotInplemented;
        //2x
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
        mainOptcodes[0x2A] = NotInplemented;
        mainOptcodes[0x2B] = NotInplemented;
        mainOptcodes[0x2C] = NotInplemented;
        mainOptcodes[0x2D] = NotInplemented;
        mainOptcodes[0x2E] = NotInplemented;
        mainOptcodes[0x2F] = NotInplemented;
        //3x
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
        mainOptcodes[0x3A] = NotInplemented;
        mainOptcodes[0x3B] = NotInplemented;
        mainOptcodes[0x3C] = NotInplemented;
        mainOptcodes[0x3D] = NotInplemented;
        mainOptcodes[0x3E] = NotInplemented;
        mainOptcodes[0x3F] = NotInplemented;
        //4x
        mainOptcodes[0x40] = NOP;
        mainOptcodes[0x41] = LD_B_C;
        mainOptcodes[0x42] = LD_B_D;
        mainOptcodes[0x43] = LD_B_E;
        mainOptcodes[0x44] = LD_B_H;
        mainOptcodes[0x45] = LD_B_L;
        mainOptcodes[0x46] = LD_B_HL;
        mainOptcodes[0x47] = LD_B_A;
        mainOptcodes[0x48] = LD_C_B;
        mainOptcodes[0x49] = NOP;
        mainOptcodes[0x4A] = LD_C_D;
        mainOptcodes[0x4B] = LD_C_E;
        mainOptcodes[0x4C] = LD_C_H;
        mainOptcodes[0x4D] = LD_C_L;
        mainOptcodes[0x4E] = LD_C_HL;
        mainOptcodes[0x4F] = LD_C_A;
        //5x
        mainOptcodes[0x50] = LD_D_B;
        mainOptcodes[0x51] = LD_D_C;
        mainOptcodes[0x52] = NOP;
        mainOptcodes[0x53] = LD_D_E;
        mainOptcodes[0x54] = LD_D_H;
        mainOptcodes[0x55] = LD_D_L;
        mainOptcodes[0x56] = LD_D_HL;
        mainOptcodes[0x57] = LD_D_A;
        mainOptcodes[0x58] = LD_E_B;
        mainOptcodes[0x59] = LD_E_C;
        mainOptcodes[0x5A] = LD_E_D;
        mainOptcodes[0x5B] = NOP;
        mainOptcodes[0x5C] = LD_E_H;
        mainOptcodes[0x5D] = LD_E_L;
        mainOptcodes[0x5E] = LD_E_HL;
        mainOptcodes[0x5F] = LD_E_A;
        //6x
        mainOptcodes[0x60] = LD_H_B;
        mainOptcodes[0x61] = LD_H_C;
        mainOptcodes[0x62] = LD_H_D;
        mainOptcodes[0x63] = LD_H_E;
        mainOptcodes[0x64] = NOP;
        mainOptcodes[0x65] = LD_H_L;
        mainOptcodes[0x66] = LD_H_HL;
        mainOptcodes[0x67] = LD_H_A;
        mainOptcodes[0x68] = LD_L_B;
        mainOptcodes[0x69] = LD_L_C;
        mainOptcodes[0x6A] = LD_L_D;
        mainOptcodes[0x6B] = LD_L_E;
        mainOptcodes[0x6C] = LD_L_H;
        mainOptcodes[0x6D] = NOP;
        mainOptcodes[0x6E] = LD_L_HL;
        mainOptcodes[0x6F] = LD_L_A;
        //7x
        mainOptcodes[0x70] = LD_HL_B;
        mainOptcodes[0x71] = LD_HL_C;
        mainOptcodes[0x72] = LD_HL_D;
        mainOptcodes[0x73] = LD_HL_E;
        mainOptcodes[0x74] = LD_HL_H;
        mainOptcodes[0x75] = LD_HL_L;
        mainOptcodes[0x76] = HALT; //TODO: not implemented
        mainOptcodes[0x77] = LD_HL_A;
        mainOptcodes[0x78] = NotInplemented;
        mainOptcodes[0x79] = NotInplemented;
        mainOptcodes[0x7A] = NotInplemented;
        mainOptcodes[0x7B] = NotInplemented;
        mainOptcodes[0x7C] = NotInplemented;
        mainOptcodes[0x7D] = NotInplemented;
        mainOptcodes[0x7E] = NotInplemented;
        mainOptcodes[0x7F] = NotInplemented;
        //8x
        mainOptcodes[0x80] = ADD_A_B;
        mainOptcodes[0x81] = NotInplemented;
        mainOptcodes[0x82] = NotInplemented;
        mainOptcodes[0x83] = NotInplemented;
        mainOptcodes[0x84] = NotInplemented;
        mainOptcodes[0x85] = NotInplemented;
        mainOptcodes[0x86] = NotInplemented;
        mainOptcodes[0x87] = NotInplemented;
        mainOptcodes[0x88] = NotInplemented;
        mainOptcodes[0x89] = NotInplemented;
        mainOptcodes[0x8A] = NotInplemented;
        mainOptcodes[0x8B] = NotInplemented;
        mainOptcodes[0x8C] = NotInplemented;
        mainOptcodes[0x8D] = NotInplemented;
        mainOptcodes[0x8E] = NotInplemented;
        mainOptcodes[0x8F] = NotInplemented;
        //9x
        mainOptcodes[0x90] = SUB_B;
        mainOptcodes[0x91] = NotInplemented;
        mainOptcodes[0x92] = NotInplemented;
        mainOptcodes[0x93] = NotInplemented;
        mainOptcodes[0x94] = NotInplemented;
        mainOptcodes[0x95] = NotInplemented;
        mainOptcodes[0x96] = NotInplemented;
        mainOptcodes[0x97] = NotInplemented;
        mainOptcodes[0x98] = NotInplemented;
        mainOptcodes[0x99] = NotInplemented;
        mainOptcodes[0x9A] = NotInplemented;
        mainOptcodes[0x9B] = NotInplemented;
        mainOptcodes[0x9C] = NotInplemented;
        mainOptcodes[0x9D] = NotInplemented;
        mainOptcodes[0x9E] = NotInplemented;
        mainOptcodes[0x9F] = NotInplemented;
        //Ax
        mainOptcodes[0xA0] = AND_B;
        mainOptcodes[0xA1] = NotInplemented;
        mainOptcodes[0xA2] = NotInplemented;
        mainOptcodes[0xA3] = NotInplemented;
        mainOptcodes[0xA4] = NotInplemented;
        mainOptcodes[0xA5] = NotInplemented;
        mainOptcodes[0xA6] = NotInplemented;
        mainOptcodes[0xA7] = NotInplemented;
        mainOptcodes[0xA8] = NotInplemented;
        mainOptcodes[0xA9] = NotInplemented;
        mainOptcodes[0xAA] = NotInplemented;
        mainOptcodes[0xAB] = NotInplemented;
        mainOptcodes[0xAC] = NotInplemented;
        mainOptcodes[0xAD] = NotInplemented;
        mainOptcodes[0xAE] = NotInplemented;
        mainOptcodes[0xAF] = NotInplemented;
        //Bx
        mainOptcodes[0xB0] = OR_B;
        mainOptcodes[0xB1] = NotInplemented;
        mainOptcodes[0xB2] = NotInplemented;
        mainOptcodes[0xB3] = NotInplemented;
        mainOptcodes[0xB4] = NotInplemented;
        mainOptcodes[0xB5] = NotInplemented;
        mainOptcodes[0xB6] = NotInplemented;
        mainOptcodes[0xB7] = NotInplemented;
        mainOptcodes[0xB8] = NotInplemented;
        mainOptcodes[0xB9] = NotInplemented;
        mainOptcodes[0xBA] = NotInplemented;
        mainOptcodes[0xBB] = NotInplemented;
        mainOptcodes[0xBC] = NotInplemented;
        mainOptcodes[0xBD] = NotInplemented;
        mainOptcodes[0xBE] = NotInplemented;
        mainOptcodes[0xBF] = NotInplemented;
        //Cx
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
        mainOptcodes[0xCA] = NotInplemented;
        mainOptcodes[0xCB] = NotInplemented;
        mainOptcodes[0xCC] = NotInplemented;
        mainOptcodes[0xCD] = NotInplemented;
        mainOptcodes[0xCE] = NotInplemented;
        mainOptcodes[0xCF] = NotInplemented;
        //Dx
        mainOptcodes[0xD0] = NotInplemented;
        mainOptcodes[0xD1] = NotInplemented;
        mainOptcodes[0xD2] = NotInplemented;
        mainOptcodes[0xD3] = NotInplemented;
        mainOptcodes[0xD4] = NotInplemented;
        mainOptcodes[0xD5] = NotInplemented;
        mainOptcodes[0xD6] = NotInplemented;
        mainOptcodes[0xD7] = NotInplemented;
        mainOptcodes[0xD8] = NotInplemented;
        mainOptcodes[0xD9] = NotInplemented;
        mainOptcodes[0xDA] = NotInplemented;
        mainOptcodes[0xDB] = NotInplemented;
        mainOptcodes[0xDC] = NotInplemented;
        mainOptcodes[0xDD] = NotInplemented;
        mainOptcodes[0xDE] = NotInplemented;
        mainOptcodes[0xDF] = NotInplemented;
        //Ex
        mainOptcodes[0xE0] = NotInplemented;
        mainOptcodes[0xE1] = NotInplemented;
        mainOptcodes[0xE2] = NotInplemented;
        mainOptcodes[0xE3] = NotInplemented;
        mainOptcodes[0xE4] = NotInplemented;
        mainOptcodes[0xE5] = NotInplemented;
        mainOptcodes[0xE6] = NotInplemented;
        mainOptcodes[0xE7] = NotInplemented;
        mainOptcodes[0xE8] = NotInplemented;
        mainOptcodes[0xE9] = NotInplemented;
        mainOptcodes[0xEA] = NotInplemented;
        mainOptcodes[0xEB] = NotInplemented;
        mainOptcodes[0xEC] = NotInplemented;
        mainOptcodes[0xED] = NotInplemented;
        mainOptcodes[0xEE] = NotInplemented;
        mainOptcodes[0xEF] = NotInplemented;
        //Fx
        mainOptcodes[0xF0] = NotInplemented;
        mainOptcodes[0xF1] = NotInplemented;
        mainOptcodes[0xF2] = NotInplemented;
        mainOptcodes[0xF3] = NotInplemented;
        mainOptcodes[0xF4] = NotInplemented;
        mainOptcodes[0xF5] = NotInplemented;
        mainOptcodes[0xF6] = NotInplemented;
        mainOptcodes[0xF7] = NotInplemented;
        mainOptcodes[0xF8] = NotInplemented;
        mainOptcodes[0xF9] = NotInplemented;
        mainOptcodes[0xFA] = NotInplemented;
        mainOptcodes[0xFB] = NotInplemented;
        mainOptcodes[0xFC] = NotInplemented;
        mainOptcodes[0xFD] = NotInplemented;
        mainOptcodes[0xFE] = NotInplemented;
        mainOptcodes[0xFF] = NotInplemented;

    }
    
    public int execute_from_byte(byte optcode,ref MemoryBus memoryBus)
    {
        Console.WriteLine("\n----- Values -----");
        Console.WriteLine($"PC: {memoryBus.Pc}");
        Console.WriteLine($"Executing instruction {optcode:X2}");
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
        Console.WriteLine($"{memoryBus.Pc}: Not Implemented");
        return 0;
    }
    //0x
    private int NOP(MemoryBus memoryBus)
    {
        return 1;
    }
    
    private int LD_BC_d16(MemoryBus memoryBus)
    {
        memoryBus.B = memoryBus.read_buffer(memoryBus.Pc++);
        memoryBus.C = memoryBus.read_buffer(memoryBus.Pc++);
        return 3;
    }

    private int LD_BC_A(MemoryBus memoryBus)
    {
        memoryBus.write_buffer(memoryBus.BC, memoryBus.A);

        return 2;
    }

    private int INC_BC(MemoryBus memoryBus)
    {
        memoryBus.BC++;

        return 2;
    }

    private int INC_B(MemoryBus memoryBus)
    {
        byte value = (byte)(memoryBus.B + 1);

        memoryBus.Zbit = value == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = ((memoryBus.B & 0xF) + (1 & 0xF)) > 0xF;

        memoryBus.B++;
        
        return 1;
    }

    private int DEC_B(MemoryBus memoryBus)
    {
        byte value = (byte)(memoryBus.B - 1);
        memoryBus.Zbit = value == 0;
        memoryBus.Nbit = true;
        memoryBus.Hbit = (memoryBus.B & 0xF) < (1 & 0xF);
        
        memoryBus.B--;
        return 1;
    }

    private int LD_B_d8(MemoryBus memoryBus)
    {
        memoryBus.B = memoryBus.read_buffer(memoryBus.Pc++);
        return 2;
    }

    private int RLCA(MemoryBus memoryBus)
    {
        bool bit7 = (memoryBus.A & 0x80) != 0; //Logial AND of bit 7
        memoryBus.A = (byte)(memoryBus.A << 1); //Bitshift A to the left
        
        memoryBus.A = (byte)(memoryBus.A | (bit7 ? 0x01: 0x00)); //Make bit 0 one or zero depending on the previous bit 7
        
        memoryBus.Zbit = false;
        memoryBus.Nbit = false;
        memoryBus.Hbit = false;
        memoryBus.Cbit = bit7;
        
        return 1;
    }
    
    //1x
    private int STOP(MemoryBus memoryBus)
    {
        return 1;
    }
    
    //2x
    private int JR_NZ_s8(MemoryBus memoryBus)
    {
        if (!memoryBus.Zbit)
        {
            memoryBus.Pc += memoryBus.read_buffer(memoryBus.Pc++);
            return 3;
        }

        memoryBus.Pc++;
        return 2;
    }
    
    //3x
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
    
    //4x

    private int LD_B_C(MemoryBus memoryBus)
    {
        memoryBus.B =  memoryBus.C;
        
        return 1;
    }

    private int LD_B_D(MemoryBus memoryBus)
    {
        memoryBus.B = memoryBus.D;
        
        return 1;
    }

    private int LD_B_E(MemoryBus memoryBus)
    {
        memoryBus.B = memoryBus.E;
        
        return 1;
    }

    private int LD_B_H(MemoryBus memoryBus)
    {
        memoryBus.B = memoryBus.H;
        
        return 1;
    }

    private int LD_B_L(MemoryBus memoryBus)
    {
        memoryBus.B = memoryBus.L;
        
        return 1;
    }

    private int LD_B_HL(MemoryBus memoryBus)
    {
        memoryBus.B = memoryBus.read_buffer(memoryBus.HL);
        
        return 2;
    }

    private int LD_B_A(MemoryBus memoryBus)
    {
        memoryBus.B = memoryBus.A;
        
        return 1;
    }

    private int LD_C_B(MemoryBus memoryBus)
    {
        memoryBus.C = memoryBus.B;
        
        return 1;
    }

    private int LD_C_D(MemoryBus memoryBus)
    {
        memoryBus.C = memoryBus.D;
        
        return 1;
    }

    private int LD_C_E(MemoryBus memoryBus)
    {
        memoryBus.C = memoryBus.E;
        
        return 1;
    }

    private int LD_C_H(MemoryBus memoryBus)
    {
        memoryBus.C = memoryBus.H;
        
        return 1;
    }

    private int LD_C_L(MemoryBus memoryBus)
    {
        memoryBus.C = memoryBus.L;
        
        return 1;
    }

    private int LD_C_HL(MemoryBus memoryBus)
    {
        memoryBus.C = memoryBus.read_buffer(memoryBus.HL);
        
        return 2;
    }

    private int LD_C_A(MemoryBus memoryBus)
    {
        memoryBus.C = memoryBus.A;
        
        return 1;
    }
    
    //5x
    private int LD_D_B(MemoryBus memoryBus)
    {
        memoryBus.D = memoryBus.B;
        
        return 1;
    }

    private int LD_D_C(MemoryBus memoryBus)
    {
        memoryBus.D = memoryBus.C;
        
        return 1;
    }

    private int LD_D_E(MemoryBus memoryBus)
    {
        memoryBus.D = memoryBus.E;
        
        return 1;
    }

    private int LD_D_H(MemoryBus memoryBus)
    {
        memoryBus.D = memoryBus.H;

        return 1;
    }

    private int LD_D_L(MemoryBus memoryBus)
    {
        memoryBus.D = memoryBus.L;
        
        return 1;
    }

    private int LD_D_HL(MemoryBus memoryBus)
    {
        memoryBus.D = memoryBus.read_buffer(memoryBus.HL);
        
        return 2;
    }

    private int LD_D_A(MemoryBus memoryBus)
    {
        memoryBus.D = memoryBus.A;
        
        return 1;
    }

    private int LD_E_B(MemoryBus memoryBus)
    {
        memoryBus.E = memoryBus.B;
        
        return 1;
    }

    private int LD_E_C(MemoryBus memoryBus)
    {
        memoryBus.E = memoryBus.C;
        
        return 1;
    }

    private int LD_E_D(MemoryBus memoryBus)
    {
        memoryBus.E = memoryBus.D;
        
        return 1;
    }

    private int LD_E_H(MemoryBus memoryBus)
    {
        memoryBus.E = memoryBus.H;
        
        return 1;
    }

    private int LD_E_L(MemoryBus memoryBus)
    {
        memoryBus.E = memoryBus.L;
        
        return 1;
    }

    private int LD_E_HL(MemoryBus memoryBus)
    {
        memoryBus.E = memoryBus.read_buffer(memoryBus.HL);
        
        return 2;
    }

    private int LD_E_A(MemoryBus memoryBus)
    {
        memoryBus.E = memoryBus.A;
        
        return 1;
    }
    
    
    
    //6x
    private int LD_H_B(MemoryBus memoryBus)
    {
        memoryBus.H = memoryBus.B;
        
        return 1;
    }
    
    private int LD_H_C(MemoryBus memoryBus)
    {
        memoryBus.H = memoryBus.C;
        
        return 1;
    }
    
    private int LD_H_D(MemoryBus memoryBus)
    {
        memoryBus.H = memoryBus.D;
        
        return 1;
    }

    private int LD_H_E(MemoryBus memoryBus)
    {
        memoryBus.H = memoryBus.E;
        
        return 1;
    }

    private int LD_H_L(MemoryBus memoryBus)
    {
        memoryBus.H = memoryBus.L;
        
        return 1;
    }

    private int LD_H_HL(MemoryBus memoryBus)
    {
        memoryBus.H = memoryBus.read_buffer(memoryBus.HL);
        
        return 2;
    }

    private int LD_H_A(MemoryBus memoryBus)
    {
        memoryBus.H = memoryBus.A;
        
        return 1;
    }

    private int LD_L_B(MemoryBus memoryBus)
    {
        memoryBus.L = memoryBus.B;
        
        return 1;
    }

    private int LD_L_C(MemoryBus memoryBus)
    {
        memoryBus.L = memoryBus.C;
        
        return 1;
    }

    private int LD_L_D(MemoryBus memoryBus)
    {
        memoryBus.L = memoryBus.D;
        
        return 1;
    }
    
    private int LD_L_E(MemoryBus memoryBus)
    {
        memoryBus.L = memoryBus.E;
        
        return 1;
    }
    
    private int LD_L_H(MemoryBus memoryBus)
    {
        memoryBus.L = memoryBus.H;
        
        return 1;
    }

    private int LD_L_HL(MemoryBus memoryBus)
    {
        memoryBus.L = memoryBus.read_buffer(memoryBus.HL);
        
        return 2;
    }

    private int LD_L_A(MemoryBus memoryBus)
    {
        memoryBus.L = memoryBus.A;
        
        return 1;
    }
    
    //7x
    private int LD_HL_B(MemoryBus memoryBus)
    {
        memoryBus.write_buffer(memoryBus.HL, memoryBus.B);
        
        return 2;
    }
    
    private int LD_HL_C(MemoryBus memoryBus)
    {
        memoryBus.write_buffer(memoryBus.HL, memoryBus.C);
        
        return 2;
    }
    
    private int LD_HL_D(MemoryBus memoryBus)
    {
        memoryBus.write_buffer(memoryBus.HL, memoryBus.D);
        
        return 2;
    }
    
    private int LD_HL_E(MemoryBus memoryBus)
    {
        memoryBus.write_buffer(memoryBus.HL, memoryBus.E);
        
        return 2;
    }
    
    private int LD_HL_H(MemoryBus memoryBus)
    {
        memoryBus.write_buffer(memoryBus.HL, memoryBus.H);
        
        return 2;
    }
    
    private int LD_HL_L(MemoryBus memoryBus)
    {
        memoryBus.write_buffer(memoryBus.HL, memoryBus.L);
        
        return 2;
    }

    private int HALT(MemoryBus memoryBus)
    {
        return NotInplemented(memoryBus);
    }
    
    private int LD_HL_A(MemoryBus memoryBus)
    {
        memoryBus.write_buffer(memoryBus.HL, memoryBus.A);
        
        return 2;
    }
    
    //8x
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
    
    //9x
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
    
    //Ax
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
    
    //Bx
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