using ListWatchedMoviesAndSeries.EditorForm;
using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;
using ListWatchedMoviesAndSeries.Repository;

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

        private readonly string _path = @"C:\\Grid\";

        public BoxCinemaForm()
        {
            InitializeComponent();
            if (Directory.Exists(_path) == false)
                Directory.CreateDirectory(_path);
        }

        public void SetNameGrid(CinemaModel cinema)
        {
            if (cinema != null)
            {
                if (cinema.Type == TypeCinema.Series)
                {
                    AddCinemaGridRow(dgvSeries, cinema);
                    SaveData(dgvSeries);
                }
                else if (cinema.Type == TypeCinema.Movie)
                {
                    AddCinemaGridRow(dgvMove, cinema);
                    SaveData(dgvMove);
                }
                AddCinemaGridRow(dgvCinema, cinema);
                SaveData(dgvCinema);
            }
        }

        public void EditItemGrid(CinemaModel cinemaItem, int numberRowGridCinema, int numberRowAllGridCinema)
        {
            if (cinemaItem != null)
            {
                if (cinemaItem.Type == TypeCinema.Series)
                {
                    ReplacementEditItem(dgvSeries, cinemaItem, numberRowGridCinema);
                    SaveData(dgvSeries);
                }
                else if (cinemaItem.Type == TypeCinema.Movie)
                {
                    ReplacementEditItem(dgvMove, cinemaItem, numberRowGridCinema);
                    SaveData(dgvMove);
                }
                ReplacementEditItem(dgvCinema, cinemaItem, numberRowAllGridCinema);
                SaveData(dgvCinema);
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

        private void btnEditRow_Click(object sender, EventArgs e)
        {
            var page = BoxName.SelectedTab;

            if (page == tabMovePage)
            {
                if (IsEditRowGrid(dgvMove, out int indexRowMove, out CinemaModel? item) && item != null)
                {
                    ShowEditCinema(dgvMove, item, indexRowMove);
                }
            }
            else if (page == tabSeriesPage)
            {
                if (IsEditRowGrid(dgvSeries, out int indexRowSeries, out CinemaModel? item) && item != null)
                {
                    ShowEditCinema(dgvSeries, item, indexRowSeries);
                }
            }
            else if (page == tabAllCinemaPage)
            {
                if (IsEditRowGrid(dgvCinema, out int indexRowAllCinema, out CinemaModel? item) && item != null)
                {
                    ShowEditCinema(dgvCinema, item, indexRowAllCinema);
                }
            }
        }

        private void btnDeliteMovie_Click(object sender, EventArgs e)
        {
            var page = BoxName.SelectedTab;

            if (page == tabMovePage)
            {
                if (RemoveRowGrid(dgvMove, out string? idItem))
                {
                    RemoveItemRowGrid(dgvCinema, idItem);
                }
            }
            else if (page == tabSeriesPage)
            {
                if (RemoveRowGrid(dgvSeries, out string? idItem))
                {
                    RemoveItemRowGrid(dgvCinema, idItem);
                }
            }
            else if (page == tabAllCinemaPage)
            {
                if (RemoveRowGrid(dgvCinema, out string? idItem))
                {
                    if (IsCheckItemGridMove(idItem))
                    {
                        RemoveItemRowGrid(dgvMove, idItem);
                    }
                    else
                    {
                        RemoveItemRowGrid(dgvSeries, idItem);
                    }
                }
            }
        }

        private void btnPullingFile_Click(object sender, EventArgs e)
        {
            GetItemDeserialize(dgvMove);
            GetItemDeserialize(dgvSeries);
            GetItemDeserialize(dgvCinema);
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
            foreach (DataGridViewRow row in dataGridCinema.Rows)
            {
                if (row.Cells[IndexColumnId].Value.ToString() == id)
                {
                    dataGridCinema.Rows.RemoveAt(row.Index);
                    SaveData(dataGridCinema);
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
            var partOrSeason = cinema.NumberSequel;
            var formatDate = cinema.Detail?.DateWatch?.ToString("dd.MM.yyyy") ?? string.Empty;
            dataGridCinema.Rows.Add(cinema.Name, partOrSeason.ToString(), cinema.Detail?.GetView(), formatDate, cinema.Detail?.Grade, cinema.Id.ToString(), cinema.Type);
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
                var partOrSeason = item.NumberSequel;
                var formatDate = item.Detail?.DateWatch?.ToString("dd.MM.yyyy") ?? string.Empty;
                dataGridCinema.Rows.Add(item.Name, partOrSeason.ToString(), item.Detail?.GetView(), formatDate, item.Detail?.Grade, item.Id.ToString(), item.Type);
            }
        }

        /// <summary>
        /// Finding ID an element in a Move table.
        /// </summary>
        /// <param name="id">ID element</param>
        /// <returns>
        /// True:item in Move table.
        /// False:item in Series table.
        /// </returns>
        private bool IsCheckItemGridMove(string? id)
        {
            var countRowGridMove = dgvMove.RowCount;
            if (countRowGridMove == 0)
                return false;
            for (int i = 0; i < countRowGridMove; i++)
            {
                var titleItem = dgvMove.Rows[i].Cells[IndexColumnId].Value;
                if (titleItem != null && titleItem.Equals(id))
                    return true;
            }
            return false;
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
            var id = item.Id?.ToString() ?? string.Empty;
            var indexRowAllCinema = indexRow;
            if (grid == dgvCinema)
            {
                var dataGrid = IsCheckItemGridMove(id) ? dgvMove : dgvSeries;
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
                CinemaModel cinemaItem = new CinemaModel(
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
                CinemaModel cinemaItem = new CinemaModel(
                                                  title,
                                                  sequel,
                                                  type,
                                                  Guid.Parse(id.ToString()));
                return cinemaItem;
            }
        }

        /// <summary>
        /// Get item by ID from the data row table.
        /// </summary>
        /// <param name="row">Item data row</param>
        /// <returns>
        /// The filling of all fields of the element depends on the data in the row data table.
        /// Type: WatchItem.
        /// </returns>
        private static WatchItem GetItem(DataGridViewRow row)
        {
            var title = row.Cells[IndexColumnName].Value.ToString();
            var sequel = decimal.Parse(row.Cells[IndexColumnSequel].Value.ToString());
            var id = row.Cells[IndexColumnId].Value ?? Guid.NewGuid();
            var type = TypeCinema.FromName(row.Cells[IndexColumnType].Value.ToString());
            if (row.Cells[IndexColumnDate].Value.ToString() != string.Empty)
            {
                var strDateWatch = row.Cells[IndexColumnDate].Value.ToString();
                var dateWatch = DateTime.Parse(strDateWatch);
                var grade = decimal.Parse(row.Cells[IndexColumnGrade].Value.ToString() ?? "0");

                var cinemaItem = new WatchItem(
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
                var cinemaItem = new WatchItem(
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

            if (cinemaItem.Detail?.DateWatch != null)
            {
                grid.Rows[rowIndex].Cells[IndexColumnIsWatch].Value = "+";
                grid.Rows[rowIndex].Cells[IndexColumnDate].Value = cinemaItem.Detail?.DateWatch?.ToString("dd.MM.yyyy");
                grid.Rows[rowIndex].Cells[IndexColumnGrade].Value = cinemaItem.Detail?.Grade;
            }
            else
            {
                grid.Rows[rowIndex].Cells[IndexColumnIsWatch].Value = "-";
                grid.Rows[rowIndex].Cells[IndexColumnDate].Value = string.Empty;
                grid.Rows[rowIndex].Cells[IndexColumnGrade].Value = string.Empty;
            }
        }

        /// <summary>
        /// Recording JSON Serializer grid in files.
        /// Path in the field "_path".
        /// </summary>
        /// <param name="date">Table for writing</param>
        private void SaveData(DataGridView date)
        {
            if (date.Rows.Count < 0)
                MessageBoxProvider.ShowError("Grid without elements.");
            var itemList = new List<WatchItem>();
            foreach (DataGridViewRow row in date.Rows)
            {
                if (row.Cells[IndexColumnId].Value == null)
                    break;
                var item = GetItem(row);
                item.InitializationType(item.Type?.Value ?? 0);
                itemList.Add(item);
            }
            var path = @$"{_path}Grid{date.Tag}.json";
            var fileRepository = new FileWatchItemRepository(path);
            try
            {
                fileRepository.Save(itemList);
            }
            catch (Exception error)
            {
                MessageBoxProvider.ShowError(error.Message);
            }
        }

        /// <summary>
        /// Filling in tabular data from a file.
        /// (JsonSerializer.Deserialize)
        /// </summary>
        /// <param name="grid">Table to fill</param>
        private void GetItemDeserialize(DataGridView grid)
        {
            grid.Rows.Clear();
            var pathFile = @$"{_path}Grid{grid.Tag}.json";
            if (!File.Exists(pathFile))
            {
                MessageBoxProvider.ShowError("File not found.");
                return;
            }
            var fileRepository = new FileWatchItemRepository(pathFile);
            try
            {
                var itemGrid = fileRepository.GetAll();
                if (itemGrid == null || itemGrid.Count <= 0)
                    return;
                AddCinemaGrid(grid, itemGrid);
            }
            catch (Exception error)
            {
                MessageBoxProvider.ShowError(error.Message);
            }
        }
    }
}
