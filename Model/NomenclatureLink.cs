using System.Text;

namespace EventPlanning.Model
{
    public class NomenclatureLink : Root
    {
        private string _link = "";
        public string Link 
        { 
            get { return _link; } 
            set { SetLink(value); } 
        }
        public NomenclatureLink() 
        {
            Link ??= "";
        }

        private void SetLink(string link) 
        {
            _link = link;
            if (Name == null || Name == "Ссылка" || Name == "")
            {
                Name = FillName(link).GetAwaiter().GetResult();
            }
        }
        static async Task<string> FillName(string link) 
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            string html;
            string title = "Ссылка";
            try
            {
                var result = await client.GetAsync(link);
                using (var sr = new StreamReader(await result.Content.ReadAsStreamAsync()))
                {
                    string htmltitle = "";
                    html = sr.ReadToEnd();
                    if (html.Contains("<title>"))
                    {
                        htmltitle = html.Substring(html.IndexOf("<title>") + 7);
                        htmltitle = htmltitle.Remove(htmltitle.IndexOf("</title>")).Trim();
                    }
                    if (htmltitle != "") title = htmltitle;
                }
            }
            catch (Exception e) 
            { 
            }
            return title;
        }
 
    }
}
