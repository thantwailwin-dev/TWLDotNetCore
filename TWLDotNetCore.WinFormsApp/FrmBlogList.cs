using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWLDotNetCore.Shared;
using TWLDotNetCore.WinFormsApp.Models;
using TWLDotNetCore.WinFormsApp.Queries;

namespace TWLDotNetCore.WinFormsApp
{

    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;
        private readonly int _edit = 1;
        private readonly int _delete = 2;
        public FrmBlogList()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            BlogList();
        }

        private void BlogList()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(BlogQuery.SelectBlog);
            dgvData.DataSource = lst;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            MessageBox.Show($"{(int)EnumFormControlType.Edit}");
            MessageBox.Show($"{e.ColumnIndex}");

            if (e.RowIndex == -1) return;

            #region if

            var blogId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value);

            if (e.ColumnIndex == (int)EnumFormControlType.Edit)
            {                
                FrmBlog frm = new FrmBlog(blogId);
                frm.ShowDialog();
                BlogList();
            }
            else if (e.ColumnIndex == (int)EnumFormControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogResult != DialogResult.Yes) return;
                
                DeleteBlog(blogId);                                
            }

            #endregion

            #region Switch Case

            /*int index = e.ColumnIndex;
            EnumFormControlType enumFormControlType = (EnumFormControlType)index;

            switch (enumFormControlType)
            {
                
                case EnumFormControlType.Edit:
                    FrmBlog frm = new FrmBlog(blogId);
                    frm.ShowDialog();
                    BlogList();
                    break;
                case EnumFormControlType.Delete:
                    var dialogResult = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult != DialogResult.Yes) return;

                    DeleteBlog(blogId);
                    break;
                case EnumFormControlType.None:                
                default:
                    MessageBox.Show("Invalid Case.");
                    break;
            }*/

            #endregion

            /*EnumFormControlType enumFormControlType = EnumFormControlType.None;
            switch (enumFormControlType)
            {
                case EnumFormControlType.None:
                    break;
                case EnumFormControlType.Edit:
                    break;
                case EnumFormControlType.Delete:
                    break;
                default:
                    break;
            }*/
        }

        private void DeleteBlog(int id)
        {            
            int result = _dapperService.Execute(BlogQuery.DeleteBlog, new { BlogId = id });

            string message = result > 0 ? "Deleting Success!" : "Deleting Failed!";
            MessageBox.Show(message);
            BlogList();
        }
    }
}
