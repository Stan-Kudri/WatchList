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

        public const int NumberTypeAllCinema = 0;
        public const int NumberTypeMove = 1;
        public const int NumberTypeSeries = 2;

        private const string TypeTagMove = "Move";
        private const string TypeTagSeries = "Series";

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
                }
                else if (cinema.Type == TypeCinema.Movie)
                {
                    AddCinemaGridRow(dgvMove, cinema);
                }
                AddCinemaGridRow(dgvCinema, cinema);
            }
        }

        public void EditItemGrid(CinemaModel cinemaItem, int numberRowGridCinema, int numberRowAllGridCinema)
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

        private void BtnFormMovie_Click(object sender, EventArgs e)
        {
            using (var form = new AddCinemaForm(this, TypeCinema.Movie))
            {
                form.ShowDialog();
            }
        }

        private void BtnFormSeries_Click(object sender, EventArgs e)
        {
            using (var form = new AddCinemaForm(this, TypeCinema.Series))
            {
                form.ShowDialog();
            }
        }

        private void BtnEditRow_Click(object sender, EventArgs e)
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

        private void BtnDeliteMovie_Click(object sender, EventArgs e)
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

        //Удаление строки из переданной таблицы, по выбранной строке.
        //out параметр является id фильма/сериала, который необходимо удалить с таблицы (Если это Move/Series тогла с Cinema и наоборот).
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

        //Нахождения id по выбранной строке.
        private string? SelectedRowCinemaId(DataGridView gridCinema)
        {
            int rowIndex = gridCinema.CurrentCell.RowIndex;
            return gridCinema.Rows[rowIndex].Cells[IndexColumnId].Value.ToString();
        }

        //Удаление строки из таблицы по значению id.
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

        //Добавить элемент в таблицу.
        private void AddCinemaGridRow(DataGridView dataGridCinema, CinemaModel cinema)
        {
            var partOrSeason = cinema.NumberSequel;
            string formatDate = cinema.Detail?.DateWatch?.ToString("dd.MM.yyyy") ?? string.Empty;
            dataGridCinema.Rows.Add(cinema.Name, partOrSeason.ToString(), cinema.GetView(), formatDate, cinema.Detail?.Grade, cinema.Id.ToString());
        }

        private void AddCinemaGrid(DataGridView dataGridCinema, List<WatchItem> itemGrid)
        {
            foreach (var item in itemGrid)
            {
                var partOrSeason = item.NumberSequel;
                string formatDate = item.Detail?.DateWatch?.ToString("dd.MM.yyyy") ?? string.Empty;
                dataGridCinema.Rows.Add(item.Name, partOrSeason.ToString(), item.GetView(), formatDate, item.Detail?.Grade, item.Id.ToString());
            }
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

        private bool IsEditRowGrid(DataGridView cinema, out int rowIndex, out CinemaModel? cinemaItem)
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

        private void ShowEditCinema(DataGridView grid, CinemaModel item, int indexRow)
        {
            item.Type = GetType(grid);
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

        //Выдача нового элемента таблицы по номеру строки.
        private static CinemaModel GetItem(DataGridView cinema, int rowIndex)
        {
            var title = cinema.Rows[rowIndex].Cells[IndexColumnName].Value.ToString();
            var sequel = decimal.Parse(cinema.Rows[rowIndex].Cells[IndexColumnSequel].Value.ToString());
            var id = cinema.Rows[rowIndex].Cells[IndexColumnId].Value.ToString() ?? string.Empty;

            if (cinema.Rows[rowIndex].Cells[IndexColumnDate].Value.ToString() != string.Empty)
            {
                var strDateWatch = cinema.Rows[rowIndex].Cells[IndexColumnDate].Value.ToString();
                var dateWatch = DateTime.Parse(strDateWatch);
                var grade = decimal.Parse(cinema.Rows[rowIndex].Cells[IndexColumnGrade].Value.ToString() ?? "0");
                CinemaModel cinemaItem = new CinemaModel(
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
                CinemaModel cinemaItem = new CinemaModel(
                                                  title,
                                                  sequel,
                                                  TypeCinema.Unknown,
                                                  id);
                return cinemaItem;
            }
        }

        //Выдача нового элемента таблицы из строки.
        private static WatchItem GetItem(DataGridViewRow row)
        {
            var title = row.Cells[IndexColumnName].Value.ToString();
            var sequel = decimal.Parse(row.Cells[IndexColumnSequel].Value.ToString());
            var id = row.Cells[IndexColumnId].Value.ToString() ?? string.Empty;
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
                                                   null,
                                                   id);
                return cinemaItem;
            }
            else
            {
                var cinemaItem = new WatchItem(
                                                  title,
                                                  sequel,
                                                  null,
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

        private void ReplacementEditItem(DataGridView cinema, CinemaModel cinemaItem, int rowItem)
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
                item.InstallationType(NumberType(grid));
                itemList.Add(item);
            }
            var path = @$"{_path}Grid{grid.Tag}.json";
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

        private int NumberType(DataGridView grid)
        {
            if ((string)grid.Tag == TypeTagMove)
                return NumberTypeMove;
            if ((string)grid.Tag == TypeTagSeries)
                return NumberTypeSeries;
            return NumberTypeAllCinema;
        }

        private TypeCinema GetType(DataGridView grid)
        {
            if ((string)grid.Tag == TypeTagMove)
                return TypeCinema.Movie;
            else if ((string)grid.Tag == TypeTagSeries)
                return TypeCinema.Series;
            return TypeCinema.Unknown;
        }
    }
}
