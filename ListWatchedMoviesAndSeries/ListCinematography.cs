using ListWatchedMoviesAndSeries.EditorForm;
using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;
using System.Text.Json;

namespace ListWatchedMoviesAndSeries
{
    public partial class BoxCinemaForm : Form
    {
        private string path = @"C:\\Grid\";
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public BoxCinemaForm()
        {
            InitializeComponent();
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);
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
            int columnIndex = 5; //Column "ID" in DataGridView

            return gridCinema.Rows[rowIndex].Cells[columnIndex].Value.ToString();
        }

        private void RemoveItemRowGrid(DataGridView dataGridCinema, string? id)
        {
            foreach (DataGridViewRow row in dataGridCinema.Rows)
            {
                if (row.Cells[5].Value.ToString() == id)
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
                var titleItem = dgvMove.Rows[i].Cells[5].Value;
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
            var title = cinema.Rows[rowIndex].Cells[0].Value.ToString();
            var sequel = decimal.Parse(cinema.Rows[rowIndex].Cells[1].Value.ToString());
            var id = cinema.Rows[rowIndex].Cells[5].Value.ToString();

            if (cinema.Rows[rowIndex].Cells[3].Value.ToString() != string.Empty)
            {
                var strDateWatch = cinema.Rows[rowIndex].Cells[3].Value.ToString();
                var dateWatch = DateTime.Parse(strDateWatch);
                var grade = decimal.Parse(cinema.Rows[rowIndex].Cells[4].Value.ToString());
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
            var title = row.Cells[0].Value.ToString();
            var sequel = decimal.Parse(row.Cells[1].Value.ToString());
            var id = row.Cells[5].Value.ToString();
            if (row.Cells[3].Value.ToString() != string.Empty)
            {
                var strDateWatch = row.Cells[3].Value.ToString();
                var dateWatch = DateTime.Parse(strDateWatch);
                var grade = decimal.Parse(row.Cells[4].Value.ToString());

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
                if (row.Cells[5].Value.ToString() == id)
                {
                    return row.Index;
                }
            }
            return -1;
        }

        private void ReplacementEditItem(DataGridView cinema, WatchItem cinemaItem, int rowItem)
        {
            cinema.Rows[rowItem].Cells[0].Value = cinemaItem.Name;
            cinema.Rows[rowItem].Cells[1].Value = cinemaItem.NumberSequel;
            cinema.Rows[rowItem].Cells[5].Value = cinemaItem.Id;

            if (cinemaItem.Detail?.DateWatch != null)
            {
                cinema.Rows[rowItem].Cells[2].Value = "+";
                cinema.Rows[rowItem].Cells[3].Value = cinemaItem.Detail?.DateWatch?.ToString("dd.MM.yyyy");
                cinema.Rows[rowItem].Cells[4].Value = cinemaItem.Detail?.Grade;
            }
            else
            {
                cinema.Rows[rowItem].Cells[2].Value = "-";
                cinema.Rows[rowItem].Cells[3].Value = string.Empty;
                cinema.Rows[rowItem].Cells[4].Value = string.Empty;
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
                if (row.Cells[5].Value == null)
                    break;
                var item = GetItem(row);
                item.Type = GetType(grid);
                itemList.Add(GetItem(row));
            }

            using (FileStream stream = new FileStream(@$"{path}Grid{GridType(grid)}.json", FileMode.Create))
            {
                JsonSerializer.Serialize(stream, itemList, _options);
            }
        }

        //Получение названия типа таблицы.
        private string GridType(DataGridView grid)
        {
            if (grid == dgvMove)
                return "Move";
            else if (grid == dgvSeries)
                return "Series";
            return "Cinema";
        }

        private TypeCinema GetType(DataGridView grid)
        {
            if (grid == dgvMove)
                return TypeCinema.Movie;
            else if (grid == dgvSeries)
                return TypeCinema.Series;
            return TypeCinema.Unknown;
        }

        private void GetItemDeserialize(DataGridView grid)
        {
            grid.Rows.Clear();
            var pathFile = @$"{path}Grid{GridType(grid)}.json";
            if (!File.Exists(pathFile))
            {
                MessageBoxProvider.ShowError("File missing.");
                return;
            }
            using (FileStream stream = new FileStream(pathFile, FileMode.Open))
            {
                var itemList = JsonSerializer.Deserialize<List<WatchItem>>(stream);
                if (itemList == null || itemList.Count <= 0)
                    return;
                foreach (var item in itemList)
                {
                    AddCinemaGridRow(grid, item);
                }
            }
        }
    }
}