namespace DataGridProject.DataGridSort
{
    /// <summary>
    /// データグリッドソートディレクター
    /// </summary>
    internal class DataGridSortDirector
    {
        private readonly FuncSortAscending funcSortAscending;

        private readonly FuncSortDescending funcSortDescending;

        private readonly FuncSortNormal funcSortNormal;

        /// <summary>
        /// ソートメンバーパス
        /// </summary>
        /// <remarks>nullは未ソース</remarks>
        private string? sortMemberPath;

        /// <summary>
        /// 降順判定
        /// </summary>
        /// <remarks>nullは未ソート</remarks>
        private bool? isDescending;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="funcSortAscending">昇順ソート関数</param>
        /// <param name="funcSortDescending">降順ソート関数</param>
        /// <param name="funcSortNormal">通常ソート関数</param>
        public DataGridSortDirector(FuncSortAscending funcSortAscending, FuncSortDescending funcSortDescending, FuncSortNormal funcSortNormal)
        {
            this.funcSortAscending = funcSortAscending;
            this.funcSortDescending = funcSortDescending;
            this.funcSortNormal = funcSortNormal;

            sortMemberPath = null;
            isDescending = null;
        }

        /// <summary>
        /// ソートする
        /// </summary>
        /// <param name="sortMemberPath">ソートメンバーパス</param>
        public void Sort(string sortMemberPath)
        {
            // 未ソート
            if(this.sortMemberPath == null)
            {
                // 昇順にソート
                funcSortAscending(sortMemberPath);

                // パス変更
                this.sortMemberPath = sortMemberPath;

                // ソート方向を昇順
                isDescending = false;

                return;
            }

            // 前回と違う名前
            if ( !this.sortMemberPath.Equals(sortMemberPath))
            {
                // 昇順にソート
                funcSortAscending(sortMemberPath);

                // 前回のものを通常
                funcSortNormal(this.sortMemberPath);

                // パス変更
                this.sortMemberPath = sortMemberPath;

                // ソート方向を昇順
                isDescending = false;

                return;
            }

            // 前回と同じ名前 昇順
            // 降順にする
            if(isDescending != false)
            {
                // 昇順にソート
                funcSortAscending(sortMemberPath);

                // パス変更
                this.sortMemberPath = sortMemberPath;

                // ソート方向を昇順
                isDescending = false;

                return;
            }

            // 降順にソート
            funcSortDescending(sortMemberPath);

            // パス変更
            this.sortMemberPath = sortMemberPath;

            // ソート方向を昇順
            isDescending = true;

            return;
        }
    }
}
