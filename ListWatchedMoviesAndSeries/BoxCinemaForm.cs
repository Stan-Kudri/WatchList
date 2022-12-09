using Core.Repository.DbContex;
using ListWatchedMoviesAndSeries.EditorForm;
using ListWatchedMoviesAndSeries.Model;
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

        private FilterModel Filter { get; set; } = new();

        private readonly WatchCinemaDbContext _db;

        private readonly WatchItemRepository _repository;

        public BoxCinemaForm()
        {
            InitializeComponent();

            var builder = new DbContextOptionsBuilder().UseSqlite("Data Source=app.db");
            _db = new WatchCinemaDbContext(builder.Options);
            _repository = new WatchItemRepository(_db);

            Load += BoxCinemaForm_Load;
            LoadData();
        }

        private void BoxCinemaForm_Load(object? sender, EventArgs e)
        {
            _db.Database.EnsureCreated();
            cmbFilterType.DataSource = Filter.TypeFilter;
            cmbFilterWatch.DataSource = Filter.WatchFilter;
            filterModelBindingSource.DataSource = Filter;
        }

        public void SetNameGrid(CinemaModel cinema)
        {
            if (cinema?.Type != null)
            {
                AddCinemaGridRow(cinema);
                _repository.Add(cinema.ToWatchItem());
            }
        }

        public void EditItemGrid(CinemaModel cinema, int numberRowGridCinema)
        {
            if (cinema?.Type != null)
            {
                ReplacementEditItem(dgvCinema, cinema, numberRowGridCinema);
                _repository.Update(cinema.ToWatchItem());

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

        private void btnUseFilter_Click(object sender, EventArgs e)
        {
            GridClear();
            var filter = Filter.GetFilter();
            var listByFilter = _repository.GetItemByFilter(filter);
            AddCinemaGrid(listByFilter);
        }

        private void btnCancleFilter_Click(object sender, EventArgs e)
        {
            GridClear();
            LoadData();
        }

        private void btnEditRow_Click(object sender, EventArgs e)
        {
            if (IsEditRowGrid(out int indexRowMove, out CinemaModel? item) && item != null)
            {
                ShowEditCinema(item, indexRowMove);
            }
        }

        private void btnDeliteMovie_Click(object sender, EventArgs e)
        {
            if (RemoveRowGrid(out string idItem))
            {
                if (!Guid.TryParse(idItem, out var id))
                    return;
                _repository.Remove(id);
            }
        }

        private void btnReplaceFile_Click(object sender, EventArgs e)
        {
            var openReplaceDataFromFile = new OpenFileDialog { Filter = "Data Base (*.db)|*.db" };
            if (openReplaceDataFromFile.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = openReplaceDataFromFile.FileName;

            var builder = new DbContextOptionsBuilder().UseSqlite($"Data Source={fileName}");
            var repository = new WatchItemRepository(new WatchCinemaDbContext(builder.Options));

            _repository.RemoveRange();
            _repository.Add(repository.GetAll());

            GridClear();
            LoadData(repository);
        }

        /// <summary>
        /// Deleting a row of table data.
        /// Out ID in delete from another table.
        /// </summary>
        /// <param name="dataGridCinema">Table</param>
        /// <param name="id">Object ID to delete</param>
        /// <returns></returns>
        private bool RemoveRowGrid(out string id)
        {
            if (dgvCinema.SelectedRows.Count == 0)
            {
                id = string.Empty;
                MessageBoxProvider.ShowWarning("Highlight the desired line");
                return false;
            }
            id = SelectedRowCinemaId();
            RemoveItemRowGrid(id);

            return true;
        }

        /// <summary>
        /// Get ID on the selected line table.
        /// </summary>
        /// <param name="gridCinema">Table with element</param>
        /// <returns></returns>
        private string SelectedRowCinemaId()
        {
            var rowIndex = dgvCinema.CurrentCell.RowIndex;
            var id = dgvCinema.Rows[rowIndex].Cells[IndexColumnId].Value;
            return id.ToString() ?? string.Empty;
        }

        /// <summary>
        /// Delete line by Id.
        /// </summary>
        /// <param name="dataGridCinema">Table with element row.</param>
        /// <param name="id">Object ID to delete</param>
        private void RemoveItemRowGrid(string? id)
        {
            if (dgvCinema.RowCount == 0)
                MessageBoxProvider.ShowError("The element is missing from the table.");
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
        /// Add element in table.
        /// </summary>
        /// <param name="dataGridCinema">Table</param>
        /// <param name="cinema">Add element </param>
        private void AddCinemaGridRow(CinemaModel cinema)
        {
            var intSequel = decimal.ToInt64(cinema.NumberSequel ?? 0);
            var formatDate = cinema.Detail.GetWatchData();
            dgvCinema.Rows.Add(cinema.Name, intSequel.ToString(), cinema.Detail?.Watch, formatDate, cinema.Detail?.Grade, cinema.Id.ToString(), cinema.Type);
        }

        /// <summary>
        /// Filling the table with data.
        /// </summary>
        /// <param name="dataGridCinema">Table to fill</param>
        /// <param name="itemGrid">List of elements</param>
        private void AddCinemaGrid(List<WatchItem> itemGrid)
        {
            foreach (var item in itemGrid)
            {
                var intSequel = decimal.ToInt64(item.NumberSequel ?? 0);
                var formatDate = item.Detail?.GetWatchData();
                dgvCinema.Rows.Add(item.Name, intSequel.ToString(), item.Detail?.Watch, formatDate, item.Detail?.Grade, item.Id.ToString(), item.Type);
            }
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
        private bool IsEditRowGrid(out int rowIndex, out CinemaModel? cinemaItem)
        {
            if (dgvCinema.SelectedRows.Count == 0)
            {
                rowIndex = -1;
                cinemaItem = null;
                MessageBoxProvider.ShowWarning("Highlight the desired line");
                return false;
            }
            rowIndex = dgvCinema.CurrentCell.RowIndex;
            cinemaItem = GetItem(dgvCinema, rowIndex);
            return true;
        }

        /// <summary>
        /// Change the selected element in the EditorItemCinemaForm.
        /// </summary>
        /// <param name="grid">Table with element</param>
        /// <param name="item">Element to сhange</param>
        /// <param name="indexRow">Number row element</param>
        private void ShowEditCinema(CinemaModel item, int indexRow)
        {
            var id = item.Id.ToString() ?? string.Empty;
            using (var form = new EditorItemCinemaForm(this, item, indexRow))
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
            var title = CellElement(rowItems, IndexColumnName) ?? throw new ArgumentException("Name cannot be null.");
            if (!decimal.TryParse(CellElement(rowItems, IndexColumnSequel) ?? throw new ArgumentException("Sequel cannot be null."), out var sequel))
                throw new InvalidOperationException("Invalid cast.");

            if (!Guid.TryParse(CellElement(rowItems, IndexColumnId), out var id))
                throw new InvalidOperationException("Invalid cast.");

            var type = TypeCinema.FromName(CellElement(rowItems, IndexColumnType));
            var strDateWatch = CellElement(rowItems, IndexColumnDate);

            if (strDateWatch != string.Empty && strDateWatch != null)
            {
                var dateWatch = DateTime.Parse(strDateWatch);
                if (!decimal.TryParse(CellElement(rowItems, IndexColumnGrade) ?? throw new ArgumentException("Grade cannot be null."), out var grade))
                    throw new InvalidOperationException("Invalid cast.");

                var cinemaItem = new CinemaModel(
                                                   title,
                                                   sequel,
                                                   dateWatch,
                                                   grade,
                                                   type,
                                                   id);
                return cinemaItem;
            }
            else
            {
                var cinemaItem = new CinemaModel(
                                                  title,
                                                  sequel,
                                                  type,
                                                  id);
                return cinemaItem;
            }
        }

        private static string? CellElement(DataGridViewRow rowItem, int indexColumn)
        {
            return rowItem.Cells[indexColumn].Value.ToString();
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
            try
            {
                var itemGrid = _repository.GetAll();
                if (itemGrid == null || itemGrid.Count <= 0)
                    return;
                AddCinemaGrid(itemGrid);
            }
            catch (Exception error)
            {
                MessageBoxProvider.ShowError(error.Message);
            }
        }

        private void LoadData(WatchItemRepository repository)
        {
            try
            {
                var itemGrid = repository.GetAll();
                if (itemGrid == null || itemGrid.Count <= 0)
                    return;
                AddCinemaGrid(itemGrid);
            }
            catch (Exception error)
            {
                MessageBoxProvider.ShowError(error.Message);
            }
        }

        private void GridClear() => dgvCinema.Rows.Clear();
    }
}
