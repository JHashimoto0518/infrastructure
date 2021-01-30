using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using JHashimoto.Infrastructure.Diagnostics;

namespace JHashimoto.Infrastructure.Collections {
    /// <summary>
    /// <para>
    /// オブジェクトのリストを表す抽象クラスです。
    /// </para>
    /// </summary>
    /// <typeparam name="T">リストの要素の型。</typeparam>
    public abstract class ListBase<T> {
        /// <summary>
        /// 保持しているリスト。
        /// </summary>
        private readonly List<T> list;

        /// <summary>
        /// 保持しているリストを取得します。
        /// </summary>
        public List<T> Items {
            get { return list; }
        }

        /// <summary>
        /// <see cref="ListBase"/>クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="list">保持するリスト。</param>
        public ListBase(IEnumerable<T> list) {
            Guard.ArgumentNotNull<IEnumerable<T>>(list, "list");

            this.list = list.ToList();
        }

        /// <summary>
        /// <see cref="ListBase"/>クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="item">保持するリストに含まれる要素。</param>
        public ListBase(T item) : this(new List<T>() { item }) {
        }

        /// <summary>
        /// <see cref="ListBase"/>クラスの新しいインスタンスを初期化します。
        /// </summary>
        public ListBase() {
            this.list = new List<T>();
        }

        /// <summary>
        /// リストが要素を保持しているかどうかを示す値を取得します。
        /// </summary>
        /// <value>リストが要素を保持している場合は<c>true</c>。要素を保持していない場合は<c>false</c>。</value>
        public bool HasData {
            get {
                return this.list.Any();
            }
        }

        /// <summary>
        /// リストに要素を追加します。
        /// </summary>
        /// <param name="item">追加する要素。</param>
        public void Add(T item) {
            this.list.Add(item);
        }

        /// <summary>
        /// リストに要素を追加します。
        /// </summary>
        /// <param name="items">追加する要素。</param>
        public void AddRange(IEnumerable<T> items) {
            Guard.ArgumentNotNull<IEnumerable<T>>(items, "items");

            this.list.AddRange(items);
        }

        /// <summary>
        /// 現在のオブジェクトを表す文字列を返します。
        /// </summary>
        /// <returns>現在のオブジェクトを説明する文字列。</returns>
        public override string ToString() {
            if (this.HasData == false) {
                return "[None]";
            }

            StringBuilder b = new StringBuilder();

            foreach (T d in this.list) {
                if (b.Length != 0)
                    b.AppendLine();

                b.Append(d);
            }

            return b.ToString();
        }
    }
}
