namespace ListWatchedMoviesAndSeries
{
    public static class DateTimePickerExt
    {
        public static DateTime? NullableValue(this DateTimePicker dtp)
        {
            return dtp.Checked ? dtp.Value : null;
        }

        public static void NullableValue(this DateTimePicker dtp, DateTime? value)
        {
            dtp.Checked = value.HasValue;
            if (value.HasValue) dtp.Value = value.Value;
        }
    }
}
