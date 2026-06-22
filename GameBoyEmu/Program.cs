using GameBoyEmu;
using Raylib_cs;

Raylib.InitWindow(title:"GameBoyEmu", width:800, height:800);
Raylib.SetTargetFPS(60);

Framebuffer framebuffer = new Framebuffer(160, 144);
MemoryBus memoryBus = new MemoryBus("/home/krunkske/Documents/GitHub/GameBoyEmu/GameBoyEmu/roms/Tetris (World) (Rev 1).gb");
Cpu cpu = new Cpu();
Ppu ppu = new Ppu();

//Main loop
while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.White);
    
    int cycleCount = cpu.Cycle(ref memoryBus);
    ppu.Cycle();
    
    
    Raylib.DrawTexture(framebuffer.MakeFrame(), posX:0, posY:0, Color.White);
    Raylib.EndDrawing();
}

Raylib.CloseWindow();
