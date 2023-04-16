using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System;
using System.IO;
using System.Windows.Forms;
using System.Security.Permissions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        private void newBtn_Click(object sender, EventArgs e)
        {
            // Google Drive�̃t�@�C��ID
            string fileId = "1W0RKrcfFYowTjZUgtf_C_IZftfpeDVPJ";

            // �t�@�C���_�E�����[�h�p��URL�𐶐�����
            string downloadUrl = $"https://drive.google.com/u/0/uc?id=1W0RKrcfFYowTjZUgtf_C_IZftfpeDVPJ&export=download";

            // �t�@�C���̃_�E�����[�h�Ɖ�
            using (WebClient client = new WebClient())
            {
                // �_�E�����[�h��̈ꎞ�t�@�C�������w�肷��
                string tempZipPath = Path.Combine(Path.GetTempPath(), "NEW TRACK.zip");

                // �t�@�C�����_�E�����[�h����
                client.DownloadFile(downloadUrl, tempZipPath);



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
                    processStartInfo.Arguments = $"/c wszst x \"{filePath}\"";
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
            openFileDialog1.Filter = "brres file (*.brres)|*.brres";
            openFileDialog1.Title = "Chose your brres file";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string brresPath = openFileDialog1.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                process.StandardInput.WriteLine("wszst minimap \"" + brresPath + "\" --auto");
                process.StandardInput.Flush();
                process.StandardInput.Close();
                string output = process.StandardOutput.ReadToEnd();
                if (output.Contains("left-down"))
                {
                    MessageBox.Show("Patch success minimap!");
                }
                else
                {
                    MessageBox.Show("Failed minimap patching!");
                }
            }
        }
    }
}
   
    
