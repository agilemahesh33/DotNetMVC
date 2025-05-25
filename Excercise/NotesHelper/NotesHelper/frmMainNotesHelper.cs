using NAudio.Utils;
using NAudio.Wave;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks.Dataflow;
using Whisper.net;
using Whisper.net.Ggml;

namespace NotesHelper;

public partial class frmMainNotesHelper : Form
{
    private WasapiLoopbackCapture capture;
    private MemoryStream recordedAudioStream;
    private WaveFileWriter writer;
    private bool isRecording = false;

    private WhisperProcessor processor; // Changed from IWhisperProcessor
    private MemoryStream bufferStream;
    private readonly object bufferLock = new object();

    public frmMainNotesHelper()
    {
        InitializeComponent();
    }

    private void btnStartStop_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnStartStop.Text == "Start")
            {
                StartRecording();
                btnStartStop.Text = "Stop";
            }
            else
            {
                StopCapture();
                btnStartStop.Text = "Start";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

   

    private void frmMainNotesHelper_Load(object sender, EventArgs e)
    {
        // Prepare model on load
        var modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ggml-base.en.bin");
        if (!File.Exists(modelPath))
        {
            MessageBox.Show("Missing model file.");
            return;
        }

        var factory = WhisperFactory.FromPath(modelPath);
        processor = factory.CreateBuilder().WithLanguage("en").Build();
    }
    private void StartRecording()
    {
        capture = new WasapiLoopbackCapture();
        bufferStream = new MemoryStream();

        capture.DataAvailable += async (s, a) =>
        {
            lock (bufferLock)
            {
                bufferStream.Write(a.Buffer, 0, a.BytesRecorded);
            }

            if (bufferStream.Length > capture.WaveFormat.AverageBytesPerSecond * 3) // ~3 seconds
            {
                await ProcessAudioBuffer();
            }
        };

        capture.RecordingStopped += (s, a) =>
        {
            if (capture != null)
            {
                capture.Dispose();
                capture = null;
            }
        };

        capture.StartRecording();
    }

    private async Task ProcessAudioBuffer()
    {
        MemoryStream localCopy;
        lock (bufferLock)
        {
            localCopy = new MemoryStream(bufferStream.ToArray());
            bufferStream.SetLength(0);
        }

        localCopy.Position = 0;

        // Step 1: Wrap raw audio with correct format
        using var rawWaveStream = new RawSourceWaveStream(localCopy, capture.WaveFormat);

        // Step 2: Convert to 16-bit PCM mono 16kHz (required by Whisper)
        var targetFormat = new WaveFormat(16000, 16, 1);
        using var resampler = new MediaFoundationResampler(rawWaveStream, targetFormat)
        {
            ResamplerQuality = 60
        };

        // Step 3: Write to WAV memory stream
        using var wavStream = new MemoryStream();
        WaveFileWriter.WriteWavFileToStream(wavStream, resampler);
        wavStream.Position = 0;

        // Debug (optional):
        //Debug.WriteLine($"Format: {resampler.OutputWaveFormat}");

        // Step 4: Process with Whisper
        try
        {
            await foreach (var segment in processor.ProcessAsync(wavStream))
            {
                AppendText(segment.Text.Trim());
            }
        }
        catch (Exception ex)
        {
            Invoke(() => MessageBox.Show("Transcription failed: " + ex.Message));
        }
    }



    private void StopCapture()
    {
        capture?.StopRecording();
        capture?.Dispose();
        capture = null;
    }

    private void AppendText(string newText)
    {
        if (string.IsNullOrWhiteSpace(newText)) return;

        Invoke(() =>
        {
            richTextBox1.AppendText(newText + Environment.NewLine);
        });
    }
}
