using System;
using UnityEngine;

namespace Asteroids.Abstract_Factory
{
    public class InputFactory
    {
        public IInput CreateInput(RuntimePlatform platform)
        {
            switch (platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsEditor:
                    return new PCInput();
                case RuntimePlatform.XBOX360:
                case RuntimePlatform.PS3:
                    return new ConsoleInput();
                default:
                    throw new ArgumentOutOfRangeException(nameof(platform), platform, null);
            }
        }

    }
}