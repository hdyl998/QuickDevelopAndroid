using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanhuTextChange2Android
{
   public class ViewStyleItem
    {

        public const string WRAP_CONTENT = "wrap_content";
        public const string MATCH_PARENT = "match_parent";


        public bool isBold;
        public string textColor;
        public string textSize;
        public string lineSpaceExtra;
        public string text;
        public string drawablePadding;




        public string id;
        public string background;

        public string gravity;
        public string layout_gravity;


        public string padding;
        public string padding_left;

        public string padding_right;

        public string padding_top;
        public string padding_bottom;

        public string width;
        public string height;

        public string controlName;



        public bool isText;

        public bool isContainer;


        public override string ToString()
        {


            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("<{0:s} ",controlName));


            if (id!=null) {
                builder.Append(string.Format("\r\nandroid:id=\"@+id/{0:S}\"", id));
            }

           


            builder.Append(string.Format("\r\nandroid:layout_width=\"{0:S}\"", width));
            builder.Append(string.Format("\r\nandroid:layout_height=\"{0:S}\"", height));


            if (background != null) {
                builder.Append(string.Format("\r\nandroid:background=\"{0:S}\"",background));
            }

            if (isText) { 
                if (text == "") {
                    text = "@string/app_default";
                }
                if (textColor == "")
                {
                    textColor = "defaultTextColor";
                }
                else {
                    textColor = "_"+textColor.ToUpper();
                }
                if (textSize == "")
                {
                    textSize = "defaultTextSize";
                }
                else {
                    try
                    {
                        int size = int.Parse(textSize);
                        if (size % 2 == 1)
                            size++;
                        textSize = string.Format("s{0:d}px", size);
                    }
                    catch (Exception) {
                   
                    }

                }



                builder.Append(string.Format("\r\nandroid:text=\"{0:S}\"", text));
                builder.Append(string.Format("\r\nandroid:textColor=\"@color/{0:S}\"", textColor));
                builder.Append(string.Format("\r\nandroid:textSize=\"@dimen/{0:S}\"", textSize));

                if (drawablePadding !=null) {
                    builder.Append(string.Format("\r\nandroid:drawablePadding=\"{0:S}\"", drawablePadding));
                }
                if (lineSpaceExtra != null) {
                    builder.Append(string.Format("\r\nandroid:lineSpacingExtra=\"{0:S}\"", lineSpaceExtra));
                }

                if (isBold)
                {
                    builder.Append("\r\nandroid:textStyle=\"bold\"");
                }
            }

            if (gravity != null) {

                builder.Append(string.Format("\r\nandroid:gravity=\"{0:S}\"", gravity));
            }
            if (layout_gravity != null) {
                builder.Append(string.Format("\r\nandroid:layout_gravity=\"{0:S}\"", layout_gravity));
            }

            if (padding != null) {
                builder.Append(string.Format("\r\nandroid:padding=\"{0:S}\"", padding));
            }

            if (padding_left != null)
            {
                builder.Append(string.Format("\r\nandroid:padding_left=\"{0:S}\"", padding_left));
            }

            if (padding_right != null)
            {
                builder.Append(string.Format("\r\nandroid:padding_right=\"{0:S}\"", padding_right));
            }
            if (padding_top != null)
            {
                builder.Append(string.Format("\r\nandroid:padding_top=\"{0:S}\"", padding_top));
            }

            if (padding_bottom != null)
            {
                builder.Append(string.Format("\r\nandroid:padding_bottom=\"{0:S}\"", padding_bottom));
            }

            if (isContainer) {
                builder.Append("\r\n> ");

                builder.Append(string.Format("\r\n</{0:S}> ",controlName));
            }
            else{
                builder.Append("\r\n/> ");
            }

        


            return builder.ToString();
        }

    }
}
