
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Infraestructure.Util;

namespace Infraestructure
{
    public class FileSystemErrorLog : IErrorLog
    {
        public async Task Write(string data)
        {
            var txt = DateTime.UtcNow + " - " + data + Environment.NewLine;

            await FileUtil.WriteText("Logs\\erros.txt", txt);
        }
    }
}