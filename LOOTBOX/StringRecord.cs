// https://habr.com/ru/post/130361/
// https://habr.com/ru/post/146901/
// https://regex101.com/r/gM6pE0/1
// ФИО Лучше не проверять. Достаточный пример ребенок И.Маска.

using System;

namespace LOOTBOX
{
    public class StringRecord
    {
        private const int MAX_LEIGHT = 50;
        public string Value { get; }

        public StringRecord(string value, int max_string_len = MAX_LEIGHT, bool requared = true)
        {
            if (max_string_len < 1 || max_string_len > int.MaxValue)
            {
                throw new StringRecordExeption($"Значение вне диапазона 1...{int.MaxValue}. Указано: {max_string_len}");
            }

            if (value.Length > max_string_len)
            {
                value = value.Substring(0, max_string_len);
            }

            value = value.Trim();

            if (requared && string.IsNullOrWhiteSpace(value))
            {
                throw new StringRecordExeption("Пустая строка или пробельные символы недопустимы.");
            }

            Value = value;
        }
    }
    class StringRecordExeption : ArgumentException
    {
        public StringRecordExeption(string message) : base(message)
        {

        }
    }
}

