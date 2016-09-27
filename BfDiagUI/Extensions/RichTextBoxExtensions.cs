using BfDiagUI.API;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BfDiagUI
{
    public static class RichTextBoxExtensions
    {
        public static void GoToLine(this RichTextBox rtb, int lineNumber)
        {
            int currentLine = User32.SendMessage(rtb.Handle, User32.EM_GETFIRSTVISIBLELINE, 0, 0);
            User32.SendMessage(rtb.Handle, User32.EM_LINESCROLL, 0, lineNumber - currentLine - 1);
        }

        public static void Scroll(this RichTextBox rtb, int lineNumber)
        {
            int charIndex = rtb.GetFirstCharIndexFromLine(lineNumber - 1);
            rtb.Select(charIndex, 1);
            rtb.ScrollToCaret();
            rtb.Refresh();
        }

        public static int GetFirstVisibleLineNumber(this RichTextBox rtb)
        {
            int charIndex = rtb.GetCharIndexFromPosition(new Point(1,1));
            return rtb.GetLineFromCharIndex(charIndex) + 1;
        }
        
        public static int GetLineNumber(this RichTextBox rtb)
        {
            int charIndex = rtb.SelectionStart;
            return rtb.GetLineFromCharIndex(charIndex) + 1;
        }

        public static int GetColumnNumber(this RichTextBox rtb)
        {
            int rowStartIndex = User32.SendMessage(rtb.Handle, User32.EM_LINEINDEX, -1, 0);

            return rtb.SelectionStart - rowStartIndex + 1;
        }

        public struct Selection
        {
            public int Start;
            public int Length;
            public Color Color;

            public Selection(int start, int length, Color color)
            {
                this.Start = start;
                this.Length = length;
                this.Color = color;
            }
        }

        #region Native Functions
        // System.Windows.Forms.RichTextBox
        private static NativeMethods.CHARFORMATA GetCharFormat(this RichTextBox rtb, bool fSelection)
        {
            NativeMethods.CHARFORMATA cHARFORMATA = new NativeMethods.CHARFORMATA();
            UnsafeNativeMethods.SendMessage(new HandleRef(rtb, rtb.Handle), 1082, fSelection ? 1 : 0, cHARFORMATA);
            return cHARFORMATA;
        }
        #endregion

        public static void HighlightRTF(this RichTextBox rtb)
        {

            List<Selection> selections = new List<Selection>();

            try
            {
                int k = 0;

                string str = rtb.Text;

                int st, en;
                int lasten = -1;
                while (k < str.Length)
                {
                    st = str.IndexOf('<', k);

                    if (st < 0)
                        break;

                    if (lasten > 0)
                    {
                        selections.Add(new Selection(lasten + 1, st - lasten - 1, HighlightColors.HC_INNERTEXT));
                    }

                    en = str.IndexOf('>', st + 1);
                    if (en < 0)
                        break;

                    k = en + 1;
                    lasten = en;

                    if (str[st + 1] == '!')
                    {
                        selections.Add(new Selection(st + 1, st - 1, HighlightColors.HC_COMMENT));
                        continue;

                    }
                    String nodeText = str.Substring(st + 1, en - st - 1);


                    bool inString = false;

                    int lastSt = -1;
                    int state = 0;
                    /* 0 = before node name
                     * 1 = in node name
                       2 = after node name
                       3 = in attribute
                       4 = in string
                       */
                    int startNodeName = 0, startAtt = 0;
                    for (int i = 0; i < nodeText.Length; ++i)
                    {
                        if (nodeText[i] == '"')
                            inString = !inString;

                        if (inString && nodeText[i] == '"')
                            lastSt = i;
                        else
                            if (nodeText[i] == '"')
                            {
                                selections.Add(new Selection(lastSt + st + 2, i - lastSt - 1, HighlightColors.HC_STRING));
                            }

                        switch (state)
                        {
                            case 0:
                                if (!Char.IsWhiteSpace(nodeText, i))
                                {
                                    startNodeName = i;
                                    state = 1;
                                }
                                break;
                            case 1:
                                if (Char.IsWhiteSpace(nodeText, i))
                                {
                                    selections.Add(new Selection(startNodeName + st, i - startNodeName + 1, HighlightColors.HC_NODE));
                                    state = 2;
                                }
                                break;
                            case 2:
                                if (!Char.IsWhiteSpace(nodeText, i))
                                {
                                    startAtt = i;
                                    state = 3;
                                }
                                break;

                            case 3:
                                if (Char.IsWhiteSpace(nodeText, i) || nodeText[i] == '=')
                                {
                                    selections.Add(new Selection(startAtt + st, i - startAtt + 1, HighlightColors.HC_ATTRIBUTE));
                                    state = 4;
                                }
                                break;
                            case 4:
                                if (nodeText[i] == '"' && !inString)
                                    state = 2;
                                break;


                        }

                    }
                    if (state == 1)
                    {
                        selections.Add(new Selection(st + 1, nodeText.Length, HighlightColors.HC_NODE));
                    }
                }

                var groupSelectionsByColor = from s in selections
                                             group s by s.Color.Name into g
                                             orderby g.Key
                                             select g;


                rtb.SelectAll();
                rtb.SelectionColor = Color.Black;

                foreach (IGrouping<string, Selection> g in groupSelectionsByColor.Where(x => x.Key != Color.Black.Name))
                {
                    //this.ForceHandleCreate();
                    NativeMethods.CHARFORMATA charFormat = rtb.GetCharFormat(true);
                    charFormat.dwMask = 1073741824;
                    charFormat.dwEffects = 0;
                    charFormat.crTextColor = ColorTranslator.ToWin32(g.First().Color);

                    HandleRef handle = new HandleRef(rtb, rtb.Handle);
                    
                    foreach (Selection s in g)
                    {
                        rtb.Select(s.Start, s.Length);
                        UnsafeNativeMethods.SendMessage(handle, 1092, 1, charFormat);
                    }
                }

                //IEnumerable<Selection> mySelections = selections.OrderBy(x => x.Start);
                //foreach (var s in mySelections)
                //{
                //    rtb.Select(s.Start, s.Length);
                //    rtb.SelectionColor = s.Color;
                //}
            }

            finally
            {
            }
        }       
    }
}
