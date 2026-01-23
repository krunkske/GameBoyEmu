namespace GameBoyEmu;

public class cpu
{
    private instruction instruction =  new instruction();
    public int cycle(ref memory memory)
    {
        byte next_instruction = memory.memory_buffer[memory.PC];
        return instruction.execute_from_byte(next_instruction, ref memory);
    }
}