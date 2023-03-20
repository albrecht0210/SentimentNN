using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Word2vec.Tools;

namespace SentimentNN
{
    public static class DatasetHelper
    {
        public static readonly string[] StopWords = new string[]
        {
            "i", "me", "my", "myself", "we", "our", "ours", "ourselves", "you", "you're", "you've", "you'll", "you'd",
            "your", "yours", "yourself", "yourselves", "he", "him", "his", "himself", "she", "she's", "her", "hers",
            "herself", "it", "it's", "its", "itself", "they", "them", "their", "theirs", "themselves", "what", "which",
            "who", "whom", "this", "that", "that'll", "these", "those", "am", "is", "are", "was", "were", "be", "been",
            "being", "have", "has", "had", "having", "do", "does", "did", "doing", "a", "an", "the", "and", "but", "if",
            "or", "because", "as", "until", "while", "of", "at", "by", "for", "with", "about", "against", "between",
            "into", "through", "during", "before", "after", "above", "below", "to", "from", "up", "down", "in", "out",
            "on", "off", "over", "under", "again", "further", "then", "once", "here", "there", "when", "where", "why",
            "how", "all", "any", "both", "each", "few", "more", "most", "other", "some", "such", "no", "nor", "not",
            "only", "own", "same", "so", "than", "too", "very", "s", "t", "can", "will", "just", "don", "don't",
            "should", "should've", "now", "d", "ll", "m", "o", "re", "ve", "y", "ain", "aren", "aren't", "couldn",
            "couldn't", "didn", "didn't", "doesn", "doesn't", "hadn", "hadn't", "hasn", "hasn't", "haven", "haven't",
            "isn", "isn't", "ma", "mightn", "mightn't", "mustn", "mustn't", "needn", "needn't", "shan", "shan't",
            "shouldn", "shouldn't", "wasn", "wasn't", "weren", "weren't", "won", "won't", "wouldn", "wouldn't"
        };

        public static (string[], string[]) CSV2Array(string filename)
        {
            List<string> inputList = new List<string>();
            List<string> outputList = new List<string>();

            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.ReadFields();

                while (!parser.EndOfData)
                {
                    // Read each row of the CSV file
                    string[] fields = parser.ReadFields();

                    inputList.Add(fields[0]);
                    outputList.Add(fields[1]);
                }
            }

            return (inputList.ToArray(), outputList.ToArray());
        }

        public static (string[], string[], string[], string[]) TrainTestSplit(string[] input, string[] output, double training_size)
        {
            Random random = new Random(42);

            // Shuffle the indices of the input array
            int[] indices = Enumerable.Range(0, input.Length).ToArray();
            for (int i = 0; i < indices.Length; i++)
            {
                int j = random.Next(i, indices.Length);
                int temp = indices[i];
                indices[i] = indices[j];
                indices[j] = temp;
            }

            // Split the indices into train and test sets
            int train_size = (int)(input.Length * training_size);
            int[] train_indices = indices.Take(train_size).ToArray();
            int[] test_indices = indices.Skip(train_size).ToArray();

            // Create the train and test input and output arrays
            string[] train_input = train_indices.Select(i => input[i]).ToArray();
            string[] test_input = test_indices.Select(i => input[i]).ToArray();
            string[] train_output = train_indices.Select(i => output[i]).ToArray();
            string[] test_output = test_indices.Select(i => output[i]).ToArray();

            return (train_input, train_output, test_input, test_output);
        }

        public static string[] InputTextProcessing(string[] inputs)
        {
            List<string> input_list = new List<string>();

            foreach (string input in inputs)
            {
                string data = input;

                data = data.ToLower();

                // Remove HTML tags
                data = Regex.Replace(data, "<.*?>", string.Empty);

                // Remove special characters and numbers
                data = Regex.Replace(data, "[^a-z\\s]", string.Empty);

                // Remove single characters
                data = Regex.Replace(data, "\\b[a-z]\\b", string.Empty);

                string[] words = data.Split(' ');

                var filteredWords = words.Where(w => !StopWords.Contains(w)).ToArray();

                data = string.Join(' ', filteredWords);
            }

            return input_list.ToArray();
        }

        public static string InputTextProcessing(string input)
        {
            string data = input;

            data = data.ToLower();

            // Remove HTML tags
            data = Regex.Replace(data, "<.*?>", string.Empty);

            // Remove special characters and numbers
            data = Regex.Replace(data, "[^a-z\\s]", string.Empty);

            // Remove single characters
            data = Regex.Replace(data, "\\b[a-z]\\b", string.Empty);

            string[] words = data.Split(' ');

            var filteredWords = words.Where(w => !StopWords.Contains(w)).ToArray();

            data = string.Join(' ', filteredWords);

            return data;
        }
        
        public static double[] OutputTextProcessing(string[] outputs)
        {
            List<double> output_list = new List<double>();

            foreach (string output in outputs)
            {
                if (output == "positive")
                    output_list.Add(1);
                else if (output == "negative")
                    output_list.Add(-1);
            }

            return output_list.ToArray();
        }
        
        public static double[] WordEmbedding(Vocabulary model, string sentence)
        {
            double[] vector = new double[model.VectorDimensionsCount];

            // add all words that exist in the vocabulary
            int inVocabularyCount = 0;
            foreach (string word in sentence.Split(' '))
            {
                try
                {
                    float[] wordVector = model.GetRepresentationFor(word).NumericVector;
                    for (int i = 0; i < model.VectorDimensionsCount; i++)
                    {
                        vector[i] += (double)wordVector[i];
                    }
                    inVocabularyCount++;
                }
                catch
                {
                    // ignore anything not in vocabulary
                }
            }

            // return the average of the vectors 
            for (int i = 0; i < model.VectorDimensionsCount; i++)
            {
                vector[i] /= inVocabularyCount;
            }

            return vector;
        }

        public static void SaveTrainingData(string filename, List<double[]> input, double[] output)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                int output_counter = 0;
                foreach (double[] value in input)
                {
                    string csvLine = string.Join(",", value);
                    csvLine += "," + output[output_counter];
                    sw.WriteLine(csvLine);
                    output_counter++;
                }
            }
        }

        public static (List<double[]>, double[]) LoadTrainingData(string filename)
        {
            List<double[]> input_list = new List<double[]>();
            List<double> output_list = new List<double>();

            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');
                    double[] inputs = new double[values.Length - 1];
                    for (int i = 0; i < inputs.Length; i++)
                        inputs[i] = double.Parse(values[i]);
                    input_list.Add(inputs);
                    output_list.Add(double.Parse(values[values.Length - 1]));
                }
            }

            return (input_list, output_list.ToArray());
        }

        public static void SaveTestingData(string filename, string[] input, string[] output)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    string csvLine = input[i] + "," + output[i];
                    sw.WriteLine(csvLine);
                }
            }
        }

        public static (string[], string[]) LoadTestingData(string filename)
        {
            List<string> input_list = new List<string>();
            List<string> output_list = new List<string>();

            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(',');
                    string input_data = string.Join(",", parts.Take(parts.Length - 1));
                    string output_data = parts.Last();

                    input_list.Add(input_data);
                    output_list.Add(output_data);
                }
            }

            return (input_list.ToArray(), output_list.ToArray());
        }
    }
}
