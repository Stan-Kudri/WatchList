using MaterialSkin.Controls;
using WatchList.Core.Model.Filter.Components;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Repository.Db;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Core.Service.DataLoading.Rules;
using WatchList.WinForms.BindingItem.ModelBoxForm;
using WatchList.WinForms.BuilderDbContext;
using WatchList.WinForms.ChildForms;
using WatchList.WinForms.ChildForms.Extension;
using WatchList.WinForms.Extension;
using WatchList.WinForms.Message;

namespace WatchList.WinForms
{
    /// <summary>
    /// This is the main form class.
    /// </summary>
    public partial class BoxCinemaForm : MaterialForm
    {
        private const string HighlightTheDesiredLine = "No items selected.";

        private const int IndexColumnName = 0;
        private const int IndexColumnSequel = 1;
        private const int IndexColumnStatus = 2;
        private const int IndexColumnDate = 3;
        private const int IndexColumnGrade = 4;
        private const int IndexColumnId = 5;
        private const int IndexColumnType = 6;

        private readonly WatchItemService _itemService;
        private readonly IMessageBox _messageBox;
        private readonly WatchCinemaDbContext _dbContext;

        private WatchItemSearchRequest _searchRequest = new WatchItemSearchRequest();

        private PagedList<WatchItem> _pagedList;

        public BoxCinemaForm(WatchCinemaDbContext db)
        {
            InitializeComponent();
            _dbContext = db;
            _messageBox = new MessageBoxShow();
            _itemService = new WatchItemService(db, _messageBox);
            _pagedList = _itemService.GetPage(_searchRequest);

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
                UpdateGridData();
            }
        }

        private void BtnCancelFilter_Click(object sender, EventArgs e)
        {
            cmbFilterType.SelectedItem = Filter.Type = TypeFilter.AllCinema;
            cmbFilterStatus.SelectedItem = Filter.Status = StatusFilter.AllCinema;
            cmbFilterType.Refresh();
            cmbFilterStatus.Refresh();
        }

        private void BtnAddCinema_Click(object sender, EventArgs e)
        {
            var addForm = new AddCinemaForm();

            if (addForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var itemCinema = addForm.GetCinema();
            _itemService.Add(itemCinema.ToWatchItem());

            UpdateGridData();
        }

        private void BtnEditRow_Click(object sender, EventArgs e)
        {
            var indexEditRow = GetSelectedRowIndexes();
            if (indexEditRow.Count == 1)
            {
                var oldItem = GetItem(indexEditRow.First());
                var updateForm = new EditorItemCinemaForm(oldItem);

                if (updateForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var updateItem = updateForm.GetEditItemCinema();
                _itemService.Update(oldItem.ToWatchItem(), updateItem.ToWatchItem());
                UpdateGridData();
            }
            else
            {
                _messageBox.ShowWarning("Select one item.");
            }
        }

        private void BtnDeleteMovie_Click(object sender, EventArgs e)
        {
            var selectedRowIds = GetSelectedRowIndexes()
                .Select(idx => dgvCinema.Rows[idx].Get<Guid>(IndexColumnId))
                .ToList();

            if (selectedRowIds.Count == 0)
            {
                _messageBox.ShowWarning(HighlightTheDesiredLine);
                return;
            }

            if (!_messageBox.ShowQuestion("Delete selected items?"))
            {
                return;
            }

            foreach (var id in selectedRowIds)
            {
                RemoveItemRowGrid(id);
                _itemService.Remove(id);
            }

            LoadData();
        }

        private void BtnDownloadDataFile_Click(object sender, EventArgs e)
        {
            var openReplaceDataFromFile = new OpenFileDialog { Filter = "Data Base (*.db)|*.db" };
            if (openReplaceDataFromFile.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            var dataLoadingForm = new MergeDatabaseForm();
            if (dataLoadingForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var dbContext = new FileDbContextFactory(openReplaceDataFromFile.FileName).Create();
            var algorithmLoadData = dataLoadingForm.GetLoadData();
            var loadRule = new DeleteGradeRule(algorithmLoadData.IsDeleteGrade);
            var repositoryDataDownload = new WatchItemRepository(dbContext);
            var downloadDataService = new DownloadDataService(_dbContext, _messageBox);
            downloadDataService.Download(repositoryDataDownload, loadRule);
            UpdateGridData();
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
            if (!int.TryParse(textBoxPage.Text, out var pageNumber)
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
        /// Delete line table by Id.
        /// </summary>
        /// <param name="id">Object ID to delete.</param>
        private void RemoveItemRowGrid(Guid? id)
        {
            foreach (DataGridViewRow row in dgvCinema.Rows)
            {
                var idItem = row.Get<Guid?>(IndexColumnId);
                if (idItem != null && idItem == id)
                {
                    dgvCinema.Rows.RemoveAt(row.Index);
                    break;
                }
            }
        }

        /// <summary>
        /// Filling the table with data.
        /// </summary>
        /// <param name="items">List of elements.</param>
        private void FillGrid(List<WatchItem> items)
        {
            foreach (var item in items)
            {
                dgvCinema.Rows.Add(item.Title, item.Sequel, item.Status.Name, item.GetWatchData(), item.Grade, item.Id, item.Type);
            }
        }

        /// <summary>
        /// Filling in tabular data from a file.
        /// </summary>
        private void LoadData()
        {
            try
            {
                _searchRequest.Page = Page.GetPage();
                _searchRequest.Sort = Sort.GetSortItem();
                _pagedList = _itemService.GetPage(_searchRequest);
                var item = _pagedList.Items;

                GridClear();
                FillGrid(item);
                CustomUpdateFormState();

                labelTotalPage.Text = labelTotalPage.Text = string.Format("/{0}", Math.Max(_pagedList.PageCount, 1));
                textBoxPage.Text = _pagedList.PageNumber.ToString();
            }
            catch (Exception error)
            {
                _messageBox.ShowError(error.Message);
            }
        }

        /// <summary>
        /// Delete data from the table.
        /// </summary>
        private void GridClear() => dgvCinema.Rows.Clear();

        /// <summary>
        /// Create a new SearchRequest in the database for the selected ComboBox("Filter", "Sort", "PageNumber") and updates the tabular data on it.
        /// </summary>
        private void UpdateGridData()
        {
            _searchRequest = new WatchItemSearchRequest(Filter.GetFilter(), Sort.GetSortItem(), Page.GetPage());
            LoadData();
        }

        /// <summary>
        /// The method creates a data change/input restriction if the number of pages is zero.
        /// </summary>
        private void CustomUpdateFormState()
        {
            var hasPageControl = _pagedList.PageCount > 0 ? true : false;

            btnBackPage.Enabled =
                btnEndPage.Enabled =
                    btnNextPage.Enabled =
                        btnStartPage.Enabled =
                            labelTotalPage.Enabled =
                                textBoxPage.Enabled =
                                    hasPageControl;
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

            var sequel = CellElement(rowItems, IndexColumnSequel).ParseInt();
            var id = CellElement(rowItems, IndexColumnId).ParseGuid();

            var type = TypeCinema.FromName(CellElement(rowItems, IndexColumnType));
            var status = StatusCinema.FromName(CellElement(rowItems, IndexColumnStatus));

            if (status == StatusCinema.Planned)
            {
                return CinemaModel.CreatePlanned(title, sequel, status, type, id);
            }

            var grade = CellElement(rowItems, IndexColumnGrade).ParseDecimal();
            var strDateWatch = CellElement(rowItems, IndexColumnDate);
            DateTime? dateWatch = status == StatusCinema.Viewed ? DateTime.Parse(strDateWatch) : null;

            return CinemaModel.CreateNonPlanned(title, sequel, dateWatch, grade, status, type, id);
        }

        /// <summary>
        /// Gets the line numbers that are selected, without duplicates.
        /// </summary>
        /// <returns>
        /// Selection line numbers.
        /// </returns>
        private HashSet<int> GetSelectedRowIndexes()
        {
            var result = new HashSet<int>();
            foreach (DataGridViewRow dgvCinemaSelectedRow in dgvCinema.SelectedRows)
            {
                result.Add(dgvCinemaSelectedRow.Index);
            }

            foreach (DataGridViewCell dgvCinemaSelectedCell in dgvCinema.SelectedCells)
            {
                result.Add(dgvCinemaSelectedCell.RowIndex);
            }

            return result;
        }

        private string CellElement(DataGridViewRow rowItem, int indexColumn) => rowItem.GetString(indexColumn) ?? throw new Exception("String cannot be null.");

        /// <summary>
        /// The method checks whether the element selection filter has been changed.
        /// </summary>
        /// <returns>
        /// True - The filter has been changed. False - else.
        /// </returns>
        private bool IsNotChangesFilter() => _searchRequest.CompareFilter(Filter.GetFilter());

        /// <summary>
        /// The method checks if the size of the page data has changed.
        /// </summary>
        /// <returns>
        /// True - The page size has been changed. False - else.
        /// </returns>
        private bool IsChangedSizePage() => _searchRequest.Page.Size != Page.Size;

        /// <summary>
        /// Get the size of the page data.
        /// </summary>
        /// <returns>
        /// Page size.
        /// </returns>
        private int SelectedPageSize() => Page.Items[cmbPageSize.SelectedIndex];
    }
}
