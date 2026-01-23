namespace GameBoyEmu;

public class instruction
{
    public int execute_from_byte(byte value,ref memory memory)
    {
        int instruction_count = 0;
        switch (value)
        {
            case 0:
                Console.WriteLine("0");
                break;
            case 1:
                Console.WriteLine("1");
                break;
        }

        memory.PC = 0;
        return instruction_count;
    }
}