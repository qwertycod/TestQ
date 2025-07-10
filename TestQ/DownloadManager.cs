namespace TestQ
{
    using System;
    using System.Net.Http; // For HttpClient, though we'll just simulate
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class DownloadManager
    {
        // Simulate a file download operation
        private static async Task DownloadFileAsync(string fileName, int durationSeconds, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Starting download: {fileName} (Expected: {durationSeconds}s) on Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            try
            {
                for (int i = 0; i < durationSeconds; i++)
                {
                    // *** 1. Periodically check for cancellation ***
                    // Option A: Check IsCancellationRequested
                    if (cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Cancellation requested for {fileName}. Aborting loop.");
                        cancellationToken.ThrowIfCancellationRequested(); // Optional: throw for consistent exception handling
                    }

                    // Simulate downloading a chunk
                    await Task.Delay(1000, cancellationToken); // Task.Delay also accepts a CancellationToken!
                                                               // If cancellationToken is cancelled, Task.Delay will throw OperationCanceledException

                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {fileName}: {i + 1}/{durationSeconds} seconds completed.");
                }

                Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Finished download: {fileName}");
            }
            catch (OperationCanceledException)
            {
                // *** 2. Handle OperationCanceledException ***
                // This catches the exception thrown by Task.Delay or ThrowIfCancellationRequested()
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Download cancelled for {fileName}.");
                // Perform any necessary cleanup for the cancelled task here
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] An error occurred during download of {fileName}: {ex.Message}");
            }
        }

        public static async Task Main1(string[] args)
        {
            Console.WriteLine("Press 'C' to cancel all downloads at any time.");
            Console.WriteLine("--------------------------------------------------");

            // Create a CancellationTokenSource - this is our controller
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                CancellationToken token = cts.Token; // Get the token to pass to cancellable operations

                // List of tasks to run concurrently
                List<Task> downloadTasks = new List<Task>();

                // Start some simulated downloads
                downloadTasks.Add(DownloadFileAsync("file1.zip", 5, token)); // Will run for 5 seconds
                downloadTasks.Add(DownloadFileAsync("image.jpg", 3, token)); // Will run for 3 seconds
                downloadTasks.Add(DownloadFileAsync("document.pdf", 7, token)); // Will run for 7 seconds

                // Task to listen for user input (e.g., 'C' for cancel)
                Task userInputTask = Task.Run(() =>
                {
                    Console.WriteLine("\nWaiting for cancellation signal...");
                    while (!token.IsCancellationRequested) // Keep looping until token is cancelled
                    {
                        if (Console.ReadKey(true).KeyChar == 'c')
                        {
                            Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss.fff}] 'C' pressed. Signalling cancellation...");
                            cts.Cancel(); // Signal cancellation!
                            break;
                        }
                        Thread.Sleep(100); // Avoid busy-waiting
                    }
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] User input listener stopped.");
                });

                // Wait for all download tasks to complete (or be cancelled)
                // Use Task.WhenAll to wait for all downloads AND the user input listener
                // We use Task.WhenAny to wait for either all downloads or the user input task to complete first.
                // If any download task or the user input task throws an exception, Task.WhenAll would re-throw.
                // WhenAny allows us to manage the cancellation part.
                try
                {
                    // Create a task that completes when all download tasks are done
                    Task allDownloadsTask = Task.WhenAll(downloadTasks);

                    // Wait until either all downloads complete OR the user input listener completes (due to cancellation)
                    await Task.WhenAny(allDownloadsTask, userInputTask);

                    // If downloads are still running, it means cancellation was requested via user input
                    if (!allDownloadsTask.IsCompleted)
                    {
                        Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss.fff}] Downloads were cancelled by user input.");
                    }
                    else
                    {
                        Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss.fff}] All downloads completed naturally.");
                    }
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss.fff}] A task threw an OperationCanceledException at the top level.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss.fff}] An unhandled exception occurred: {ex.Message}");
                }
                finally
                {
                    // Ensure the user input task finishes gracefully if not already
                    if (!userInputTask.IsCompleted)
                    {
                        // If Main exits, Task.Run tasks might continue in background, but this ensures it stops checking
                        // if cancellation was never requested by user
                        // In a real app, you might await userInputTask or manage its lifetime explicitly.
                    }

                    // Give some time for messages to flush
                    await Task.Delay(500);
                }
            } // CancellationTokenSource is disposed here, releasing resources
            Console.WriteLine("\nApplication exit.");
        }
    }
}
