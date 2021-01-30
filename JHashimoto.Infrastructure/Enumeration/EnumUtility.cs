using System;

namespace JHashimoto.Infrastructure.Enumeration {
    public static class EnumUtility {
        /// <summary>
        /// 列挙定数の名前または数値の文字列形式を、等価の列挙オブジェクトに変換します。
        /// </summary>
        /// <typeparam name="T">列挙型。</typeparam>
        /// <param name="value">変換する名前または値が含まれている文字列。</param>
        /// <returns>値が<paramref name="value"/>により表される<typeparamref name="T"/>型のオブジェクト。</returns>
        /// <remarks>この演算では、大文字と小文字が区別されます。</remarks>
        public static T Parse<T>(string value) where T : struct {
            return (T) EnumUtility.Parse<T>(value, ignoreCase: false);
        }

        /// <summary>
        /// 列挙定数の名前または数値の文字列形式を、等価の列挙オブジェクトに変換します。
        /// 演算で大文字と小文字を区別するかどうかをパラメーターで指定します。
        /// </summary>
        /// <typeparam name="T">列挙型。</typeparam>
        /// <param name="value">変換する名前または値が含まれている文字列。</param>
        /// <param name="ignoreCase">大文字と小文字を区別しない場合は true。大文字と小文字を区別する場合は false。 </param>
        /// <returns>値が<paramref name="value"/>により表される<typeparamref name="T"/>型のオブジェクト。</returns>
        public static T Parse<T>(string value, bool ignoreCase) where T : struct {
            return (T) Enum.Parse(typeof(T), value, ignoreCase);
        }
    }
}
