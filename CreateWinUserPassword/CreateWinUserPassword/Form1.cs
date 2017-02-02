using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace CreateWinUserPassword
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<NewUser> NewUsers = new List<NewUser>();

        private void button1_Click(object sender, EventArgs e)
        {
            NewUsers.Clear();
            DirectoryEntry AD = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
            DirectoryEntry grp;
            string[] usernames = tbUsers.Text.Split(new String[] { "\n", "\r", "\n\r", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            
            if(usernames.Length <=0)
            {
                MessageBox.Show("Введите список учеток");
                return;
            }

            for (int i = 0; i < usernames.Length; i++)
            {
                NewUser nu = new NewUser(usernames[i]);
                NewUsers.Add(nu);
                Thread.Sleep(1);

                if (cbTest.Checked == false)
                {
                    grp = AD.Children.Find(nu.Name, "user");
                    if (grp != null)
                    {
                        grp.Invoke("SetPassword", new object[] { nu.Password });
                    }
                    grp.CommitChanges();
                }
            }

            var csv = new StringBuilder();
            foreach (var item in NewUsers)
            {
                var newLine = string.Format("{0};{1}", item.Name, item.Password);
                csv.AppendLine(newLine);
            }

            Clipboard.SetText(csv.ToString());
            MessageBox.Show("Данные скопированы в буфер обмена!");
            if(cbSaveToFile.Checked == true)
                File.WriteAllText(Environment.CurrentDirectory + "\\1.csv", csv.ToString());
        }
    }

    public class NewUser
    {
        Random rnd = new Random(DateTime.Now.Millisecond);

        public string Name = "";
        public string Password = "";

        public NewUser(string _Name)
        {
            Name = _Name;
            Password = CreatePassword();
        }

        string CreatePassword()
        {
            string result = GenerateSymbol() + GenerateSymbol() + rnd.Next(100).ToString("D2") +
                            GenerateSymbol() + GenerateSymbol() + rnd.Next(100).ToString("D2");
            return result;
        }

        string GenerateSymbol()
        { 
            string abc = "qwertyuiopasdfghjklzxcvbnm";//QWERTYUIOPASDFGHJKLZXCVBNM!@#$%^&*()"; //набор символов
            int lng = abc.Length;
            return abc[rnd.Next(lng)].ToString();
        }
    }
}
