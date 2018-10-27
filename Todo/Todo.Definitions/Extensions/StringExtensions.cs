using System.Text;
using HtmlAgilityPack;

namespace System
{
    public static class StringExtensions
	{
		public static string RemoveAllHtml(this string content)
		{
			var doc = new HtmlDocument();
			doc.LoadHtml(content);

			var root = doc.DocumentNode;
			var newContent = new StringBuilder();

			foreach (var node in root.DescendantsAndSelf())
			{
				if (!node.HasChildNodes)
				{
					string text = node.InnerText;
					if (!string.IsNullOrEmpty(text))
						newContent.AppendLine(text.Trim());
				}
			}

			return newContent.ToString().Replace("\\n", "\r\n");
		}
	}
}
