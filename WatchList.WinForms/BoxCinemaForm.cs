using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Sortable;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;
using WatchList.WinForms.BindingItem.ModelBoxForm;
using WatchList.WinForms.BindingItem.ModelBoxForm.Filter;
using WatchList.WinForms.BindingItem.ModelBoxForm.Sorter;
using WatchList.WinForms.ChildForms;
using WatchList.WinForms.ChildForms.Extension;
using WatchList.WinForms.Exceptions;
using WatchList.WinForms.Extension;

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

        private readonly IServiceProvider _serviceProvider;
        private readonly WatchItemService _itemService;
        private readonly IMessageBox _messageBox;
        private readonly ILogger<WatchItemRepository> _logger;
        private readonly DownloadDataService _downloadDataService;

        private readonly SortWatchItemModel _sortField;
        private readonly FilterItemModel _filterItem;
        private readonly ItemSearchRequest _searchRequests;

        private PagedList<WatchItem> _pagedList;
        private bool _isAscending = true;

        public BoxCinemaForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _messageBox = serviceProvider.GetRequiredService<IMessageBox>();
            _itemService = serviceProvider.GetRequiredService<WatchItemService>();
            _sortField = serviceProvider.GetRequiredService<SortWatchItemModel>();
            _filterItem = serviceProvider.GetRequiredService<FilterItemModel>();
            _logger = serviceProvider.GetRequiredService<ILogger<WatchItemRepository>>();
            _downloadDataService = serviceProvider.GetRequiredService<DownloadDataService>();
            _searchRequests = new ItemSearchRequest(_filterItem, _sortField.GetSortItem(), Page.GetPage(), _isAscending);
            _pagedList = _itemService.GetPage(_searchRequests);
            Load += BoxCinemaForm_Load;
        }

        private PageModel Page { get; set; } = new PageModel();

        private void BoxCinemaForm_Load(object? sender, EventArgs e)
        {
            cmbPageSize.DataSource = Page.Items;
            checkBoxCMBSort.Items.AddRange(_sortField.SelectField);
            cbCMBTypeFilter.Items.AddRange(_filterItem.SelectTypeField);
            cbCMBStatusFilter.Items.AddRange(_filterItem.SelectStatusField);

            checkBoxCMBSort.SelectItemsStr(_sortField.GetSortFieldArray());
            cbCMBTypeFilter.SelectAllItem();
            cbCMBStatusFilter.SelectAllItem();
        }

        private async void BtnUseFilter_Click(object sender, EventArgs e)
        {
            Page.Number = 1;
            await UpdateGridData();
        }

        private async void BtnCancelFilter_Click(object sender, EventArgs e)
        {
            _filterItem.Clear();
            _sortField.Clear();
            checkBoxCMBSort.SelectItemsStr(_sortField.GetSortFieldArray());
            cbCMBTypeFilter.SelectAllItem();
            cbCMBStatusFilter.SelectAllItem();
            await UpdateGridData();
        }

        private async void BtnAddCinema_ClickAsync(object sender, EventArgs e)
        {
            var addForm = new AddCinemaForm(_messageBox);

            if (addForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            _logger.LogInformation("Click save add item.");
            var itemCinema = addForm.GetCinema();
            await _itemService.AddAsync(itemCinema.ToWatchItem());

            await UpdateGridData();
        }

        private async void BtnEditRow_ClickAsync(object sender, EventArgs e)
        {
            var indexEditRow = GetSelectedRowIndexes();
            if (indexEditRow.Count == 1)
            {
                var oldItem = GetItem(indexEditRow.First());
                var updateForm = new EditorItemCinemaForm(oldItem, _messageBox);

                if (updateForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                _logger.LogInformation("Click save edit item.");
                var updateItem = updateForm.GetEditItemCinema();
                await _itemService.UpdateAsync(oldItem.ToWatchItem(), updateItem.ToWatchItem());
                await UpdateGridData();
            }
            else
            {
                await _messageBox.ShowWarning("Select one item.");
            }
        }

        private async void BtnDeleteMovie_ClickAsync(object sender, EventArgs e)
        {
            var selectedRowIds = GetSelectedRowIndexes()
                .Select(idx => dgvCinema.Rows[idx].Get<Guid>(IndexColumnId))
                .ToList();

            if (selectedRowIds.Count == 0)
            {
                await _messageBox.ShowWarning(HighlightTheDesiredLine);
                return;
            }

            if (!await _messageBox.ShowQuestion("Delete selected items?"))
            {
                return;
            }

            _logger.LogInformation("Click delite item.");
            foreach (var id in selectedRowIds)
            {
                RemoveItemRowGrid(id);
                _itemService.Remove(id);
            }

            await LoadDataAsync();
        }

        private async void BtnDownloadDataFile_Click(object sender, EventArgs e)
        {
            var dataLoadingForm = _serviceProvider.GetRequiredService<MergeDatabaseForm>();
            if (dataLoadingForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var openReplaceDataFromFile = new OpenFileDialog { Filter = "Data Base (*.db)|*.db" };
            if (openReplaceDataFromFile.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            var pathFile = openReplaceDataFromFile.FileName;
            _logger.LogInformation($"Add item from the selected file <{0}>.", pathFile);

            var dbContext = new DbContextFactoryMigrator(pathFile).Create();
            var loadRuleConfig = dataLoadingForm.GetLoadRuleConfig();
            await _downloadDataService.DownloadDataByDB(dbContext, loadRuleConfig);
            await UpdateGridData();
        }

        private void BoxCinemaForm_FormClosing(object sender, FormClosingEventArgs e)
            => _logger.LogTrace("Close App.");

        private async void BtnBackPage_Click(object sender, EventArgs e)
        {
            if (_pagedList.HasPreviousPage)
            {
                Page.Number--;
                await LoadDataAsync();
            }
        }

        private async void BtnStartPage_Click(object sender, EventArgs e)
        {
            if (_pagedList.HasPreviousPage)
            {
                Page.Number = 1;
                await LoadDataAsync();
            }
        }

        private async void BtnNextPage_Click(object sender, EventArgs e)
        {
            if (_pagedList.HasNextPage)
            {
                Page.Number++;
                await LoadDataAsync();
            }
        }

        private async void BtnEndPage_Click(object sender, EventArgs e)
        {
            if (_pagedList.HasNextPage)
            {
                Page.Number = _pagedList.Count;
                await LoadDataAsync();
            }
        }

        private async void BtnTypeSort_Click(object sender, EventArgs e)
        {
            if (_isAscending)
            {
                _isAscending = false;
                btnTypeSort.Text = TypeSortFields.Descending.Name;
            }
            else
            {
                _isAscending = true;
                btnTypeSort.Text = TypeSortFields.Ascending.Name;
            }

            await UpdateGridData();
        }

        private async void CmbPageSize_Changed(object sender, EventArgs e)
        {
            var pageSizeCmb = SelectedPageSize();

            if (Page.ChangedPage(pageSizeCmb))
            {
                Page.Size = pageSizeCmb;
                Page.Number = 1;
                await LoadDataAsync();
            }
        }

        private async void CheckBoxCMBSort_ValueChang(object sender, EventArgs e)
        {
            var selectField = new HashSet<SortFieldWatchItem>();
            foreach (string item in checkBoxCMBSort.Items)
            {
                var checkBoxItem = checkBoxCMBSort.CheckBoxItems[item];

                if (checkBoxItem.Checked && SortFieldWatchItem.TryFromName(item, out var sortField))
                {
                    selectField.Add(sortField);
                }
            }

            _sortField.SortFields = selectField;
            await LoadDataAsync();
        }

        private async void TextBoxPage_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxPage.Text, out var pageNumber)
                || pageNumber > _pagedList.Count
                || _pagedList.PageNumber == Page.Number)
            {
                textBoxPage.Text = _pagedList.PageNumber.ToString();
                return;
            }

            Page.Number = pageNumber;
            await LoadDataAsync();
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
        private async Task LoadDataAsync()
        {
            try
            {
                UpdataSearchRequests();
                _pagedList = _itemService.GetPage(_searchRequests);
                if (IsNotFirstPageEmpty())
                {
                    Page.Number -= 1;
                    await LoadDataAsync();
                }

                var item = _pagedList.Items;

                GridClear();
                FillGrid(item);
                CustomUpdateFormState();

                labelTotalPage.Text = labelTotalPage.Text = string.Format("/{0}", Math.Max(_pagedList.Count, 1));
                textBoxPage.Text = _pagedList.PageNumber.ToString();
            }
            catch (Exception error)
            {
                await _messageBox.ShowError(error.Message);
            }
        }

        private void SelectSortField()
            => _sortField.SortFields = checkBoxCMBSort.SelectFieldCheckBoxCMB<SortFieldWatchItem>();

        private void SelectFilterField()
        {
            _filterItem.FilterTypeField = cbCMBTypeFilter.SelectFieldCheckBoxCMB<TypeCinema>();
            _filterItem.FilterStatusField = cbCMBStatusFilter.SelectFieldCheckBoxCMB<StatusCinema>();
        }

        /// <summary>
        /// Delete data from the table.
        /// </summary>
        private void GridClear() => dgvCinema.Rows.Clear();

        /// <summary>
        /// Create a new SearchRequest in the database for the selected ComboBox("Filter", "Sort", "PageNumber") and updates the tabular data on it.
        /// </summary>
        private async Task UpdateGridData()
        {
            SelectSortField();
            SelectFilterField();
            await LoadDataAsync();
        }

        /// <summary>
        /// The method creates a data change/input restriction if the number of pages is zero.
        /// </summary>
        private void CustomUpdateFormState()
        {
            var hasPageControl = _pagedList.Count > 0 ? true : false;

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
            var title = CellElement(rowItems, IndexColumnName);

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

        private void UpdataSearchRequests()
        {
            _searchRequests.Page = Page.GetPage();
            _searchRequests.Sort = _sortField.GetSortItem();
            _searchRequests.Filter = _filterItem.GetFilter();
            _searchRequests.IsAscending = _isAscending;
        }

        /// <summary>
        /// Gets a string from a table cell, if there is null then an exception.
        /// </summary>
        /// <param name="rowItem">Element row number.</param>
        /// <param name="indexColumn">Column number.</param>
        /// <returns>
        /// Get the cell element in string representation.
        /// </returns>
        /// <exception cref="Exception">
        /// String is null.
        /// </exception>
        private string CellElement(DataGridViewRow rowItem, int indexColumn)
            => rowItem.GetString(indexColumn)
            ?? throw new ExceptionIncorrectCellData(rowItem, indexColumn);

        /// <summary>
        /// The method checks if the page is empty.
        /// </summary>
        /// <returns>
        /// True - The page contains no elements and is not the first.
        /// </returns>
        private bool IsNotFirstPageEmpty() => _pagedList.HasEmptyPage && Page.Number != 1;

        /// <summary>
        /// Get the size of the page data.
        /// </summary>
        /// <returns>
        /// Page size.
        /// </returns>
        private int SelectedPageSize() => Page.Items[cmbPageSize.SelectedIndex];
    }
}
