using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System;
using System.IO;
using System.Windows.Forms;
using System.Security.Permissions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MKW_WSZS_GUI
{
    public partial class Form1 : Form
    {

        //Most of this source code was written by Chat GPT.
        //Appllication created by TakumaBlenderStudio and Visual Studio C# Windows Form App.

        //This source code is open to the public, so feel free to download and
        //edit it. I will abandon the copyright of this software, but when
        //uploading the edited source code, please be sure to write "Based Takuma Blender Studio".

        private string downloadUrl = "https://drive.google.com/u/0/uc?id=1W0RKrcfFYowTjZUgtf_C_IZftfpeDVPJ&export=download";
        private string zipFileName = "NEW TRACK.zip";



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Wiimms SZS Tools���C���X�g�[������Ă��邩�m�F����
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c wszst";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            if (output.Contains("Wiimms SZS Tools"))
            {
                // Wiimms SZS Tools���C���X�g�[������Ă���ꍇ
                MessageBox.Show("Wiimms SZS Tools has been installed", "Installed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // �A�v�����N������
                // ...
                unpackBtn.Enabled = true;
                packBtn.Enabled = false;
                pachBtn.Enabled = true;
            }
            else
            {
                // Wiimms SZS Tools���C���X�g�[������Ă��Ȃ��ꍇ
                MessageBox.Show("Wiimms SZS Tools were not found on your computer", "NO Wiimms SZS Tools", MessageBoxButtons.OK, MessageBoxIcon.Question);

                // �A�v�������
                Application.Exit();
            }
        }

        private async void newBtn_Click(object sender, EventArgs e)
        {
            dlBar.Value = 0;
            dlStatus.Text = "Download Status:";
            string fileId = "1W0RKrcfFYowTjZUgtf_C_IZftfpeDVPJ";
            string downloadUrl = $"https://drive.google.com/u/0/uc?id={fileId}&export=download";
            string tempZipPath = Path.Combine(Path.GetTempPath(), "NEW TRACK.zip");

            // �t�@�C���̃_�E�����[�h�Ɖ�
            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += (s, ev) =>
                {
                    dlBar.Text = $"downloading...{ev.ProgressPercentage}%";
                };

                await client.DownloadFileTaskAsync(new Uri(downloadUrl), tempZipPath);

                dlBar.Value = 100;
                dlStatus.Text = "Download Success!";



                // �𓀐�̃p�X���擾����
                string extractPath = Path.Combine(Application.StartupPath, "extracted");

                // �𓀐�̐e�f�B���N�g���ɏ������݌������Ȃ��ꍇ�͗^����
                DirectoryInfo extractParentDir = Directory.GetParent(extractPath);
                if (!extractParentDir.Exists)
                {
                    Directory.CreateDirectory(extractParentDir.FullName);
                    new FileIOPermission(FileIOPermissionAccess.Write, extractParentDir.FullName).Demand();
                }

                // �𓀐�̃f�B���N�g�������݂��Ȃ��ꍇ�͍쐬����
                if (!Directory.Exists(extractPath))
                {
                    Directory.CreateDirectory(extractPath);
                }

                // Zip�t�@�C�����𓀂���
                using (ZipArchive archive = ZipFile.OpenRead(tempZipPath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string fullPath = Path.Combine(extractPath, entry.FullName);

                        if (string.IsNullOrEmpty(entry.Name))
                        {
                            Directory.CreateDirectory(fullPath);
                        }
                        else
                        {
                            entry.ExtractToFile(fullPath, true);

                            folderPath.Text = fullPath;
                            unpackBtn.Enabled = true;
                            packBtn.Enabled = true;
                            pachBtn.Enabled = true;
                        }
                    }
                }

                // �ꎞ�t�@�C�����폜����
                File.Delete(tempZipPath);

                MessageBox.Show("''NEW TRACK'' Data Download completed!", "New Track Base Created!");
            }
        }

        private void folderBtn_Click(object sender, EventArgs e)
        {
            string message = "Chose your folder of course. \n For Example... : *_course.d";
            MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            using (var dialog = new FolderBrowserDialog())
            {
                // �_�C�A���O�̐�����ݒ肵�܂�
                dialog.Description = "Chose your folder";

                // �_�C�A���O��\�����AOK���N���b�N���ꂽ�ꍇ�̓p�X�����e�L�X�g�{�b�N�X�ɕ\�����܂�
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    folderPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void unpackBtn_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                // �_�C�A���O�̐ݒ�
                dialog.Filter = "SZS File (*.szs)|*.szs";
                dialog.Title = "Chose Your SZS file";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = dialog.FileName;

                    // �R�}���h�v�����v�g��WSZST�����s���ăt�@�C�����𓀂���
                    var processStartInfo = new ProcessStartInfo();
                    processStartInfo.FileName = "cmd.exe";
                    processStartInfo.Arguments = $"/c wszst x " + filePath; ;
                    processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    processStartInfo.UseShellExecute = false;
                    processStartInfo.RedirectStandardOutput = true;
                    processStartInfo.CreateNoWindow = true;

                    var process = new Process();
                    process.StartInfo = processStartInfo;
                    process.EnableRaisingEvents = true;

                    // �R�}���h�v�����v�g����̏o�͂��擾���邽�߂̃C�x���g�n���h��
                    process.OutputDataReceived += (s, ea) =>
                    {
                        if (!string.IsNullOrWhiteSpace(ea.Data))
                        {
                            if (ea.Data.Contains("EXTRACT"))
                            {
                                MessageBox.Show("Unpaced SZS", "Success!");
                            }
                            else if (ea.Data.Contains("Error"))
                            {
                                MessageBox.Show("Ooops!! Something went wrong!", "Failed!");
                            }
                        }
                    };

                    process.Start();
                    process.BeginOutputReadLine();
                }
            }
        }

        private void folderPath_TextChanged(object sender, EventArgs e)
        {
            packBtn.Enabled = true;
        }

        private void packBtn_Click(object sender, EventArgs e)
        {
            
            string folderPath_s = folderPath.Text;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.WriteLine("wszst c " + folderPath_s + " --overwrite");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            string output = process.StandardOutput.ReadToEnd();
            if (output.Contains("CREATE"))
            {
                MessageBox.Show("Packed SZS");
            }
            else
            {
                MessageBox.Show("Failed Packing!");
            }
        }

        private void pachBtn_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "packed .szs file (*.szs)|*.szs";
            openFileDialog1.Title = "Chose your szs file";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string brresPath = openFileDialog1.FileName;
                ProcessStartInfo startInfo2 = new ProcessStartInfo();
                startInfo2.FileName = "cmd.exe";
                startInfo2.RedirectStandardInput = true;
                startInfo2.RedirectStandardOutput = true;
                startInfo2.UseShellExecute = false;
                Process process2 = new Process();
                process2.StartInfo = startInfo2;
                process2.Start();
                process2.StandardInput.WriteLine("wszst minimap " + brresPath + " --auto");
                process2.StandardInput.Flush();
                process2.StandardInput.Close();
                string output = process2.StandardOutput.ReadToEnd();
                if (output.Contains("YAZ0"))
                {
                    MessageBox.Show("Patch success minimap!");
                }
                else
                {
                    MessageBox.Show("Failed minimap patching!");
                }
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// URL������̃u���E�U�ŊJ��
        /// </summary>
        /// <param name="url">https://github.com/TAKUMA1216/MKW-WSZS-GUI/releases</param>
        /// <returns>Process</returns>
        private Process OpenUrl(string url)
        {
            ProcessStartInfo pi = new ProcessStartInfo()
            {
                FileName = url,
                UseShellExecute = true,
            };

            return Process.Start(pi);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string url = "https://github.com/TAKUMA1216/MKW-WSZS-GUI/releases";
            OpenUrl(url);
        }

        private void moveBtn_Click(object sender, EventArgs e)
        {
            // �t�@�C���I���_�C�A���O��\�����A�ړ����̃t�@�C����I������
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "szs files (*.szs)|*.szs";
            openFileDialog.Title = "Select a szs file to move";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string sourceFilePath = openFileDialog.FileName;

            // �ړ���̃t�H���_�[��I������
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select a folder to move the file to";

            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string destinationFolderPath = folderBrowserDialog.SelectedPath;

            // �ړ���̃p�X���쐬����
            string destinationFilePath = Path.Combine(destinationFolderPath, Path.GetFileName(sourceFilePath));

            // �ړ���ɓ����̃t�@�C��������ꍇ�ɏ㏑�����邩�m�F����
            if (File.Exists(destinationFilePath))
            {
                DialogResult result = MessageBox.Show("File already exists. Do you want to overwrite it?", "Confirm Overwrite", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }

            // �t�@�C�����ړ�����
            try
            {
                File.Move(sourceFilePath, destinationFilePath);
                MessageBox.Show("File moved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error moving file: " + ex.Message);
            }
        
    }
    }
}
   
    
