namespace SentimentNN
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            load_data_btn = new Button();
            save_data_btn = new Button();
            text_process_btn = new Button();
            load_vocabulary_btn = new Button();
            load_dataset_btn = new Button();
            groupBox2 = new GroupBox();
            epoch_text = new TextBox();
            load_weight_btn = new Button();
            save_weight_btn = new Button();
            learn_btn = new Button();
            create_model_btn = new Button();
            groupBox3 = new GroupBox();
            t_sentiment_txt = new TextBox();
            p_sentiment_txt = new TextBox();
            label2 = new Label();
            review_btn = new Button();
            label1 = new Label();
            review_data_txt = new RichTextBox();
            testing_index_box = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(load_data_btn);
            groupBox1.Controls.Add(save_data_btn);
            groupBox1.Controls.Add(text_process_btn);
            groupBox1.Controls.Add(load_vocabulary_btn);
            groupBox1.Controls.Add(load_dataset_btn);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(143, 206);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Database Setting";
            // 
            // load_data_btn
            // 
            load_data_btn.Location = new Point(6, 166);
            load_data_btn.Name = "load_data_btn";
            load_data_btn.Size = new Size(130, 30);
            load_data_btn.TabIndex = 4;
            load_data_btn.Text = "Load Data";
            load_data_btn.UseVisualStyleBackColor = true;
            load_data_btn.Click += load_data_btn_Click;
            // 
            // save_data_btn
            // 
            save_data_btn.Location = new Point(6, 130);
            save_data_btn.Name = "save_data_btn";
            save_data_btn.Size = new Size(130, 30);
            save_data_btn.TabIndex = 3;
            save_data_btn.Text = "Save Data";
            save_data_btn.UseVisualStyleBackColor = true;
            save_data_btn.Click += save_data_btn_Click;
            // 
            // text_process_btn
            // 
            text_process_btn.Location = new Point(6, 94);
            text_process_btn.Name = "text_process_btn";
            text_process_btn.Size = new Size(130, 30);
            text_process_btn.TabIndex = 2;
            text_process_btn.Text = "Text Processing";
            text_process_btn.UseVisualStyleBackColor = true;
            text_process_btn.Click += text_process_btn_Click;
            // 
            // load_vocabulary_btn
            // 
            load_vocabulary_btn.Location = new Point(6, 58);
            load_vocabulary_btn.Name = "load_vocabulary_btn";
            load_vocabulary_btn.Size = new Size(130, 30);
            load_vocabulary_btn.TabIndex = 1;
            load_vocabulary_btn.Text = "Load Vocabulary";
            load_vocabulary_btn.UseVisualStyleBackColor = true;
            load_vocabulary_btn.Click += load_vocabulary_btn_Click;
            // 
            // load_dataset_btn
            // 
            load_dataset_btn.Location = new Point(6, 22);
            load_dataset_btn.Name = "load_dataset_btn";
            load_dataset_btn.Size = new Size(130, 30);
            load_dataset_btn.TabIndex = 0;
            load_dataset_btn.Text = "Load Dataset";
            load_dataset_btn.UseVisualStyleBackColor = true;
            load_dataset_btn.Click += load_dataset_btn_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(epoch_text);
            groupBox2.Controls.Add(load_weight_btn);
            groupBox2.Controls.Add(save_weight_btn);
            groupBox2.Controls.Add(learn_btn);
            groupBox2.Controls.Add(create_model_btn);
            groupBox2.Location = new Point(12, 224);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(143, 197);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Neural Network";
            // 
            // epoch_text
            // 
            epoch_text.Location = new Point(6, 58);
            epoch_text.Name = "epoch_text";
            epoch_text.PlaceholderText = "Epoch";
            epoch_text.Size = new Size(130, 23);
            epoch_text.TabIndex = 5;
            // 
            // load_weight_btn
            // 
            load_weight_btn.Location = new Point(6, 159);
            load_weight_btn.Name = "load_weight_btn";
            load_weight_btn.Size = new Size(130, 30);
            load_weight_btn.TabIndex = 4;
            load_weight_btn.Text = "Load Weights";
            load_weight_btn.UseVisualStyleBackColor = true;
            // 
            // save_weight_btn
            // 
            save_weight_btn.Location = new Point(6, 123);
            save_weight_btn.Name = "save_weight_btn";
            save_weight_btn.Size = new Size(130, 30);
            save_weight_btn.TabIndex = 3;
            save_weight_btn.Text = "Save Weights";
            save_weight_btn.UseVisualStyleBackColor = true;
            // 
            // learn_btn
            // 
            learn_btn.Location = new Point(6, 87);
            learn_btn.Name = "learn_btn";
            learn_btn.Size = new Size(130, 30);
            learn_btn.TabIndex = 2;
            learn_btn.Text = "Learn";
            learn_btn.UseVisualStyleBackColor = true;
            // 
            // create_model_btn
            // 
            create_model_btn.Location = new Point(6, 22);
            create_model_btn.Name = "create_model_btn";
            create_model_btn.Size = new Size(130, 30);
            create_model_btn.TabIndex = 0;
            create_model_btn.Text = "Create Model";
            create_model_btn.UseVisualStyleBackColor = true;
            create_model_btn.Click += create_model_btn_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(t_sentiment_txt);
            groupBox3.Controls.Add(p_sentiment_txt);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(review_btn);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(review_data_txt);
            groupBox3.Controls.Add(testing_index_box);
            groupBox3.Location = new Point(172, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(373, 409);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Database Setting";
            // 
            // t_sentiment_txt
            // 
            t_sentiment_txt.Location = new Point(131, 306);
            t_sentiment_txt.Name = "t_sentiment_txt";
            t_sentiment_txt.ReadOnly = true;
            t_sentiment_txt.Size = new Size(120, 23);
            t_sentiment_txt.TabIndex = 9;
            // 
            // p_sentiment_txt
            // 
            p_sentiment_txt.Location = new Point(131, 342);
            p_sentiment_txt.Name = "p_sentiment_txt";
            p_sentiment_txt.ReadOnly = true;
            p_sentiment_txt.Size = new Size(120, 23);
            p_sentiment_txt.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 345);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 7;
            label2.Text = "Predicted Sentiment:";
            // 
            // review_btn
            // 
            review_btn.Location = new Point(6, 270);
            review_btn.Name = "review_btn";
            review_btn.Size = new Size(130, 30);
            review_btn.TabIndex = 6;
            review_btn.Text = "Review";
            review_btn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 309);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 2;
            label1.Text = "Target Sentiment: ";
            // 
            // review_data_txt
            // 
            review_data_txt.Location = new Point(6, 56);
            review_data_txt.Name = "review_data_txt";
            review_data_txt.Size = new Size(361, 208);
            review_data_txt.TabIndex = 1;
            review_data_txt.Text = "";
            // 
            // testing_index_box
            // 
            testing_index_box.FormattingEnabled = true;
            testing_index_box.Location = new Point(6, 27);
            testing_index_box.Name = "testing_index_box";
            testing_index_box.Size = new Size(121, 23);
            testing_index_box.TabIndex = 0;
            testing_index_box.Text = "Testing Data";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 432);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button load_data_btn;
        private Button save_data_btn;
        private Button text_process_btn;
        private Button load_vocabulary_btn;
        private Button load_dataset_btn;
        private GroupBox groupBox2;
        private TextBox epoch_text;
        private Button load_weight_btn;
        private Button save_weight_btn;
        private Button learn_btn;
        private Button create_model_btn;
        private GroupBox groupBox3;
        private TextBox t_sentiment_txt;
        private TextBox p_sentiment_txt;
        private Label label2;
        private Button review_btn;
        private Label label1;
        private RichTextBox review_data_txt;
        private ComboBox testing_index_box;
    }
}