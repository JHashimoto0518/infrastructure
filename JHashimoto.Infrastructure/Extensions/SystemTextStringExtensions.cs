using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using JHashimoto.Infrastructure.Diagnostics;

namespace JHashimoto.Infrastructure.Extensions {
    public static class SystemTextStringExtensions {
        /// <summary>
        /// 指定された文字数の文字列を文字列の右端から取得します。
        /// </summary>
        /// <param name="self">System.Stringのインスタンス。</param>
        /// <param name="length">取り出す文字列の文字数。</param>
        /// <returns>取り出した文字列。</returns>
        public static string Right(this string self, int length) {
            Guard.ArgumentNotNull<string>(self, "self", "Null文字列に対してRightを呼び出すことはできません。");
            Guard.ArgumentIsPositive(length, "length");

            if (NeedsTruncateChars(self, length) == false)
                return self;

            return self.Substring(self.Length - length, length);
        }

        /// <summary>
        /// 指定された文字数の文字列を文字列の左端から取得します。
        /// </summary>
        /// <param name="self">System.Stringのインスタンス。</param>
        /// <param name="length">取り出す文字列の文字数。</param>
        /// <returns>取り出した文字列。</returns>
        public static string Left(this string self, int length) {
            Guard.ArgumentNotNull<string>(self, "self", "Null文字列に対してLeftを呼び出すことはできません。");
            Guard.ArgumentIsPositive(length, "length");

            if (NeedsTruncateChars(self, length) == false)
                return self;

            return self.Substring(0, length);
        }

        /// <summary>
        /// 文字列の削除が必要かどうかを示す値を取得します。
        /// </summary>
        /// <param name="self">System.Stringのインスタンス。</param>
        /// <param name="length">取り出す文字列の文字数。</param>
        /// <returns>文字列の削除が必要な場合はtrue。不要な場合はfalse。</returns>
        private static bool NeedsTruncateChars(string self, int length) {
            if (string.IsNullOrEmpty(self))
                return false;

            if (self.Length <= length) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 文字列の先頭から、指定された文字列を削除します。
        /// </summary>
        /// <param name="self">System.Stringのインスタンス。</param>
        /// <param name="trimString">削除する文字列。</param>
        /// <returns>
        /// 現在の文字列の先頭から、<paramref name="trimString"/>パラメーターの文字を削除した後に残った文字列。 
        /// </returns>
        /// <remarks>文字列の先頭から指定された文字列が繰り返し出現する場合は、１回目に出現した文字列だけを削除します。</remarks>
        public static string TrimStartOnce(this string self, string trimString) {
            Guard.ArgumentNotNull<string>(self, "self", "Null文字列に対してTrimStartOnceを呼び出すことはできません。");

            if (string.IsNullOrEmpty(self))
                return self;

            if (self.StartsWith(trimString))
                return self.Substring(trimString.Length, self.Length - trimString.Length);

            return self;
        }

        /// <summary>
        /// 文字列の末尾から、指定された文字列を削除します。
        /// </summary>
        /// <param name="self"><see cref="System.String"/>のインスタンス。</param>
        /// <param name="trimString">削除する文字列。</param>
        /// <returns>
        /// 現在の文字列の末尾から、<paramref name="trimString"/>パラメーターの文字を削除した後に残った文字列。 
        /// </returns>
        /// <remarks>文字列の末尾から指定された文字列が繰り返し出現する場合は、１回目に出現した文字列だけを削除します。</remarks>
        public static string TrimEndOnce(this string self, string trimString) {
            Guard.ArgumentNotNull<string>(self, "self", "Null文字列に対してを呼び出すことはできません。");

            if (string.IsNullOrEmpty(self))
                return self;

            if (self.EndsWith(trimString))
                return self.Substring(0, self.Length - trimString.Length);

            return self;
        }

        public static string GetPackageUri(this string resourceName, string assemblyName) {
            return $"pack://application:,,,/{assemblyName};component/Resources/{resourceName}";
        }

        public static string GetPackageUri(this string resourceName) {
            return GetPackageUri(resourceName, Assembly.GetCallingAssembly().FullName);
        }
    }
}
