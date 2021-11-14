using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Balloons.Model
{
    public static class Config
    {
        public static readonly float GameFieldWidth = 8;
        public static readonly float UpGameFieldBorder = 6;
        public static readonly float DownGameFieldBorder = -5;
        public static readonly float BalloonSpawnerSpeed = 2f; // Entities per second
        public static readonly float SpawnerAcceleration = 0.000005f;
        public static readonly int StartBalloonSpeed = 3;
        public static readonly int BalloonSpeedSpread = 40; // As a percentage (%)
        public static readonly int StartPlayerHealth = 100;

        public static readonly int LittleDamage = 10;
        public static readonly int MediumDamage = 20;
        public static readonly int BigDamage = 40;

        public static readonly uint LittleScore = 1;
        public static readonly uint MediumScore = 2;
        public static readonly uint BigScore = 3;

        public static readonly uint LittleSize = 3;
        public static readonly uint MediumSize = 5;
        public static readonly uint BigSize = 7;

        public static readonly IReadOnlyList<UnityEngine.Color> BalloonColors = new UnityEngine.Color[]
                {
                    UnityEngine.Color.black, UnityEngine.Color.blue, UnityEngine.Color.cyan, UnityEngine.Color.gray, UnityEngine.Color.green,
                    UnityEngine.Color.magenta, UnityEngine.Color.red, UnityEngine.Color.white, UnityEngine.Color.yellow,
                };
    }
}
