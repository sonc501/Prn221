using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Repo.Commons
{
    public class Pagination<T>
    {
        public int TotalItemsCount { get; set; } = 0;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; }
        public ICollection<T> Items { get; set; }


        // calculated value below
        public int TotalPagesCount
        {
            get
            {
                var temp = TotalItemsCount / PageSize;
                if (TotalItemsCount % PageSize == 0)
                {
                    return temp;
                }
                return temp + 1;
            }
        }

        /// <summary>
        /// page number start from 0
        /// </summary>
        public bool Next => PageIndex + 1 < TotalPagesCount;
        public bool Previous => PageIndex > 0;
    }
}
