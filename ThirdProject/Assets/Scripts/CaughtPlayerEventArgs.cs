using System;
using UnityEngine;

namespace BananaMan
{
    public class CaughtPlayerEventArgs:EventArgs
    {
        public Color Color { get; }
        
        public CaughtPlayerEventArgs(Color Сolor)
        {
            Color = Color;
        }
    }
}