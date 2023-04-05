using Movie.BLL;

namespace Movie.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgwMovies.DataSource = MovieController.GetFilms();
            cbCategories.DataSource=MovieController.GetCategories();
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbCategories.SelectedIndex;
            string searchingWords = tbSearching.Text;
            if (tbSearching.Text==null)
            {
                MovieController.GetFilmsByCategory(selectedIndex);
            }
            else
            {               
                dgwMovies.DataSource = MovieController.GetSearchedFilms(searchingWords, selectedIndex);
            }
            
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            int selectedIndex = cbCategories.SelectedIndex;
            string searchingWords = tbSearching.Text;
            if (tbSearching.Text == null)
            {
                MovieController.GetFilmsByCategory(selectedIndex);
            }
            else
            {
                dgwMovies.DataSource = MovieController.GetSearchedFilms(searchingWords, selectedIndex);
            }
        }
    }
}