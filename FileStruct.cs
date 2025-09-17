using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStruct
{
    public class File
    {
        private string _name;
        private string _last_edit_time;
        private string _last_edit_date;
        private string _type;

        // Констукторы
        public File()
        {
            _name = "Undefined";
            _last_edit_time = "00:00";
            _last_edit_date = "00.00.0000";
            _type = ".///";
        }
        public File(string name, string last_edit_time, string last_edit_date, string type)
        {
            _name = name;
            _last_edit_time = last_edit_time;
            _last_edit_date = last_edit_date;
            this._type = type;
        }

        // Сеттеры для полей класса
        public void SetName(string name)
        {
            this._name = name;
        }
        public void SetLastEditedtime(string _let)
        {
            this._last_edit_date = _let;
        }
        public void SetLastEditDate(string led)
        {
            this._last_edit_date = led;
        }
        public void SetType(string type)
        {
            this._type = type;
        }

        // Геттеры для полей класса
        public string GetName()
        {
            return this._name;
        }
        public string GetLastEditedTime()
        {
            return this._last_edit_time;
        }
        public string GetLastEditedDate()
        {
            return this._last_edit_date;
        }
        public string GetType()
        {
            return this._type;
        }
    }
}
