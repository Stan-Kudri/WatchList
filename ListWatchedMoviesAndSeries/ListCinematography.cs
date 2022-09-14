using ListWatchedMoviesAndSeries.EditorForm;
using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;
using ListWatchedMoviesAndSeries.Repository;
using System.Text.Json;

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

        private const string TypeTagMove = "Move";
        private const string TypeTagSeries = "Series";

        private string _path = @"C:\\Grid\";
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public BoxCinemaForm()
        {
            InitializeComponent();
            if (Directory.Exists(_path) == false)
                Directory.CreateDirectory(_path);
        }

        public void SetNameGrid(WatchItem cinema)
        {
            if (cinema != null)
            {
                if (cinema.Type == TypeCinema.Series)
                {
                    AddCinemaGridRow(dgvSeries, cinema);
                }
                else if (cinema.Type == TypeCinema.Movie)
                {
                    AddCinemaGridRow(dgvMove, cinema);
                }
                AddCinemaGridRow(dgvCinema, cinema);
            }
        }

        public void EditItemGrid(WatchItem cinemaItem, int numberRowGridCinema, int numberRowAllGridCinema)
        {
            if (cinemaItem != null)
            {
                if (cinemaItem.Type == TypeCinema.Series)
                {
                    ReplacementEditItem(dgvSeries, cinemaItem, numberRowGridCinema);
                }
                else if (cinemaItem.Type == TypeCinema.Movie)
                {
                    ReplacementEditItem(dgvMove, cinemaItem, numberRowGridCinema);
                }
                ReplacementEditItem(dgvCinema, cinemaItem, numberRowAllGridCinema);
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

        private void btnEditCinema_Click(object sender, EventArgs e)
        {
            var page = BoxName.SelectedTab;

            if (page == tabMovePage)
            {
                if (IsEditRowGrid(dgvMove, out int indexRowMove, out WatchItem? item) && item != null)
                {
                    item.Type = TypeCinema.Movie;
                    var id = item.Id?.ToString() ?? string.Empty;
                    var indexRowAllCinema = GetNumberItemGridCinema(dgvCinema, id);
                    using (var form = new EditorItemCinemaForm(this, item, indexRowMove, indexRowAllCinema))
                    {
                        form.ShowDialog();
                    }
                }
            }
            else if (page == tabSeriesPage)
            {
                if (IsEditRowGrid(dgvSeries, out int indexRowSeries, out WatchItem? item) && item != null)
                {
                    item.Type = TypeCinema.Series;
                    var id = item.Id?.ToString() ?? string.Empty;
                    var indexRowAllCinema = GetNumberItemGridCinema(dgvCinema, id);
                    using (var form = new EditorItemCinemaForm(this, item, indexRowSeries, indexRowAllCinema))
                    {
                        form.ShowDialog();
                    }
                }
            }
            else if (page == tabAllCinemaPage)
            {
                if (IsEditRowGrid(dgvCinema, out int indexRowAllCinema, out WatchItem? item) && item != null)
                {
                    var id = item?.Id?.ToString() ?? string.Empty;
                    var dataGrid = IsCheckItemGridMove(id) ? dgvMove : dgvSeries;
                    var indexRow = GetNumberItemGridCinema(dataGrid, id);
                    var type = dataGrid == dgvMove ? TypeCinema.Movie : TypeCinema.Series;
                    item.Type = type;
                    using (var form = new EditorItemCinemaForm(this, item, indexRow, indexRowAllCinema))
                    {
                        form.ShowDialog();
                    }
                }
            }
        }

        private void btnDeliteMovie_Click(object sender, EventArgs e)
        {
            var page = BoxName.SelectedTab;

            if (page == tabMovePage)
            {
                if (RemoveRowGrid(dgvMove, out string? idItem))
                    RemoveItemRowGrid(dgvCinema, idItem);
            }
            else if (page == tabSeriesPage)
            {
                if (RemoveRowGrid(dgvSeries, out string? idItem))
                    RemoveItemRowGrid(dgvCinema, idItem);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            GridSerializer(dgvMove);
            GridSerializer(dgvSeries);
            GridSerializer(dgvCinema);
        }

        private void btnPullingFile_Click(object sender, EventArgs e)
        {
            GetItemDeserialize(dgvMove);
            GetItemDeserialize(dgvSeries);
            GetItemDeserialize(dgvCinema);
        }

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

        private string? SelectedRowCinemaId(DataGridView gridCinema)
        {
            int rowIndex = gridCinema.CurrentCell.RowIndex;
            return gridCinema.Rows[rowIndex].Cells[IndexColumnId].Value.ToString();
        }

        private void RemoveItemRowGrid(DataGridView dataGridCinema, string? id)
        {
            foreach (DataGridViewRow row in dataGridCinema.Rows)
            {
                if (row.Cells[IndexColumnId].Value.ToString() == id)
                {
                    dataGridCinema.Rows.RemoveAt(row.Index);
                    break;
                }
            }
        }

        private void AddCinemaGridRow(DataGridView dataGridCinema, WatchItem cinema)
        {
            var partOrSeason = cinema.NumberSequel;
            string formatDate = cinema.Detail?.DateWatch?.ToString("dd.MM.yyyy") ?? string.Empty;
            dataGridCinema.Rows.Add(cinema.Name, partOrSeason.ToString(), cinema.GetView(), formatDate, cinema.Detail?.Grade, cinema.Id.ToString());
        }

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

        private bool IsEditRowGrid(DataGridView cinema, out int rowIndex, out WatchItem? cinemaItem)
        {
            if (cinema.SelectedRows.Count == 0)
            {
                rowIndex = -1;
                cinemaItem = null;
                MessageBoxProvider.ShowWarning("Highlight the desired line");
                return false;
            }
            rowIndex = cinema.CurrentCell.RowIndex;
            cinemaItem = GetItem(cinema, rowIndex);
            return true;
        }

        //Выдача нового элемента таблицы по номеру строки.
        private WatchItem GetItem(DataGridView cinema, int rowIndex)
        {
            var title = cinema.Rows[rowIndex].Cells[IndexColumnName].Value.ToString();
            var sequel = decimal.Parse(cinema.Rows[rowIndex].Cells[IndexColumnSequel].Value.ToString());
            var id = cinema.Rows[rowIndex].Cells[IndexColumnId].Value.ToString();

            if (cinema.Rows[rowIndex].Cells[IndexColumnDate].Value.ToString() != string.Empty)
            {
                var strDateWatch = cinema.Rows[rowIndex].Cells[IndexColumnDate].Value.ToString();
                var dateWatch = DateTime.Parse(strDateWatch);
                var grade = decimal.Parse(cinema.Rows[rowIndex].Cells[IndexColumnGrade].Value.ToString());
                WatchItem cinemaItem = new WatchItem(
                                                   title,
                                                   sequel,
                                                   dateWatch,
                                                   grade,
                                                   TypeCinema.Unknown,
                                                   id);
                return cinemaItem;
            }
            else
            {
                WatchItem cinemaItem = new WatchItem(
                                                  title,
                                                  sequel,
                                                  TypeCinema.Unknown,
                                                  id);
                return cinemaItem;
            }
        }

        //Выдача нового элемента таблицы из строки.
        private WatchItem GetItem(DataGridViewRow row)
        {
            var title = row.Cells[IndexColumnName].Value.ToString();
            var sequel = decimal.Parse(row.Cells[IndexColumnSequel].Value.ToString());
            var id = row.Cells[IndexColumnId].Value.ToString();
            if (row.Cells[IndexColumnDate].Value.ToString() != string.Empty)
            {
                var strDateWatch = row.Cells[IndexColumnDate].Value.ToString();
                var dateWatch = DateTime.Parse(strDateWatch);
                var grade = decimal.Parse(row.Cells[IndexColumnGrade].Value.ToString());

                WatchItem cinemaItem = new WatchItem(
                                                   title,
                                                   sequel,
                                                   dateWatch,
                                                   grade,
                                                   TypeCinema.Unknown,
                                                   id);
                return cinemaItem;
            }
            else
            {
                WatchItem cinemaItem = new WatchItem(
                                                  title,
                                                  sequel,
                                                  TypeCinema.Unknown,
                                                  id);
                return cinemaItem;
            }
        }

        private int GetNumberItemGridCinema(DataGridView cinema, string id)
        {
            foreach (DataGridViewRow row in cinema.Rows)
            {
                if (row.Cells[IndexColumnId].Value.ToString() == id)
                {
                    return row.Index;
                }
            }
            return -1;
        }

        private void ReplacementEditItem(DataGridView cinema, WatchItem cinemaItem, int rowItem)
        {
            cinema.Rows[rowItem].Cells[IndexColumnName].Value = cinemaItem.Name;
            cinema.Rows[rowItem].Cells[IndexColumnSequel].Value = cinemaItem.NumberSequel;
            cinema.Rows[rowItem].Cells[IndexColumnId].Value = cinemaItem.Id;

            if (cinemaItem.Detail?.DateWatch != null)
            {
                cinema.Rows[rowItem].Cells[IndexColumnIsWatch].Value = "+";
                cinema.Rows[rowItem].Cells[IndexColumnDate].Value = cinemaItem.Detail?.DateWatch?.ToString("dd.MM.yyyy");
                cinema.Rows[rowItem].Cells[IndexColumnGrade].Value = cinemaItem.Detail?.Grade;
            }
            else
            {
                cinema.Rows[rowItem].Cells[IndexColumnIsWatch].Value = "-";
                cinema.Rows[rowItem].Cells[IndexColumnDate].Value = string.Empty;
                cinema.Rows[rowItem].Cells[IndexColumnGrade].Value = string.Empty;
            }
        }

        //Запись JSON в файл, по пути каталога path и с названием, в зависимости от таблицы.
        private void GridSerializer(DataGridView grid)
        {
            if (grid.Rows.Count < 0)
                MessageBoxProvider.ShowError("Grid without elements.");
            var itemList = new List<WatchItem>();
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells[IndexColumnId].Value == null)
                    break;
                var item = GetItem(row);
                item.Type = GetType(grid);
                itemList.Add(item);
            }
            var path = @$"{_path}Grid{grid.Tag}.json";
            var fileRepository = new FileWatchItemRepository(path);
            fileRepository.Save(itemList);
        }

        private TypeCinema GetType(DataGridView grid)
        {
            if (grid.Tag == TypeTagMove)
                return TypeCinema.Movie;
            else if (grid.Tag == TypeTagSeries)
                return TypeCinema.Series;
            return TypeCinema.Unknown;
        }

        private void GetItemDeserialize(DataGridView grid)
        {
            grid.Rows.Clear();
            var pathFile = @$"{_path}Grid{grid.Tag}.json";
            if (!File.Exists(pathFile))
            {
                MessageBoxProvider.ShowError("File missing.");
                return;
            }
            var fileRepository = new FileWatchItemRepository(pathFile);
            var itemGrid = fileRepository.GetAll();
            if (itemGrid == null || itemGrid.Count <= 0)
                return;
            foreach (var item in itemGrid)
            {
                AddCinemaGridRow(grid, item);
            }
        }
    }
}