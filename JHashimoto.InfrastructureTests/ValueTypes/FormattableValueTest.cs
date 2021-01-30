using JHashimoto.Infrastructure.ValueTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JHashimoto.Infrastructure.Tests.ValueTypes {
    /// <summary>
    /// FormattableValueTest の概要の説明
    /// </summary>
    [TestClass]
    public class FormattableValueTest {
        public FormattableValueTest() {
            //
            // TODO: コンストラクター ロジックをここに追加します
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///現在のテストの実行についての情報および機能を
        ///提供するテスト コンテキストを取得または設定します。
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region 追加のテスト属性
        //
        // テストを作成する際には、次の追加属性を使用できます:
        //
        // クラス内で最初のテストを実行する前に、ClassInitialize を使用してコードを実行してください
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // クラス内のテストをすべて実行したら、ClassCleanup を使用してコードを実行してください
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 各テストを実行する前に、TestInitialize を使用してコードを実行してください
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 各テストを実行した後に、TestCleanup を使用してコードを実行してください
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ゼロ埋め() {
            FormattableValue<int> v = new FormattableValue<int>(1000, 8, '0');

            string expected = "00001000";
            string actual = v.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 半角スペース埋め() {
            FormattableValue<int> v = new FormattableValue<int>(1000, 8, ' ');

            string expected = "    1000";
            string actual = v.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Null() {
            FormattableValue<Formattable> v = new FormattableValue<Formattable>(null, 8, ' ');

            string expected = new string(' ', 8);

            string actual = v.ToString();

            Assert.AreEqual(expected, actual);
        }

        class Formattable : IFormattable {
            public string ToString(string format, IFormatProvider formatProvider) {
                return base.ToString();
            }
        }
    }
}
