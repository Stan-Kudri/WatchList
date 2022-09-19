﻿using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries
{
    public partial class AddCinemaForm : Form
    {
        private readonly BoxCinemaForm _box;
        private bool _checkDataWatch; //Поле для контроля использования DataTimePicker даты просмотра.
        private readonly TypeCinema _type;

        public AddCinemaForm(BoxCinemaForm formBoxCinema, TypeCinema type)
        {
            _box = formBoxCinema;
            _type = type;
            InitializeComponent();
            labelNumberSeaquel.Text = _type.Name;
            dateTimePickerCinema.MaxDate = DateTime.Now;
        }

        private void BtnAddSCinema_Click(object sender, EventArgs e)
        {
            if (!ValidateFields(out var errorMessage))
            {
                MessageBoxProvider.ShowWarning(errorMessage);
            }
            else
            {
                if (_checkDataWatch)
                {
                    _box.SetNameGrid(new WatchItem(txtAddCinema.Text, numericSeaquel.Value, dateTimePickerCinema.Value, numericGradeCinema.Value, _type));
                }
                else
                {
                    _box.SetNameGrid(new WatchItem(txtAddCinema.Text, numericSeaquel.Value, _type));
                }
                DefoultValue();
            }
        }

        private void BtnClearTxtCinema_Click(object sender, EventArgs e) => DefoultValue();

        private void BtnBackFormCinema_Click(object sender, EventArgs e) => Close();

        private void DtpCinema_ValueChanged(object sender, EventArgs e)
        {
            _checkDataWatch = true;
            numericGradeCinema.ReadOnly = false;
            numericGradeCinema.Enabled = true;
        }

        private void DefoultValue()
        {
            txtAddCinema.Text = string.Empty;
            _checkDataWatch = false;
            numericGradeCinema.Enabled = false;
            numericGradeCinema.Value = 0;
            numericSeaquel.Value = 0;
            numericGradeCinema.ReadOnly = true;
        }

        private bool ValidateFields(out string errorMessage)
        {
            if (txtAddCinema.Text.Length <= 0)
            {
                errorMessage = $"Enter {_type.Name} name";
                return false;
            }
            else if (numericSeaquel.Value == 0)
            {
                errorMessage = $"Enter namber {_type.Name}";
                return false;
            }
            else if (_checkDataWatch == true && numericGradeCinema.Value == 0)
            {
                errorMessage = "Grade cinema above in zero";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
    }
}