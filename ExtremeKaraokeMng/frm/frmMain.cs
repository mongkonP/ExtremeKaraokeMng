using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtremeKaraokeMng.frm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            folChar = new List<string>() { "0","1","2","3","4","5","6",
                "7","8","9","A","B","C","D","E","F","G","H","I",
                "J","K","L","M","N","O","P","Q","R"
                ,"S","T","U","V","W","X","Y","Z" };

            textboxOpenPath1.Direvtory = Properties.Settings.Default.pathKaraoke;
            textboxOpenPath3.Direvtory = Properties.Settings.Default.pathSource;

          /*  Task.Factory.StartNew(() =>
            {
                foreach (var f in Directory.GetFiles(@"D:\Extreme Karaoke\eXtreme Karaoke", "*", SearchOption.AllDirectories))
                {
                    this.lblStatus.Text = "Check File: " + f;
                    try { File.Delete(f); } catch { }
                }
            });*/


        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textboxOpenPath1.Direvtory) || !Directory.Exists(textboxOpenPath3.Direvtory)) return;

            Task.Factory.StartNew(() => CheckFileNCN(textboxOpenPath3.Direvtory));
            // Task.Factory.StartNew(() => CheckFileEMK(textboxOpenPath3.Direvtory));
            Task.Factory.StartNew(() => CheckSoundFont(textboxOpenPath3.Direvtory));
        }

        private void textboxOpenPath1_DirevtoryChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textboxOpenPath1.Direvtory))
            {

                Properties.Settings.Default.pathKaraoke = textboxOpenPath1.Direvtory;
                Properties.Settings.Default.Save();
            }
        }

        private void textboxOpenPath3_DirevtoryChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textboxOpenPath3.Direvtory))
            {

                Properties.Settings.Default.pathSource = textboxOpenPath3.Direvtory;
                Properties.Settings.Default.Save();
            }
        }
        private string ConvertAsciiToUTF8(string inAsciiString)
        {

            Encoding inAsciiEncoding = Encoding.ASCII;


            Encoding outUTF8Encoding = Encoding.ASCII;
            byte[] inAsciiBytes = inAsciiEncoding.GetBytes(inAsciiString);

            byte[] outUTF8Bytes = Encoding.Convert(inAsciiEncoding, outUTF8Encoding, inAsciiBytes);
            char[] inUTF8Chars = new char[outUTF8Encoding.GetCharCount(outUTF8Bytes, 0, outUTF8Bytes.Length)];
            outUTF8Encoding.GetChars(outUTF8Bytes, 0, outUTF8Bytes.Length, inUTF8Chars, 0);

            string outUTF8String = new string(inUTF8Chars);
            return outUTF8String;
        }

        string Endcode(string s)
        {
            Encoding iso88591 = System.Text.Encoding.GetEncoding("iso-8859-1");
            Encoding iso885911 = System.Text.Encoding.GetEncoding("iso-8859-11");

            byte[] isoBytes = iso88591.GetBytes(s);


            s = iso885911.GetString(isoBytes);

            return s;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textboxOpenPath1.Direvtory)) return;
            if (!System.IO.Directory.Exists(textboxOpenPath1.Direvtory + "\\Data")) { MessageBox.Show("ไม่พบ Song Data"); return; }

            string strQuery = "SELECT CODE,TYPE,SUB_TYPE,ARTIST + TITLE as SongName FROM SONG where TYPE like '%MIDI%'  order by ARTIST + TITLE";


            var file = textboxOpenPath1.Direvtory + "\\Data\\SONG.DBF";

            Task.Factory.StartNew(() =>
            {

                this.sONGDataGridView.Invoke(new Action(() => this.sONGDataGridView.Rows.Clear()));
                using (var dbfDataReader = new DbfDataReader.DbfDataReader(file))
                {
                    while (dbfDataReader.Read())
                    {


                        this.sONGDataGridView.Invoke(new Action(() => this.sONGDataGridView.Rows.Add(
                            Convert.ToString(dbfDataReader["CODE"]),
                          Convert.ToString(dbfDataReader["TYPE"]),
                          Convert.ToString(dbfDataReader["SUB_TYPE"]),
                            Endcode((Convert.ToString(dbfDataReader["ARTIST"]) + " " + Convert.ToString(dbfDataReader["TITLE"])))

                            )));

                    }
                }


                /*  int maxThread = 10;

                  int sngPer = (int)(sONGDataGridView.RowCount - 1) / maxThread;
                  myProgressBar1.Invoke(new Action(() => {
                      myProgressBar1.TextShow = "Check Dup ";
                      myProgressBar1.Maximum = this.sONGDataGridView.RowCount - 1;
                  }));

                  for (int i = 0; i < maxThread; i++)
                  {
                      Task.Factory.StartNew(() => CheckDupFile(i * sngPer, (i + 1) * sngPer));

                  }
                */
            });


        }
        #region _tor func
        List<string> folChar;
        private void CheckSoundFont(string path)
        {
            string folSoundFont = textboxOpenPath1.Direvtory + @"\SoundFont\";
            var files = Directory.GetFiles(textboxOpenPath3.Direvtory, "*.lyr", SearchOption.AllDirectories);
            Directory.CreateDirectory(folSoundFont);
            if (files.Length > 0)
            {
                foreach (var f in files)
                {
                    try
                    {
                        File.Move(f, folSoundFont + Path.GetFileName(f));
                    }
                    catch { File.Delete(f); }
                }
            }
        }
        private void CheckFileNCN(string path)
        {
            var files = Directory.GetFiles(textboxOpenPath3.Direvtory, "*.lyr", SearchOption.AllDirectories);
            string folNCN = textboxOpenPath1.Direvtory + @"\Songs\MIDI\NCN\";

            string s_S = ""; string t_S = "";
            string s_L = ""; string t_L = "";
            string s_C = ""; string t_C = "";
            string Fol_Lyrics;
            string Fol_Song;
            string Fol_Cursor;

            if (files.Length > 0)
            {
                Task.Factory.StartNew(() =>
                {

                    /*folChar.ForEach(cr =>
                    {
                        Directory.CreateDirectory(folNCN + "Lyrics\\" + cr);
                        Directory.CreateDirectory(folNCN + "Song\\" + cr);
                        Directory.CreateDirectory(folNCN + "Cursor\\" + cr);

                    });*/

                    this.myProgressBar2.Invoke(new Action(() =>
                    {
                        this.myProgressBar2.TextShow = "Check NCN ";
                        this.myProgressBar2.Value = 0;
                        this.myProgressBar2.Maximum = files.Length - 1;
                    }));


                    int i = 0;
                    int ic = 0;


                    Fol_Lyrics = folNCN + "Lyrics\\" + folChar[i];
                    Fol_Song = folNCN + "Song\\" + folChar[i];
                    Fol_Cursor = folNCN + "Cursor\\" + folChar[i];
                    Directory.CreateDirectory(Fol_Song);
                    Directory.CreateDirectory(Fol_Lyrics);
                    Directory.CreateDirectory(Fol_Cursor);



                    foreach (var f in files)
                    {

                        s_L = f.ToLower();
                        s_S = s_L.Replace("\\lyrics\\", "\\song\\").Replace(".lyr", ".mid");
                        s_C = s_L.Replace("\\lyrics\\", "\\cursor\\").Replace(".lyr", ".cur");
                        //เช็คก่อนว่ามีไฟล์ mid กับ cur ไม๊ ถ้ามีก็รันต่อได้
                        if (System.IO.File.Exists(s_C) && System.IO.File.Exists(s_S))
                        {

                            do
                            {
                                t_S = Fol_Song + "\\" + folChar[i] + string.Format("{0:00000}", ic) + ".mid";
                                t_C = Fol_Cursor + "\\" + folChar[i] + string.Format("{0:00000}", ic) + ".cur";
                                t_L = Fol_Lyrics + "\\" + folChar[i] + string.Format("{0:00000}", ic) + ".lyr";
                                ic++;

                                if (ic >= 30000)
                                {
                                    i++;
                                    ic = 0;
                                    Fol_Lyrics = folNCN + "Lyrics\\" + folChar[i];
                                    Fol_Song = folNCN + "Song\\" + folChar[i];
                                    Fol_Cursor = folNCN + "Cursor\\" + folChar[i];
                                    MIDI_Dll.MIDI_Dll.CreatePath(Fol_Song);
                                    MIDI_Dll.MIDI_Dll.CreatePath(Fol_Lyrics);
                                    MIDI_Dll.MIDI_Dll.CreatePath(Fol_Cursor);
                                }

                            } while (System.IO.File.Exists(t_L) || System.IO.File.Exists(t_C) || System.IO.File.Exists(t_S));


                            /* System.IO.File.Move(s_S, t_S);
                             System.IO.File.Move(s_C, t_C);
                             System.IO.File.Move(s_L, t_L);*/
                            MessageBox.Show(s_L + "\n" + File.Exists(s_L));

                        }


                        try
                        {



                            this.lblStatus.Invoke(new Action(() =>
                            {
                                this.lblStatus.Text = "Check File: " + s_L;
                            }));
                            if (this.myProgressBar2.Value + 1 < this.myProgressBar2.Maximum)
                                this.myProgressBar2.Invoke(new Action(() => { this.myProgressBar2.Value++; }));
                        }
                        catch { }


                    }

                });
            }
        }
        private void CheckFileEMK(string path)
        {

            var files = Directory.GetFiles(textboxOpenPath3.Direvtory, "*.emk", SearchOption.AllDirectories);
            string folEMK = textboxOpenPath1.Direvtory + @"\Songs\MIDI\EMK\";
            string folSong;
            if (files.Length > 0)
            {
                Task.Factory.StartNew(() =>
                {

                    folChar.ForEach(cr =>
                    {
                        Directory.CreateDirectory(folEMK + cr);

                    });


                    this.myProgressBar1.Invoke(new Action(() => {
                        this.myProgressBar1.TextShow = "Check EMK ";
                        this.myProgressBar1.Value = 0;
                        this.myProgressBar1.Maximum = files.Length - 1;
                    }));


                    int i = 0;
                    int ic = 0;
                    folSong = folEMK + folChar[i];
                    Directory.CreateDirectory(folSong);
                    string t_E = "";
                    foreach (var f in files)
                    {
                        do
                        {
                            t_E = folSong + "\\" + folChar[i] + string.Format("{0:00000}", ic) + ".emk";
                            ic++;

                            if (ic >= 30000)
                            {
                                i++;
                                ic = 0;
                                folSong = folEMK + folChar[i];
                                Directory.CreateDirectory(folSong);
                            }

                        } while (System.IO.File.Exists(t_E));

                        try
                        {

                            System.IO.File.Move(f, t_E);

                            this.lblStatus.Invoke(new Action(() =>
                            {
                                this.lblStatus.Text =
                                    "Check File: " + f + " to " + t_E;
                            }));
                            if (this.myProgressBar1.Value + 1 < this.myProgressBar1.Maximum)
                                this.myProgressBar1.Invoke(new Action(() => { this.myProgressBar1.Value++; }));
                        }
                        catch { }


                    }

                });

            }

        }
        private void CheckDupFile(int min, int max)
        {
            string cri = "";
            int i = min;
            while (true)
            {

                if (this.sONGDataGridView[3, i].Value.ToString().Trim().Replace(" ", "").ToUpper() != cri)
                {
                    cri = this.sONGDataGridView[3, i].Value.ToString().Trim().Replace(" ", "").ToUpper();
                }
                else
                {
                    if (this.sONGDataGridView[2, i].Value.ToString() == "EMK")
                    {
                        DelFile(textboxOpenPath1.Direvtory + "\\SONGS\\MIDI\\EMK\\" + this.sONGDataGridView[0, i].Value.ToString().Substring(0, 1) + "\\" + this.sONGDataGridView[0, i].Value.ToString() + ".emk");
                    }
                    else if (this.sONGDataGridView[2, i].Value.ToString() == "NCN")
                    {
                        DelFile(textboxOpenPath1.Direvtory + "\\SONGS\\MIDI\\NCN\\Lyrics\\" + this.sONGDataGridView[0, i].Value.ToString().Substring(0, 1) + "\\" + this.sONGDataGridView[0, i].Value.ToString() + ".lyr");
                        DelFile(textboxOpenPath1.Direvtory + "\\SONGS\\MIDI\\NCN\\Cursor\\" + this.sONGDataGridView[0, i].Value.ToString().Substring(0, 1) + "\\" + this.sONGDataGridView[0, i].Value.ToString() + ".cur");
                        DelFile(textboxOpenPath1.Direvtory + "\\SONGS\\MIDI\\NCN\\Song\\" + this.sONGDataGridView[0, i].Value.ToString().Substring(0, 1) + "\\" + this.sONGDataGridView[0, i].Value.ToString() + ".mid");
                    }

                }
                try
                {


                    this.myProgressBar1.Invoke(new Action(() => { this.myProgressBar1.Value++; }));
                }
                catch { }
                System.Threading.Thread.Sleep(5);


                i++;

                if (i > max + 1 || i > sONGDataGridView.RowCount)
                {
                    { return; }
                }
            }
        }
        void DelFile(string file)
        {
            try
            {
                File.Delete(file);
                this.lblStatus.Invoke(new Action(() =>
                {
                    this.lblStatus.Text = "Delete File: " + file;
                }));
            }
            catch { }

        }
        #endregion

        private void btnRunEMK_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textboxOpenPath1.Direvtory) || !Directory.Exists(textboxOpenPath3.Direvtory)) return;

            // Task.Factory.StartNew(() => CheckFileNCN(textboxOpenPath3.Direvtory));
            Task.Factory.StartNew(() => CheckFileEMK(textboxOpenPath3.Direvtory));
            Task.Factory.StartNew(() => CheckSoundFont(textboxOpenPath3.Direvtory));
        }
    }
}
