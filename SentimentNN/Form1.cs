using Backprop;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using Word2vec.Tools;
using Backprop;

namespace SentimentNN
{
    public partial class Form1 : Form
    {
        Vocabulary _model;
        NeuralNet net;

        (string[], string[]) _unprocessed_text;
        (string[], string[], string[], string[]) _split_data;

        string[] input_train_unprocessed_text;
        string[] output_train_unprocessed_text;

        string[] input_test_unprocessed_text;
        string[] output_test_unprocessed_text;

        string[] input_train_processed_text;

        List<double[]> input;
        double[] output;

        public Form1()
        {
            InitializeComponent();
        }

        private void load_dataset_btn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Loading Dataset...");
            _unprocessed_text = DatasetHelper.CSV2Array("D:\\Datasets\\Sentiment\\IMDB Dataset.csv");
            _split_data = DatasetHelper.TrainTestSplit(_unprocessed_text.Item1, _unprocessed_text.Item2, 0.7);
            input_train_unprocessed_text = _split_data.Item1;
            output_train_unprocessed_text = _split_data.Item2;
            input_test_unprocessed_text = _split_data.Item3;
            output_test_unprocessed_text = _split_data.Item4;

            for (int i = 0; i < input_test_unprocessed_text.Length; i++)
                testing_index_box.Items.Add((i + 1));

            Debug.WriteLine("Dataset Loaded.");
            Debug.WriteLine(DatasetHelper.InputTextProcessing("Those were the best days of my life!"));

        }

        private void load_vocabulary_btn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Loading Vocabulary...");
            _model = new Word2VecBinaryReader().Read("D:\\Datasets\\Sentiment\\GoogleNews-vectors-negative300.bin");
            Debug.WriteLine("Vocabulary Loaded.");
        }

        private void text_process_btn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Processing Text...");
            input_train_processed_text = DatasetHelper.InputTextProcessing(input_train_unprocessed_text);
            output = DatasetHelper.OutputTextProcessing(output_train_unprocessed_text);
            input = new List<double[]>();


            for (int i = 0; i < input_train_processed_text.Length; i++)
            {
                Debug.WriteLine("Data: " + (i + 1));
                input.Add(DatasetHelper.WordEmbedding(_model, input_train_processed_text[i]));
            }

            Debug.WriteLine("Text Processed.");
        }

        private void save_data_btn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Saving Data...");
            DatasetHelper.SaveTrainingData("D:\\Datasets\\SentimentNNData\\train.csv", input, output);
            DatasetHelper.SaveTestingData("D:\\Datasets\\SentimentNNData\\test.csv", input_test_unprocessed_text, output_test_unprocessed_text);
            Debug.WriteLine("Data Saved...");
        }

        private void load_data_btn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Loading Data...");
            (List<double[]>, double[]) _training_data = DatasetHelper.LoadTrainingData("D:\\Datasets\\SentimentNNData\\train.csv");
            input = _training_data.Item1;
            output = _training_data.Item2;

            (string[], string[]) _testing_data = DatasetHelper.LoadTestingData("D:\\Datasets\\SentimentNNData\\test.csv");
            input_test_unprocessed_text = _testing_data.Item1;
            output_test_unprocessed_text = _testing_data.Item2;

            for (int i = 0; i < input_test_unprocessed_text.Length; i++)
                testing_index_box.Items.Add((i + 1));

            Debug.WriteLine("Data Loaded...");
        }

        private void create_model_btn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Creating Neural Network...");
            net = new NeuralNet(300, 16, 2);
            Debug.WriteLine("Neural Network Created.");
        }

        private void learn_btn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Learning Data...");
            int epoch = Convert.ToInt32(epoch_text.Text);

            for (int i = 0; i < epoch; i++)
            {
                int output_counter = 0;
                foreach (double[] data in input)
                {
                    Debug.WriteLine("Epoch: " + (i + 1) + ", Data: " + (output_counter + 1) + ", Length: " + data.Length);
                    for (int x = 0; x < data.Length; x++)
                        net.setInputs(x, data[x]);

                    if (output[output_counter] == 1)
                    {
                        net.setDesiredOutput(0, 1);
                        net.setDesiredOutput(1, 0);
                    }
                    else
                    {
                        net.setDesiredOutput(0, 0);
                        net.setDesiredOutput(1, 1);
                    }
                    net.learn();
                    output_counter++;
                }
            }
            Debug.WriteLine("Data Learned.");
        }

        private void save_weight_btn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Saving Weights...");
            net.saveWeights("D:\\Datasets\\SentimentNNData\\weights.txt");
            Debug.WriteLine("Weights Saved...");
        }

        private void load_weight_btn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Loading Weights...");
            net.loadWeights("D:\\Datasets\\SentimentNNData\\weights.txt");
            Debug.WriteLine("Weights Loaded...");
        }

        private void testing_index_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Setting Testing Data...");
            review_data_txt.Text = input_test_unprocessed_text[testing_index_box.SelectedIndex];
            string temp = output_test_unprocessed_text[testing_index_box.SelectedIndex];
            t_sentiment_txt.Text = char.ToUpper(temp[0]) + temp.Substring(1);
            p_sentiment_txt.Text = "";
            Debug.WriteLine("Testing Data Set...");
        }

        private void review_btn_Click(object sender, EventArgs e)
        {
            string input_test_processed_text = DatasetHelper.InputTextProcessing(input_test_unprocessed_text[testing_index_box.SelectedIndex]);
            double[] input_test = DatasetHelper.WordEmbedding(_model, input_test_processed_text);

            for (int x = 0; x < input_test.Length; x++)
                net.setInputs(x, input_test[x]);
            net.run();

            double[] output_val = new double[2];
            output_val[0] = net.getOuputData(0);
            output_val[1] = net.getOuputData(1);

            for (int i = 0; i < output_val.Length; i++)
                Debug.WriteLine(output_val[i]);

            int maxIndex = Array.IndexOf(output_val, output_val.Max());

            if (maxIndex == 0)
                p_sentiment_txt.Text = "Positive";
            else
                p_sentiment_txt.Text = "Negative";
        }
    }
}