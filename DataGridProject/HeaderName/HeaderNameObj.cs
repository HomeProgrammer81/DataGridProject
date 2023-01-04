namespace DataGridProject.HeaderName
{
    /// <summary>
    /// ヘッダー名
    /// </summary>
    internal class HeaderNameObj
    {
        /// <summary>
        /// ソートメンバーパス
        /// </summary>
        public readonly string sortMemberPath;

        /// <summary>
        /// ヘッダープロパティ名称
        /// </summary>
        public string headerProperty { get; }

        /// <summary>
        /// 通常名称
        /// </summary>
        public string normalName { get; }

        /// <summary>
        /// 昇順名称
        /// </summary>
        public string ascendingName { get; }

        /// <summary>
        /// 降順名称
        /// </summary>
        public string descendingName { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="sortMemberPath">ソートメンバーパス</param>
        /// <param name="headerProperty">ヘッダープロパティ名称</param>
        /// <param name="normalName">通常名称</param>
        /// <param name="ascendingName">昇順名称</param>
        /// <param name="descendingName">降順名称</param>
        public HeaderNameObj(string sortMemberPath, string headerProperty, string normalName, string ascendingName, string descendingName )
        {
            this.sortMemberPath = sortMemberPath;
            this.headerProperty = headerProperty;
            this.normalName = normalName;
            this.ascendingName = ascendingName;
            this.descendingName = descendingName;
        }

        /// <summary>
        /// ソートメンバーパスが一致するか確認する
        /// </summary>
        /// <param name="sortMemberPath">ソートメンバーパス</param>
        /// <returns>true:一致する</returns>
        public bool EqualSortMemberPath(string sortMemberPath)
        {
            return this.sortMemberPath.Equals(sortMemberPath);
        }
    }
}
