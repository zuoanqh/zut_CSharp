﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zuoanqh.libzut.FileIO
{
  /// <summary>
  /// Provides a simple, stated solution for writing text into a file.
  /// </summary>
  public static class Logger
  {
    public const string FOLDER_NAME = "Logger";

    /// <summary>
    /// The data to be written.
    /// </summary>
    public static List<string> Current;

    static Logger()
    {
      Current = new List<string>();
    }
    /// <summary>
    /// Add a line.
    /// </summary>
    /// <param name="Line"></param>
    public static void Log(string Line)
    {
      Current.Add(Line);
    }

    /// <summary>
    /// Add a line with a time stamp before it.
    /// </summary>
    /// <param name="Line"></param>
    public static void LogTimed(string Line)
    {
      Log(DateTime.Now.ToString("yyyy_MM_dd___HH_mm_ss_fff") + "\t" + Line);
    }

    /// <summary>
    /// Save the log with default file name.
    /// </summary>
    public static void Save()
    {
      string fname = "LoggerEntry_" + DateTime.Now.ToString("yyyy_MM_dd___HH_mm_ss_fff") + ".txt";
      Save(fname, false);
    }
    /// <summary>
    /// Save the log with default file name and open with default application.
    /// </summary>
    public static void SaveAndOpen()
    {
      string fname = "LoggerEntry_" + DateTime.Now.ToString("yyyy_MM_dd___HH_mm_ss_fff") + ".txt";
      Save(fname, true);
    }

    /// <summary>
    /// Save the log with given file name.
    /// Open currently don't work, sorry.
    /// </summary>
    /// <param name="FileName"></param>
    /// <param name="Open">Open the file afterwards.</param>
    public static void Save(string FileName, bool Open)
    {
      var dir = Path.Combine(Directory.GetCurrentDirectory(), "Logger");

      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);
      ByLineFileIO.WriteFile(Current, Path.Combine("Logger", FileName));

      Current = new List<string>();
      if (Open)
      {//TODO: How?
        //System.Diagnostics.Process.Start(Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Logger", FileName)));
      }
    }

  }
}