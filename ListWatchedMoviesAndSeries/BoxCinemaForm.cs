using Core.Repository.DbContex;
using ListWatchedMoviesAndSeries.EditorForm;
using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;
using ListWatchedMoviesAndSeries.Repository;
using Microsoft.EntityFrameworkCore;

namespace ListWatchedMoviesAndSeries
{
    public partial class BoxCinemaForm : Form
    {
        private const int IndexColumnName = 0;
        private const int IndexColumnSequel = 1;
        private const int IndexColumnIsWatch = 2;
        private const int IndexColumnDate = 3;
        private const int IndexColumnGrade = 4;
        private const int IndexColumnId = 5;
        private const int IndexColumnType = 6;

        private readonly Dictionary<TypeCinema, DataGridView> _gridByTypeMap = new Dictionary<TypeCinema, DataGridView>();

        private readonly Dictionary<TabPage, DataGridView> _gridByPageMap = new Dictionary<TabPage, DataGridView>();

        private readonly WatchCinemaDbContext _db;

        private readonly WatchItemRepository _repository;

        public BoxCinemaForm()
        {
            InitializeComponent();

            var builder = new DbContextOptionsBuilder().UseSqlite("Data Source=app.db");
            _db = new WatchCinemaDbContext(builder.Options);
            _repository = new WatchItemRepository(_db);

            _gridByTypeMap = new Dictionary<TypeCinema, DataGridView>
            {
                { TypeCinema.Series, dgvSeries },
                { TypeCinema.Movie, dgvMove },
                { TypeCinema.Anime, dgvAnime },
                { TypeCinema.Cartoon, dgvCartoon },
                { TypeCinema.Unknown, dgvCinema }
            };
            _gridByPageMap = new Dictionary<TabPage, DataGridView>
            {
                { tabSeriesPage, dgvSeries },
                { tabMoviePage, dgvMove },
                { tabAnimePage, dgvAnime },
                { tabCartoonPage, dgvCartoon },
                { tabAllCinemaPage, dgvCinema }
            };

            Load += BoxCinemaForm_Load;
        }

        private void BoxCinemaForm_Load(object? sender, EventArgs e)
        {
            _db.Database.EnsureCreated();
        }

        public void SetNameGrid(CinemaModel cinema)
        {
            if (cinema?.Type != null && _gridByTypeMap.TryGetValue(cinema.Type, out var dgv))
            {
                AddCinemaGridRow(dgv, cinema);
                AddCinemaGridRow(dgvCinema, cinema);
                _repository.Add(cinema.ToWatchItem());
            }
        }

        public void EditItemGrid(CinemaModel cinema, int numberRowGridCinema, int numberRowAllGridCinema)
        {
            if (cinema?.Type != null && _gridByTypeMap.TryGetValue(cinema.Type, out var dgv))
            {
                ReplacementEditItem(dgv, cinema, numberRowGridCinema);
                ReplacementEditItem(dgvCinema, cinema, numberRowAllGridCinema);
                _repository.UpDate(cinema.ToWatchItem());
            }
        }

        private void btnFormMovie_Click(object sender, EventArgs e)
        {
            using (var form = new AddCinemaForm(this, TypeCinema.Movie))
            {
                form.ShowDialog();
            }
        }

        private void btnFormSeries_Click(object sender, EventArgs e)
        {
            using (var form = new AddCinemaForm(this, TypeCinema.Series))
            {
                form.ShowDialog();
            }
        }

        private void btnFormAnime_Click(object sender, EventArgs e)
        {
            using (var form = new AddCinemaForm(this, TypeCinema.Anime))
            {
                form.ShowDialog();
            }
        }

        private void btnFormCartoon_Click(object sender, EventArgs e)
        {
            using (var form = new AddCinemaForm(this, TypeCinema.Cartoon))
            {
                form.ShowDialog();
            }
        }

        private void btnEditRow_Click(object sender, EventArgs e)
        {
            var page = Box.SelectedTab;
            var dgv = GridOnPage(page);
            if (IsEditRowGrid(dgv, out int indexRowMove, out CinemaModel? item) && item != null)
            {
                ShowEditCinema(dgv, item, indexRowMove);
            }
        }

        private DataGridView GridOnPage(TabPage page)
        {
            if (_gridByPageMap.TryGetValue(page, out var dgv))
            {
                return dgv;
            }
            else
            {
                throw new Exception("Page does not exist");
            }
        }

        private void btnDeliteMovie_Click(object sender, EventArgs e)
        {
            var page = Box.SelectedTab;
            if (!_gridByPageMap.TryGetValue(page, out var dgv))
                throw new ArgumentNullException(nameof(page));

            if (RemoveRowGrid(dgv, out string? idItem))
            {
                if (page == tabAllCinemaPage)
                    dgv = SearchTypeItem(idItem);
                else
                    dgv = dgvCinema;
                RemoveItemRowGrid(dgv, idItem);
                var strId = Guid.Parse(idItem);
                if (strId != null)
                    _repository.Remove(Guid.Parse(idItem));
                else
                    MessageBoxProvider.ShowError("Id not null");
            }
        }

        private void btnPullingFile_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Deleting a row of table data.
        /// Out ID in delete from another table.
        /// </summary>
        /// <param name="dataGridCinema">Table</param>
        /// <param name="id">Object ID to delete</param>
        /// <returns></returns>
        private bool RemoveRowGrid(DataGridView dataGridCinema, out string? id)
        {
            if (dataGridCinema.SelectedRows.Count == 0)
            {
                id = string.Empty;
                MessageBoxProvider.ShowWarning("Highlight the desired line");
                return false;
            }
            id = SelectedRowCinemaId(dataGridCinema);
            RemoveItemRowGrid(dataGridCinema, id);

            return true;
        }

        /// <summary>
        /// Get ID on the selected line table.
        /// </summary>
        /// <param name="gridCinema">Table with element</param>
        /// <returns></returns>
        private static string? SelectedRowCinemaId(DataGridView gridCinema)
        {
            var rowIndex = gridCinema.CurrentCell.RowIndex;
            return gridCinema.Rows[rowIndex].Cells[IndexColumnId].Value.ToString();
        }

        /// <summary>
        /// Delete line by Id.
        /// </summary>
        /// <param name="dataGridCinema">Table with element row.</param>
        /// <param name="id">Object ID to delete</param>
        private void RemoveItemRowGrid(DataGridView dataGridCinema, string? id)
        {
            if (dataGridCinema.RowCount == 0)
                MessageBoxProvider.ShowError("The element is missing from the table.");
            foreach (DataGridViewRow row in dataGridCinema.Rows)
            {
                if (row.Cells[IndexColumnId].Value.ToString() == id)
                {
                    dataGridCinema.Rows.RemoveAt(row.Index);
                    break;
                }
            }
        }

        /// <summary>
        /// Add element in table.
        /// </summary>
        /// <param name="dataGridCinema">Table</param>
        /// <param name="cinema">Add element </param>
        private void AddCinemaGridRow(DataGridView dataGridCinema, CinemaModel cinema)
        {
            var intSequel = decimal.ToInt64(cinema.NumberSequel ?? 0);
            var formatDate = cinema.Detail.GetWatchData();
            dataGridCinema.Rows.Add(cinema.Name, intSequel.ToString(), cinema.Detail?.Watch, formatDate, cinema.Detail?.Grade, cinema.Id.ToString(), cinema.Type);
        }

        /// <summary>
        /// Add element in table.
        /// </summary>
        /// <param name="dataGridCinema">Table</param>
        /// <param name="cinema">Add element </param>
        private void AddCinemaGridRow(DataGridView dataGridCinema, WatchItem cinema)
        {
            var intSequel = decimal.ToInt64(cinema.NumberSequel ?? 0);
            var formatDate = cinema.Detail.GetWatchData();
            dataGridCinema.Rows.Add(cinema.Name, intSequel.ToString(), cinema.Detail?.Watch, formatDate, cinema.Detail?.Grade, cinema.Id.ToString(), cinema.Type);
        }

        /// <summary>
        /// Filling the table with data.
        /// </summary>
        /// <param name="dataGridCinema">Table to fill</param>
        /// <param name="itemGrid">List of elements</param>
        private void AddCinemaGrid(DataGridView dataGridCinema, List<WatchItem> itemGrid)
        {
            foreach (var item in itemGrid)
            {
                var intSequel = decimal.ToInt64(item.NumberSequel ?? 0);
                var formatDate = item.Detail?.GetWatchData();
                dataGridCinema.Rows.Add(item.Name, intSequel.ToString(), item.Detail?.Watch, formatDate, item.Detail?.Grade, item.Id.ToString(), item.Type);
            }
        }

        /// <summary>
        /// Finding ID an element in a Move table.
        /// </summary>
        /// <param name="id">ID element</param>
        /// <returns>
        /// SFinding an element in a table.
        /// </returns>
        private DataGridView SearchTypeItem(string? id)
        {
            var countRowGridAllCinema = dgvCinema.RowCount;
            if (countRowGridAllCinema == 0)
                throw new Exception("Element not found");
            for (int i = 0; i < countRowGridAllCinema; i++)
            {
                var titleItem = dgvCinema.Rows[i].Cells[IndexColumnId].Value;
                if (titleItem != null && titleItem.Equals(id))
                {
                    TypeCinema type = TypeCinema.FromName(dgvCinema.Rows[i].Cells[IndexColumnType].Value.ToString());
                    return _gridByTypeMap[type];
                }
            }
            throw new ArgumentException("Type not found");
        }

        /// <summary>
        /// Edit the selected item.
        /// </summary>
        /// <param name="grid">Table with element</param>
        /// <param name="rowIndex">Number row element</param>
        /// <param name="cinemaItem">Element to сhange</param>
        /// <returns>
        /// True:Row selected.
        /// False:Row not selected.
        /// </returns>
        private bool IsEditRowGrid(DataGridView grid, out int rowIndex, out CinemaModel? cinemaItem)
        {
            if (grid.SelectedRows.Count == 0)
            {
                rowIndex = -1;
                cinemaItem = null;
                MessageBoxProvider.ShowWarning("Highlight the desired line");
                return false;
            }
            rowIndex = grid.CurrentCell.RowIndex;
            cinemaItem = GetItem(grid, rowIndex);
            return true;
        }

        /// <summary>
        /// Change the selected element in the EditorItemCinemaForm.
        /// </summary>
        /// <param name="grid">Table with element</param>
        /// <param name="item">Element to сhange</param>
        /// <param name="indexRow">Number row element</param>
        private void ShowEditCinema(DataGridView grid, CinemaModel item, int indexRow)
        {
            var id = item.Id.ToString() ?? string.Empty;
            var indexRowAllCinema = indexRow;
            if (grid == dgvCinema)
            {
                var dataGrid = SearchTypeItem(id);
                indexRow = GetNumberItemGridCinema(dataGrid, id);
            }
            else
            {
                indexRowAllCinema = GetNumberItemGridCinema(dgvCinema, id);
            }
            using (var form = new EditorItemCinemaForm(this, item, indexRow, indexRowAllCinema))
            {
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Get item by ID from the table.
        /// </summary>
        /// <param name="grid">Table with element</param>
        /// <param name="indexRow">Number row element</param>
        /// <returns>
        /// The filling of all fields of the element depends on the data in the table.
        /// Type: CinemaModel.
        /// </returns>
        private static CinemaModel GetItem(DataGridView grid, int indexRow)
        {
            var rowItems = grid.Rows[indexRow];
            var title = rowItems.Cells[IndexColumnName].Value.ToString();
            var sequel = decimal.Parse(rowItems.Cells[IndexColumnSequel].Value.ToString());
            var id = rowItems.Cells[IndexColumnId].Value ?? Guid.NewGuid();
            var type = TypeCinema.FromName(rowItems.Cells[IndexColumnType].Value.ToString());
            if (rowItems.Cells[IndexColumnDate].Value.ToString() != string.Empty)
            {
                var strDateWatch = rowItems.Cells[IndexColumnDate].Value.ToString();
                var dateWatch = DateTime.Parse(strDateWatch);
                var grade = decimal.Parse(rowItems.Cells[IndexColumnGrade].Value.ToString() ?? "0");
                var cinemaItem = new CinemaModel(
                                                   title,
                                                   sequel,
                                                   dateWatch,
                                                   grade,
                                                   type,
                                                   Guid.Parse(id.ToString()));
                return cinemaItem;
            }
            else
            {
                var cinemaItem = new CinemaModel(
                                                  title,
                                                  sequel,
                                                  type,
                                                  Guid.Parse(id.ToString()));
                return cinemaItem;
            }
        }

        /// <summary>
        /// Get number row to change.
        /// </summary>
        /// <param name="grid">Table with element</param>
        /// <param name="id">Number ID</param>
        /// <returns>
        /// The row number of the element in the table.
        /// If there is no element, return -1.
        /// </returns>
        private static int GetNumberItemGridCinema(DataGridView grid, string id)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells[IndexColumnId].Value.ToString() == id)
                {
                    return row.Index;
                }
            }
            return -1;
        }

        /// <summary>
        /// Changing a table element.
        /// </summary>
        /// <param name="grid">Table with element</param>
        /// <param name="cinemaItem">Element to change</param>
        /// <param name="rowIndex">Number row element</param>
        private void ReplacementEditItem(DataGridView grid, CinemaModel cinemaItem, int rowIndex)
        {
            grid.Rows[rowIndex].Cells[IndexColumnName].Value = cinemaItem.Name;
            grid.Rows[rowIndex].Cells[IndexColumnSequel].Value = cinemaItem.NumberSequel;
            grid.Rows[rowIndex].Cells[IndexColumnId].Value = cinemaItem.Id;
            grid.Rows[rowIndex].Cells[IndexColumnType].Value = cinemaItem.Type;

            if (cinemaItem.Detail.DateWatch != null)
            {
                grid.Rows[rowIndex].Cells[IndexColumnIsWatch].Value = "+";
                grid.Rows[rowIndex].Cells[IndexColumnDate].Value = cinemaItem.Detail.GetWatchData();
                grid.Rows[rowIndex].Cells[IndexColumnGrade].Value = cinemaItem.Detail.Grade;
            }
            else
            {
                grid.Rows[rowIndex].Cells[IndexColumnIsWatch].Value = "-";
                grid.Rows[rowIndex].Cells[IndexColumnDate].Value = string.Empty;
                grid.Rows[rowIndex].Cells[IndexColumnGrade].Value = string.Empty;
            }
        }

        /// <summary>
        /// Filling in tabular data from a file.
        /// </summary>
        /// <param name="grid">Table to fill</param>
        private void LoadData()
        {
            ClearAllGrid();
            try
            {
                AddGridCinema(out var itemGridCinema);
                foreach (var item in itemGridCinema)
                {
                    if (item != null)
                    {
                        AddCinemaGridRow(_gridByTypeMap[item.Type], item);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBoxProvider.ShowError(error.Message);
            }
        }

        private void ClearAllGrid()
        {
            foreach (var item in _gridByTypeMap)
            {
                item.Value.Rows.Clear();
            }
        }

        private void AddGridCinema(out List<WatchItem> itemGrid)
        {
            itemGrid = _repository.GetAll();
            if (itemGrid == null || itemGrid.Count <= 0)
                return;
            AddCinemaGrid(dgvCinema, itemGrid);
        }
    }
}
