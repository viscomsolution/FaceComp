using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace TGMTcs
{
    public class TGMTsound
    {
        static WaveOut waveOut;
        public static bool PlaySound(string filepath)
        {
            if (!File.Exists(filepath))
                return false;

            try
            {
                FileInfo fi = new FileInfo(filepath);
                if(fi.Extension == ".wav")
                {
                    var player = new SoundPlayer(filepath);
                    player.Play();
                }
                else
                {
                    if (waveOut != null)
                    {
                        waveOut.Stop();
                    }
                    var reader = new Mp3FileReader(filepath);
                    waveOut = new WaveOut();
                    waveOut.Init(reader);
                    waveOut.Play();
                }                
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}

    

