using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace DataGridProject.HeaderName
{
    internal class HeaderNames
    {
        private readonly List<HeaderNameObj> list;

        public HeaderNames(List<HeaderNameObj> list)
        {
            this.list = list;
        }

        public string SearchNormalName(string headerPropertyName)
        {
            HeaderNameObj? headerName = list.FirstOrDefault(headerName => headerName.EqualHeaderPropertyName(headerPropertyName));
            if(headerName == null)
            {
                throw new Exception("プロパティ名が不正です");
            }
            return headerName.normalName;
        }

        public string SearchAscendingName(string headerPropertyName)
        {
            HeaderNameObj? headerName = list.FirstOrDefault(headerName => headerName.EqualHeaderPropertyName(headerPropertyName));
            if (headerName == null)
            {
                throw new Exception("プロパティ名が不正です");
            }
            return headerName.ascendingName;
        }

        public string SearchDescendingName(string headerPropertyName)
        {
            HeaderNameObj? headerName = list.FirstOrDefault(headerName => headerName.EqualHeaderPropertyName(headerPropertyName));
            if (headerName == null)
            {
                throw new Exception("プロパティ名が不正です");
            }
            return headerName.descendingName;
        }

        public bool ExistPropertyName(string headerPropertyName)
        {
            return list.Any(headerName => headerName.EqualHeaderPropertyName(headerPropertyName));
        }
    }
}
