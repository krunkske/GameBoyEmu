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
        //implemented
        #region inst_0x 
        mainOptcodes[0x00] = NOP;
        mainOptcodes[0x01] = LD_BC_d16;
        mainOptcodes[0x02] = LD_BC_A;
        mainOptcodes[0x03] = INC_BC;
        mainOptcodes[0x04] = INC_B;
        mainOptcodes[0x05] = DEC_B;
        mainOptcodes[0x06] = LD_B_d8;
        mainOptcodes[0x07] = RLCA;
        mainOptcodes[0x08] = LD_a16_SP;
        mainOptcodes[0x09] = ADD_HL_BC;
        mainOptcodes[0x0A] = LD_A_BC;
        mainOptcodes[0x0B] = DEC_BC;
        mainOptcodes[0x0C] = INC_C;
        mainOptcodes[0x0D] = DEC_C;
        mainOptcodes[0x0E] = LD_C_d8;
        mainOptcodes[0x0F] = RRCA;
        #endregion
        //implemented
        #region inst_1x
        mainOptcodes[0x10] = STOP;
        mainOptcodes[0x11] = LD_DE_d16;
        mainOptcodes[0x12] = LD_DE_A;
        mainOptcodes[0x13] = INC_DE;
        mainOptcodes[0x14] = INC_D;
        mainOptcodes[0x15] = DEC_D;
        mainOptcodes[0x16] = LD_D_d8;
        mainOptcodes[0x17] = RLA;
        mainOptcodes[0x18] = JR_s8;
        mainOptcodes[0x19] = ADD_HL_DE;
        mainOptcodes[0x1A] = LD_A_DE;
        mainOptcodes[0x1B] = DEC_DE;
        mainOptcodes[0x1C] = INC_E;
        mainOptcodes[0x1D] = DEC_E;
        mainOptcodes[0x1E] = LD_E_d8;
        mainOptcodes[0x1F] = RRA;
        #endregion
        //implemented + TODO * 2
        #region inst_2x
        mainOptcodes[0x20] = JR_NZ_s8;
        mainOptcodes[0x21] = LD_HL_d16;
        mainOptcodes[0x22] = LD_HL_plus_A;
        mainOptcodes[0x23] = INC_HL_1;
        mainOptcodes[0x24] = INC_H;
        mainOptcodes[0x25] = DEC_H;
        mainOptcodes[0x26] = LD_H_d8;
        mainOptcodes[0x27] = DAA; //TODO
        mainOptcodes[0x28] = JR_Z_s8;
        mainOptcodes[0x29] = ADD_HL_HL; //TODO
        mainOptcodes[0x2A] = LD_A_HL_plus;
        mainOptcodes[0x2B] = DEC_HL;
        mainOptcodes[0x2C] = INC_L;
        mainOptcodes[0x2D] = DEC_L;
        mainOptcodes[0x2E] = LD_L_d8;
        mainOptcodes[0x2F] = CPL;
        #endregion
        //incomplete 9/16
        #region inst_3x
        mainOptcodes[0x30] = JR_NC_s8;
        mainOptcodes[0x31] = LD_SP_d16;
        mainOptcodes[0x32] = LD_HL_min_A;
        mainOptcodes[0x33] = INC_SP;
        mainOptcodes[0x34] = INC_HL;
        mainOptcodes[0x35] = DEC_HL;
        mainOptcodes[0x36] = LD_HL_d8;
        mainOptcodes[0x37] = SCF;
        mainOptcodes[0x38] = JR_C_s8;
        mainOptcodes[0x39] = NotInplemented;
        mainOptcodes[0x3A] = NotInplemented;
        mainOptcodes[0x3B] = NotInplemented;
        mainOptcodes[0x3C] = NotInplemented;
        mainOptcodes[0x3D] = NotInplemented;
        mainOptcodes[0x3E] = NotInplemented;
        mainOptcodes[0x3F] = NotInplemented;
        #endregion
        //implemented
        #region inst_4x
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
        #endregion
        //implemented
        #region inst_5x
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
        #endregion
        //implemented
        #region inst_6x
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
        #endregion
        //TODO incomplete + TODO
        #region inst_7x
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
        #endregion
        //implemented
        #region inst_8x
        mainOptcodes[0x80] = ADD_A_B;
        mainOptcodes[0x81] = ADD_A_C;
        mainOptcodes[0x82] = ADD_A_D;
        mainOptcodes[0x83] = ADD_A_E;
        mainOptcodes[0x84] = ADD_A_H;
        mainOptcodes[0x85] = ADD_A_L;
        mainOptcodes[0x86] = ADD_A_HL;
        mainOptcodes[0x87] = ADD_A_A;
        mainOptcodes[0x88] = ADC_A_B;
        mainOptcodes[0x89] = ADC_A_C;
        mainOptcodes[0x8A] = ADC_A_D;
        mainOptcodes[0x8B] = ADC_A_E;
        mainOptcodes[0x8C] = ADC_A_H;
        mainOptcodes[0x8D] = ADC_A_L;
        mainOptcodes[0x8E] = ADC_A_HL;
        mainOptcodes[0x8F] = ADC_A_A;
        #endregion
        //TODO incomplete
        #region inst_9x
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
        #endregion
        //implemented
        #region inst_Ax
        mainOptcodes[0xA0] = AND_B;
        mainOptcodes[0xA1] = AND_C;
        mainOptcodes[0xA2] = AND_D;
        mainOptcodes[0xA3] = AND_E;
        mainOptcodes[0xA4] = AND_H;
        mainOptcodes[0xA5] = AND_L;
        mainOptcodes[0xA6] = AND_HL;
        mainOptcodes[0xA7] = AND_A;
        mainOptcodes[0xA8] = XOR_B;
        mainOptcodes[0xA9] = XOR_C;
        mainOptcodes[0xAA] = XOR_D;
        mainOptcodes[0xAB] = XOR_E;
        mainOptcodes[0xAC] = XOR_H;
        mainOptcodes[0xAD] = XOR_L;
        mainOptcodes[0xAE] = XOR_HL;
        mainOptcodes[0xAF] = XOR_A;
        #endregion
        //TODO incomplete
        #region inst_Bx
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
        #endregion
        //TODO incomplete
        #region inst_Cx
        mainOptcodes[0xC0] = NotInplemented;
        mainOptcodes[0xC1] = NotInplemented;
        mainOptcodes[0xC2] = NotInplemented;
        mainOptcodes[0xC3] = JP_a16;
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
        #endregion
        //TODO incomplete
        #region inst_Dx
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
        mainOptcodes[0xDD] = NotInplemented;
        mainOptcodes[0xDE] = NotInplemented;
        mainOptcodes[0xDF] = NotInplemented;
        #endregion
        //TODO incomplete
        #region inst_Ex
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
        #endregion
        //TODO incomplete
        #region inst_Fx
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
        #endregion

    }
    
    public int execute_from_byte(byte optcode, MemoryBus memoryBus)
    {
        Console.WriteLine("\n----- Values -----\n");
        Console.WriteLine($"PC: 0x{memoryBus.Pc:X2}");
        Console.WriteLine();
        Console.WriteLine($"-- Executing instruction {mainOptcodes[optcode].Method.Name} ({optcode:X2}) --");
        int amountOfCycles = mainOptcodes[optcode](memoryBus);
        
        Console.WriteLine("-- Done executing --");
        
        Console.WriteLine("\n------ END ------\n");
        
        return amountOfCycles;
        
    }
    

    private int NotInplemented(MemoryBus memoryBus)
    {
        Console.WriteLine($"Instruction {memoryBus.read_buffer((ushort)(memoryBus.Pc - 1)):X2} not implemented");
        return 0;
    }

    #region inst_0x
    private int NOP(MemoryBus memoryBus)
    {
        return 1;
    }
    
    private int LD_BC_d16(MemoryBus memoryBus)
    {
        memoryBus.C = memoryBus.read_buffer(memoryBus.Pc++);
        memoryBus.B = memoryBus.read_buffer(memoryBus.Pc++);
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

    private int LD_a16_SP(MemoryBus memoryBus)
    {   
        byte higherNibble = memoryBus.read_buffer(memoryBus.Pc++);
        byte lowerNibble = memoryBus.read_buffer(memoryBus.Pc++);

        ushort result = (ushort)(higherNibble << 8 | lowerNibble);
        
        memoryBus.write_buffer_u16((ushort)(higherNibble << 8 | lowerNibble), memoryBus.Sp);
        return 5;
    }

    private int ADD_HL_BC(MemoryBus memoryBus)
    {
        int result = memoryBus.BC + memoryBus.HL;

        memoryBus.Nbit = false;
        memoryBus.Hbit = ((memoryBus.BC & 0xF) + (1 & 0xF)) > 0xF; //TODO: This is probably wrong
        memoryBus.Cbit = result > 0xFFFF;

        memoryBus.HL = (ushort)result;

        return 2;
    }

    private int LD_A_BC(MemoryBus memoryBus)
    {
        memoryBus.A = memoryBus.read_buffer(memoryBus.BC);
        return 2;
    }

    private int DEC_BC(MemoryBus memoryBus)
    {
        memoryBus.BC--;
        return 2;
    }

    private int INC_C(MemoryBus memoryBus)
    {
        int result = memoryBus.C + 1;
        memoryBus.Zbit = memoryBus.C == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = ((memoryBus.C & 0xF) + (1 & 0xF)) > 0xF;

        memoryBus.C++;
        return 1;
    }

    private int DEC_C(MemoryBus memoryBus)
    {
        int result = memoryBus.C - 1;
        memoryBus.Zbit = memoryBus.C == 0;
        memoryBus.Nbit = true;
        memoryBus.Hbit = ((memoryBus.C & 0xF) + (1 & 0xF)) > 0xF;
        memoryBus.C--;
        return 1;
    }

    private int LD_C_d8(MemoryBus memoryBus)
    {
        memoryBus.C = memoryBus.read_buffer(memoryBus.Pc++);
        return 2;
    }

    private int RRCA(MemoryBus memoryBus)
    {
        bool bit0 = (memoryBus.A & 0x01) != 0; //Logical AND of bit 0
        memoryBus.A = (byte)(memoryBus.A >> 1); //Bitshift A to the right
        
        memoryBus.A = (byte)(memoryBus.A | (bit0 ? 0x08: 0x00)); //Make bit 0 one or zero depending on the previous bit 7
        
        memoryBus.Zbit = false;
        memoryBus.Nbit = false;
        memoryBus.Hbit = false;
        memoryBus.Cbit = bit0;

        return 1;
    }
    #endregion
    
    #region inst_1x
    private int STOP(MemoryBus memoryBus)
    {
        return 1;
    }

    private int LD_DE_d16(MemoryBus memoryBus)
    {
        memoryBus.E = memoryBus.read_buffer(memoryBus.Pc++);
        memoryBus.D = memoryBus.read_buffer(memoryBus.Pc++);
        return 3;
    }

    private int LD_DE_A(MemoryBus memoryBus)
    {
        memoryBus.write_buffer(memoryBus.DE, memoryBus.A);

        return 2;
    }

    private int INC_DE(MemoryBus memoryBus)
    {
        memoryBus.DE++;
        return 2;
    }
    
    private int INC_D(MemoryBus memoryBus)
    {
        byte value = (byte)(memoryBus.D + 1);

        memoryBus.Zbit = value == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = ((memoryBus.D & 0xF) + (1 & 0xF)) > 0xF;

        memoryBus.D++;
        
        return 1;
    }

    private int DEC_E(MemoryBus memoryBus)
    {
        int result = memoryBus.E - 1;
        memoryBus.Zbit = memoryBus.E == 0;
        memoryBus.Nbit = true;
        memoryBus.Hbit = ((memoryBus.E & 0xF) + (1 & 0xF)) > 0xF;
        memoryBus.E--;
        return 1;
    }

    private int LD_E_d8(MemoryBus memoryBus)
    {
        memoryBus.E = memoryBus.read_buffer(memoryBus.Pc++);
        return 2;
    }

    
    private int RRA(MemoryBus memoryBus)
    {
        bool bit0 = (memoryBus.A & 0x01) != 0;
        memoryBus.A = (byte)(memoryBus.A >> 1);
        memoryBus.A = (byte)(memoryBus.A | (memoryBus.Cbit ? 0x80: 0x00));
        memoryBus.Cbit = bit0;
        
        return 1;
    }
    
    private int DEC_D(MemoryBus memoryBus)
    {
        byte value = (byte)(memoryBus.D - 1);
        memoryBus.Zbit = value == 0;
        memoryBus.Nbit = true;
        memoryBus.Hbit = (memoryBus.D & 0xF) < (1 & 0xF);
        
        memoryBus.D--;
        return 1;
    }
    
    private int LD_D_d8(MemoryBus memoryBus)
    {
        memoryBus.D = memoryBus.read_buffer(memoryBus.Pc++);
        return 2;
    }

    private int RLA(MemoryBus memoryBus)
    {
        bool bit7 = (memoryBus.A & 0x80) != 0; //Logical AND of bit 7
        memoryBus.A = (byte)(memoryBus.A << 1);
        memoryBus.A = (byte)(memoryBus.A | (bit7 ? 0x01: 0x00));
        memoryBus.Hbit = false;
        memoryBus.Zbit = false;
        memoryBus.Nbit = false;
        memoryBus.Cbit = bit7;
        
        return 1;
    }

    private int JR_s8(MemoryBus memoryBus)
    {
        memoryBus.Pc += memoryBus.read_buffer(memoryBus.Pc++);

        return 3;
    }

    private int ADD_HL_DE(MemoryBus memoryBus)
    {
        int result = memoryBus.DE + memoryBus.HL;

        memoryBus.Nbit = false;
        memoryBus.Hbit = ((memoryBus.DE & 0xF) + (1 & 0xF)) > 0xF; //TODO: This is probably wrong
        memoryBus.Cbit = result > 0xFFFF;

        memoryBus.HL = (ushort)result;

        return 2;
    }

    private int LD_A_DE(MemoryBus memoryBus)
    {
        memoryBus.A = memoryBus.read_buffer(memoryBus.DE);
        return 2;
    }

    private int DEC_DE(MemoryBus memoryBus)
    {
        memoryBus.DE--;
        return 2;
    }

    private int INC_E(MemoryBus memoryBus)
    {
        int result = memoryBus.E + 1;
        memoryBus.Zbit = memoryBus.E == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = ((memoryBus.E & 0xF) + (1 & 0xF)) > 0xF;

        memoryBus.E++;
        return 1;
    }
    
    #endregion
    
    #region inst_2x
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
    
    private int LD_HL_d16(MemoryBus memoryBus)
    {
        memoryBus.L = memoryBus.read_buffer(memoryBus.Pc++);
        memoryBus.H = memoryBus.read_buffer(memoryBus.Pc++);
        return 3;
    }

    private int LD_HL_plus_A(MemoryBus memoryBus)
    {
        memoryBus.write_buffer(memoryBus.HL, memoryBus.A);
        memoryBus.HL++;
        return 2;
    }

    private int INC_HL_1(MemoryBus memoryBus)
    {
        memoryBus.HL++;
        return 2;
    }

    private int INC_H(MemoryBus memoryBus)
    {
        byte value = (byte)(memoryBus.H + 1);

        memoryBus.Zbit = value == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = ((memoryBus.H & 0xF) + (1 & 0xF)) > 0xF;

        memoryBus.H++;
        
        return 1;
    }
    
    private int DEC_H(MemoryBus memoryBus)
    {
        int result = memoryBus.H - 1;
        memoryBus.Zbit = memoryBus.H == 0;
        memoryBus.Nbit = true;
        memoryBus.Hbit = ((memoryBus.H & 0xF) + (1 & 0xF)) > 0xF;
        memoryBus.H--;
        return 1;
    }

    private int LD_H_d8(MemoryBus memoryBus)
    {
        memoryBus.H = memoryBus.read_buffer(memoryBus.Pc++);
        return 2;
    }

    private int DAA(MemoryBus memoryBus)
    {
        byte adjutsment = 0;
        if (memoryBus.Nbit)
        {
            if (memoryBus.Hbit) { adjutsment += 6; }

            if (memoryBus.Cbit) { adjutsment += 96; }

            memoryBus.A -= adjutsment;
        }
        else
        {
            if (memoryBus.Hbit || (memoryBus.A & 15) > 9) { adjutsment += 6; }

            if (memoryBus.Cbit || memoryBus.A > 153)
            {
                adjutsment += 96;
                memoryBus.Cbit = true;
            }

            memoryBus.A += adjutsment;
        }
        memoryBus.Zbit = memoryBus.A == 0; //Do not know if it has to be for registry A
        memoryBus.Hbit = false;
        // memoryBus.Cbit TODO: check if the carry flag needs to be true or false
        return 1;
    }

    private int JR_Z_s8(MemoryBus memoryBus)
    {
        if (memoryBus.Zbit)
        {
            memoryBus.Pc += memoryBus.read_buffer(memoryBus.Pc++);
            return 3;
        }

        return 2;
    }
    
    private int ADD_HL_HL(MemoryBus memoryBus)
    {
        int result = memoryBus.HL + memoryBus.HL;

        memoryBus.Nbit = false;
        memoryBus.Hbit = ((memoryBus.HL & 0xF) + (1 & 0xF)) > 0xF; //TODO: This is probably wrong
        memoryBus.Cbit = result > 0xFFFF;

        memoryBus.HL = (ushort)result;

        return 2;
    }

    private int LD_A_HL_plus(MemoryBus memoryBus)
    {
        memoryBus.A = memoryBus.read_buffer(memoryBus.HL);
        memoryBus.HL++;
        return 2;
    }

    private int DEC_HL_1(MemoryBus memoryBus)
    {
        memoryBus.HL--;
        return 2;
    }
    
    private int INC_L(MemoryBus memoryBus)
    {
        int result = memoryBus.L + 1;
        memoryBus.Zbit = memoryBus.L == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = ((memoryBus.L & 0xF) + (1 & 0xF)) > 0xF;

        memoryBus.L++;
        return 1;
    }
    
    private int DEC_L(MemoryBus memoryBus)
    {
        int result = memoryBus.L - 1;
        memoryBus.Zbit = memoryBus.L == 0;
        memoryBus.Nbit = true;
        memoryBus.Hbit = ((memoryBus.L & 0xF) + (1 & 0xF)) > 0xF;
        memoryBus.L--;
        return 1;
    }

    private int LD_L_d8(MemoryBus memoryBus)
    {
        memoryBus.L = memoryBus.read_buffer(memoryBus.Pc++);
        return 2;
    }

    private int CPL(MemoryBus memoryBus)
    {
        memoryBus.A = (byte)~memoryBus.A;
        memoryBus.Nbit = true;
        memoryBus.Hbit = true;
        return 1;
    }
    
    #endregion

    #region inst_3x
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

    private int LD_SP_d16(MemoryBus memoryBus)
    {
        byte lower = memoryBus.read_buffer(memoryBus.Pc++);
        byte upper = memoryBus.read_buffer(memoryBus.Pc++);
        ushort result = (ushort)((upper << 8) + lower);

        memoryBus.Sp = result;
        
        return 3;
    }

    private int LD_HL_min_A(MemoryBus memoryBus)
    {
        memoryBus.write_buffer(memoryBus.HL, memoryBus.A);
        memoryBus.HL--;
        return 2;
    }

    private int INC_SP(MemoryBus memoryBus)
    {
        memoryBus.Sp++;
        return 2;
    }

    private int INC_HL(MemoryBus memoryBus)
    {
        byte value = memoryBus.read_buffer(memoryBus.HL);
        
        int result = value++;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.read_buffer(memoryBus.HL) & 0xF) + (value & 0xF)) > 0xF; //Check if A + value_in is bigger than 16
        //memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.write_buffer(memoryBus.HL, (byte)result);
        
        return 3;
    }

    private int DEC_HL(MemoryBus memoryBus) //TODO This one might be wrong
    {
        byte value = memoryBus.read_buffer(memoryBus.HL);

        int result = value--;
        memoryBus.Zbit = (byte)result == 0;
        memoryBus.Nbit = true;
        memoryBus.Hbit = (memoryBus.read_buffer(memoryBus.HL) & 0xF) < (1 & 0xF);

        memoryBus.write_buffer(memoryBus.HL, (byte)result);
        return 1;
    }

    private int LD_HL_d8(MemoryBus memoryBus)
    {
        memoryBus.write_buffer(memoryBus.HL, memoryBus.read_buffer(memoryBus.Pc++));
        return 3;
    }

    private int SCF(MemoryBus memoryBus)
    {
        memoryBus.Nbit = false;
        memoryBus.Hbit = false;
        memoryBus.Cbit = true;
        return 1;
    }

    private int JR_C_s8(MemoryBus memoryBus)
    {
        if (memoryBus.Cbit)
        {
            memoryBus.Pc += memoryBus.read_buffer(memoryBus.Pc++);
            return 3;
        }

        return 2;
    }
    
    #endregion

    #region inst_4x
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
    
    #endregion

    #region inst_5x
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
    
    #endregion
    
    #region inst_6x
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
    
    #endregion

    #region inst_7x
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
    
    #endregion

    #region inst_8x
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

    private int ADD_A_C(MemoryBus memoryBus)
    {
        byte value = memoryBus.C;
        
        int result = value + memoryBus.A;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF)) > 0xF; //Check if A + value_in is bigger than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 1;
    }
    
    private int ADD_A_D(MemoryBus memoryBus)
    {
        byte value = memoryBus.D;
        
        int result = value + memoryBus.A;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF)) > 0xF; //Check if A + value_in is bigger than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 1;
    }
    
    private int ADD_A_E(MemoryBus memoryBus)
    {
        byte value = memoryBus.E;
        
        int result = value + memoryBus.A;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF)) > 0xF; //Check if A + value_in is bigger than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 1;
    }
    
    private int ADD_A_H(MemoryBus memoryBus)
    {
        byte value = memoryBus.H;
        
        int result = value + memoryBus.A;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF)) > 0xF; //Check if A + value_in is bigger than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 1;
    }
    
    private int ADD_A_L(MemoryBus memoryBus)
    {
        byte value = memoryBus.L;
        
        int result = value + memoryBus.A;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF)) > 0xF; //Check if A + value_in is bigger than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 1;
    }
    
    private int ADD_A_HL(MemoryBus memoryBus)
    {
        byte value = memoryBus.read_buffer(memoryBus.HL);
        
        int result = value + memoryBus.A;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF)) > 0xF; //Check if A + value_in is bigger than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 2;
    }
    
    private int ADD_A_A(MemoryBus memoryBus)
    {
        byte value = memoryBus.A;
        
        int result = value + memoryBus.A;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF)) > 0xF; //Check if A + value_in is bigger than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 1;
    }
    
    private int ADC_A_B(MemoryBus memoryBus)
    {
        byte value = memoryBus.B;
        byte carry = (byte)(memoryBus.Cbit ? 0 : 1);
        
        int result = value + memoryBus.A + carry;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF) + carry) > 0xF; //Check if the first 4 bits of A + the first 4 bits of value_in is bigger + carry than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 1;
    }
    
    private int ADC_A_C(MemoryBus memoryBus)
    {
        byte value = memoryBus.C;
        byte carry = (byte)(memoryBus.Cbit ? 0 : 1);
        
        int result = value + memoryBus.A + carry;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF) + carry) > 0xF; //Check if the first 4 bits of A + the first 4 bits of value_in is bigger + carry than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 1;
    }
    
    private int ADC_A_D(MemoryBus memoryBus)
    {
        byte value = memoryBus.D;
        byte carry = (byte)(memoryBus.Cbit ? 0 : 1);
        
        int result = value + memoryBus.A + carry;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF) + carry) > 0xF; //Check if the first 4 bits of A + the first 4 bits of value_in is bigger + carry than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 1;
    }
    
    private int ADC_A_E(MemoryBus memoryBus)
    {
        byte value = memoryBus.E;
        byte carry = (byte)(memoryBus.Cbit ? 0 : 1);
        
        int result = value + memoryBus.A + carry;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF) + carry) > 0xF; //Check if the first 4 bits of A + the first 4 bits of value_in is bigger + carry than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 1;
    }
    
    private int ADC_A_H(MemoryBus memoryBus)
    {
        byte value = memoryBus.H;
        byte carry = (byte)(memoryBus.Cbit ? 0 : 1);
        
        int result = value + memoryBus.A + carry;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF) + carry) > 0xF; //Check if the first 4 bits of A + the first 4 bits of value_in is bigger + carry than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 1;
    }
    
    private int ADC_A_L(MemoryBus memoryBus)
    {
        byte value = memoryBus.L;
        byte carry = (byte)(memoryBus.Cbit ? 0 : 1);
        
        int result = value + memoryBus.A + carry;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF) + carry) > 0xF; //Check if the first 4 bits of A + the first 4 bits of value_in is bigger + carry than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 1;
    }
    
    private int ADC_A_HL(MemoryBus memoryBus)
    {
        byte value = memoryBus.read_buffer(memoryBus.HL);
        byte carry = (byte)(memoryBus.Cbit ? 0 : 1);
        
        int result = value + memoryBus.A + carry;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF) + carry) > 0xF; //Check if the first 4 bits of A + the first 4 bits of value_in is bigger + carry than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 2;
    }
    
    private int ADC_A_A(MemoryBus memoryBus)
    {
        byte value = memoryBus.A;
        byte carry = (byte)(memoryBus.Cbit ? 0 : 1);
        
        int result = value + memoryBus.A + carry;
        memoryBus.Zbit = (byte)result == 0; 
        memoryBus.Nbit = false; //No subtraction
        memoryBus.Hbit = ((memoryBus.A & 0xF) + (value & 0xF) + carry) > 0xF; //Check if the first 4 bits of A + the first 4 bits of value_in is bigger + carry than 16
        memoryBus.Cbit = result > 0xFF; //Bigger than 255
        
        memoryBus.A = (byte)result;
        
        return 1;
    }
    
    #endregion
    
    #region inst_9x
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
    
    #endregion
    
    #region inst_Ax
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

    private int AND_C(MemoryBus memoryBus)
    {
        byte value = memoryBus.C;

        byte result = (byte)(value & memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = true;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }

    private int AND_D(MemoryBus memoryBus)
    {
        byte value = memoryBus.D;

        byte result = (byte)(value & memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = true;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }

    private int AND_E(MemoryBus memoryBus)
    {
        byte value = memoryBus.E;

        byte result = (byte)(value & memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = true;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }

    private int AND_H(MemoryBus memoryBus)
    {
        byte value = memoryBus.H;

        byte result = (byte)(value & memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = true;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }

    private int AND_L(MemoryBus memoryBus)
    {
        byte value = memoryBus.L;

        byte result = (byte)(value & memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = true;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }

    private int AND_HL(MemoryBus memoryBus)
    {
        byte value = memoryBus.read_buffer(memoryBus.HL);

        byte result = (byte)(value & memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = true;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 2;
    }

    private int AND_A(MemoryBus memoryBus)
    {
        byte value = memoryBus.A;

        byte result = (byte)(value & memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = true;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }

    private int XOR_B(MemoryBus memoryBus)
    {
        byte value = memoryBus.B;

        byte result = (byte)(value ^ memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = false;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }
    
    private int XOR_C(MemoryBus memoryBus)
    {
        byte value = memoryBus.C;

        byte result = (byte)(value ^ memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = false;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }
    
    private int XOR_D(MemoryBus memoryBus)
    {
        byte value = memoryBus.D;

        byte result = (byte)(value ^ memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = false;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }
    
    private int XOR_E(MemoryBus memoryBus)
    {
        byte value = memoryBus.E;

        byte result = (byte)(value ^ memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = false;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }
    
    private int XOR_H(MemoryBus memoryBus)
    {
        byte value = memoryBus.H;

        byte result = (byte)(value ^ memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = false;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }
    
    private int XOR_L(MemoryBus memoryBus)
    {
        byte value = memoryBus.L;

        byte result = (byte)(value ^ memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = false;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }
    
    private int XOR_HL(MemoryBus memoryBus)
    {
        byte value = memoryBus.read_buffer(memoryBus.HL);

        byte result = (byte)(value ^ memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = false;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 2;
    }
    
    private int XOR_A(MemoryBus memoryBus)
    {
        byte value = memoryBus.A;

        byte result = (byte)(value ^ memoryBus.A);
        
        memoryBus.Zbit = result == 0;
        memoryBus.Nbit = false;
        memoryBus.Hbit = false;
        memoryBus.Cbit = false;
        
        memoryBus.A = result;

        return 1;
    }
    #endregion

    #region inst_Bx
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
    
    #endregion
    
    #region inst_Cx
    private int JP_a16(MemoryBus memoryBus)
    {
        byte lower = memoryBus.read_buffer(memoryBus.Pc++);
        byte upper = memoryBus.read_buffer(memoryBus.Pc++);
        
        ushort result = (ushort)((upper << 8) + lower);
        
        memoryBus.Pc = result;
        return 4;
    }
    
    #endregion
}