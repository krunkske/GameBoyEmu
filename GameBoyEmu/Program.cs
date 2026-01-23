using GameBoyEmu;
using Raylib_cs;

Raylib.InitWindow(title:"GameBoyEmu", width:800, height:800);
Raylib.SetTargetFPS(60);

framebuffer framebuffer = new framebuffer(160, 144);
memory memory = new memory();
cpu cpu = new cpu();
ppu ppu = new ppu();

//Main loop
while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.White);
    
    int cycle_count = cpu.cycle(ref memory);
    ppu.cycle();
    
    
    framebuffer.MakeFrame();
    Raylib.DrawTexture(framebuffer.MakeFrame(), posX:0, posY:0, Color.White);
    Raylib.EndDrawing();
}

Raylib.CloseWindow();
