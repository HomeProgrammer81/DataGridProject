namespace DataGridProject.HeaderName
{
    /// <summary>
    /// ヘッダー名
    /// </summary>
    internal class HeaderNameObj
    {
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
        /// ヘッダープロパティ名称
        /// </summary>
        private readonly string headerPropertyName;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="normalName">通常名称</param>
        /// <param name="ascendingName">昇順名称</param>
        /// <param name="descendingName">降順名称</param>
        /// <param name="headerPropertyName">ヘッダープロパティ名称</param>
        public HeaderNameObj(string normalName, string ascendingName, string descendingName, string headerPropertyName)
        {
            this.normalName = normalName;
            this.ascendingName = ascendingName;
            this.descendingName = descendingName;
            this.headerPropertyName = headerPropertyName;
        }

        public bool EqualHeaderPropertyName(string headerPropertyName)
        {
            return this.headerPropertyName.Equals(headerPropertyName);
        }
    }
}
