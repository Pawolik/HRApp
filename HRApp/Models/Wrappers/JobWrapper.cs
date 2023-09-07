using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Models.Wrappers
{
    public class JobWrapper : IDataErrorInfo
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(ID):
                        if (ID == 0)
                        {
                            Error = "Pole wymagane!";
                        }
                        else
                        {
                            Error = string.Empty;
                        }
                        break;

                    default:
                        break;
                }
                return Error;
            }
        }
        public string Error { get; set; }
        public bool IsValid
        {
            get
            {
                return string.IsNullOrWhiteSpace(Error);
            }
        }
        // Możesz dodać dodatkowe właściwości lub metody
    }
}
