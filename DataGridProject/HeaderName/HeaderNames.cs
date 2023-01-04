using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGridProject.HeaderName
{
    /// <summary>
    /// ヘッダー名一覧
    /// </summary>
    internal class HeaderNames
    {
        /// <summary>
        /// 一覧
        /// </summary>
        private readonly List<HeaderNameObj> list;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="list">一覧</param>
        public HeaderNames(List<HeaderNameObj> list)
        {
            this.list = list;
        }

        /// <summary>
        /// ヘッダー名を取得する
        /// </summary>
        /// <param name="sortMemberPath">ソートメンバーパス</param>
        /// <returns>ヘッダー名</returns>
        public HeaderNameObj? GetHeaderName( string sortMemberPath )
        {
            return list.FirstOrDefault(headerName => headerName.EqualSortMemberPath(sortMemberPath));
        }

        /// <summary>
        /// ループする
        /// </summary>
        /// <param name="func"></param>
        public void Loop( Action<HeaderNameObj> func)
        {
            foreach ( var headerName in list)
            {
                func(headerName);
            }
        }
    }
}
