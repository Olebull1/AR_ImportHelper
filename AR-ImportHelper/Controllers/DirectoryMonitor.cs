using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR_ImportHelper.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;

    public class DirectoryMonitor
    {
        private readonly string _directoryPath;
        private HashSet<string> _existingFiles;
        private CancellationTokenSource _cts;
        private bool firstPass;

        public event Action<List<string>> OnNewFilesDetected;

        public DirectoryMonitor(string directoryPath)
        {
            firstPass = true;
            _directoryPath = directoryPath;
            _existingFiles = new HashSet<string>(Directory.Exists(directoryPath) ? Directory.GetFiles(directoryPath) : Enumerable.Empty<string>());
        }

        public void StartMonitoring()
        {
            _cts = new CancellationTokenSource();
            Task.Run(() => MonitorDirectory(_cts.Token), _cts.Token);
        }

        public void StopMonitoring()
        {
            _cts?.Cancel();
        }

        private void MonitorDirectory(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (!Directory.Exists(_directoryPath))
                    {
                        Thread.Sleep(2000);
                        continue;
                    }

                    var currentFiles = new HashSet<string>(Directory.GetFiles(_directoryPath));

                    if (!currentFiles.SetEquals(_existingFiles) || firstPass)
                    {
                        firstPass = false;
                        _existingFiles = currentFiles;
                        OnNewFilesDetected?.Invoke(_existingFiles.ToList()); // Notify subscribers
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error monitoring directory: {ex.Message}");
                }

                Thread.Sleep(2000); // Wait 2 seconds before checking again
            }
        }
    }

}
