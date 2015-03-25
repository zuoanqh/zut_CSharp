﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut
{
  /// <summary>
  /// Zuoanqh's Utility class of general algorithms. It's named "zu" because zut.zut is weird.
  /// Note it is intended for the name to be in lowercase, since it's easier to type in only lowercase. 
  /// These are shorthands that dosen't have fancy OOP purpouses really.
  /// </summary>
  public static class zu
  {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The type of lists</typeparam>
    /// <param name="before">the list before the change</param>
    /// <param name="after">the list after the change</param>
    /// <returns>a Tuple that first element is what's new, second element is what's deleted.</returns>
    public static Tuple<List<T>, List<T>> ListDiff<T>(List<T> before, List<T> after)
    {
      List<T> added, deleted;
      added = new List<T>(after);//only what we have now can possible be added
      deleted = new List<T>(before);//only what we've had can be deleted

      foreach (T i in after)
      {
        if (before.Contains(i))
        {
          deleted.Remove(i);//subtract the common ones
          added.Remove(i);
        }
      }

      return new Tuple<List<T>, List<T>>(added, deleted);
    }
    /// <summary>
    /// Open the given directory if exists. If not, a debug error message will be printed.
    /// </summary>
    /// <param name="targetDirectory"></param>
    public static void openDirectory(string targetDirectory)
    {
      if (Directory.Exists(targetDirectory))
        Process.Start(targetDirectory);
      else
        zerr.e("zut.openDirectory", "Directory not exist: " + targetDirectory);
    }
    /// <summary>
    /// Logic method. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="one"></param>
    /// <param name="other"></param>
    /// <returns>Other, if one is null. Else one.</returns>
    public static T OtherIfNull<T>(T one, T other)
    {
      return (one == null) ? other : one;
    }

    //public static T NullIfFalse<T>(bool condition, T result)
    //{
    //  return (condition)?result:null;
    //}

    /// <summary>
    /// Invoke the action if value given is not null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="action"></param>
    /// <param name="value"></param>
    public static void DoIfNotNull<T>(Action<T> action, T value)
    {
      if (value != null) action.Invoke(value);
    }

    /// <summary>
    /// Invoke the action on all targets.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="action"></param>
    /// <param name="targets"></param>
    public static void DoToAll<T>(Action<T> action, params T[] targets)
    {
      foreach (T t in targets) action.Invoke(t);
    }
  }
}
