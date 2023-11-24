using EntityManager.Data;
using EntityManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntityManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ArticleContext _db;
        public MainWindow()
        {
            _db = new ArticleContext();
            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            var name = NameCreateInput.Text;
            if (name.Trim() == "")
            {
                MessageBox.Show("Article name can't be empty");
                return;
            }
            _db.Articles.Add(new Article { Name = name });
            _db.SaveChanges();
            MessageBox.Show("Created new article.");
        }

        private void QueryBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Article> articles = _db.Articles.OrderByDescending(x => x.PubDate).ToList();
            ArticleBox.Text = "";
            foreach (var article in articles) 
                ArticleBox.Text += $"Id: {article.Id}\r\n" +
                                   $"Name: {article.Name}\r\n" +
                                   $"Publication Date: {article.PubDate}\r\n\r\n";
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (!int.TryParse(IdRemoveInp.Text, out id))
                return;
            var article = _db.Articles.FirstOrDefault(x => x.Id == id);
            if (article == null)
            {
                MessageBox.Show("No such article");
                return;
            }
            _db.Articles.Remove(article);
            _db.SaveChanges();
            MessageBox.Show($"Article {article.Id} successfully removed");
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (!int.TryParse(IdUpdateInp.Text, out id) || NameUpdateInp.Text.Trim() == "")
                return;
            var article = _db.Articles.FirstOrDefault(x => x.Id == id);
            if (article == null)
            {
                MessageBox.Show("No such article");
                return;
            }

            article.Name = NameUpdateInp.Text;
            _db.Articles.Update(article);
            _db.SaveChanges();
            MessageBox.Show($"Article {article.Id} successfully updated");
        }
    }
}
