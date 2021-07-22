using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ParkingSystem5Team
{
    public partial class MainParkingSystem : Form
    { 
        public string CarNum;
        public string cn;
        public string cn2;
        public string cn3;
        public string ph;        

        public MainParkingSystem()
        {
            InitializeComponent();
        }
        public static string[] Carstr = new string[100];
        private void btnReserve_Click(object sender, EventArgs e) //예약 버튼 눌렀을때
        {
            if (File.Exists(@"C:\ParkingSystem\Register\Register.csv") == false)
            {
                return;
            }
            FileStream fs = File.OpenRead(@"C:\ParkingSystem\Register\Register.csv");
            StreamReader sr = new StreamReader(fs);
            int i = 0;
            while (sr.EndOfStream == false)
            {
                string data = sr.ReadLine();
                if (data == null) { break; }
                string[] sitems = data.Split('\t', '\n');
                Carstr[i] = sitems[0];
                i++;
            }
            sr.Close();
            fs.Close();
            int a = 0;
            if (txtCarNumber.Text == "")
                MessageBox.Show("번호를 입력해주세요");
            else
            {
                for (int j = 1; j < i; j++)
                {
                    if (txtCarNumber.Text == Carstr[j])
                    {
                        a = 1;
                        break;
                    }
                    else
                    {
                        a = 0;
                    }
                }
                if (a == 1)
                {
                    reservation rese = new reservation();
                    rese.Owner = this;
                    CarNum = txtCarNumber.Text;
                    rese.ShowDialog();
                    rese.Dispose();
                }
                else
                {
                    MessageBox.Show("등록된 차량이 아닙니다.\n예약이 불가능합니다.");
                }
            }

        }
        private void Blue() //파란불
        {
            BlueBox.BackColor = Color.Blue;
            RedBox.BackColor = Color.Black;
        }
        private void Red() //빨간불
        {
            RedBox.BackColor = Color.Red;
            BlueBox.BackColor = Color.Black;
        }
        private void White() //default
        {
            BlueBox.BackColor = Color.Black;
            RedBox.BackColor = Color.Black;
        }

        public static string[] Carstr2 = new string[100];
        public static string[] Phonestr = new string[100];
        public void strCompare()
        {
            if (File.Exists(@"C:\ParkingSystem\Register\Register.csv") == false)
            {
                return;
            }
            FileStream fs = File.OpenRead(@"C:\ParkingSystem\Register\Register.csv");
            StreamReader sr = new StreamReader(fs);

            int i = 0;
            while (sr.EndOfStream == false)
            {
                string data = sr.ReadLine();
                if (data == null) { break; }
                string[] sitems = data.Split('\t', '\n');
                Carstr2[i] = sitems[0];
                Phonestr[i] = sitems[2];
                i++;
            }
            sr.Close();
            fs.Close();
            
            Member Mem = new Member();
            Nonmember nonMem = new Nonmember();

            for (int j = 1; j < i; j++)
            {
                if (txtCarNumber.Text == Carstr2[j])
                {
                    Mem.Owner = this;
                    cn = txtCarNumber.Text.Substring(0, 3);
                    cn2 = txtCarNumber.Text.Substring(3, 1);
                    cn3 = txtCarNumber.Text.Substring(4, 4);
                    ph = Phonestr[j];
                    
                    Mem.ShowDialog();
                    Mem.Dispose();
                }
                
                /*if (txtCarNumber.Text != Carstr2[j])
                {
                    nonMem.Owner = this;
                    cn = txtCarNumber.Text.Substring(0, 3);
                    cn2 = txtCarNumber.Text.Substring(3, 1);
                    cn3 = txtCarNumber.Text.Substring(4, 4);
                    nonMem.ShowDialog();
                    nonMem.Dispose();

                }
                
                */
            }

        }
        private void t_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare(); //얘만 추가하면됨
            //t_MouseDoubleClick(sender, e);
            if (txtCarNumber.Text != t1.Text && A1.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t1.Text = txtCarNumber.Text;
                if (t1.Text == t2.Text || t1.Text == t3.Text || t1.Text == t4.Text
                    || t1.Text == t5.Text || t1.Text == t6.Text || t1.Text == t7.Text
                    || t1.Text == t8.Text || t1.Text == t9.Text || t1.Text == t10.Text
                    || t1.Text == t11.Text || t1.Text == t12.Text || t1.Text == t13.Text
                    || t1.Text == t14.Text || t1.Text == t15.Text || t1.Text == t16.Text
                    || t1.Text == t17.Text || t1.Text == t18.Text || t1.Text == t19.Text
                    || t1.Text == t20.Text || t1.Text == t21.Text || t1.Text == t22.Text
                    || t1.Text == t23.Text || t1.Text == t24.Text || t1.Text == t25.Text
                    || t1.Text == t26.Text || t1.Text == t27.Text || t1.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t1.Text = "1";
                }
                else
                {
                    Red();
                    A1.Visible = true;
                    PA1.Visible = false;

                }

            }
        }

        private void t_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            A1.Visible = false;
            PA1.Visible = true;
            txtCarNumber.Text = t1.Text;
            t1.Text = "1";
        }

        private void t_MouseHover(object sender, EventArgs e)
        {
            White();
            if (A1.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (A1.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }          
        }

        private void t1_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare();
            if (txtCarNumber.Text != t2.Text && A2.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t2.Text = txtCarNumber.Text;
                if (t2.Text == t1.Text || t2.Text == t3.Text || t2.Text == t4.Text
                    || t2.Text == t5.Text || t2.Text == t6.Text || t2.Text == t7.Text
                    || t2.Text == t8.Text || t2.Text == t9.Text || t2.Text == t10.Text
                    || t2.Text == t11.Text || t2.Text == t12.Text || t2.Text == t13.Text
                    || t2.Text == t14.Text || t2.Text == t15.Text || t2.Text == t16.Text
                    || t2.Text == t17.Text || t2.Text == t18.Text || t2.Text == t19.Text
                    || t2.Text == t20.Text || t2.Text == t21.Text || t2.Text == t22.Text
                    || t2.Text == t23.Text || t2.Text == t24.Text || t2.Text == t25.Text
                    || t2.Text == t26.Text || t2.Text == t27.Text || t2.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t2.Text = "2";
                }
                else
                {
                    Red();
                    A2.Visible = true;
                    PA2.Visible = false;
                }

            }
        }

        private void t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            A2.Visible = false;
            PA2.Visible = true;
            txtCarNumber.Text = t2.Text;
            t2.Text = "2";
            
        }

        private void t2_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare();
            if (txtCarNumber.Text != t3.Text && A3.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t3.Text = txtCarNumber.Text;
                if (t3.Text == t1.Text || t3.Text == t2.Text || t3.Text == t4.Text
                    || t3.Text == t5.Text || t3.Text == t6.Text || t3.Text == t7.Text
                    || t3.Text == t8.Text || t3.Text == t9.Text || t3.Text == t10.Text
                    || t3.Text == t11.Text || t3.Text == t12.Text || t3.Text == t13.Text
                    || t3.Text == t14.Text || t3.Text == t15.Text || t3.Text == t16.Text
                    || t3.Text == t17.Text || t3.Text == t18.Text || t3.Text == t19.Text
                    || t3.Text == t20.Text || t3.Text == t21.Text || t3.Text == t22.Text
                    || t3.Text == t23.Text || t3.Text == t24.Text || t3.Text == t25.Text
                    || t3.Text == t26.Text || t3.Text == t27.Text || t3.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t3.Text = "3";
                }
                else
                {
                    Red();
                    A3.Visible = true;
                    PA3.Visible = false;

                }
            }
        }

        private void t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            A3.Visible = false;
            PA3.Visible = true;
            txtCarNumber.Text = t3.Text;
            t3.Text = "3";
            
        }

        private void t3_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare();
            if (txtCarNumber.Text != t4.Text && A4.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t4.Text = txtCarNumber.Text;
                if (t4.Text == t1.Text || t4.Text == t2.Text || t4.Text == t3.Text
                    || t4.Text == t5.Text || t4.Text == t6.Text || t4.Text == t7.Text
                    || t4.Text == t8.Text || t4.Text == t9.Text || t4.Text == t10.Text
                    || t4.Text == t11.Text || t4.Text == t12.Text || t4.Text == t13.Text
                    || t4.Text == t14.Text || t4.Text == t15.Text || t4.Text == t16.Text
                    || t4.Text == t17.Text || t4.Text == t18.Text || t4.Text == t19.Text
                    || t4.Text == t20.Text || t4.Text == t21.Text || t4.Text == t22.Text
                    || t4.Text == t23.Text || t4.Text == t24.Text || t4.Text == t25.Text
                    || t4.Text == t26.Text || t4.Text == t27.Text || t4.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t4.Text = "4";
                }
                else
                {
                    Red();
                    A4.Visible = true;
                    PA4.Visible = false;
                }

            }
        }

        private void t3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            A4.Visible = false;
            PA4.Visible = true;
            txtCarNumber.Text = t4.Text;
            t4.Text = "4";
        }

        private void t4_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare();
            if (txtCarNumber.Text != t5.Text && A5.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t5.Text = txtCarNumber.Text;
                if (t5.Text == t1.Text || t5.Text == t2.Text || t5.Text == t3.Text
                    || t5.Text == t4.Text || t5.Text == t6.Text || t5.Text == t7.Text
                    || t5.Text == t8.Text || t5.Text == t9.Text || t5.Text == t10.Text
                    || t5.Text == t11.Text || t5.Text == t12.Text || t5.Text == t13.Text
                    || t5.Text == t14.Text || t5.Text == t15.Text || t5.Text == t16.Text
                    || t5.Text == t17.Text || t5.Text == t18.Text || t5.Text == t19.Text
                    || t5.Text == t20.Text || t5.Text == t21.Text || t5.Text == t22.Text
                    || t5.Text == t23.Text || t5.Text == t24.Text || t5.Text == t25.Text
                    || t5.Text == t26.Text || t5.Text == t27.Text || t5.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t5.Text = "5";
                }
                else
                {
                    Red();
                    A5.Visible = true;
                    PA5.Visible = false;
                }
            }
        }

        private void t4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            A5.Visible = false;
            PA5.Visible = true;
            txtCarNumber.Text = t5.Text;
            t5.Text = "5";
        }

        private void t5_MouseClick(object sender, MouseEventArgs e)
        {
            strCompare();
            if (txtCarNumber.Text != t6.Text && A6.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t6.Text = txtCarNumber.Text;
                if (t6.Text == t1.Text || t6.Text == t2.Text || t6.Text == t3.Text
                    || t6.Text == t4.Text || t6.Text == t5.Text || t6.Text == t7.Text
                    || t6.Text == t8.Text || t6.Text == t9.Text || t6.Text == t10.Text
                    || t6.Text == t11.Text || t6.Text == t12.Text || t6.Text == t13.Text
                    || t6.Text == t14.Text || t6.Text == t15.Text || t6.Text == t16.Text
                    || t6.Text == t17.Text || t6.Text == t18.Text || t6.Text == t19.Text
                    || t6.Text == t20.Text || t6.Text == t21.Text || t6.Text == t22.Text
                    || t6.Text == t23.Text || t6.Text == t24.Text || t6.Text == t25.Text
                    || t6.Text == t26.Text || t6.Text == t27.Text || t6.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t6.Text = "6";
                }
                else
                {
                    Red();
                    A6.Visible = true;
                    PA6.Visible = false;

                }

            }
        }

        private void t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            A6.Visible = false;
            PA6.Visible = true;
            txtCarNumber.Text = t6.Text;
            t6.Text = "6"; 
        }
        private void t6_MouseClick(object sender, MouseEventArgs e)
        {
            strCompare();
            if (txtCarNumber.Text != t7.Text && A7.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t7.Text = txtCarNumber.Text;
                if (t7.Text == t1.Text || t7.Text == t2.Text || t7.Text == t3.Text
                    || t7.Text == t4.Text || t7.Text == t5.Text || t7.Text == t6.Text
                    || t7.Text == t8.Text || t7.Text == t9.Text || t7.Text == t10.Text
                    || t7.Text == t11.Text || t7.Text == t12.Text || t7.Text == t13.Text
                    || t7.Text == t14.Text || t7.Text == t15.Text || t7.Text == t16.Text
                    || t7.Text == t17.Text || t7.Text == t18.Text || t7.Text == t19.Text
                    || t7.Text == t20.Text || t7.Text == t21.Text || t7.Text == t22.Text
                    || t7.Text == t23.Text || t7.Text == t24.Text || t7.Text == t25.Text
                    || t7.Text == t26.Text || t7.Text == t27.Text || t7.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t7.Text = "7";
                }
                else
                {
                    Red();
                    A7.Visible = true;
                    PA7.Visible = false;
                }
            }
        }

        private void t6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            A7.Visible = false;
            PA7.Visible = true;
            txtCarNumber.Text = t7.Text;
            t7.Text = "7";
        }

        private void t7_MouseClick(object sender, MouseEventArgs e)
        {
            strCompare();
            if (txtCarNumber.Text != t8.Text && B1.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t8.Text = txtCarNumber.Text;
                if (t8.Text == t1.Text || t8.Text == t2.Text || t8.Text == t3.Text
                    || t8.Text == t4.Text || t8.Text == t5.Text || t8.Text == t6.Text
                    || t8.Text == t7.Text || t8.Text == t9.Text || t8.Text == t10.Text
                    || t8.Text == t11.Text || t8.Text == t12.Text || t8.Text == t13.Text
                    || t8.Text == t14.Text || t8.Text == t15.Text || t8.Text == t16.Text
                    || t8.Text == t17.Text || t8.Text == t18.Text || t8.Text == t19.Text
                    || t8.Text == t20.Text || t8.Text == t21.Text || t8.Text == t22.Text
                    || t8.Text == t23.Text || t8.Text == t24.Text || t8.Text == t25.Text
                    || t8.Text == t26.Text || t8.Text == t27.Text || t8.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t8.Text = "8";
                }
                else
                {
                    Red();
                    B1.Visible = true;
                    PB1.Visible = false;
                }
            }
        }

        private void t7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            B1.Visible = false;
            PB1.Visible = true;
            txtCarNumber.Text = t8.Text;
            t8.Text = "8";
        }

        private void t8_MouseClick(object sender, MouseEventArgs e)
        {
            strCompare();
            if (txtCarNumber.Text != t9.Text && B2.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t9.Text = txtCarNumber.Text;
                if (t9.Text == t1.Text || t9.Text == t2.Text || t8.Text == t3.Text
                    || t9.Text == t4.Text || t9.Text == t5.Text || t9.Text == t6.Text
                    || t9.Text == t7.Text || t9.Text == t8.Text || t9.Text == t10.Text
                    || t9.Text == t11.Text || t9.Text == t12.Text || t9.Text == t13.Text
                    || t9.Text == t14.Text || t9.Text == t15.Text || t9.Text == t16.Text
                    || t9.Text == t17.Text || t9.Text == t18.Text || t9.Text == t19.Text
                    || t9.Text == t20.Text || t9.Text == t21.Text || t9.Text == t22.Text
                    || t9.Text == t23.Text || t9.Text == t24.Text || t9.Text == t25.Text
                    || t9.Text == t26.Text || t9.Text == t27.Text || t9.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t9.Text = "9";
                }
                else
                {
                    Red();
                    B2.Visible = true;
                    PB2.Visible = false;
                }
            }
        }

        private void t8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            B2.Visible = false;
            PB2.Visible = true;
            txtCarNumber.Text = t9.Text;
            t9.Text = "9";
        }

        private void t9_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare();
            if (txtCarNumber.Text != t10.Text && B3.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t10.Text = txtCarNumber.Text;
                if (t10.Text == t1.Text || t10.Text == t2.Text || t10.Text == t3.Text
                    || t10.Text == t4.Text || t10.Text == t5.Text || t10.Text == t6.Text
                    || t10.Text == t7.Text || t10.Text == t8.Text || t10.Text == t9.Text
                    || t10.Text == t11.Text || t10.Text == t12.Text || t10.Text == t13.Text
                    || t10.Text == t14.Text || t10.Text == t15.Text || t10.Text == t16.Text
                    || t10.Text == t17.Text || t10.Text == t18.Text || t10.Text == t19.Text
                    || t10.Text == t20.Text || t10.Text == t21.Text || t10.Text == t22.Text
                    || t10.Text == t23.Text || t10.Text == t24.Text || t10.Text == t25.Text
                    || t10.Text == t26.Text || t10.Text == t27.Text || t10.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t10.Text = "10";
                }
                else
                {
                    Red();
                    B3.Visible = true;
                    PB3.Visible = false;
                }
            }
        }

        private void t9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            B3.Visible = false;
            PB3.Visible = true;
            txtCarNumber.Text = t10.Text;
            t10.Text = "10";
        }

        private void t10_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare();
            if (txtCarNumber.Text != t11.Text && B4.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t11.Text = txtCarNumber.Text;
                if (t11.Text == t1.Text || t11.Text == t2.Text || t1.Text == t3.Text
                    || t11.Text == t4.Text || t11.Text == t5.Text || t1.Text == t6.Text
                    || t11.Text == t7.Text || t11.Text == t8.Text || t1.Text == t9.Text
                    || t11.Text == t10.Text || t11.Text == t12.Text || t1.Text == t13.Text
                    || t11.Text == t14.Text || t11.Text == t15.Text || t1.Text == t16.Text
                    || t11.Text == t17.Text || t11.Text == t18.Text || t1.Text == t19.Text
                    || t11.Text == t20.Text || t11.Text == t21.Text || t1.Text == t22.Text
                    || t11.Text == t23.Text || t11.Text == t24.Text || t1.Text == t25.Text
                    || t11.Text == t26.Text || t11.Text == t27.Text || t1.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t11.Text = "11";
                }
                else
                {
                    Red();
                    B4.Visible = true;
                    PB4.Visible = false;
                }
            }
        }

        private void t10_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            B4.Visible = false;
            PB4.Visible = true;
            txtCarNumber.Text = t11.Text;
            t11.Text = "11";
        }

        private void t11_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare();
            if (txtCarNumber.Text != t12.Text && B5.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t12.Text = txtCarNumber.Text;
                if (t12.Text == t1.Text || t12.Text == t2.Text || t12.Text == t3.Text
                    || t12.Text == t4.Text || t12.Text == t5.Text || t12.Text == t6.Text
                    || t12.Text == t7.Text || t12.Text == t8.Text || t12.Text == t9.Text
                    || t12.Text == t10.Text || t12.Text == t11.Text || t12.Text == t13.Text
                    || t12.Text == t14.Text || t12.Text == t15.Text || t12.Text == t16.Text
                    || t12.Text == t17.Text || t12.Text == t18.Text || t12.Text == t19.Text
                    || t12.Text == t20.Text || t12.Text == t21.Text || t12.Text == t22.Text
                    || t12.Text == t23.Text || t12.Text == t24.Text || t12.Text == t25.Text
                    || t12.Text == t26.Text || t12.Text == t27.Text || t12.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t12.Text = "12";
                }
                else
                {
                    Red();
                    B5.Visible = true;
                    PB5.Visible = false;
                }
            }
        }

        private void t11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            B5.Visible = false;
            PB5.Visible = true;
            txtCarNumber.Text = t12.Text;
            t12.Text = "12";
        }

        private void t12_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare();
            if (txtCarNumber.Text != t13.Text && B6.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t13.Text = txtCarNumber.Text;
                if (t13.Text == t1.Text || t13.Text == t2.Text || t13.Text == t3.Text
                    || t13.Text == t4.Text || t13.Text == t5.Text || t13.Text == t6.Text
                    || t13.Text == t7.Text || t13.Text == t9.Text || t13.Text == t10.Text
                    || t13.Text == t11.Text || t13.Text == t12.Text || t13.Text == t13.Text
                    || t13.Text == t14.Text || t13.Text == t15.Text || t13.Text == t16.Text
                    || t13.Text == t17.Text || t13.Text == t18.Text || t13.Text == t19.Text
                    || t13.Text == t20.Text || t13.Text == t21.Text || t13.Text == t22.Text
                    || t13.Text == t23.Text || t13.Text == t24.Text || t13.Text == t25.Text
                    || t13.Text == t26.Text || t13.Text == t27.Text || t13.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t13.Text = "13";
                }
                else
                {
                    Red();
                    B6.Visible = true;
                    PB6.Visible = false;
                }
            }
        }

        private void t12_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            B6.Visible = false;
            PB6.Visible = true;
            txtCarNumber.Text = t13.Text;
            t13.Text = "13";
        }

        private void t13_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare();
            if (txtCarNumber.Text != t14.Text && B7.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t14.Text = txtCarNumber.Text;
                if (t14.Text == t1.Text || t14.Text == t2.Text || t14.Text == t3.Text
                    || t14.Text == t4.Text || t14.Text == t5.Text || t14.Text == t6.Text
                    || t14.Text == t7.Text || t14.Text == t8.Text || t14.Text == t9.Text
                    || t14.Text == t10.Text || t14.Text == t11.Text || t14.Text == t12.Text
                    || t14.Text == t13.Text || t14.Text == t15.Text || t14.Text == t16.Text
                    || t14.Text == t17.Text || t14.Text == t18.Text || t14.Text == t19.Text
                    || t14.Text == t20.Text || t14.Text == t21.Text || t14.Text == t22.Text
                    || t14.Text == t23.Text || t14.Text == t24.Text || t14.Text == t25.Text
                    || t14.Text == t26.Text || t14.Text == t27.Text || t14.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t14.Text = "14";
                }
                else
                {
                    Red();
                    B7.Visible = true;
                    PB7.Visible = false;
                }
            }
        }

        private void t13_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            B7.Visible = false;
            PB7.Visible = true;
            txtCarNumber.Text = t14.Text;
            t14.Text = "14";
        }

        private void t14_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare();
            if (txtCarNumber.Text != t15.Text && C1.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t15.Text = txtCarNumber.Text;
                if (t15.Text == t1.Text || t15.Text == t2.Text || t15.Text == t3.Text
                    || t15.Text == t4.Text || t15.Text == t5.Text || t15.Text == t6.Text
                    || t15.Text == t7.Text || t15.Text == t8.Text || t15.Text == t9.Text
                    || t15.Text == t10.Text || t15.Text == t11.Text || t15.Text == t12.Text
                    || t15.Text == t13.Text || t15.Text == t14.Text || t15.Text == t16.Text
                    || t15.Text == t17.Text || t15.Text == t18.Text || t15.Text == t19.Text
                    || t15.Text == t20.Text || t15.Text == t21.Text || t15.Text == t22.Text
                    || t15.Text == t23.Text || t15.Text == t24.Text || t15.Text == t25.Text
                    || t15.Text == t26.Text || t15.Text == t27.Text || t15.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t15.Text = "15";
                }
                else
                {
                    Red();
                    C1.Visible = true;
                    PC1.Visible = false;
                }
            }
        }

        private void t14_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            C1.Visible = false;
            PC1.Visible = true;
            txtCarNumber.Text = t16.Text;
            t15.Text = "15";
        }

        private void t15_MouseClick(object sender, MouseEventArgs e)
        {
            strCompare();
            if (txtCarNumber.Text != t16.Text && C2.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t16.Text = txtCarNumber.Text;
                if (t16.Text == t1.Text || t16.Text == t2.Text || t16.Text == t3.Text
                    || t16.Text == t4.Text || t16.Text == t5.Text || t16.Text == t6.Text
                    || t16.Text == t7.Text || t16.Text == t8.Text || t16.Text == t9.Text
                    || t16.Text == t10.Text || t16.Text == t11.Text || t16.Text == t12.Text
                    || t16.Text == t13.Text || t16.Text == t14.Text || t16.Text == t15.Text
                    || t16.Text == t17.Text || t16.Text == t18.Text || t16.Text == t19.Text
                    || t16.Text == t20.Text || t16.Text == t21.Text || t16.Text == t22.Text
                    || t16.Text == t23.Text || t16.Text == t24.Text || t16.Text == t25.Text
                    || t16.Text == t26.Text || t16.Text == t27.Text || t16.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t16.Text = "16";
                }
                else
                {
                    Red();
                    C2.Visible = true;
                    PC2.Visible = false;
                }
            }
        }

        private void t15_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            C2.Visible = false;
            PC2.Visible = true;
            txtCarNumber.Text = t16.Text;
            t16.Text = "16";
        }

        private void t16_MouseClick(object sender, MouseEventArgs e)
        {
            strCompare();
            if (txtCarNumber.Text != t17.Text && C3.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t17.Text = txtCarNumber.Text;
                if (t17.Text == t1.Text || t17.Text == t2.Text || t17.Text == t3.Text
                    || t17.Text == t4.Text || t17.Text == t5.Text || t17.Text == t6.Text
                    || t17.Text == t7.Text || t17.Text == t8.Text || t17.Text == t9.Text
                    || t17.Text == t10.Text || t17.Text == t11.Text || t17.Text == t12.Text
                    || t17.Text == t13.Text || t17.Text == t14.Text || t17.Text == t15.Text
                    || t17.Text == t16.Text || t17.Text == t18.Text || t17.Text == t19.Text
                    || t17.Text == t20.Text || t17.Text == t21.Text || t17.Text == t22.Text
                    || t17.Text == t23.Text || t17.Text == t24.Text || t17.Text == t25.Text
                    || t17.Text == t26.Text || t17.Text == t27.Text || t17.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t17.Text = "17";
                }
                else
                {
                    Red();
                    C3.Visible = true;
                    PC3.Visible = false;
                }
            }
        }

        private void t16_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            C3.Visible = false;
            PC3.Visible = true;
            txtCarNumber.Text = t17.Text;
            t17.Text = "17";
        }

        private void t17_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare();
            if (txtCarNumber.Text != t18.Text && C4.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t18.Text = txtCarNumber.Text;
                if (t18.Text == t1.Text || t18.Text == t2.Text || t18.Text == t3.Text
                    || t18.Text == t4.Text || t18.Text == t5.Text || t18.Text == t6.Text
                    || t18.Text == t7.Text || t18.Text == t8.Text || t18.Text == t9.Text
                    || t18.Text == t10.Text || t18.Text == t11.Text || t18.Text == t12.Text
                    || t18.Text == t13.Text || t18.Text == t14.Text || t18.Text == t15.Text
                    || t18.Text == t16.Text || t18.Text == t17.Text || t18.Text == t19.Text
                    || t18.Text == t20.Text || t18.Text == t21.Text || t18.Text == t22.Text
                    || t18.Text == t23.Text || t18.Text == t24.Text || t18.Text == t25.Text
                    || t18.Text == t26.Text || t18.Text == t27.Text || t18.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t18.Text = "18";
                }
                else
                {
                    Red();
                    C4.Visible = true;
                    PC4.Visible = false;
                }
            }
        }

        private void t17_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            C4.Visible = false;
            PC4.Visible = true;
            txtCarNumber.Text = t18.Text;
            t18.Text = "18";
        }

        private void t18_MouseClick(object sender, MouseEventArgs e)
        {
            strCompare();
            if (txtCarNumber.Text != t19.Text && C5.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t19.Text = txtCarNumber.Text;
                if (t19.Text == t1.Text || t19.Text == t2.Text || t19.Text == t3.Text
                    || t19.Text == t4.Text || t19.Text == t5.Text || t19.Text == t6.Text
                    || t19.Text == t7.Text || t19.Text == t8.Text || t19.Text == t9.Text
                    || t19.Text == t10.Text || t19.Text == t11.Text || t19.Text == t12.Text
                    || t19.Text == t13.Text || t19.Text == t14.Text || t19.Text == t15.Text
                    || t19.Text == t16.Text || t19.Text == t17.Text || t19.Text == t18.Text
                    || t19.Text == t20.Text || t19.Text == t21.Text || t19.Text == t22.Text
                    || t19.Text == t23.Text || t19.Text == t24.Text || t19.Text == t25.Text
                    || t19.Text == t26.Text || t19.Text == t27.Text || t19.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t19.Text = "19";
                }
                else
                {
                    Red();
                    C5.Visible = true;
                    PC5.Visible = false;
                }
            }
        }

        private void t18_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            C5.Visible = false;
            PC5.Visible = true;
            txtCarNumber.Text = t19.Text;
            t19.Text = "19";
        }

        private void t19_MouseClick(object sender, MouseEventArgs e)
        {
            strCompare();
            if (txtCarNumber.Text != t20.Text && C6.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t20.Text = txtCarNumber.Text;
                if (t20.Text == t1.Text || t20.Text == t2.Text || t20.Text == t3.Text
                    || t20.Text == t4.Text || t20.Text == t5.Text || t20.Text == t6.Text
                    || t20.Text == t7.Text || t20.Text == t8.Text || t20.Text == t9.Text
                    || t20.Text == t10.Text || t20.Text == t11.Text || t20.Text == t12.Text
                    || t20.Text == t13.Text || t20.Text == t14.Text || t20.Text == t15.Text
                    || t20.Text == t16.Text || t20.Text == t17.Text || t20.Text == t18.Text
                    || t20.Text == t19.Text || t20.Text == t21.Text || t20.Text == t22.Text
                    || t20.Text == t23.Text || t20.Text == t24.Text || t20.Text == t25.Text
                    || t20.Text == t26.Text || t20.Text == t27.Text || t20.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t20.Text = "20";
                }
                else
                {
                    Red();
                    C6.Visible = true;
                    PC6.Visible = false;
                }
            }
        }

        private void t19_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            C6.Visible = false;
            PC6.Visible = true;
            txtCarNumber.Text = t20.Text;
            t20.Text = "20";
        }

        private void t20_MouseClick(object sender, MouseEventArgs e)
        {
            strCompare();
            if (txtCarNumber.Text != t21.Text && C7.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t21.Text = txtCarNumber.Text;
                if (t21.Text == t1.Text || t21.Text == t2.Text || t21.Text == t3.Text
                    || t21.Text == t4.Text || t21.Text == t5.Text || t21.Text == t6.Text
                    || t21.Text == t7.Text || t21.Text == t8.Text || t21.Text == t9.Text
                    || t21.Text == t10.Text || t21.Text == t11.Text || t21.Text == t12.Text
                    || t21.Text == t13.Text || t21.Text == t14.Text || t21.Text == t15.Text
                    || t21.Text == t16.Text || t21.Text == t17.Text || t21.Text == t18.Text
                    || t21.Text == t19.Text || t21.Text == t20.Text || t21.Text == t22.Text
                    || t21.Text == t23.Text || t21.Text == t24.Text || t21.Text == t25.Text
                    || t21.Text == t26.Text || t21.Text == t27.Text || t21.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t21.Text = "21";
                }
                else
                {
                    Red();
                    C7.Visible = true;
                    PC7.Visible = false;
                }
            }
        }

        private void t20_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            C7.Visible = false;
            PC7.Visible = true;
            txtCarNumber.Text = t21.Text;
            t21.Text = "21";
        }

        private void t21_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare();
            if (txtCarNumber.Text != t22.Text && D1.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t22.Text = txtCarNumber.Text;
                if (t22.Text == t1.Text || t22.Text == t2.Text || t22.Text == t3.Text
                    || t22.Text == t4.Text || t22.Text == t5.Text || t22.Text == t6.Text
                    || t22.Text == t7.Text || t22.Text == t8.Text || t22.Text == t9.Text
                    || t22.Text == t10.Text || t22.Text == t11.Text || t22.Text == t12.Text
                    || t22.Text == t13.Text || t22.Text == t14.Text || t22.Text == t15.Text
                    || t22.Text == t16.Text || t22.Text == t17.Text || t22.Text == t18.Text
                    || t22.Text == t19.Text || t22.Text == t20.Text || t22.Text == t21.Text
                    || t22.Text == t23.Text || t22.Text == t24.Text || t22.Text == t25.Text
                    || t22.Text == t26.Text || t22.Text == t27.Text || t22.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t22.Text = "22";
                }
                else
                {
                    Red();
                    D1.Visible = true;
                    PD1.Visible = false;
                }
            }
        }

        private void t21_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            D1.Visible = false;
            PD1.Visible = true;
            txtCarNumber.Text = t22.Text;
            t22.Text = "22";
        }

        private void t22_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare();
            if (txtCarNumber.Text != t23.Text && D2.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t23.Text = txtCarNumber.Text;
                if (t23.Text == t1.Text || t23.Text == t2.Text || t23.Text == t3.Text
                    || t23.Text == t4.Text || t23.Text == t5.Text || t23.Text == t6.Text
                    || t23.Text == t7.Text || t23.Text == t8.Text || t23.Text == t9.Text
                    || t23.Text == t10.Text || t23.Text == t11.Text || t23.Text == t12.Text
                    || t23.Text == t13.Text || t23.Text == t14.Text || t23.Text == t15.Text
                    || t23.Text == t16.Text || t23.Text == t17.Text || t23.Text == t18.Text
                    || t23.Text == t19.Text || t23.Text == t20.Text || t23.Text == t21.Text
                    || t23.Text == t22.Text || t23.Text == t24.Text || t23.Text == t25.Text
                    || t23.Text == t26.Text || t23.Text == t27.Text || t23.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t23.Text = "23";
                }
                else
                {
                    Red();
                    D2.Visible = true;
                    PD2.Visible = false;
                }
            }
        }

        private void t22_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            D2.Visible = false;
            PD2.Visible = true;
            txtCarNumber.Text = t23.Text;
            t23.Text = "23";
        }

        private void t23_MouseClick(object sender, MouseEventArgs e) 
        {
            strCompare();
            if (txtCarNumber.Text != t24.Text && D3.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t24.Text = txtCarNumber.Text;
                if (t24.Text == t1.Text || t24.Text == t2.Text || t24.Text == t3.Text
                    || t24.Text == t4.Text || t24.Text == t5.Text || t24.Text == t6.Text
                    || t24.Text == t7.Text || t24.Text == t8.Text || t24.Text == t9.Text
                    || t24.Text == t10.Text || t24.Text == t11.Text || t24.Text == t12.Text
                    || t24.Text == t13.Text || t24.Text == t14.Text || t24.Text == t15.Text
                    || t24.Text == t16.Text || t24.Text == t17.Text || t24.Text == t18.Text
                    || t24.Text == t19.Text || t24.Text == t20.Text || t24.Text == t21.Text
                    || t24.Text == t22.Text || t24.Text == t23.Text || t24.Text == t25.Text
                    || t24.Text == t26.Text || t24.Text == t27.Text || t24.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t24.Text = "24";
                }
                else
                {
                    Red();
                    D3.Visible = true;
                    PD3.Visible = false;
                }
            }
        }

        private void t23_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            D3.Visible = false;
            PD3.Visible = true;
            txtCarNumber.Text = t24.Text;
            t24.Text = "24";
        }

        private void t24_MouseClick(object sender, MouseEventArgs e)
        {
            strCompare();
            if (txtCarNumber.Text != t25.Text && D4.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t25.Text = txtCarNumber.Text;
                if (t25.Text == t1.Text || t25.Text == t2.Text || t25.Text == t3.Text
                    || t25.Text == t4.Text || t25.Text == t5.Text || t25.Text == t6.Text
                    || t25.Text == t7.Text || t25.Text == t8.Text || t25.Text == t9.Text
                    || t25.Text == t10.Text || t25.Text == t11.Text || t25.Text == t12.Text
                    || t25.Text == t13.Text || t25.Text == t14.Text || t25.Text == t15.Text
                    || t25.Text == t16.Text || t25.Text == t17.Text || t25.Text == t18.Text
                    || t25.Text == t19.Text || t25.Text == t20.Text || t25.Text == t21.Text
                    || t25.Text == t22.Text || t25.Text == t23.Text || t25.Text == t24.Text
                    || t25.Text == t26.Text || t25.Text == t27.Text || t25.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t25.Text = "25";
                }
                else
                {
                    Red();
                    D4.Visible = true;
                    PD4.Visible = false;
                }
            }
        }

        private void t24_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            D4.Visible = false;
            PD4.Visible = true;
            txtCarNumber.Text = t25.Text;
            t25.Text = "25";
        }

        private void t25_MouseClick(object sender, MouseEventArgs e)
        {
            strCompare();
            if (txtCarNumber.Text != t26.Text && D5.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t26.Text = txtCarNumber.Text;
                if (t26.Text == t1.Text || t26.Text == t2.Text || t26.Text == t3.Text
                    || t26.Text == t4.Text || t26.Text == t5.Text || t26.Text == t6.Text
                    || t26.Text == t7.Text || t26.Text == t8.Text || t26.Text == t9.Text
                    || t26.Text == t10.Text || t26.Text == t11.Text || t26.Text == t12.Text
                    || t26.Text == t13.Text || t26.Text == t14.Text || t26.Text == t15.Text
                    || t26.Text == t16.Text || t26.Text == t17.Text || t26.Text == t18.Text
                    || t26.Text == t19.Text || t26.Text == t20.Text || t26.Text == t21.Text
                    || t26.Text == t22.Text || t26.Text == t23.Text || t26.Text == t24.Text
                    || t26.Text == t25.Text || t26.Text == t27.Text || t26.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t26.Text = "26";
                }
                else
                {
                    Red();
                    D5.Visible = true;
                    PD5.Visible = false;
                }
            }
        }

        private void t25_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            D5.Visible = false;
            PD5.Visible = true;
            txtCarNumber.Text = t26.Text;
            t26.Text = "26";
        }

        private void t26_MouseClick(object sender, MouseEventArgs e)
        {
            strCompare();
            if (txtCarNumber.Text != t27.Text && D6.Visible == true || txtCarNumber.Text == "") MessageBox.Show("주차가 불가능합니다.");
            else
            {
                t27.Text = txtCarNumber.Text;
                if (t27.Text == t1.Text || t27.Text == t2.Text || t27.Text == t3.Text
                    || t27.Text == t4.Text || t27.Text == t5.Text || t27.Text == t6.Text
                    || t27.Text == t7.Text || t27.Text == t8.Text || t27.Text == t9.Text
                    || t27.Text == t10.Text || t27.Text == t11.Text || t27.Text == t12.Text
                    || t27.Text == t13.Text || t27.Text == t14.Text || t27.Text == t15.Text
                    || t27.Text == t16.Text || t27.Text == t17.Text || t27.Text == t18.Text
                    || t27.Text == t19.Text || t27.Text == t20.Text || t27.Text == t21.Text
                    || t27.Text == t22.Text || t27.Text == t23.Text || t27.Text == t24.Text
                    || t27.Text == t25.Text || t27.Text == t26.Text || t27.Text == t28.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t27.Text = "27";
                }
                else
                {
                    Red();
                    D6.Visible = true;
                    PD6.Visible = false;
                }
            }
        }

        private void t26_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            D6.Visible = false;
            PD6.Visible = true;
            txtCarNumber.Text = t27.Text;
            t27.Text = "27";
        }

        private void t27_MouseClick(object sender, MouseEventArgs e)
        {
            strCompare();
            if (txtCarNumber.Text != t28.Text && D7.Visible == true || txtCarNumber.Text == "") MessageBox.Show("차량 번호를 입력해주세요.");
            else
            {
                t28.Text = txtCarNumber.Text;
                if (t28.Text == t1.Text || t28.Text == t2.Text || t28.Text == t3.Text
                    || t28.Text == t4.Text || t28.Text == t5.Text || t28.Text == t6.Text
                    || t28.Text == t7.Text || t28.Text == t8.Text || t28.Text == t9.Text
                    || t28.Text == t10.Text || t28.Text == t11.Text || t28.Text == t12.Text
                    || t28.Text == t13.Text || t28.Text == t14.Text || t28.Text == t15.Text
                    || t28.Text == t16.Text || t28.Text == t17.Text || t28.Text == t18.Text
                    || t28.Text == t19.Text || t28.Text == t20.Text || t28.Text == t21.Text
                    || t28.Text == t22.Text || t28.Text == t23.Text || t28.Text == t24.Text
                    || t28.Text == t25.Text || t28.Text == t26.Text || t28.Text == t27.Text)
                {
                    MessageBox.Show("해당 차량은 이미 주차가 되어있습니다.");
                    t28.Text = "28";
                }
                else
                {
                    Red();
                    D7.Visible = true;
                    PD7.Visible = false;
                }
            }
        }

        private void t27_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Blue();
            D7.Visible = false;
            PD7.Visible = true;
            txtCarNumber.Text = t28.Text;
            t28.Text = "28";
        }

        private void t1_MouseHover(object sender, EventArgs e)
        {
            White();

            if (A2.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (A2.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t2_MouseHover(object sender, EventArgs e)
        {
            White();

            if (A3.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (A3.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t3_MouseHover(object sender, EventArgs e)
        {
            White();

            if (A4.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (A4.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t4_MouseHover(object sender, EventArgs e)
        {
            White();

            if (A5.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (A5.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t5_MouseHover(object sender, EventArgs e)
        {
            White();

            if (A6.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (A6.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t6_MouseHover(object sender, EventArgs e)
        {
            White();

            if (A7.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (A7.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t7_MouseHover(object sender, EventArgs e)
        {
            White();

            if (B1.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (B1.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t8_MouseHover(object sender, EventArgs e)
        {
            White();

            if (B2.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (B2.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t9_MouseHover(object sender, EventArgs e)
        {
            White();

            if (B3.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (B3.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t10_MouseHover(object sender, EventArgs e)
        {
            White();

            if (B4.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (B4.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t11_MouseHover(object sender, EventArgs e)
        {
            White();

            if (B5.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (B5.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t12_MouseHover(object sender, EventArgs e)
        {
            White();

            if (B6.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (B6.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t13_MouseHover(object sender, EventArgs e)
        {
            White();

            if (B7.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (B7.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t14_MouseHover(object sender, EventArgs e)
        {
            White();

            if (C1.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (C1.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t15_MouseHover(object sender, EventArgs e)
        {
            White();

            if (C2.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (C2.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t16_MouseHover(object sender, EventArgs e)
        {
            White();

            if (C3.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (C3.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t17_MouseHover(object sender, EventArgs e)
        {
            White();

            if (C4.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (C4.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t18_MouseHover(object sender, EventArgs e)
        {
            White();

            if (C5.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (C5.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t19_MouseHover(object sender, EventArgs e)
        {
            White();

            if (C6.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (C6.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t20_MouseHover(object sender, EventArgs e)
        {
            White();

            if (C7.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (C7.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t21_MouseHover(object sender, EventArgs e)
        {
            White();

            if (D1.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (D1.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t22_MouseHover(object sender, EventArgs e)
        {
            White();

            if (D2.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (D2.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t23_MouseHover(object sender, EventArgs e)
        {
            White();

            if (D3.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (D3.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t24_MouseHover(object sender, EventArgs e)
        {
            White();

            if (D4.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (D4.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t25_MouseHover(object sender, EventArgs e)
        {
            White();

            if (D5.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (D5.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t26_MouseHover(object sender, EventArgs e)
        {
            White();

            if (D6.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (D6.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }

        private void t27_MouseHover(object sender, EventArgs e)
        {
            White();

            if (D7.Visible == true)
            {
                RedBox.BackColor = Color.Red;
            }
            else if (D7.Visible == false)
            {
                BlueBox.BackColor = Color.Blue;
            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtCarNumber.Text == "") MessageBox.Show("번호를 입력해주세요");
            else
            {
                RegisterPark register = new RegisterPark();
                register.ShowDialog();
                register.Dispose();
            } 
        }
    }
}
