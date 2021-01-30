using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JHashimoto.Infrastructure.Extensions {
    public static class SystemIOStreamExtensions {
        public static void WrireToFile(this Stream self, string path) {
            using (var destination = new FileStream(path, FileMode.Create, FileAccess.Write)) {
                self.CopyTo(destination);
            }
        }
    }
}
