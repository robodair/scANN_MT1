using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANNShell
{
    public partial class Form1 : Form
    {
        string dir = "DataFiles";

        DataClass trainData = new DataClass();
        DataClass testData = new DataClass();
        DataClass valData = new DataClass();

        public Form1()
        {
            InitializeComponent();
        }

        class UI : UserInterface
        {
            public Form1 form;

            public UI(Form1 formQ)
            {
                form = formQ;
            }

            public override void error(string s)
            {
                form.textBox2.Text = form.textBox2.Text + "ERROR>>" + s + "\r\n";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("ERROR>>" + s, "Error", buttons);
            }
            public override void clear(string s)
            {
                form.textBox2.Text = "";
            }
            public override void warning(string s)
            {
                form.textBox2.Text = form.textBox2.Text + "WARNING>>" + s + "\r\n";
            }
            public override void note(string s)
            {
                form.textBox2.Text = form.textBox2.Text + "NOTE>>" + s + "\r\n";
            }
        }

        // MT1 Q1
        private void buttonRunCancer_Click(object sender, EventArgs e)
        {
            string dir = this.textPath.Text;
            string datafile = @"\MT1Data\cancer.txt";
            string commonNameForDataset = "Cancer Dataset";

            int inputs = 9;
            int hidden = (int) numericNodesBox.Value;  // was 9
            int outputs = 2;
            double eta = (double) numericETA.Value;    // was 0.1
            int epochs = (int) numericEpochsBox.Value; // was 15
            Random rnd1 = new Random(1996); // data split random number
            Random rnd2 = new Random(); // ANN initialise weights and shuffle data random number
            int sizeOfDataSet = 683;
            int sizeOfTest = sizeOfDataSet / 3;
            int sizeOfValidation = sizeOfDataSet / 3;
            int sizeOfTrain = sizeOfDataSet - sizeOfTest - sizeOfValidation;

            textBox2.Clear(); // clear previous messages

            DataClass cancerRaw = new DataClass(dir, datafile, new UI(this));
            string s = cancerRaw.showDataPart(5, inputs + 1, "F4", commonNameForDataset);
            textBox1.AppendText(s);
            textBox1.AppendText("\r\n\r\n");

            cancerRaw.normalize(0, inputs - 1, "");
            string ss = cancerRaw.showDataPart(5, inputs + 1, "F4", commonNameForDataset + " Normalised");
            textBox1.AppendText(ss);
            textBox1.AppendText("\r\n\r\n");

            DataClass cancerExemplar = cancerRaw.makeExemplar(inputs, outputs, 1);
            string se = cancerExemplar.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Exemplar Data");
            textBox1.AppendText(se);
            textBox1.AppendText("\r\n\r\n");

            trainData = new DataClass();
            testData = new DataClass();
            valData = new DataClass();
            DataClass tempData = new DataClass();

            cancerExemplar.extractSplit(out trainData, out tempData, sizeOfTrain, rnd1);
            tempData.extractSplit(out testData, out valData, sizeOfTest, rnd1);
            trainData.writeToFile(dir, @"\MT1Data\cancerTempTrain.txt"); // debug
            testData.writeToFile(dir, @"\MT1Data\cancerTempTest.txt");
            valData.writeToFile(dir, @"\MT1Data\cancerTempVal.txt");

            string s1 = trainData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Training Data");
            textBox1.AppendText(s1);
            textBox1.AppendText("\r\n\r\n");

            string s2 = testData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Testing Data");
            textBox1.AppendText(s2);
            textBox1.AppendText("\r\n\r\n");

            string s3 = valData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Validation Data");
            textBox1.AppendText(s3);
            textBox1.AppendText("\r\n\r\n");

            NeuralNetwork nn = new NeuralNetwork(inputs, hidden, outputs, new UI(this), rnd2);
            nn.InitializeWeights(rnd2);
            textBox1.AppendText("\r\nBeginning training using incremental back-propagation\r\n");
            nn.train(trainData.data, testData.data, epochs, eta, dir + @"\MT1Data\nnlog.txt", nnChart, nnProgressBar, true);
            textBox1.AppendText("Training complete\r\n");

            double trainAcc = nn.Accuracy(trainData.data, dir + @"\MT1Data\trainOut.txt");
            string ConfusionTrain = nn.showConfusionPercent(dir + @"\MT1Data\trainConfusion.txt");
            double testAcc = nn.Accuracy(testData.data, dir + @"\MT1Data\testOut.txt");
            string ConfusionTest = nn.showConfusionPercent(dir + @"\MT1Data\testConfusion.txt");
            double valAcc = nn.Accuracy(valData.data, dir + @"\MT1Data\valOut.txt");
            string ConfusionVal = nn.showConfusionPercent(dir + @"\MT1Data\valConfusion.txt");

            // convert accuracy to percents
            trainAcc = trainAcc * 100;
            testAcc = testAcc * 100;
            valAcc = valAcc * 100;
            textBox1.AppendText("Training Accuracy   = " + trainAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Testing Accuracy    = " + testAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Validation Accuracy = " + valAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("Training Confusion Matrix \r\n" + ConfusionTrain + "\r\n\r\n");
            textBox1.AppendText("Testing Confusion Matrix \r\n" + ConfusionTest + "\r\n\r\n");
            textBox1.AppendText("Validation Confusion Matrix \r\n" + ConfusionVal + "\r\n\r\n");

            // finally save weights for the future
            nn.saveANN(dir + @"\MT1Data\cancer_Weights.txt");
        }

        // MT1 Q2
        private void buttonRunWine_Click(object sender, EventArgs e)
        {
            string dir = this.textPath.Text;
            string datafile = @"\MT1Data\Wine.txt";
            string commonNameForDataset = "Wine Dataset";

            int outputs = 3;
            int inputs = 13;

            int hidden = (int)numericNodesBox.Value;  // was 13
            double eta = (double)numericETA.Value;    // was 0.05
            int epochs = (int)numericEpochsBox.Value; // was 120

            Random rnd1 = new Random(24); // data split random number
            Random rnd2 = new Random(); // ANN initialise weights and shuffle data random number

            int sizeOfDataSet = 178;
            int sizeOfTest = sizeOfDataSet / 3;
            int sizeOfValidation = sizeOfDataSet / 3;
            int sizeOfTrain = sizeOfDataSet - sizeOfTest - sizeOfValidation;

            textBox2.Clear(); // clear previous messages

            DataClass WineRaw = new DataClass(dir, datafile, new UI(this));
            string s = WineRaw.showDataPart(5, inputs + 1, "F4", commonNameForDataset);
            textBox1.AppendText(s);
            textBox1.AppendText("\r\n\r\n");

            WineRaw.normalize(0, inputs - 1, "");
            string ss = WineRaw.showDataPart(5, inputs + 1, "F4", commonNameForDataset + " Normalised");
            textBox1.AppendText(ss);
            textBox1.AppendText("\r\n\r\n");

            DataClass WineExemplar = WineRaw.makeExemplar(inputs, outputs, 1);
            string se = WineExemplar.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Exemplar Data");
            textBox1.AppendText(se);
            textBox1.AppendText("\r\n\r\n");

            trainData = new DataClass();
            testData = new DataClass();
            valData = new DataClass();
            DataClass tempData = new DataClass();

            WineExemplar.extractSplit(out trainData, out tempData, sizeOfTrain, rnd1);
            tempData.extractSplit(out testData, out valData, sizeOfTest, rnd1);
            trainData.writeToFile(dir, @"\MT1Data\WineTempTrain.txt"); // debug
            testData.writeToFile(dir, @"\MT1Data\WineTempTest.txt");
            valData.writeToFile(dir, @"\MT1Data\WineTempVal.txt");

            string s1 = trainData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Training Data");
            textBox1.AppendText(s1);
            textBox1.AppendText("\r\n\r\n");

            string s2 = testData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Testing Data");
            textBox1.AppendText(s2);
            textBox1.AppendText("\r\n\r\n");

            string s3 = valData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Validation Data");
            textBox1.AppendText(s3);
            textBox1.AppendText("\r\n\r\n");

            NeuralNetwork nn = new NeuralNetwork(inputs, hidden, outputs, new UI(this), rnd2);
            nn.InitializeWeights(rnd2);
            textBox1.AppendText("\r\nBeginning training using incremental back-propagation\r\n");
            nn.train(trainData.data, testData.data, epochs, eta, dir + "nnlog.txt", nnChart, nnProgressBar, true);
            textBox1.AppendText("Training complete\r\n");

            double trainAcc = nn.Accuracy(trainData.data, dir + @"\MT1Data\trainOut.txt");
            string ConfusionTrain = nn.showConfusionPercent(dir + @"\MT1Data\trainConfusion.txt");
            double testAcc = nn.Accuracy(testData.data, dir + @"\MT1Data\testOut.txt");
            string ConfusionTest = nn.showConfusionPercent(dir + @"\MT1Data\testConfusion.txt");
            double valAcc = nn.Accuracy(valData.data, dir + @"\MT1Data\valOut.txt");
            string ConfusionVal = nn.showConfusionPercent(dir + @"\MT1Data\valConfusion.txt");

            // convert accuracy to percents
            trainAcc = trainAcc * 100;
            testAcc = testAcc * 100;
            valAcc = valAcc * 100;
            textBox1.AppendText("Training Accuracy   = " + trainAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Testing Accuracy    = " + testAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Validation Accuracy = " + valAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("Training Confusion Matrix \r\n" + ConfusionTrain + "\r\n\r\n");
            textBox1.AppendText("Testing Confusion Matrix \r\n" + ConfusionTest + "\r\n\r\n");
            textBox1.AppendText("Validation Confusion Matrix \r\n" + ConfusionVal + "\r\n\r\n");

            // finally save weights for the future
            nn.saveANN(dir + @"\MT1Data\Wine_Weights.txt");
        }

        // MT1 Q3
        private void buttonHeartCleveland_Click(object sender, EventArgs e)
        {
            string dir = this.textPath.Text;
            string datafile = @"\MT1Data\Heart-ClevelandFixed.txt";
            string commonNameForDataset = "Heart-Cleveland Dataset";

            int outputs = 5;
            int inputs = 13;

            int hidden = (int)numericNodesBox.Value;  // was 16
            double eta = (double)numericETA.Value;    // was 0.1
            int epochs = (int)numericEpochsBox.Value; // was 300

            Random rnd1 = new Random(1997); // data split random number
            Random rnd2 = new Random(); // ANN initialise weights and shuffle data random number

            int sizeOfDataSet = 303;
            int sizeOfTest = sizeOfDataSet / 3;
            int sizeOfValidation = sizeOfDataSet / 3;
            int sizeOfTrain = sizeOfDataSet - sizeOfTest - sizeOfValidation;

            textBox2.Clear(); // clear previous messages

            DataClass heartClevelandRaw = new DataClass(dir, datafile, new UI(this));
            string s = heartClevelandRaw.showDataPart(5, inputs + 1, "F4", commonNameForDataset);
            textBox1.AppendText(s);
            textBox1.AppendText("\r\n\r\n");

            heartClevelandRaw.normalize(0, inputs - 1, "");
            string ss = heartClevelandRaw.showDataPart(5, inputs + 1, "F4", commonNameForDataset + " Normalised");
            textBox1.AppendText(ss);
            textBox1.AppendText("\r\n\r\n");

            DataClass heartClevelandExemplar = heartClevelandRaw.makeExemplar(inputs, outputs, 0);
            string se = heartClevelandExemplar.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Exemplar Data");
            textBox1.AppendText(se);
            textBox1.AppendText("\r\n\r\n");

            trainData = new DataClass();
            testData = new DataClass();
            valData = new DataClass();
            DataClass tempData = new DataClass();

            heartClevelandExemplar.extractSplit(out trainData, out tempData, sizeOfTrain, rnd1);
            tempData.extractSplit(out testData, out valData, sizeOfTest, rnd1);
            trainData.writeToFile(dir, @"\MT1Data\Heart-ClevelandFixedTempTrain.txt"); // debug
            testData.writeToFile(dir, @"\MT1Data\Heart-ClevelandFixedTempTest.txt");
            valData.writeToFile(dir, @"\MT1Data\Heart-ClevelandFixedTempVal.txt");

            string s1 = trainData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Training Data");
            textBox1.AppendText(s1);
            textBox1.AppendText("\r\n\r\n");

            string s2 = testData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Testing Data");
            textBox1.AppendText(s2);
            textBox1.AppendText("\r\n\r\n");

            string s3 = valData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Validation Data");
            textBox1.AppendText(s3);
            textBox1.AppendText("\r\n\r\n");

            NeuralNetwork nn = new NeuralNetwork(inputs, hidden, outputs, new UI(this), rnd2);
            nn.InitializeWeights(rnd2);
            textBox1.AppendText("\r\nBeginning training using incremental back-propagation\r\n");
            nn.train(trainData.data, testData.data, epochs, eta, dir + "nnlog.txt", nnChart, nnProgressBar, true);
            textBox1.AppendText("Training complete\r\n");

            double trainAcc = nn.Accuracy(trainData.data, dir + @"\MT1Data\trainOut.txt");
            string ConfusionTrain = nn.showConfusionPercent(dir + @"\MT1Data\trainConfusion.txt");
            double testAcc = nn.Accuracy(testData.data, dir + @"\MT1Data\testOut.txt");
            string ConfusionTest = nn.showConfusionPercent(dir + @"\MT1Data\testConfusion.txt");
            double valAcc = nn.Accuracy(valData.data, dir + @"\MT1Data\valOut.txt");
            string ConfusionVal = nn.showConfusionPercent(dir + @"\MT1Data\valConfusion.txt");

            // convert accuracy to percents
            trainAcc = trainAcc * 100;
            testAcc = testAcc * 100;
            valAcc = valAcc * 100;
            textBox1.AppendText("Training Accuracy   = " + trainAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Testing Accuracy    = " + testAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Validation Accuracy = " + valAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("Training Confusion Matrix \r\n" + ConfusionTrain + "\r\n\r\n");
            textBox1.AppendText("Testing Confusion Matrix \r\n" + ConfusionTest + "\r\n\r\n");
            textBox1.AppendText("Validation Confusion Matrix \r\n" + ConfusionVal + "\r\n\r\n");

            // finally save weights for the future
            nn.saveANN(dir + @"\MT1Data\Heart-ClevelandFixed_Weights.txt");

        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Test Buttons
        private void buttonTest1_Click(object sender, EventArgs e)
        {
            DataClass d = new DataClass();
            d.readFromFile(dir, "test1.txt");
            string s = d.showData();
            textBox1.Text = s;
            d.writeToFile(dir, "temp.txt");
            d.normalize(0, 1, "");
            string ss = d.showData();
            textBox1.Text = textBox1.Text + "\r\n\r\n" + ss;
            DataClass d1 = null;
            DataClass d2 = null;
            d.extractSplit(out d1, out d2, 4, new Random());
            string s1 = d1.showData();
            string s2 = d2.showData();
            textBox1.Text = textBox1.Text + "\r\n\r\n" + s1;
            textBox1.Text = textBox1.Text + "\r\n\r\n" + s2;

        }

        private void buttonTest2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            DataClass d = new DataClass();
            d.readFromFile(dir, "test1.txt");
            string s = d.showData();
            textBox1.Text = s;
            textBox1.Text = textBox1.Text + "\r\n\r\n";

            DataClass dd = d.makeExemplar(2, 3, 1);
            string ss = dd.showData();
            textBox1.Text = textBox1.Text + ss;
            textBox1.Text = textBox1.Text + "\r\n\r\n";
        }

        private void buttonTest3_Click(object sender, EventArgs e)
        {
            // test of save and restore weights 
            Random rnd2 = new Random(40);
            int inputs = 4;
            int hidden = 5;
            int outputs = 3;

            NeuralNetwork nnn = new NeuralNetwork(inputs, hidden, outputs, new UI(this), rnd2);
            nnn.InitializeWeights(rnd2);
            nnn.loadANN(dir + "irisWeights.txt");

            nnn.saveANN(dir + "irisWeights2.txt");

            double trainAcc = nnn.Accuracy(trainData.data, dir + "trainOut.txt");
            string ConfusionTrain = nnn.showConfusion(dir + "trainConfusion.txt");
            double testAcc = nnn.Accuracy(testData.data, dir + "testOut.txt");
            string ConfusionTest = nnn.showConfusion(dir + "testConfusion.txt");
            double valAcc = nnn.Accuracy(valData.data, dir + "valOut.txt");
            string ConfusionVal = nnn.showConfusion(dir + "valConfusion.txt");

            // convert accuracy to percents
            trainAcc = trainAcc * 100;
            testAcc = testAcc * 100;
            valAcc = valAcc * 100;
            textBox1.AppendText("Training Accuracy   = " + trainAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Testing Accuracy    = " + testAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Validation Accuracy = " + valAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("Training Confusion Matrix \r\n" + ConfusionTrain + "\r\n\r\n");
            textBox1.AppendText("Testing Confusion Matrix \r\n" + ConfusionTest + "\r\n\r\n");
            textBox1.AppendText("Validation Confusion Matrix \r\n" + ConfusionVal + "\r\n\r\n");

        }

        private void showDataDistribution(DataClass dataClass, string title, int outputs)
        {
            textBox1.AppendText(title + "\t\tA:" + dataClass.attributes + "C:" + dataClass.columns + "\r\n");
            int[] counts = new int[outputs];
            foreach (double[] row in dataClass.data)
            {
                for(int i = 0; i < outputs; i++)
                {
                    int index = dataClass.columns - outputs + i;
                    if (row[index] > 0.5d)
                    {
                        ++counts[i];
                    }
                }
                
            }
            foreach (int count in counts)
            {
                textBox1.AppendText(count + "\t");
            }
            textBox1.AppendText("\r\n\r\n");
        }
        
        // Ass1 Q1
        private void btnWeedSeed_Click(object sender, EventArgs e)
        {
            string dir = this.textPath.Text;
            string datafile = @"\Ass1Data\weedseed.txt";
            string commonNameForDataset = "WeedSeed Dataset";

            int inputs = 7;
            int outputs = 10;

            int hidden = (int)numericNodesBox.Value;
            double eta = (double)numericETA.Value;
            int epochs = (int)numericEpochsBox.Value;

            Random rnd1 = new Random(2007); // data split random number
            //int seed = System.DateTime.UtcNow.Millisecond;
            int seed = (int)numericWeedSeedSeed.Value;
            textBox1.AppendText("TODAY'S SEED: " + seed.ToString() + "\r\n\r\n");
            Random rnd2 = new Random(seed); // ANN initialise weights and shuffle data random number
            int sizeOfDataSet = 398;
            int sizeOfTest = sizeOfDataSet / 3;
            int sizeOfValidation = sizeOfDataSet / 3;
            int sizeOfTrain = sizeOfDataSet - sizeOfTest - sizeOfValidation;

            textBox2.Clear(); // clear previous messages

            DataClass weedSeedRaw = new DataClass(dir, datafile, new UI(this));
            string s = weedSeedRaw.showDataPart(5, inputs + 1, "F4", commonNameForDataset);
            textBox1.AppendText(s);
            textBox1.AppendText("\r\n\r\n");

            weedSeedRaw.normalize(0, inputs - 1, "");
            string ss = weedSeedRaw.showDataPart(5, inputs + 1, "F4", commonNameForDataset + " Normalised");
            textBox1.AppendText(ss);
            textBox1.AppendText("\r\n\r\n");

            DataClass weedSeedExemplar = weedSeedRaw.makeExemplar(inputs, outputs, 1);
            string se = weedSeedExemplar.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Exemplar Data");
            textBox1.AppendText(se);
            textBox1.AppendText("\r\n\r\n");

            trainData = new DataClass();
            testData = new DataClass();
            valData = new DataClass();
            DataClass tempData = new DataClass();

            weedSeedExemplar.extractSplit(out trainData, out tempData, sizeOfTrain, rnd1);
            tempData.extractSplit(out testData, out valData, sizeOfTest, rnd1);
            trainData.writeToFile(dir, @"\Ass1Data\Out\weedseed\weedSeedTempTrain.txt"); // debug
            testData.writeToFile(dir, @"\Ass1Data\Out\weedseed\weedSeedTempTest.txt");
            valData.writeToFile(dir, @"\Ass1Data\Out\weedseed\weedSeedTempVal.txt");

            showDataDistribution(trainData, "Training Data Class Distribution", outputs);
            showDataDistribution(testData, "Testing Data Class Distribution", outputs);
            showDataDistribution(valData, "Validation Data Class Distribution", outputs);

            string s1 = trainData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Training Data");
            textBox1.AppendText(s1);
            textBox1.AppendText("\r\n\r\n");

            string s2 = testData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Testing Data");
            textBox1.AppendText(s2);
            textBox1.AppendText("\r\n\r\n");

            string s3 = valData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Validation Data");
            textBox1.AppendText(s3);
            textBox1.AppendText("\r\n\r\n");

            NeuralNetwork nn = new NeuralNetwork(inputs, hidden, outputs, new UI(this), rnd2);
            nn.InitializeWeights(rnd2);
            textBox1.AppendText("\r\nBeginning training using incremental back-propagation\r\n");
            nn.train(trainData.data, testData.data, epochs, eta, dir + @"\Ass1Data\Out\weedseed\nnlog.txt", nnChart, nnProgressBar, true);
            textBox1.AppendText("Training complete\r\n");

            double trainAcc = nn.Accuracy(trainData.data, dir + @"\Ass1Data\Out\weedseed\trainOut.txt");
            string ConfusionTrain = nn.showConfusionPercent(dir + @"\Ass1Data\Out\weedseed\trainConfusion.txt");
            double testAcc = nn.Accuracy(testData.data, dir + @"\Ass1Data\Out\weedseed\testOut.txt");
            string ConfusionTest = nn.showConfusionPercent(dir + @"\Ass1Data\Out\weedseed\testConfusion.txt");
            double valAcc = nn.Accuracy(valData.data, dir + @"\Ass1Data\Out\weedseed\valOut.txt");
            string ConfusionVal = nn.showConfusionPercent(dir + @"\Ass1Data\Out\weedseed\valConfusion.txt");

            // convert accuracy to percents
            trainAcc = trainAcc * 100;
            testAcc = testAcc * 100;
            valAcc = valAcc * 100;
            textBox1.AppendText("Training Accuracy   = " + trainAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Testing Accuracy    = " + testAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Validation Accuracy = " + valAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("Training Confusion Matrix \r\n" + ConfusionTrain + "\r\n\r\n");
            textBox1.AppendText("Testing Confusion Matrix \r\n" + ConfusionTest + "\r\n\r\n");
            textBox1.AppendText("Validation Confusion Matrix \r\n" + ConfusionVal + "\r\n\r\n");

            // finally save weights for the future
            nn.saveANN(dir + @"\Ass1Data\Out\weedseed\weedSeed_Weights.txt");
        }

        // Ass1 Q2a
        private void btnTask2z11_Click(object sender, EventArgs e)
        {
            string dir = this.textPath.Text;
            string datafile = @"\Ass1Data\task2z11.txt";
            string commonNameForDataset = "Task 2 z 11 Dataset";

            int inputs = 2;
            int outputs = 2;

            int hidden = (int)numericNodesBox.Value;
            double eta = (double)numericETA.Value;
            int epochs = (int)numericEpochsBox.Value;

            Random rnd1 = new Random(2007); // data split random number
            //int seed = System.DateTime.UtcNow.Millisecond;
            int seed = (int)numericTask2z11Seed.Value;
            Random rnd2 = new Random(seed); // ANN initialise weights and shuffle data random number
            int sizeOfDataSet = 300;
            int sizeOfTest = sizeOfDataSet / 3;
            int sizeOfValidation = sizeOfDataSet / 3;
            int sizeOfTrain = sizeOfDataSet - sizeOfTest - sizeOfValidation;

            textBox2.Clear(); // clear previous messages

            DataClass task2z11Raw = new DataClass(dir, datafile, new UI(this));
            string s = task2z11Raw.showDataPart(5, inputs + 1, "F4", commonNameForDataset);
            textBox1.AppendText(s);
            textBox1.AppendText("\r\n\r\n");

            task2z11Raw.normalize(0, inputs - 1, "");
            string ss = task2z11Raw.showDataPart(5, inputs + 1, "F4", commonNameForDataset + " Normalised");
            textBox1.AppendText(ss);
            textBox1.AppendText("\r\n\r\n");

            DataClass task2z11Exemplar = task2z11Raw.makeExemplar(inputs, outputs, 1);
            string se = task2z11Exemplar.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Exemplar Data");
            textBox1.AppendText(se);
            textBox1.AppendText("\r\n\r\n");

            trainData = new DataClass();
            testData = new DataClass();
            valData = new DataClass();
            DataClass tempData = new DataClass();

            task2z11Exemplar.extractSplit(out trainData, out tempData, sizeOfTrain, rnd1);
            tempData.extractSplit(out testData, out valData, sizeOfTest, rnd1);
            trainData.writeToFile(dir, @"\Ass1Data\Out\task2z11\task2z11TempTrain.txt"); // debug
            testData.writeToFile(dir, @"\Ass1Data\Out\task2z11\task2z11TempTest.txt");
            valData.writeToFile(dir, @"\Ass1Data\Out\task2z11\task2z11TempVal.txt");

            showDataDistribution(trainData, "Training Data Class Distribution", outputs);
            showDataDistribution(testData, "Testing Data Class Distribution", outputs);
            showDataDistribution(valData, "Validation Data Class Distribution", outputs);

            string s1 = trainData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Training Data");
            textBox1.AppendText(s1);
            textBox1.AppendText("\r\n\r\n");

            string s2 = testData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Testing Data");
            textBox1.AppendText(s2);
            textBox1.AppendText("\r\n\r\n");

            string s3 = valData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Validation Data");
            textBox1.AppendText(s3);
            textBox1.AppendText("\r\n\r\n");

            NeuralNetwork nn = new NeuralNetwork(inputs, hidden, outputs, new UI(this), rnd2);
            nn.InitializeWeights(rnd2);
            textBox1.AppendText("\r\nBeginning training using incremental back-propagation\r\n");
            nn.train(trainData.data, testData.data, epochs, eta, dir + @"\Ass1Data\Out\task2z11\nnlog.txt", nnChart, nnProgressBar, true);
            textBox1.AppendText("Training complete\r\n");

            double trainAcc = nn.Accuracy(trainData.data, dir + @"\Ass1Data\Out\task2z11\trainOut.txt");
            string ConfusionTrain = nn.showConfusionPercent(dir + @"\Ass1Data\Out\task2z11\trainConfusion.txt");
            double testAcc = nn.Accuracy(testData.data, dir + @"\Ass1Data\Out\task2z11\testOut.txt");
            string ConfusionTest = nn.showConfusionPercent(dir + @"\Ass1Data\Out\task2z11\testConfusion.txt");
            double valAcc = nn.Accuracy(valData.data, dir + @"\Ass1Data\Out\task2z11\valOut.txt");
            string ConfusionVal = nn.showConfusionPercent(dir + @"\Ass1Data\Out\task2z11\valConfusion.txt");

            // convert accuracy to percents
            trainAcc = trainAcc * 100;
            testAcc = testAcc * 100;
            valAcc = valAcc * 100;
            textBox1.AppendText("TODAY'S SEED: " + seed.ToString() + "\r\n\r\n");
            textBox1.AppendText("Training Accuracy   = " + trainAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Testing Accuracy    = " + testAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Validation Accuracy = " + valAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("Training Confusion Matrix \r\n" + ConfusionTrain + "\r\n\r\n");
            textBox1.AppendText("Testing Confusion Matrix \r\n" + ConfusionTest + "\r\n\r\n");
            textBox1.AppendText("Validation Confusion Matrix \r\n" + ConfusionVal + "\r\n\r\n");

            // finally save weights for the future
            nn.saveANN(dir + @"\Ass1Data\Out\task2z11\task2z11_Weights.txt");
        }

        // Ass1 Q2b
        private void btnTask2z13_Click(object sender, EventArgs e)
        {
            string dir = this.textPath.Text;
            string datafile = @"\Ass1Data\task2z13.txt";
            string commonNameForDataset = "Task 2 z 11 Dataset";

            int inputs = 2;
            int outputs = 2;

            int hidden = (int)numericNodesBox.Value;
            double eta = (double)numericETA.Value;
            int epochs = (int)numericEpochsBox.Value;

            Random rnd1 = new Random(2007); // data split random number
            int seed = System.DateTime.UtcNow.Millisecond;
            //int seed = (int)numerictask2z13Seed.Value;
            Random rnd2 = new Random(seed); // ANN initialise weights and shuffle data random number
            int sizeOfDataSet = 500;
            int sizeOfTest = sizeOfDataSet / 3;
            int sizeOfValidation = sizeOfDataSet / 3;
            int sizeOfTrain = sizeOfDataSet - sizeOfTest - sizeOfValidation;

            textBox2.Clear(); // clear previous messages

            DataClass task2z13Raw = new DataClass(dir, datafile, new UI(this));
            string s = task2z13Raw.showDataPart(5, inputs + 1, "F4", commonNameForDataset);
            textBox1.AppendText(s);
            textBox1.AppendText("\r\n\r\n");

            task2z13Raw.normalize(0, inputs - 1, "");
            string ss = task2z13Raw.showDataPart(5, inputs + 1, "F4", commonNameForDataset + " Normalised");
            textBox1.AppendText(ss);
            textBox1.AppendText("\r\n\r\n");

            DataClass task2z13Exemplar = task2z13Raw.makeExemplar(inputs, outputs, 1);
            string se = task2z13Exemplar.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Exemplar Data");
            textBox1.AppendText(se);
            textBox1.AppendText("\r\n\r\n");

            trainData = new DataClass();
            testData = new DataClass();
            valData = new DataClass();
            DataClass tempData = new DataClass();

            task2z13Exemplar.extractSplit(out trainData, out tempData, sizeOfTrain, rnd1);
            tempData.extractSplit(out testData, out valData, sizeOfTest, rnd1);
            trainData.writeToFile(dir, @"\Ass1Data\Out\task2z13\task2z13TempTrain.txt"); // debug
            testData.writeToFile(dir, @"\Ass1Data\Out\task2z13\task2z13TempTest.txt");
            valData.writeToFile(dir, @"\Ass1Data\Out\task2z13\task2z13TempVal.txt");

            showDataDistribution(trainData, "Training Data Class Distribution", outputs);
            showDataDistribution(testData, "Testing Data Class Distribution", outputs);
            showDataDistribution(valData, "Validation Data Class Distribution", outputs);

            string s1 = trainData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Training Data");
            textBox1.AppendText(s1);
            textBox1.AppendText("\r\n\r\n");

            string s2 = testData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Testing Data");
            textBox1.AppendText(s2);
            textBox1.AppendText("\r\n\r\n");

            string s3 = valData.showDataPart(5, inputs + outputs, "F4", commonNameForDataset + " Validation Data");
            textBox1.AppendText(s3);
            textBox1.AppendText("\r\n\r\n");

            NeuralNetwork nn = new NeuralNetwork(inputs, hidden, outputs, new UI(this), rnd2);
            nn.InitializeWeights(rnd2);
            textBox1.AppendText("\r\nBeginning training using incremental back-propagation\r\n");
            nn.train(trainData.data, testData.data, epochs, eta, dir + @"\Ass1Data\Out\task2z13\nnlog.txt", nnChart, nnProgressBar, true);
            textBox1.AppendText("Training complete\r\n");

            double trainAcc = nn.Accuracy(trainData.data, dir + @"\Ass1Data\Out\task2z13\trainOut.txt");
            string ConfusionTrain = nn.showConfusionPercent(dir + @"\Ass1Data\Out\task2z13\trainConfusion.txt");
            double testAcc = nn.Accuracy(testData.data, dir + @"\Ass1Data\Out\task2z13\testOut.txt");
            string ConfusionTest = nn.showConfusionPercent(dir + @"\Ass1Data\Out\task2z13\testConfusion.txt");
            double valAcc = nn.Accuracy(valData.data, dir + @"\Ass1Data\Out\task2z13\valOut.txt");
            string ConfusionVal = nn.showConfusionPercent(dir + @"\Ass1Data\Out\task2z13\valConfusion.txt");

            // convert accuracy to percents
            trainAcc = trainAcc * 100;
            testAcc = testAcc * 100;
            valAcc = valAcc * 100;
            textBox1.AppendText("TODAY'S SEED: " + seed.ToString() + "\r\n\r\n");
            textBox1.AppendText("Training Accuracy   = " + trainAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Testing Accuracy    = " + testAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("Validation Accuracy = " + valAcc.ToString("F2") + "\r\n");
            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("Training Confusion Matrix \r\n" + ConfusionTrain + "\r\n\r\n");
            textBox1.AppendText("Testing Confusion Matrix \r\n" + ConfusionTest + "\r\n\r\n");
            textBox1.AppendText("Validation Confusion Matrix \r\n" + ConfusionVal + "\r\n\r\n");

            // finally save weights for the future
            nn.saveANN(dir + @"\Ass1Data\Out\task2z13\task2z13_Weights.txt");
        }

        private void buttonFaceAssignment_Click(object sender, EventArgs e)
        {
            // Code for face assignment
            //"trainFaceBoth.txt"
            dir = @"F:\B\SC2016Assignment\FaceDataProcessed\";
            string datafile = "trainFaceBoth.txt";
            string commonNameFoDataset = "Face";
            int inputs = 49;
            int hidden = 49;
            int outputs = 2;
            Random rnd1 = new Random(103); // data split random number
            Random rnd2 = new Random(104); // ANN initialise weights and shuffle data random number
        }
    }
}
