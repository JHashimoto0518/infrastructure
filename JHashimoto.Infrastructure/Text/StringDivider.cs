using System.Diagnostics.Contracts;
using JHashimoto.Infrastructure.Diagnostics;

namespace JHashimoto.Infrastructure.Text {
    public class StringDivider {

        public string Text { get; }

        public string Divider { get; }

        public string Left { get; }

        public string Right { get; }

        public int DividerLength {
            get { return Divider.Length; }
        }

        private readonly int dividerPosition;

        public StringDivider(string text, string divider) {
            Guard.ArgumentNotNullOrWhiteSpace(text, "text");
            Guard.ArgumentNotNullOrWhiteSpace(divider, "divider");
            Guard.Assert(text.IndexOf(divider) > 0, "text内にdividerが含まれていません。");

            this.Text = text;
            this.Divider = divider;

            this.dividerPosition = text.IndexOf(divider);

            this.Left = this.ParseLeft();
            this.Right = this.ParseRight();
        }

        private string ParseLeft() {
            int leftLength = this.dividerPosition;
            return this.Text.Substring(0, leftLength);
        }

        private string ParseRight() {
            int rightStartPosition = this.dividerPosition + this.DividerLength;
            int rightLength = this.Text.Length - (this.dividerPosition + this.DividerLength);
            return this.Text.Substring(rightStartPosition, rightLength);
        }
    }
}
