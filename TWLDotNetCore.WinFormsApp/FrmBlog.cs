using System.Data.SqlClient;
using System.Data;
using System.Drawing.Text;
using TWLDotNetCore.Shared;
using TWLDotNetCore.WinFormsApp.Models;
using TWLDotNetCore.WinFormsApp.Queries;

namespace TWLDotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        private readonly DapperService _dapperService;
        private readonly int _blogId;

        public FrmBlog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        public FrmBlog(int blogId)
        {
            InitializeComponent();
            _blogId = blogId;
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            var model = _dapperService.QueryFirstOrDefault<BlogModel>("select * from tbl_blog where BlogId = @BlogId", new { BlogId = _blogId });

            txtTitle.Text = model.BlogTitle;
            txtAuthor.Text = model.BlogAuthor;
            txtContent.Text = model.BlogContent;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }        

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel();
                blog.BlogTitle = txtTitle.Text.Trim();
                blog.BlogAuthor = txtAuthor.Text.Trim();
                blog.BlogContent = txtContent.Text.Trim();

                int result = _dapperService.Execute(BlogQuery.CreateBlog, blog);

                string message = result > 0 ? "Saving Success!" : "Saving Failed!";
                var messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;

                MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messageBoxIcon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new BlogModel
                {
                    BlogId = _blogId,
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogAuthor = txtAuthor.Text.Trim(),
                    BlogContent = txtContent.Text.Trim()

                };

                int result = _dapperService.Execute(BlogQuery.UpdateBlog, item);
                string message = result > 0 ? "Updating Success!" : "Updating Failed!";
                MessageBox.Show(message);
                this.Close();   
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }   

       
    }
}