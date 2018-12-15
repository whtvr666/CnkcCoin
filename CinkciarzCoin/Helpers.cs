using System;
using System.Windows.Forms;

namespace CinkciarzCoin
{
	public static class Helpers
	{
		public static void UpdateText(this TextBox txb, string text)
		{
			txb.Invoke((MethodInvoker)(() => txb.Text = text));
		}
	}
}