﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zuoanqh.libzut.Data
{
  /// <summary>
  /// A Pair that have the same element type. It is not mandatory to use this class instead, but you save keystrokes.
  /// </summary>
  /// <typeparam name="E">Element type.</typeparam>
  public class Twin<E> : Pair<E, E>
  {
    /// <summary>
    /// Copy constructor using base.
    /// </summary>
    /// <param name="First"></param>
    /// <param name="Second"></param>
    public Twin(E First, E Second) : base(First, Second) { }
  }
}
