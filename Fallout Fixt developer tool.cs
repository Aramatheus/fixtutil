using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fallout_Fixt_developer_tool
{
	public partial class Fallout_Fixt_developer_tool : Form
	{
 		public Fallout_Fixt_developer_tool()
		{
            Application.EnableVisualStyles(); 
            InitializeComponent();
            Application.EnableVisualStyles();
            CopySaveDebugLog();
            MoveScreenshotsToFolder();
        }

		public void ExitButton_Click(object sender, EventArgs e)
		{
            CopySaveDebugLog();
            MoveScreenshotsToFolder();
            this.Dispose();
		}

		private void PlayButton_Click(object sender, EventArgs e)
		{
			CopySaveDebugLog();
            MoveScreenshotsToFolder();

            if (ScreenRefresh.Checked)
            {
                //var processExists = Process.GetProcesses().Any(p => p.ProcessName.Contains("f1_screen_refresh"));
                //if (processExists != true)
                    Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\fo1_screen_refresh.exe");
            }

            if (LOG.Checked)
                if (!GNW.Checked)
                    if (!CompileAndLog.Checked)
                        Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\source\BatchFiles\LOGFILE.bat");

            if (GNW.Checked)
                if (!LOG.Checked)
                    if (!CompileAndLog.Checked)
                        Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\source\BatchFiles\ONSCREEN.bat");

            if (CompileAndLog.Checked)
                if (!LOG.Checked)
                    if (!GNW.Checked)
                        Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\source\BatchFiles\LogFileDebug.bat");


            //Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\source\BatchFiles\KILLREFRESH.bat");

		}

		public void CopySaveDebugLog()
		{
			string DebugLog = @"C:\Users\Sduibek\Documents\Dropbox\Fallout\debug.log";
			if (System.IO.File.Exists(DebugLog))
			{
                //Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\source\BatchFiles\RemoveMsgsFromDebuglog.bat");
				string NewPath = @"C:\Users\Sduibek\Documents\Dropbox\Fallout\Fixtlogs\debug";
				string DebugLogNEW = "";
				
				string[] files = System.IO.Directory.GetFiles(NewPath);
				int highest = 0;
				int tempHighNumber = 0;
				string tempSuffix;
				foreach(string name in files)
				{ 
				 	if(name.Contains("debug"))
				 	{
				 		tempSuffix = name.Substring(6, 4); //6 is debug's end, 4 is length of number string.
				 		tempHighNumber = int.Parse (tempSuffix); //probably want to Try/Catch non number exceptions, relying on becoming 0 instead.
				 		if(tempHighNumber < highest)
				 		{
				 			highest = tempHighNumber;
				 		}
				 	}	
				}
				highest += 1;
				
				tempSuffix = highest.ToString("D4");
				DebugLogNEW = "debug" + tempSuffix + ".log";
				System.IO.File.Move(DebugLog, DebugLogNEW);
				
				
//				for (int i = 1; i < 9999; i++)
//				{
//					if (i < 10) 
//					{ 
//						DebugLogNEW = (NewPath + "000" + i + ".log");
//					}
//					else if (i < 100) 
//					{
//						DebugLogNEW = (NewPath + "00" + i + ".log");
//					}
//					else if (i < 1000)
//					{
//					    DebugLogNEW = (NewPath + "0" + i + ".log");
//					}
//					else
//					{ 
//						DebugLogNEW = (NewPath + i + ".log");
//					}
//					if (System.IO.File.Exists(DebugLogNEW)) 
//					{ 
//					
//					}
//					else
//					{
//						System.IO.File.Move(DebugLog, DebugLogNEW);
//						break;
//					}
//				}
			}
		}

        public void MoveScreenshotsToFolder()
        {
            string ShotPath;
            string ShotPathNEW;

            for (int i = 0; i < 129; i++)
            {
                ShotPath = @"C:\Users\Sduibek\Documents\Dropbox\Fallout\scr00";
                if (i < 10)
                {
                    ShotPath = (ShotPath + "00" + i + ".bmp");
                }
                else if (i < 100)
                {
                    ShotPath = (ShotPath + "0" + i + ".bmp");
                }
                else
                ShotPath = (ShotPath + i + ".bmp");

                if (System.IO.File.Exists(ShotPath))
                {
                    for (int j = 0; j < 9999; j++)
                    {
                        ShotPathNEW = @"C:\Users\Sduibek\Documents\Dropbox\Fallout\Screenshots\scr";
                        if (j < 10)
                        {
                            ShotPathNEW = (ShotPathNEW + "0000" + j + ".bmp");
                        }
                        else if (j < 100)
                        {
                            ShotPathNEW = (ShotPathNEW + "000" + j + ".bmp");
                        }
                        else if (j < 1000)
                        {
                            ShotPathNEW = (ShotPathNEW + "00" + j + ".bmp");
                        }
                        else if (j < 10000)
                        {
                            ShotPathNEW = (ShotPathNEW + "0" + j + ".bmp");
                        }

                        if (System.IO.File.Exists(ShotPathNEW)) { }
                        else
                        {
                            System.IO.File.Move(ShotPath, ShotPathNEW);
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < 129; i++)
            {
                ShotPath = @"C:\Mapper2\scr00";
                if (i < 10)
                {
                    ShotPath = (ShotPath + "00" + i + ".bmp");
                }
                else if (i < 100)
                {
                    ShotPath = (ShotPath + "0" + i + ".bmp");
                }
                else
                    ShotPath = (ShotPath + i + ".bmp");

                if (System.IO.File.Exists(ShotPath))
                {
                    for (int j = 0; j < 9999; j++)
                    {
                        ShotPathNEW = @"C:\Users\Sduibek\Documents\Dropbox\Fallout\Screenshots\scr";
                        if (j < 10)
                        {
                            ShotPathNEW = (ShotPathNEW + "0000" + j + ".bmp");
                        }
                        else if (j < 100)
                        {
                            ShotPathNEW = (ShotPathNEW + "000" + j + ".bmp");
                        }
                        else if (j < 1000)
                        {
                            ShotPathNEW = (ShotPathNEW + "00" + j + ".bmp");
                        }
                        else if (j < 10000)
                        {
                            ShotPathNEW = (ShotPathNEW + "0" + j + ".bmp");
                        }

                        if (System.IO.File.Exists(ShotPathNEW)) { }
                        else
                        {
                            System.IO.File.Move(ShotPath, ShotPathNEW);
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < 129; i++)
            {
                ShotPath = @"C:\Users\Sduibek\Documents\Dropbox\Fallout\scr00";
                if (i < 10)
                {
                    ShotPath = (ShotPath + "00" + i + " (2).bmp");
                }
                else if (i < 100)
                {
                    ShotPath = (ShotPath + "0" + i + " (2).bmp");
                }
                else
                    ShotPath = (ShotPath + i + " (2).bmp");

                if (System.IO.File.Exists(ShotPath))
                {
                    for (int j = 0; j < 9999; j++)
                    {
                        ShotPathNEW = @"C:\Users\Sduibek\Documents\Dropbox\Fallout\Screenshots\scr";
                        if (j < 10)
                        {
                            ShotPathNEW = (ShotPathNEW + "0000" + j + ".bmp");
                        }
                        else if (j < 100)
                        {
                            ShotPathNEW = (ShotPathNEW + "000" + j + ".bmp");
                        }
                        else if (j < 1000)
                        {
                            ShotPathNEW = (ShotPathNEW + "00" + j + ".bmp");
                        }
                        else if (j < 10000)
                        {
                            ShotPathNEW = (ShotPathNEW + "0" + j + ".bmp");
                        }

                        if (System.IO.File.Exists(ShotPathNEW)) { }
                        else
                        {
                            System.IO.File.Move(ShotPath, ShotPathNEW);
                            break;
                        }
                    }
                }
            }
        }

        private void ddraw_ini_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\ddraw.ini");
        }

        private void f1res_ini_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\f1_res.ini");
        }

        private void fallout_cfg_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\fallout.cfg");
        }

        private void GNW_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void LOG_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void ScreenRefresh_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void ToDoFile_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout Fixt stuff\_alpha 5.4.txt");
        }

        private void CurrentScripts_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "C:\\Users\\Sduibek\\Documents\\Dropbox\\Fallout\\source\\BatchFiles\\LogFileDebug.bat");
        }

        private void OpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout");
        }

        private void GamesFolder_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Games");
        }

        private void CompileOBJ_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\source\BatchFiles\CompileOBJDUDE.bat");
        }

        private void CompileV13_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\source\BatchFiles\CompileV13CAVE.bat");
        }

        private void CompileALL_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\Scripts-editing\_pack scripts.bat");
        }

        private void ScriptsFolder_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\Scripts-editing");
        }

        private void CopyLog_Click(object sender, EventArgs e)
        {
            CopySaveDebugLog();
        }

        private void CompileAndLog_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void EditDUDE_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\Scripts-editing\OBJ_DUDE.SSL");
        }

        private void EditCAVE_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\Scripts-editing\V13CAVE.SSL");
        }

        private void Scripts_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\DATA\SCRIPTS\SCRIPTS.LST");
        }

        private void GlobalVars_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\DATA\DATA\VAULT13.GAM");
        }

        private void FixesOnly_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout Fixt stuff\BUG FIXES ONLY.txt");
        }

        private void PersGuide_Click(object sender, EventArgs e)
        {
            Process.Start("http://user.tninet.se/~jyg699a/fallout.html");
        }

        private void Fixtbugs_Click(object sender, EventArgs e)
        {
            Process.Start("http://falloutmods.wikia.com/wiki/Fallout_Fixt_bug_reports");
        }

        private void NMAego_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.nma-fallout.com/usercp.php");
        }

        private void HiReswiki_Click(object sender, EventArgs e)
        {
            Process.Start("http://falloutmods.wikia.com/wiki/High_Resolution_Patch_bugs");
        }

        private void RGPCthread_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.rpgcodex.net/forums/index.php?threads/new-fallout-fixt.76182/");
        }

        private void Scriptwiki_Click(object sender, EventArgs e)
        {
            Process.Start("http://falloutmods.wikia.com/wiki/Fallout_1_and_Fallout_2_scripting_-_commands,_reference,_tutorials");
        }

        private void CFalloutDATA_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\DATA");
        }

        private void DefineH_Click(object sender, EventArgs e)
        {
            Process.Start("notepad++.exe", "C:\\Users\\Sduibek\\Documents\\Dropbox\\Fallout Fixt stuff\\DEFINE.H");
        }

        private void DialogFldr_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\DATA\TEXT\ENGLISH\DIALOG");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GamesFO1Extracted_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Games\Fo1 extracted - DO NOT MODIFY\DATA");
        }

        private void Critter_editor_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\critters editor\Critter_editor.bat");
        }

        private void DataART_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\DATA\ART");
        }

        private void artCRITTERS_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\DATA\ART\CRITTERS");
        }

        private void dataTEXT_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\DATA\TEXT\ENGLISH");
        }

        private void textGAME_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\DATA\TEXT\ENGLISH\GAME");
        }

        private void PROITEM_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\DATA\TEXT\ENGLISH\GAME\PRO_ITEM.MSG");
        }

        private void PROCRIT_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\DATA\TEXT\ENGLISH\GAME\PRO_CRIT.MSG");
        }

        private void PROITEMS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PROfileFOrmat_Click(object sender, EventArgs e)
        {
            Process.Start("http://falloutmods.wikia.com/wiki/PRO_File_Format");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Source_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\source");
        }

        private void LoaderZIPFILE_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\Fixt loader zipfile");
        }

        private void DataDATA_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\DATA\DATA");
        }

        private void Reftodo_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout Fixt stuff\REFERENCE and to-do.txt");
        }

        private void CodeSnippets_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout Fixt stuff\code snippets.txt");
        }

        private void f2wedit_Click_1(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\source\BatchFiles\f2wedit.bat");
        }

        private void animations_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout Fixt stuff\Animation naming.txt");
        }

        private void Fixtlogs_Click(object sender, EventArgs e)
        {
            CopySaveDebugLog();
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\Fixtlogs");
        }

        private void CrashFix_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\CrashFix");
        }

        private void Changelog_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout\Fallout_Fixt_changelog.txt");
        }

        private void FixtFolder_Click_1(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Sduibek\Documents\Dropbox\Fallout Fixt stuff");
        }
	}
}