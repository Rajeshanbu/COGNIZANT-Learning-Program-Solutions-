using System;
using System.Drawing;
using System.Windows.Forms;
using Confluent.Kafka;

public class Form1 : Form
{
    private TextBox messageBox;
    private Button sendButton;
    private Button cancelButton;
    private IProducer<Null, string> producer;

    public Form1()
    {
        InitializeComponent();
        InitializeKafkaProducer();
    }

    private void InitializeKafkaProducer()
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
        this.producer = new ProducerBuilder<Null, string>(config).Build();
    }

    private async void SendButton_Click(object sender, EventArgs e)
    {
        var message = messageBox.Text;
        if (string.IsNullOrEmpty(message))
        {
            MessageBox.Show("Please enter a message.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var deliveryResult = await this.producer.ProduceAsync("chat-message", new Message<Null, string> { Value = message });
            Console.WriteLine($"Message delivered to: {deliveryResult.TopicPartitionOffset}");
            messageBox.Clear();
        }
        catch (ProduceException<Null, string> ex)
        {
            MessageBox.Show($"Failed to deliver message: {ex.Error.Reason}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        messageBox.Clear();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        producer.Flush(TimeSpan.FromSeconds(10));
        producer.Dispose();
        base.OnFormClosing(e);
    }

    // This method sets up all the UI elements.
    private void InitializeComponent()
    {
        this.Text = "Kafka Chat Producer";
        this.Size = new Size(500, 300);
        this.StartPosition = FormStartPosition.CenterScreen;

        Label infoLabel = new Label();
        infoLabel.Text = "Please Enter your Message Here:";
        infoLabel.Location = new Point(10, 10);
        infoLabel.AutoSize = true;
        this.Controls.Add(infoLabel);

        this.messageBox = new TextBox();
        this.messageBox.Location = new Point(10, 35);
        this.messageBox.Size = new Size(460, 150);
        this.messageBox.Multiline = true;
        this.messageBox.ScrollBars = ScrollBars.Vertical;
        this.Controls.Add(this.messageBox);

        this.sendButton = new Button();
        this.sendButton.Text = "Send";
        this.sendButton.Location = new Point(380, 200);
        this.sendButton.Click += new EventHandler(this.SendButton_Click);
        this.Controls.Add(this.sendButton);

        this.cancelButton = new Button();
        this.cancelButton.Text = "Cancel";
        this.cancelButton.Location = new Point(290, 200);
        this.cancelButton.Click += new EventHandler(this.CancelButton_Click);
        this.Controls.Add(this.cancelButton);
    }
}