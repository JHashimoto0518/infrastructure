using System;

namespace JHashimoto.Infrastructure.ValueTypes {
    /// <summary>
    /// 指定した文字で、桁埋めできる値を表します。
    /// </summary>
    /// <typeparam name="T">値の型。</typeparam>
    public class FormattableValue<T> where T : IFormattable {
        /// <summary>
        /// 桁埋めする値。
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// 桁数。
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// 桁埋めに使う文字。
        /// </summary>
        public char PaddingChar { get; }

        /// <summary>
        /// <see cref="FormattableValue"/>クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="value">桁埋めする値。</param>
        /// <param name="length">桁数。</param>
        /// <param name="paddingChar">桁埋めに使う文字。</param>
        public FormattableValue(T value, int length, char paddingChar) {
            this.Value = value;
            this.Length = length;
            this.PaddingChar = paddingChar;
        }

        /// <summary>
        /// 現在のオブジェクトを表す文字列を返します。
        /// </summary>
        /// <returns>現在のオブジェクトを説明する文字列。</returns>
        public override string ToString() {
            string s = this.Value == null ? string.Empty : this.Value.ToString();

            return s.PadLeft(this.Length, this.PaddingChar);
        }
    }
}
