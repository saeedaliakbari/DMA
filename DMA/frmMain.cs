using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;

namespace DMA
{
    public partial class frmMain : Form
    {
        private QuestionData question;
        private AnswerData[] answers;
        private GameData gameData;
        private RoundData[] allRoundData;
        private XpData[] allXpData;
        private string jsonSerialiseIndented;
        private string fileName = @"\DMA.json";
        private string fileNameEncrypt = @"\data.json";
        public frmMain()
        {

            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                jsonSerialiseIndented = JsonConvert.SerializeObject(gameData, Formatting.Indented);
                System.IO.File.WriteAllText(Environment.CurrentDirectory + fileName, jsonSerialiseIndented);
                MessageBox.Show("ذخیره سازی انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در ذخیره سازی فایل", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void btnNewData_Click(object sender, EventArgs e)
        {
            try
            {
                gameData = new GameData();
                groupBox1.Enabled = true;
                btnNewData.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در ایجاد فایل جدید", "خطا");
                //throw;
            }

        }

        private void btnSaveGameData_Click(object sender, EventArgs e)
        {
            try
            {
                gameData.allRoundData = new RoundData[int.Parse(txtNumberRound.Text)];
                for (int i = 0; i < gameData.allRoundData.Length; i++)
                {
                    gameData.allRoundData[i] = new RoundData();
                    cmbIdRound.Items.Add(i);
                    cmbIdRoundQ.Items.Add(i);
                }
                gameData.allLevelXp = new XpData[int.Parse(txtNumberXp.Text)];
                for (int i = 0; i < gameData.allLevelXp.Length; i++)
                {
                    gameData.allLevelXp[i] = new XpData();
                }
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("ورود کلیه موارد الزامی است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }


        }

        private void btnSaveRound_Click(object sender, EventArgs e)
        {
            try
            {
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].id = int.Parse(cmbIdRound.SelectedItem.ToString());
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].name = txtNameRound.Text;
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound = new SubRoundData[3];
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[0] = new SubRoundData();
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[0].id = 0;
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[0].Etebar = 10;
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[0].question = new QuestionData[int.Parse(txtNumber1.Text)];
                for (int i = 0; i < gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[0].question.Length; i++)
                {
                    gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[0].question[i] = new QuestionData();
                }
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[1] = new SubRoundData();
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[1].id = 1;
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[1].Etebar = 20;
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[1].question = new QuestionData[int.Parse(txtNumber1.Text)];
                for (int i = 0; i < gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[1].question.Length; i++)
                {
                    gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[1].question[i] = new QuestionData();
                }
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[2] = new SubRoundData();
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[2].id = 2;
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[2].Etebar = 30;
                gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[2].question = new QuestionData[int.Parse(txtNumber1.Text)];
                for (int i = 0; i < gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[2].question.Length; i++)
                {
                    gameData.allRoundData[int.Parse(cmbIdRound.SelectedItem.ToString())].subRound[2].question[i] = new QuestionData();
                }
                btnSave.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("ورود کلیه موارد الزامی است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void btnSaveQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].id = int.Parse(txtIdQuestion.Text);
                gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].questionText = txtQuestion.Text;
                gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer = new AnswerData[4];
                for (int i = 0; i < 4; i++)
                {
                    gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[i] = new AnswerData();
                    gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[i].id = i;
                }
                gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[0].answerText = txtAnswer1.Text;
                gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[1].answerText = txtAnswer2.Text;
                gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[2].answerText = txtAnswer3.Text;
                gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[3].answerText = txtAnswer4.Text;
                gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[0].isCorrect = rdb1.Checked;
                gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[1].isCorrect = rdb2.Checked;
                gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[2].isCorrect = rdb3.Checked;
                gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[3].isCorrect = rdb4.Checked;
                //MessageBox.Show("موفق آمیز");
                ClearQuestionText();
            }
            catch (Exception)
            {
                MessageBox.Show("ورود کلیه موارد الزامی است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                //throw;
            }


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ClearQuestionText();
        }
        private void ClearQuestionText()
        {
            try
            {
                txtIdQuestion.Text = (int.Parse(txtIdQuestion.Text) + 1).ToString();
            }
            catch (Exception)
            {

                txtIdQuestion.Text = "";
            }

            txtQuestion.Text = "";
            txtAnswer1.Text = "";
            txtAnswer2.Text = "";
            txtAnswer3.Text = "";
            txtAnswer4.Text = "";
            rdb1.Checked = false;
            rdb2.Checked = false;
            rdb3.Checked = false;
            rdb4.Checked = false;
            txtIdQuestion.Focus();
        }

        private void btnLoadJsonFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader r = new StreamReader(Environment.CurrentDirectory + fileName))
                {
                    var json = r.ReadToEnd();
                    var items = JsonConvert.DeserializeObject<GameData>(json);
                    //foreach (var item in items)
                    //{
                    //    // Console.WriteLine("{0} {1}", item.temp, item.vcc);
                    //}

                    gameData = new GameData();
                    gameData = items;
                    //groupBox2.Enabled = true;
                    groupBox3.Enabled = true;
                    btnNewData.Enabled = false;
                    btnLoadJsonFile.Enabled = false;
                    btnSave.Enabled = true;
                    btnEncrypt.Enabled = true;
                    for (int i = 0; i < gameData.allRoundData.Length; i++)
                    {
                        cmbIdRound.Items.Add(i);
                        cmbIdRoundQ.Items.Add(i);
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("بارگذاری اطلاعات با خطا مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("برنامه ورود اطلاعات بازی بردبرد\n نسخه1.4\n تاریخ بروزرسانی :1397/05/30\n:تغییرات نسخه1.2\nلود کردن فایل-\n:تغییرات نسخه1.3\nنمایش سوال باشماره آیدی-\nنمایش موضوع-\n:تغییرات نسخه 1.4\nرمزگذاری فایل-", "شرکت بازی سازی بلوط گیمز", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            //MessageBox.Show("برنامه ورود اطلاعات بازی بردبرد\n نسخه 1.1\n تاریخ :1397/03/20", "شرکت بازی سازی بلوط گیمز", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
        }

        private void btnCopyDriveC_Click(object sender, EventArgs e)
        {

        }

        private void cmbIdRoundQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                lblNameTopic.Text = gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbIdSubRound_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbIdSubRound.SelectedIndex == 0)
                {
                    lblNameTopic.Text += "-آسان";
                }
                else if (cmbIdSubRound.SelectedIndex == 1)
                {
                    lblNameTopic.Text += "-متوسط";
                }
                else
                {
                    lblNameTopic.Text += "-سخت";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtIdQuestion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtQuestion.Text = gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].questionText;
                txtAnswer1.Text = gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[0].answerText;
                txtAnswer2.Text = gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[1].answerText;
                txtAnswer3.Text = gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[2].answerText;
                txtAnswer4.Text = gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[3].answerText;
                rdb1.Checked = gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[0].isCorrect;
                rdb2.Checked = gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[1].isCorrect;
                rdb3.Checked = gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[2].isCorrect;
                rdb4.Checked = gameData.allRoundData[int.Parse(cmbIdRoundQ.SelectedItem.ToString())].subRound[int.Parse(cmbIdSubRound.SelectedItem.ToString())].question[int.Parse(txtIdQuestion.Text)].answer[3].isCorrect;
            }
            catch (Exception)
            {
                txtQuestion.Text = "";
                txtAnswer1.Text = "";
                txtAnswer2.Text = "";
                txtAnswer3.Text = "";
                txtAnswer4.Text = "";
                rdb1.Checked = false;
                rdb2.Checked = false;
                rdb3.Checked = false;
                rdb4.Checked = false;
            }

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            EncryptFile(Environment.CurrentDirectory + fileName, "saeed1375", Environment.CurrentDirectory + fileNameEncrypt);
        }

        public void EncryptFile(string file, string password, string output)
        {
            byte[] bytesToBeEncrypted = File.ReadAllBytes(file);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            File.WriteAllBytes(output, bytesEncrypted);
            MessageBox.Show("رمزگذاری فایل انجام شد");
        }

        public string DecryptFile(string file, string password/*, string output*/)
        {
            byte[] bytesToBeDecrypted = File.ReadAllBytes(file);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);
            string converted = Encoding.UTF8.GetString(bytesDecrypted, 0, bytesDecrypted.Length);
            return converted;
            //File.WriteAllBytes("E://data.json", bytesDecrypted);
        }

        private byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
    }
}
