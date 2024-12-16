using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 600, "God jul!");

Raylib.SetTargetFPS(60);

Color red = new(200, 10, 0, 255);
Vector2 leftEye = new(350, 275);
Vector2 rightEye = new(450, 275);

Vector2 hat1 = new(400, 20);
Vector2 hat2 = new(335, 200);
Vector2 hat3 = new(465, 200);

Vector2[] snowflakes = new Vector2[400];
float[] snowflakeSpeeds = new float[400];

for (int i = 0; i < snowflakes.Length; i++)
{
  snowflakes[i] = new(
    Random.Shared.Next(800),
    Random.Shared.Next(600)
  );
  snowflakeSpeeds[i] = 0.1f + 3 * (float)Random.Shared.NextDouble();
}

bool showText = false;
float timer = 30;

while (Raylib.WindowShouldClose() == false)
{
  for (int i = 0; i < snowflakes.Length; i++)
  {
    snowflakes[i].Y += snowflakeSpeeds[i];
    if (snowflakes[i].Y > 605)
    {
      snowflakes[i].Y = -3;
    }
  }

  timer -= 1;

  if (timer <= 0)
  {
    timer = 30;
    showText = !showText;
  }


  Raylib.BeginDrawing();
  Raylib.ClearBackground(Color.SkyBlue);

  Raylib.DrawCircle(400, 300, 100, Color.Yellow);
  Raylib.DrawCircleV(leftEye, 20, Color.Black);
  Raylib.DrawCircleV(rightEye, 20, Color.Black);


  Raylib.DrawRectangle(325, 200, 150, 30, Color.White);

  Raylib.DrawTriangle(hat1, hat2, hat3, red);

  Raylib.DrawRing(
    new(400, 300),
    78, 80, // inner, outer radius
    45, 135, // start, end angle
    10, // segments
    Color.Black
  );

  for (int i = 0; i < snowflakes.Length; i++)
  {
    Raylib.DrawCircleV(snowflakes[i], 4, Color.White);
  }

  if (showText == true)
  {
    Raylib.DrawText("God jul!", 175, 400, 128, Color.Red);
  }

  Raylib.EndDrawing();
}