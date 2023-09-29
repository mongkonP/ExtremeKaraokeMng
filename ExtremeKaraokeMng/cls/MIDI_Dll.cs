using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MIDI_Dll
{
    public static class MIDI_Dll
    {
     public static  void MoveFile(string _FileName)
        {
            try { System.IO.File.Delete(_FileName); }
            catch
            {
                try
                {
                    System.IO.File.Move(_FileName, PathKaraTemp() + "\\" + String.Format("{0:ddMMyyyyHHmmss}", DateTime.Now) + System.IO.Path.GetFileName(_FileName));
                }
                catch { }
            }
        }
     public static void DelFile(string _FileName)
     {
         try { System.IO.File.Delete(_FileName); }
         catch
         {
             try
             {
                 System.IO.File.Move(_FileName, System.IO.Path.GetTempPath() + "\\" + String.Format("{0:ddMMyyyyHHmmss}", DateTime.Now) + System.IO.Path.GetFileName(_FileName));
             }
             catch { }
         }
     }
     public static string Time(double d)
        {

            string days = (((int)(d / 3600) / 24) > 0) ? ((int)(d / 3600) / 24) + "days:" : "";
            string hours = ((int)(d / 3600) % 24 > 0) ? (int)(d / 3600) % 24 + "hours:" : "";
            string minutes = ((int)(d / 60) % 60 > 0) ? (int)(d / 60) % 60 + "minutes:" : "";
            string seconds = ((int)d % 60 > 0) ? ((int)d % 60) + "seconds" : "";
            return days.ToString() + hours.ToString() + minutes.ToString() + seconds.ToString();
        }

        public static string PathKaraTemp()
        {
            if (!(System.IO.Directory.Exists(System.IO.Path.GetTempPath() + "\\KaraTemp")))
            {
                CreatePath(System.IO.Path.GetTempPath() + "\\KaraTemp");
            }
            return System.IO.Path.GetTempPath() + "\\KaraTemp";
        }
        public static void CreatePath(string _path)
        {
            if (!(System.IO.Directory.Exists(_path)))
            {
                
                System.Diagnostics.Process.Start("cmd.exe", "/c md " + Convert.ToChar(34) + _path + Convert.ToChar(34));
            }
        }
    }
}
