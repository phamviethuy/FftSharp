using NAudio.Wave;
using ScottPlot;
using System;
using System.Windows;
using System.Windows.Threading;

namespace PlotDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int SAMPLE_RATE = 48000;
        private WaveInEvent wvin;
        readonly DispatcherTimer renderTimer;
        public MainWindow()
        {
            InitializeComponent();

            plotPcm.Configure(middleClickMarginX: 0);
            plotFFT.Configure(middleClickMarginX: 0);
            cbbDevices.Items.Clear();
            for (int i = 0; i < WaveIn.DeviceCount; i++)
                cbbDevices.Items.Add(WaveIn.GetCapabilities(i).ProductName);
            if (cbbDevices.Items.Count > 0)
                cbbDevices.SelectedIndex = 0;
            else
                MessageBox.Show("ERROR: no recording devices available");
            renderTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(10)
            };
            renderTimer.Tick += Render;
            btnStart.Click += BtnStart_Click;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            renderTimer.Start();
            if (btnStart.Content.ToString() == "Start")
            {
                btnStart.Content = "Stop";
                StartRecording();
            }
            else
            {
                btnStart.Content = "Start";
                wvin?.StopRecording();
            }


        }
        private void StartRecording()
        {
            wvin?.Dispose();
            wvin = new WaveInEvent
            {
                DeviceNumber = cbbDevices.SelectedIndex,
                WaveFormat = new WaveFormat(rate: SAMPLE_RATE, bits: 16, channels: 1)
            };
            wvin.DataAvailable += OnDataAvailable;
            wvin.BufferMilliseconds = 20;
            wvin?.StartRecording();
        }


        double[] lastBuffer;
        private void OnDataAvailable(object sender, WaveInEventArgs args)
        {
            int bytesPerSample = wvin.WaveFormat.BitsPerSample / 8;
            int samplesRecorded = args.BytesRecorded / bytesPerSample;
            if (lastBuffer is null || lastBuffer.Length != samplesRecorded)
                lastBuffer = new double[samplesRecorded];
            for (int i = 0; i < samplesRecorded; i++)
                lastBuffer[i] = BitConverter.ToInt16(args.Buffer, i * bytesPerSample);
        }

        PlottableSignal signalPlotFFt;
        PlottableSignal signalPlotPcm;

        private void Render(object sender, EventArgs e)
        {
            if (lastBuffer is null)
                return;

            double[] window = FftSharp.Window.Hanning(lastBuffer.Length);
            double[] windowed = FftSharp.Window.Apply(window, lastBuffer);
            double[] zeroPadded = FftSharp.Pad.ZeroPad(windowed);
            double[] fftPower = cbDecibel.IsChecked == true ?
                FftSharp.Transform.FFTpower(zeroPadded) :
                FftSharp.Transform.FFTmagnitude(zeroPadded);
            double[] fftFreq = FftSharp.Transform.FFTfreq(SAMPLE_RATE, fftPower.Length);

            // determine peak frequency
            double peakFreq = 0;
            double peakPower = 0;
            for (int i = 0; i < fftPower.Length; i++)
            {
                if (fftPower[i] > peakPower)
                {
                    peakPower = fftPower[i];
                    peakFreq = fftFreq[i];
                }
            }
            lbData.Text = $"Peak Frequency: {peakFreq:N0} Hz";

            plotFFT.plt.XLabel("Frequency Hz");
            plotPcm.plt.XLabel("Frequency Hz");

            // make the plot for the first time, otherwise update the existing plot
            if (plotFFT.plt.GetPlottables().Count == 0)
            {
                signalPlotFFt = plotFFT.plt.PlotSignal(fftPower, 2.0 * fftPower.Length / SAMPLE_RATE);
            }
            else
            {
                signalPlotFFt.ys = fftPower;
            }

            // make the plot for the first time, otherwise update the existing plot
            if (plotPcm.plt.GetPlottables().Count == 0)
            {
                signalPlotPcm = plotPcm.plt.PlotSignal(windowed, 2.0 * windowed.Length / SAMPLE_RATE);
            }
            else
            {
                signalPlotPcm.ys = zeroPadded;
            }

            if (cbAutoAxis.IsChecked == true)
            {
                plotFFT.plt.AxisAuto(horizontalMargin: 0);
                plotPcm.plt.AxisAuto(verticalMargin: 0);
            }
            try
            {
                plotPcm.Render();
                plotFFT.Render();
            }
            catch
            {


            }

        }
    }
}
