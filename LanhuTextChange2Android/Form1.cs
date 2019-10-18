using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LanhuTextChange2Android
{


 


    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = getClipboardText();

            if (text==null || text.Length==0)
            {
                textBoxInfo.Text = "【剪贴板内容为空】";
            }
            else {
                string str = text2Ui(text);
                if (str == null)
                {
                    btnGenerate_Click(null, null);
                }
                else {
                    textBoxInfo.Text = str;
                }
            }
        }

        private string text2Ui(string text) {
            int index = text.IndexOf("字重");
            if (index == -1)
            {
                return "非标准文本";
            }

            if (text.Substring(index).IndexOf("px") == -1) {

                return "请选择页面的“像素”选项";
            }
            try
            {
                string boldText = findText(text, "字重", "\r\n");
                checkBoxTextBold.Checked = "BOLD".Equals(boldText.ToUpper());

                textBoxTextViewColor.Text = findText(text, "颜色\r\n#", " ");

                textBoxTextSize.Text = findText(text, "字号\r\n", "px");

                //string lineSpaceText = findText(text, "字间距\r\n", "px");
                //style.lineSpaceExtra = int.Parse(lineSpaceText);
                textBoxTextView.Text = findText(text, "内容", "\r\n");
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }



        public string findText(string source, string start, string end) {
            int index = source.IndexOf(start);
            if (index != -1)
            {
                source = source.Substring(index + start.Length);
                int index2 = source.IndexOf(end);
                if (index2 != -1) {
                    return source.Substring(0, index2);
                }
            }
            return null;
        }





        private string getClipboardText() {

            try
            {
                if (Clipboard.ContainsText())
                {
                    string clipText = Clipboard.GetText();
                    return clipText;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxInfo.Text);
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            deftaultSetting(); 

            radioButtonControl = radioButtonTextView;


        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            deftaultSetting();

        }
        private void deftaultSetting() {
            textBoxInfo.Text = "";
            radioButtonTextView.Checked = true;

            rbWidthWrap.Checked = true;

            rbHeightWrap.Checked = true;
            radioButtonBgColor.Checked = true;
             checkBoxPaddingBottom.Checked = checkBoxPaddingTop.Checked = checkBoxPaddingRight.Checked = checkBoxPaddingLeft.Checked = checkBoxPadding.Checked = checkBoxLayoutGravity.Checked = checkBoxGravity.Checked = checkBoxTextBold.Checked = checkBoxBg.Checked = checkBoxId.Checked = false;
            
        }

        TextBox textBoxCur;


        private void btnNum10_Click(object sender, EventArgs e)
        {
            onNumClick(10);
        }


        private void onNumClick(int num) {
            if (textBoxCur != null)
            {
                textBoxCur.Text = num + "";
            }
            else {
                MessageBox.Show("请先选择编辑框");
            }
        }

        private void etWidthPoint_Enter(object sender, EventArgs e)
        {
            textBoxCur = (TextBox)sender;
        }

        private void btnNum30_Click(object sender, EventArgs e)
        {
            onNumClick(30);
        }

        private void btnNum40_Click(object sender, EventArgs e)
        {
            onNumClick(40);
        }

        private void btnNum50_Click(object sender, EventArgs e)
        {
            onNumClick(50);
        }

        private void btnNum60_Click(object sender, EventArgs e)
        {
            onNumClick(60);
        }

        private void btnNum20_Click(object sender, EventArgs e)
        {
            onNumClick(20);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (textBoxCur != null)
            {
                try
                {
                    int data = int.Parse(textBoxCur.Text);
                    textBoxCur.Text = (data + 1) + "";
                }
                catch (Exception)
                {
                    textBoxCur.Text = "1";
                }
            }
            else
            {
                MessageBox.Show("请先选择编辑框");
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (textBoxCur != null)
            {
                try
                {
                    int data = int.Parse(textBoxCur.Text);
                    textBoxCur.Text = (data - 1) + "";
                }
                catch (Exception)
                {
                    textBoxCur.Text = "0";
                }
            }
            else
            {
                MessageBox.Show("请先选择编辑框");
            }
        }

        RadioButton radioButtonControl;

        private void radioButtonTextView_CheckedChanged(object sender, EventArgs e)
        {
            textBoxIdPreName.Text = "tv";

            radioButtonControl = (RadioButton)sender;
        }

        private void radioButtonImageView_CheckedChanged(object sender, EventArgs e)
        {
            textBoxIdPreName.Text = "iv";
            radioButtonControl = (RadioButton)sender;
        }

        private void radioButtonBgView_CheckedChanged(object sender, EventArgs e)
        {
            textBoxIdPreName.Text = "tv";
            radioButtonControl = (RadioButton)sender;
        }

        private void radioButtonListView_CheckedChanged(object sender, EventArgs e)
        {
            textBoxIdPreName.Text = "listView";
            radioButtonControl = (RadioButton)sender;
        }

        private void radioButtonTitleBar_CheckedChanged(object sender, EventArgs e)
        {
            textBoxIdPreName.Text = "titleBar";
            radioButtonControl = (RadioButton)sender;
        }

        private void radioButtonView_CheckedChanged(object sender, EventArgs e)
        {
            textBoxIdPreName.Text = "view";
            radioButtonControl = (RadioButton)sender;
        }

        private void radioButtonLine_CheckedChanged(object sender, EventArgs e)
        {
            textBoxIdPreName.Text = "line";
            radioButtonControl = (RadioButton)sender;
        }

        private void radioButtonLinear_CheckedChanged(object sender, EventArgs e)
        {
            textBoxIdPreName.Text = "ll";
            radioButtonControl = (RadioButton)sender;
        }

        private void radioButtonRelative_CheckedChanged(object sender, EventArgs e)
        {
            textBoxIdPreName.Text = "ll";
            radioButtonControl = (RadioButton)sender;
        }

        private void radioButtonFrame_CheckedChanged(object sender, EventArgs e)
        {
            textBoxIdPreName.Text = "ll";
            radioButtonControl = (RadioButton)sender;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ViewStyleItem item = new ViewStyleItem();


            item.controlName = radioButtonControl.Text;
            if (radioButtonControl == radioButtonBgView)
            {
                item.controlName = "com.hd.view.roundrect.ShapeCornerBgView";
            }
            else if (radioButtonControl == radioButtonListView)
            {
                item.controlName = "com.hd.view.listview.PulltoRefreshAAMListView";
            }
            else if (radioButtonControl == radioButtonTitleBar) {
                item.controlName = "com.hd.view.TitleBar";
            }

            if (rbWidthWrap.Checked)
            {
                item.width = ViewStyleItem.WRAP_CONTENT;
            }
            else if (rbWidthMatch.Checked)
            {
                item.width = ViewStyleItem.MATCH_PARENT;
            }
            else
            {
                item.width = getOKText(etWidthPoint, "defaultBtnHeight");
            }

            if (rbHeightWrap.Checked)
            {
                item.height = ViewStyleItem.WRAP_CONTENT;
            }
            else if (rbHeightMatch.Checked)
            {
                item.height = ViewStyleItem.MATCH_PARENT;
            }
            else
            {
                item.height = getOKText(etHeightPoint,  "defaultBtnHeight");
            }

            if (radioButtonControl == radioButtonTextView|| radioButtonControl==radioButtonEditText) {
                item.isText = true;
                item.text = textBoxTextView.Text;
                item.textSize = textBoxTextSize.Text;
                item.isBold = checkBoxTextBold.Checked;
                item.textColor = textBoxTextViewColor.Text;
                if (checkBoxLineSpaceExtra.Checked) {
                    item.lineSpaceExtra = getOKText(textBoxLineSpace,"n10px");
                }
                if (checkBoxDrawablePadding.Checked) {
                    item.drawablePadding = getOKText(textBoxDrawablePadding, "defaultDrawablePadding");
                }
            }

            if (radioButtonControl == radioButtonLinear || radioButtonControl == radioButtonRelative || radioButtonControl == radioButtonFrame) {
                item.isContainer = true;
            }



            if (checkBoxId.Checked) {
                if (textBoxIdName.Text.Length > 0)
                {
                    item.id = textBoxIdPreName.Text + textBoxIdName.Text[0].ToString().ToUpper() + textBoxIdName.Text.Substring(1);
                }
                else {
                    item.id = textBoxIdPreName.Text;
                }
            }


            if (checkBoxBg.Checked) {

                if (radioButtonBgColor.Checked)
                {
                    item.background = "@color/white";
                }
                else if (radioButtonBgDrawable.Checked)
                {
                    item.background = "@drawable/";
                }
                else {
                    item.background = "@mipmap/";
                }
            }

            if (checkBoxGravity.Checked) {
                CheckBox[] boxs = { checkBoxGCenter , checkBoxGRight , checkBoxGBottom , checkBoxGVertical , checkBoxGHorizontal };
                StringBuilder builder = new StringBuilder();
                foreach (CheckBox box in boxs) {
               
                    if (box.Checked) {

                        if (builder.Length > 0)
                        {
                            builder.Append("|");
                        }
                        builder.Append(box.Text);
                    }
                }
                item.gravity = builder.ToString();
            }


            if (checkBoxLayoutGravity.Checked)
            {
                CheckBox[] boxs = { checkBoxLCenter, checkBoxLRight, checkBoxLBottom, checkBoxLVertical, checkBoxLHorizontal };
                StringBuilder builder = new StringBuilder();
                foreach (CheckBox box in boxs)
                {
            
                    if (box.Checked)
                    {
                        if (builder.Length > 0)
                        {
                            builder.Append("|");
                        }

                        builder.Append(box.Text);
                    }
                }
                item.layout_gravity = builder.ToString();
            }

            if (checkBoxPadding.Checked) {
                item.padding = getOKText(textBoxPadding, "defaultPadding");
            }
            if (checkBoxPaddingLeft.Checked)
            {
                item.padding_left = getOKText(textBoxPaddingLeft, "defaultPadding");
            }
            if (checkBoxPaddingRight.Checked)
            {
                item.padding_right = getOKText(textBoxPaddingRight, "defaultPadding");
            }
            if (checkBoxPaddingTop.Checked)
            {
                item.padding_top = getOKText(textBoxPaddingTop, "defaultPadding");
            }

            if (checkBoxPaddingBottom.Checked)
            {
                item.padding_bottom = getOKText(textBoxPaddingBottom, "defaultPadding");
            }
            textBoxInfo.Text = item.ToString();

            copyData2ClipBoard();
        }


        private void copyData2ClipBoard() {
            if (textBoxInfo.TextLength > 0)
                Clipboard.SetText(textBoxInfo.Text);
        }



        public string getOKText(TextBox tb,string deftalutText){
            bool isOK=isNumber(tb.Text);
            if (isOK) {
                return string.Format("@dimen/n{0:S}px",tb.Text);
            }
            if (tb.Text.Length == 0) {
                return string.Format("@dimen/{0:S}", deftalutText);
            }
            return string.Format("@dimen/{0:S}", tb.Text);
        }



        public bool isNumber(string txt) {
            try {
                int a = int.Parse(txt);
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnNum100_Click(object sender, EventArgs e)
        {
            onNumClick(100);
        }

        private void btnNum150_Click(object sender, EventArgs e)
        {
            onNumClick(150);
        }

        private void btnNum200_Click(object sender, EventArgs e)
        {
            onNumClick(200);
        }

        private void btnNum300_Click(object sender, EventArgs e)
        {
            onNumClick(300);
        }

        private void btnNum500_Click(object sender, EventArgs e)
        {
            onNumClick(500);
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            string text= "<include layout=\"@layout/view_line_1_deep\" /> ";
            textBoxInfo.Text = text;
            copyData2ClipBoard();
        }

        private void radioButtonEditText_CheckedChanged(object sender, EventArgs e)
        {
            textBoxIdPreName.Text = "et";
            radioButtonControl = (RadioButton)sender;
        }

        private void buttonAdd10_Click(object sender, EventArgs e)
        {
            if (textBoxCur != null)
            {
                try
                {
                    int data = int.Parse(textBoxCur.Text);
                    textBoxCur.Text = (data + 10) + "";
                }
                catch (Exception)
                {
                    textBoxCur.Text = "10";
                }
            }
            else
            {
                MessageBox.Show("请先选择编辑框");
            }
        }

        private void buttonReduce10_Click(object sender, EventArgs e)
        {
            if (textBoxCur != null)
            {
                try
                {
                    int data = int.Parse(textBoxCur.Text);
                    textBoxCur.Text = (data - 10) + "";
                }
                catch (Exception)
                {
                    textBoxCur.Text = "0";
                }
            }
            else
            {
                MessageBox.Show("请先选择编辑框");
            }
        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            textBoxTextView.Text = "";
        }






        private const int WM_HOTKEY = 0x312; //窗口消息：热键
        private const int WM_CREATE = 0x1; //窗口消息：创建
        private const int WM_DESTROY = 0x2; //窗口消息：销毁

        private const int HotKeyID = 1; //热键ID（自定义）


        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);
            switch (msg.Msg)
            {
                case WM_HOTKEY: //窗口消息：热键
                    int tmpWParam = msg.WParam.ToInt32();
                    if (tmpWParam == HotKeyID)
                    {
                        KeyBoradEvent.keybd_event(Keys.ControlKey, 0, 0, 0);
                        KeyBoradEvent.keybd_event(Keys.A, 0, 0, 0);
                        KeyBoradEvent.keybd_event(Keys.C, 0, 0, 0);
                        KeyBoradEvent.keybd_event(Keys.ControlKey, 0, KeyBoradEvent.KEYEVENTF_KEYUP, 0);
                        Thread.Sleep(300);
                        button1_Click(null, null);
                    }
                    break;
                case WM_CREATE: //窗口消息：创建
                    SystemHotKey.RegHotKey(this.Handle, HotKeyID, SystemHotKey.KeyModifiers.None, Keys.F1);
                    break;
                case WM_DESTROY: //窗口消息：销毁
                    SystemHotKey.UnRegHotKey(this.Handle, HotKeyID); //销毁热键
                    break;
                default:
                    break;
            }
        }

    }

   

    }


   


   