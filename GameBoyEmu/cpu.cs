namespace GameBoyEmu;

public class Cpu
{
    private Instruction _instruction =  new Instruction();
    public int Cycle(ref MemoryBus memoryBus)
    {
        byte nextInstruction = memoryBus.read_buffer(memoryBus.Pc++);
        return _instruction.execute_from_byte(nextInstruction, ref memoryBus);
    }
}