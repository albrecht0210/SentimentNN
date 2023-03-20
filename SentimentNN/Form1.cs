using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using Word2vec.Tools;

namespace SentimentNN
{
    public partial class Form1 : Form
    {
        Vocabulary _model;

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
            Debug.WriteLine("Dataset Loaded.");
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

            foreach (string input_text in input_train_processed_text)
                input.Add(DatasetHelper.WordEmbedding(_model, input_text));

            Debug.WriteLine("Text Processed.");
        }

        private void save_data_btn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Saving Data...");
            DatasetHelper.SaveTrainingData("D:\\Datasets\\SentimentNNData\\train.csv", input, output);
            DatasetHelper.SaveTestingData("D:\\Datasets\\SentimentNNData\\test.csv", input_test_unprocessed_text, output_test_unprocessed_text); ;
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
            Debug.WriteLine("Data Loaded...");
        }

        private void create_model_btn_Click(object sender, EventArgs e)
        {

        }
    }
}