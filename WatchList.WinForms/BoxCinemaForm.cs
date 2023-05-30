using MaterialSkin.Controls;
using WatchList.Core.Model.Filter.Components;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.PageItem;
using WatchList.Core.Repository.DbContext;
using WatchList.WinForms.BindingItem.ModelBoxForm;
using WatchList.WinForms.ChildForms.Extension;
using WatchList.WinForms.EditorForm;

namespace WatchList.WinForms
{
    /// <summary>
    /// This is the main form class.
    /// </summary>
    public partial class BoxCinemaForm : MaterialForm
    {
        private const int IndexColumnName = 0;
        private const int IndexColumnSequel = 1;
        private const int IndexColumnStatus = 2;
        private const int IndexColumnDate = 3;
        private const int IndexColumnGrade = 4;
        private const int IndexColumnId = 5;
        private const int IndexColumnType = 6;

        private readonly WatchItemService _itemService;

        private WatchItemSearchRequest _searchRequest = new WatchItemSearchRequest();

        private PagedList<WatchItem> _pagedList;

        public BoxCinemaForm(WatchCinemaDbContext db)
        {
            InitializeComponent();

            _itemService = new WatchItemService(db);
            _pagedList = _itemService.GetPageList(_searchRequest);

            Load += BoxCinemaForm_Load;
        }

        private FilterModel Filter { get; set; } = new FilterModel();

        private PageModel Page { get; set; } = new PageModel();

        private SortModel Sort { get; set; } = new SortModel();

        private void BoxCinemaForm_Load(object? sender, EventArgs e)
        {
            cmbFilterType.DataSource = Filter.TypeItem;
            cmbFilterStatus.DataSource = Filter.StatusItem;
            cmbPageSize.DataSource = Page.Items;
            cmbSortType.DataSource = Sort.Items;
            cmbSortType.SelectedItem = Sort.Type;
            filterModelBindingSource.DataSource = Filter;
        }

        private void BtnUseFilter_Click(object sender, EventArgs e)
        {
            if (!IsNotChangesFilter() || IsChangedSizePage())
            {
                Page.Number = 1;
                WriteDataToTable();
            }
        }

        private void BtnCancelFilter_Click(object sender, EventArgs e)
        {
            cmbFilterType.SelectedItem = TypeFilter.AllCinema;
            cmbFilterStatus.SelectedItem = StatusFilter.AllCinema;
            Filter.Type = TypeFilter.AllCinema;
            Filter.Status = StatusFilter.AllCinema;
            cmbFilterType.Refresh();
            cmbFilterStatus.Refresh();
        }

        private void BtnAddCinema_Click(object sender, EventArgs e)
        {
            var addForm = new AddCinemaForm();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                var itemCinema = addForm.GetCinema();
                _itemService.AddItemToDatabase(itemCinema);
            }

            WriteDataToTable();
        }

        private void BtnEditRow_Click(object sender, EventArgs e)
        {
            if (IsEditRowGrid(out CinemaModel? oldItem) && oldItem != null)
            {
                var editItemForm = new EditorItemCinemaForm(oldItem);

                if (editItemForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var changeItemCinema = editItemForm.GetEditItemCinema();
                _itemService.EditItemToDatabase(oldItem, changeItemCinema);
            }

            WriteDataToTable();
        }

        private void BtnDeleteMovie_Click(object sender, EventArgs e)
        {
            if (RemoveRowGrid(out var idItem))
            {
                if (!Guid.TryParse(idItem, out var id))
                {
                    return;
                }

                _itemService.Remove(id);
                LoadData();
            }
        }

        private void BtnReplaceFile_Click(object sender, EventArgs e)
        {
            var openReplaceDataFromFile = new OpenFileDialog { Filter = "Data Base (*.db)|*.db" };
            if (openReplaceDataFromFile.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            _itemService.ReplaceDataFromNewFile(openReplaceDataFromFile.FileName);
            WriteDataToTable();
        }

        private void BtnBackPage_Click(object sender, EventArgs e)
        {
            if (_pagedList.HasPreviousPage)
            {
                Page.Number--;
                LoadData();
            }
        }

        private void BtnStartPage_Click(object sender, EventArgs e)
        {
            if (_pagedList.HasPreviousPage)
            {
                Page.Number = 1;
                LoadData();
            }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            if (_pagedList.HasNextPage)
            {
                Page.Number++;
                LoadData();
            }
        }

        private void BtnEndPage_Click(object sender, EventArgs e)
        {
            if (_pagedList.HasNextPage)
            {
                Page.Number = _pagedList.PageCount;
                LoadData();
            }
        }

        private void CmbPageSize_Changed(object sender, EventArgs e)
        {
            var pageSizeCmb = SelectedPageSize();

            if (Page.ChangedPage(pageSizeCmb))
            {
                Page.Size = pageSizeCmb;
                Page.Number = 1;
                LoadData();
            }
        }

        private void CmbSort_ChangedItem(object sender, EventArgs e)
        {
            Sort.Type = Sort.Items[cmbSortType.SelectedIndex];
            LoadData();
        }

        private void TextBoxPage_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxPage.Text, out int pageNumber)
                || pageNumber > _pagedList.PageCount
                || _pagedList.PageNumber == Page.Number)
            {
                textBoxPage.Text = _pagedList.PageNumber.ToString();
                return;
            }

            Page.Number = pageNumber;
            LoadData();
        }

        /// <summary>
        /// Deleting a row of table data.
        /// Out ID in delete from another table.
        /// </summary>
        /// <param name="id">Object ID to delete.</param>
        /// <returns>Is item remove.</returns>
        private bool RemoveRowGrid(out string id)
        {
            if (dgvCinema.SelectedRows.Count == 0)
            {
                id = string.Empty;
                MessageBoxProvider.ShowWarning("Highlight the desired line.");
                return false;
            }

            id = SelectedRowCinemaId();
            RemoveItemRowGrid(id);

            return true;
        }

        /// <summary>
        /// Get ID on the selected line table.
        /// </summary>
        /// <returns> ID. </returns>
        private string SelectedRowCinemaId()
        {
            var rowIndex = dgvCinema.CurrentCell.RowIndex;
            var id = dgvCinema.Rows[rowIndex].Cells[IndexColumnId].Value;
            return id.ToString() ?? string.Empty;
        }

        /// <summary>
        /// Delete line table by Id.
        /// </summary>
        /// <param name="id">Object ID to delete.</param>
        private void RemoveItemRowGrid(string? id)
        {
            if (dgvCinema.RowCount == 0)
            {
                MessageBoxProvider.ShowError("The element is missing from the table.");
            }

            foreach (DataGridViewRow row in dgvCinema.Rows)
            {
                if (row.Cells[IndexColumnId].Value.ToString() == id)
                {
                    dgvCinema.Rows.RemoveAt(row.Index);
                    break;
                }
            }
        }

        /// <summary>
        /// Filling the table with data.
        /// </summary>
        /// <param name="itemGrid">List of elements.</param>
        private void AddCinemaGrid(List<WatchItem> itemGrid)
        {
            foreach (var item in itemGrid)
            {
                var intSequel = item.Sequel;
                var formatDate = item.GetWatchData();
                dgvCinema.Rows.Add(item.Title, intSequel.ToString(), item.Status.Name, formatDate, item.Grade, item.Id.ToString(), item.Type);
            }
        }

        /// <summary>
        /// Edit the selected item.
        /// </summary>
        /// <param name="cinemaItem">Element to change.</param>
        /// <returns>
        /// True:Row selected.
        /// False:Row not selected.
        /// </returns>
        private bool IsEditRowGrid(out CinemaModel? cinemaItem)
        {
            if (dgvCinema.SelectedRows.Count == 0)
            {
                cinemaItem = null;
                MessageBoxProvider.ShowWarning("Highlight the desired line");
                return false;
            }

            var rowIndex = dgvCinema.CurrentCell.RowIndex;
            cinemaItem = GetItem(rowIndex);
            return true;
        }

        /// <summary>
        /// Get item by ID from the table.
        /// </summary>
        /// <param name="indexRow">Number row element.</param>
        /// <returns>
        /// The filling of all fields of the element depends on the data in the table.
        /// Type: CinemaModel.
        /// </returns>
        private CinemaModel GetItem(int indexRow)
        {
            var rowItems = dgvCinema.Rows[indexRow];
            var title = CellElement(rowItems, IndexColumnName) ?? throw new ArgumentException("Name cannot be null.");

            CellElement(rowItems, IndexColumnSequel).ParseInt(out int sequel);
            CellElement(rowItems, IndexColumnId).ParseGuid(out Guid id);

            var type = TypeCinema.FromName(CellElement(rowItems, IndexColumnType));
            var strDateWatch = CellElement(rowItems, IndexColumnDate);
            var status = StatusCinema.FromName(CellElement(rowItems, IndexColumnStatus));

            if (status == StatusCinema.Planned)
            {
                return CinemaModel.CreatePlanned(title, sequel, status, type, id);
            }

            CellElement(rowItems, IndexColumnGrade).ParseDecimal(out decimal grade);
            DateTime? dateWatch = status == StatusCinema.Viewed && strDateWatch != null ? DateTime.Parse(strDateWatch) : null;

            return CinemaModel.CreateNonPlanned(title, sequel, dateWatch, grade, status, type, id);
        }

        private string? CellElement(DataGridViewRow rowItem, int indexColumn) => rowItem.Cells[indexColumn].Value.ToString() ?? throw new Exception("String cannot be null.");

        /// <summary>
        /// Filling in tabular data from a file.
        /// </summary>
        /// <param name="grid">Table to fill.</param>
        private void LoadData()
        {
            try
            {
                _searchRequest.Page = Page.GetPage();
                _searchRequest.Sort = Sort.GetSortItem();
                _pagedList = _itemService.GetPageList(_searchRequest);
                var item = _pagedList.Items;

                GridClear();
                AddCinemaGrid(item);
                CustomUpdateFormState();

                labelTotalPage.Text = labelTotalPage.Text = string.Format("/{0}", Math.Max(_pagedList.PageCount, 1).ToString());
                textBoxPage.Text = _pagedList.PageNumber.ToString();
            }
            catch (Exception error)
            {
                MessageBoxProvider.ShowError(error.Message);
            }
        }

        private void GridClear() => dgvCinema.Rows.Clear();

        private void WriteDataToTable()
        {
            _searchRequest = new WatchItemSearchRequest(Filter.GetFilter(), Sort.GetSortItem(), Page.GetPage());
            LoadData();
        }

        private void CustomUpdateFormState()
        {
            var hasPageControl = _pagedList.PageCount > 0 ? true : false;

            btnBackPage.Enabled = btnEndPage.Enabled = btnNextPage.Enabled = btnStartPage.Enabled = labelTotalPage.Enabled = textBoxPage.Enabled = hasPageControl;
        }

        private bool IsNotChangesFilter() => _searchRequest.CompareFilter(Filter.GetFilter());

        private bool IsChangedSizePage() => _searchRequest.Page.Size != Page.Size;

        private int SelectedPageSize() => Page.Items[cmbPageSize.SelectedIndex];
    }
}
