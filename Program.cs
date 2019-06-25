using System;
using System.IO;
using System.Text;

namespace clean_gen
{
    class MainClass
    {
		public static char[] Newlines = new char[] { ' ', '\r', '\n', '\t' };
		public static string Format = @"adb shell pm uninstall -k --user 0 {0}";

		public static string CleanStr(string App)
		{
			string str = String.Format(Format, App);
			return str;
		}
        public static string CleanText(string[] Apps)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < Apps.Length;++i)
			{
				string App = Apps[i];
				string str = CleanStr(App);
				sb.AppendLine(str);
			}
			Console.WriteLine(sb.ToString());
			return sb.ToString();
		}
        public static void Main(string[] args)
        {
			string Text=File.ReadAllText("programs.txt");
			string[] Apps = Text.Split(Newlines, StringSplitOptions.RemoveEmptyEntries);
			Array.Sort(Apps);
			CleanText(Apps);
        }
    }
}
