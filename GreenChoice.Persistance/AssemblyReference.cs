﻿using System.Reflection;

namespace GreenChoice.Persistance;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}
