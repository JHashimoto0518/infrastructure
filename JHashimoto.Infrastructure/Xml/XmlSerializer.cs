using System.Diagnostics.Contracts;
using System.IO;
using System.Xml.Serialization;
using JHashimoto.Infrastructure.Diagnostics;

namespace JHashimoto.Infrastructure.Xml {
    /// <summary>
    /// XMLファイルを読み込む機能を提供します。
    /// </summary>
    /// <typeparam name="T">読み込むデータの設定先のオブジェクトの型。</typeparam>
    public class XmlSerializer<T> {

        public void Serialize(string xmlFileFullPath, T obj) {
            using (FileStream stream = new FileStream(xmlFileFullPath, FileMode.Create, FileAccess.Write)) {
                this.Serialize(stream, obj);
            }
        }

        public void Serialize(Stream stream, T obj) {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, obj);
        }

        /// <summary>
        /// XMLファイルを読み込みます。
        /// </summary>
        /// <returns>読み込んだデータを設定したオブジェクト。</returns>
        public T Deserialize(string xmlFileFullPath) {
            Guard.ArgumentNotNullOrWhiteSpace(xmlFileFullPath, "xmlFileFullPath");
            Guard.Assert(File.Exists(xmlFileFullPath), "指定されたXMLファイルは存在しません。");

            using (FileStream stream = new FileStream(xmlFileFullPath, FileMode.Open, FileAccess.Read)) {
                return this.Deserialize(stream);
            }
        }

        /// <summary>
        /// <see cref="System.IO.FileStream"/>を読み込みます。
        /// </summary>
        /// <returns>読み込んだデータを設定したオブジェクト。</returns>
        public T Deserialize(Stream stream) {
            Guard.ArgumentNotNull<Stream>(stream, "stream");

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T) serializer.Deserialize(stream);
        }
    }
}

